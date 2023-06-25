namespace BackendChallenge.Models;

/// <summary>
/// Represents a response for an eligible incentive
/// </summary>
public class EligibleIncentiveResponse
{
    public int IncentiveId {get; set;}
    public string IncentiveName { get; set; }
    public int ServiceRequirement { get; set;}

    public EligibleIncentiveResponse(int incentiveId, string incentiveName, int serviceRequirement)
    {
        IncentiveId = incentiveId;
        IncentiveName = incentiveName;
        ServiceRequirement = serviceRequirement;
    }
}