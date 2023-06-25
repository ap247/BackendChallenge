namespace BackendChallenge.Models;

/// <summary>
/// Represents a response for an incentive
/// </summary>
public class IncentiveResponse 
{
    public int UserId {get; set;}
    public EligibleIncentiveResponse[] EligibleIncentiveResponses {get; set;}

    public IncentiveResponse(int userId, EligibleIncentiveResponse[] eligibleIncentiveResponses)
    {
        UserId = userId;
        EligibleIncentiveResponses = eligibleIncentiveResponses;
    }
}