using System.Text.Json;
using NRedisStack;

namespace N1_DocumentStorage;

public static class ObjectMerging
{
    public static async ValueTask RunExampleAsync(JsonCommands jsonCommands)
    {
        Console.WriteLine("\n\n----------  Object Merging example  ----------");

        // Create a user object and store it in Redis
        var user = new Common.User(Guid.CreateVersion7(), "John Doe", "john.doe@gmail.com");
        var key = $"user:{user.Id}";
        await jsonCommands.SetAsync(key, "$", user);
        Console.WriteLine($"Original user : {await jsonCommands.GetAsync(key)}");
        
        // Create a profile object
        var profile = new { Profile = new Common.UserProfile("SWE", "Redmond")};
        
        // Merge the profile with user
        await jsonCommands.MergeAsync(key, "$", profile);
        var userWithProfile = await jsonCommands.GetAsync(key);
        Console.WriteLine($"Merged user object : {userWithProfile}");

        var userWithProfileValue = JsonSerializer.Deserialize<Common.UserWithProfile>(userWithProfile.ToString()!);
        Console.WriteLine($"Deserialized user bio : {userWithProfileValue!.Profile.Bio}");
    }
}