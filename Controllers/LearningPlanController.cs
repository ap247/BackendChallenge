using BackendChallenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendChallenge.Models;
using BackendChallenge.Enums;
using BackendChallenge.Data.Repositories;
using BackendChallenge.Services;

namespace BackendChallenge.Controllers;

/// <summary>
/// This is the controller API class for managing the LearningPlan endpoints
/// </summary>
[ApiController]
[Route("learning-plan")]
public class LearningPlanController : ControllerBase
{
    private readonly ILogger<LearningPlanController> _logger;
    private readonly AppDbContext _db;
    private readonly UserRepository _ur;
    private readonly LearningPlanRepository _lpr;
    private readonly PlanItemService _pis;

    public LearningPlanController(ILogger<LearningPlanController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
        _ur = new UserRepository(_db);
        _lpr = new LearningPlanRepository(_db);
        _pis = new PlanItemService(_db);

    }

    // GET /learning-plan
    /// <summary>
    /// Retrieves learning plan for current user
    /// </summary>
    /// <returns>
    /// Returns an http response with a LearningPlanResponse
    /// </returns>
    [HttpGet(Name = "GetLearningPlan")]
    public async Task<ActionResult<string>> Index(CancellationToken token)
    {
        if (Request.Headers.ContainsKey("UserToken"))
        {
            try 
            {
                var uId = _ur.GetUserId(Request.Headers["UserToken"]);

                var lps = _lpr.FindLearningPlans(lp => lp.UserId.Equals(uId));

                List<PlanItemResponse> responseList = new List<PlanItemResponse>();

                foreach(var lp in lps) {
                    var lpIts =  _lpr.FindLearningPlanItems(lpIt => lpIt.LearningPlanId.Equals(lp.LearningPlanId));

                    foreach(var lpIt in lpIts) {
                        responseList.Add(_pis.createPlanItemResponse(lpIt));
                    }
                }

                LearningPlanResponse lpResponse = new LearningPlanResponse(uId, new PlanItemResponse[responseList.Count]);

                int i = 0;
                foreach(var response in responseList) {
                    lpResponse.PlanItemResponses[i] = response;
                    i++;
                }

                return Ok(lpResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching learning plan.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching learning plan.");
            }
        
        }
        else
        {
            _logger.LogError("No User Token found");
            return StatusCode(StatusCodes.Status500InternalServerError, "No User Token found");
        }
    }    
}
