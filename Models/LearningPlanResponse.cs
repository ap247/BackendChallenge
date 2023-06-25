namespace BackendChallenge.Models;

/// <summary>
/// Represents a response for a learning plan
/// </summary>
public class LearningPlanResponse 
{
    public int UserId {get; set;}
    public PlanItemResponse[] PlanItemResponses {get; set;}

    public LearningPlanResponse(int userId, PlanItemResponse[] planItemResponses)
    {
        UserId = userId;
        PlanItemResponses = planItemResponses;
    }
}