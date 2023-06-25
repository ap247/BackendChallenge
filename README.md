# Backend Challenge
This is an API Project that gives various data points on a user's learning plans and incentives as well as other users. 

# API Questions
### How many active users are there for UserToken = 1MEYQDDgwrTkYPtu7Vhfyjp7qkuGnf4ztR company?
There are 4 active users in that company.

### What does the JSON of the user plan for UserToken = 1F7Xg1CJdffsnv9uEXj6GhLERQSam4xwx6 look like?
```
{
    "userId": 2,
    "planItemResponses": [
        {
            "learningPlanItemId": 3,
            "learningItemType": "Course",
            "learningItemName": "Managerial Economics",
            "itemId": 4
        },
        {
            "learningPlanItemId": 4,
            "learningItemType": "Course",
            "learningItemName": "Design Thinking",
            "itemId": 5
        },
        {
            "learningPlanItemId": 5,
            "learningItemType": "Incentive",
            "learningItemName": "Completion Bonus",
            "itemId": 1
        }
    ]
}
```

### How many incentives is UserToken = 1DeyjK5vvSwjc9o9jYArVo2yov2SnjnXEE eligible for?
This user is eligible for 5 incentives

# Test Plan Question
In this API, we are testing how one user finds out information about other users, their learning plan and their incentives. As such, our tests should revolve around this functionality. 

This means that model, repository, and controller classes should all be extensively tested as they contain the vast majority of the logic behind these API calls. Other enum and migration classes will either be covered by exisiting tests incidentally or will not be relevant to the overall functionality of the API. 

We should prioritize unit and end-to-end tests to test both the discrete classes of code and overall API funcitonality repectively. If we anticipate that the API may experience periods of high traffic, then we should also include load testing.

For unit tests, we should try testing null and unexpected values for the models and repository classes to see that they work as expected even with odd values. 

For end-to-end tests, we should see how the API responds to GET calls and mock different repository functions to see how the controllers respond when those functions return different values. 

### Resources Used
Microsoft C# Documentation, Stack Overflow, Chat GPT