using BackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories;

/// <summary>
/// Repository class for managing the data access operations for incetives
/// </summary>
public class IncentiveRepository {
    
    private readonly AppDbContext _db;

    public IncentiveRepository(AppDbContext db) 
    {
        _db = db;
    }

    /// <summary>
    /// Retrieves an incentive given an incentive id
    /// </summary>
    /// <param name="id">Incentive id</param>
    /// <returns>The incentive or null if not found</returns>
    public Incentive GetIncentive(int? id) {
        return _db.Incentives.FirstOrDefault(incentive => incentive.IncentiveId.Equals(id));
    }


    /// <summary>
    /// Retrieves a list of incentives given a condition
    /// </summary>
    /// <param name="condition">Condition for incentive to be included</param>
    /// <returns>List of Incentives</returns>
    public List<Incentive> FindIncentives(Func<Incentive, bool> condition) {
        return _db.Incentives.Where(condition).ToList();
    }

}