using BackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Data.Repositories;

/// <summary>
/// Repository class for managing the data access operations for learning plans
/// </summary>
public class LearningPlanRepository {
    
    private readonly AppDbContext _db;

    public LearningPlanRepository(AppDbContext db) 
    {
        _db = db;
    }

    /// <summary>
    /// Retrieves a list of learning plans given a condition
    /// </summary>
    /// <param name="condition">Condition for learning plan to be included</param>
    /// <returns>List of Learning Plans</returns>
    public List<LearningPlan> FindLearningPlans(Func<LearningPlan, bool> condition)
    {
        return _db.LearningPlans.Where(condition).ToList();
    }

    /// <summary>
    /// Retrieves a list of learning plan items given a condition
    /// </summary>
    /// <param name="condition">Condition for learning plan item to be included</param>
    /// <returns>List of Learning Plan Item</returns>
    public List<LearningPlanItem> FindLearningPlanItems(Func<LearningPlanItem, bool> condition)
    {
        return _db.LearningPlanItems.Where(condition).ToList();
    }

}