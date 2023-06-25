using BackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories;

/// <summary>
/// Repository class for managing the data access operations for users
/// </summary>
public class UserRepository {
    
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) 
    {
        _db = db;
    }

    /// <summary>
    /// Retrieves a user id of a given user token
    /// </summary>
    /// <param name="token">User Token</param>
    /// <returns>The user id or null if not found</returns>
    public int GetUserId(string token) 
    {
       UserToken usertoken = _db.UserTokens.FirstOrDefault(u => u.Token.Equals(token));
       return usertoken.UserId;
    }

    /// <summary>
    /// Retrieves the company id of a given user
    /// </summary>
    /// <param name="id">User Id</param>
    /// <returns>The company id or null if not found</returns>
    public int GetCompanyId(int id)
    {
        var user = _db.Users.FirstOrDefault(u => u.UserId.Equals(id));
        return user.CompanyId;
    }

    /// <summary>
    /// Retrieves a list of users given a condition
    /// </summary>
    /// <param name="condition">Condition for user to be included</param>
    /// <returns>List of Users</returns>
    public List<User> FindUsers(Func<User, bool> condition)
    {
        return _db.Users.Where(condition).ToList();
    }

}