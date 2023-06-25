using BackendChallenge.Data;
using BackendChallenge.Models;
using BackendChallenge.Data.Repositories;
using BackendChallenge.Enums;

namespace BackendChallenge.Services;
public class PlanItemService {

    private readonly AppDbContext _db;
    private readonly CourseRepository _cr;
    private readonly IncentiveRepository _ir;

    public PlanItemService(AppDbContext db) 
    {
        _db = db;
        _cr = new CourseRepository(_db);
        _ir = new IncentiveRepository(_db);
    }

    public PlanItemResponse createPlanItemResponse(LearningPlanItem lpIt) {
        LearningItemType type = lpIt.LearningItemType;

        string lpName = ""; 

        int? id = -1;

        if(type == LearningItemType.Course) {
            id = (int) lpIt.CourseId;
            var course = _cr.GetCourse(id);
            lpName = course.CourseName;
        } else { // type == LearningItemType.Incentive
            id = (int) lpIt.IncentiveId;
            var incentive = _ir.GetIncentive(id);
            lpName = incentive.IncentiveName;
        }
        return new PlanItemResponse(lpIt.LearningPlanItemId, lpIt.LearningItemType.ToString(), lpName, id);
    }


}