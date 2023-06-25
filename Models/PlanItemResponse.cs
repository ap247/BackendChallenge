namespace BackendChallenge.Models;

/// <summary>
/// Represents a response for a learning plan item
/// </summary>
public class PlanItemResponse
{
    public int LearningPlanItemId {get; set;}
    public string LearningItemType { get; set; }
    public string LearningItemName { get; set; }
    public int? ItemId { get; set;}

    public PlanItemResponse(int learningPlanItemId, string learningItemType, string learningItemName, int? itemId)
    {
        LearningPlanItemId = learningPlanItemId;
        LearningItemType = learningItemType;
        LearningItemName = learningItemName;
        ItemId = itemId;
    }
}