using Common;
using NRedisStack;

namespace N2_JsonQuerying;

public static class PathQueries
{
    public static async ValueTask RunExampleAsync(JsonCommands jsonCommands)
    {
        Console.WriteLine("\n\n----------  JSONPath Queries example  ----------");

        var users = new List<UserWithProfile>
        {
            new(Guid.CreateVersion7(), "John Doe", "john.doe@gmail.com", new UserProfile("SWE", "123 Main St")),
            new(Guid.CreateVersion7(), "Jane Smith", "jane.smith@gmail.com", new UserProfile("Designer", "456 Oak Ave")),
            new(Guid.CreateVersion7(), "Mike Johnson", "mike.j@gmail.com", new UserProfile("PM", "789 Pine Rd"))
        };

        var key = "users:collection-pathquery";
        await jsonCommands.SetAsync(key, "$", users);
        
        // Get all email addresses
        var allEmails = await jsonCommands.GetAsync(key, ["$[*].EmailAddress"]);
        Console.WriteLine($"\n All user emails - {allEmails}");

        // Get specific array elements
        var specificUsers = await jsonCommands.GetAsync(key, ["$[0,2]"]);
        Console.WriteLine($"\n Specific users by index - {specificUsers}");

        // Get nested profile data for a specific user
        var janeProfile = await jsonCommands.GetAsync(key, ["$[1].Profile"]);
        Console.WriteLine($"\n Jane's profile - {janeProfile}");

        // Use recursive descent to find all profiles
        var allProfiles = await jsonCommands.GetAsync(key, ["$..Profile"]);
        Console.WriteLine($"\n All profiles - {allProfiles}");
    }
}