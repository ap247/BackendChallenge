using BackendChallenge.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using BackendChallenge.Models;
using BackendChallenge.Data.Repositories;

namespace BackendChallenge.Controllers;

/// <summary>
/// This is the controller API class for managing the User endpoints
/// </summary>
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly AppDbContext _db;
    private readonly UserRepository _ur;

    public UsersController(ILogger<UsersController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
        _ur = new UserRepository(_db);
    }

    // GET /users
    /// <summary>
    /// Retrieves users that also work for the same company as current user
    /// </summary>
    /// <returns>
    /// Returns an http response with an array of UserResponses
    /// </returns>
    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<string>> Index(CancellationToken token)
    {
        if (Request.Headers.ContainsKey("UserToken"))
        {
            try 
            {
                var uId =_ur.GetUserId(Request.Headers["UserToken"]);

                var cId = _ur.GetCompanyId(uId);

                var users = _ur.FindUsers(u => u.CompanyId.Equals(cId));

                UserResponse[] responses = new UserResponse[users.Count()];

                var i = 0;

                foreach (User user in users)
                {
                    responses[i] = new UserResponse(user.UserId, user.FirstName, user.LastName);
                    i++;
                }

                return Ok(responses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching users.");
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