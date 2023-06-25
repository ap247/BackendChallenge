namespace BackendChallenge.Models;

/// <summary>
/// Represents a response for a user
/// </summary>
public class UserResponse 
{
    public int UserId {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserResponse(int userId, string firstName, string lastName)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
    }
}

