using BackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories;

/// <summary>
/// Repository class for managing the data access operations for management relationships
/// </summary>
public class ManagementRelationshipRepository {
    
    private readonly AppDbContext _db;

    public ManagementRelationshipRepository(AppDbContext db) 
    {
        _db = db;
    }

    /// <summary>
    /// Determines if a given user is a manager or not
    /// </summary>
    /// <param name="userId">User id to be checked</param>
    /// <returns>True if the user is a manager, otherwise false</returns>
    public bool isUserManager(int userId) {
        return _db.ManagementRelationships.Any(mr => mr.ManagerId == userId);
    }

}