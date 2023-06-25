using BackendChallenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using BackendChallenge.Models;
using BackendChallenge.Enums;
using BackendChallenge.Data.Repositories;

namespace BackendChallenge.Controllers;

[ApiController]
[Route("[controller]")]
public class IncentivesController : ControllerBase
{
    private readonly ILogger<IncentivesController> _logger;
    private readonly AppDbContext _db;
    private readonly UserRepository _ur;
    private readonly IncentiveRepository _ir;
    private readonly ManagementRelationshipRepository _mrr;

    /// <summary>
    /// This is the controller API class for managing the Incentive endpoints
    /// </summary>
    public IncentivesController(ILogger<IncentivesController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
        _ur = new UserRepository(_db);
        _ir = new IncentiveRepository(_db);
        _mrr = new ManagementRelationshipRepository(_db);
    }

    // GET /incentives
    /// <summary>
    /// Retrieves incentives for current user
    /// </summary>
    /// <returns>
    /// Returns an http response with a IncentiveResponse
    /// </returns>
    [HttpGet(Name = "GetIncentives")]
    public async Task<ActionResult<string>> Index(CancellationToken token)
    {
        if (Request.Headers.ContainsKey("UserToken"))
        {
            try 
            {
                var uId = _ur.GetUserId(Request.Headers["UserToken"]);

                bool isManager = _mrr.isUserManager(uId);

                // includes incentives that every user has along with either manager incentives or individual contributor incentives
                var incentiveList = _ir.FindIncentives(incentive => incentive.RoleEligibility == RoleEligibility.All || 
                                                        (isManager ? incentive.RoleEligibility == RoleEligibility.Manager :
                                                        incentive.RoleEligibility == RoleEligibility.IndividualContributor));
                
                IncentiveResponse iResponse = new IncentiveResponse(uId, new EligibleIncentiveResponse[incentiveList.Count()]);

                var i = 0;
                foreach(Incentive incentive in incentiveList)
                {
                    iResponse.EligibleIncentiveResponses[i] = new EligibleIncentiveResponse(incentive.IncentiveId, incentive.IncentiveName, incentive.ServiceRequirementDays);
                    i++;
                }

                return Ok(iResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching incentives.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching users.");
            }
        
        }
        else
        {
            _logger.LogError("No User Token found");
            return StatusCode(StatusCodes.Status500InternalServerError, "No User Token found");
        }
    }
}