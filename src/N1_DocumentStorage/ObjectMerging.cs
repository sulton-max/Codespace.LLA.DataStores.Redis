using System.Text.Json;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace N1_DocumentStorage;

public static class ObjectMerging
{
    public static async ValueTask RunExampleAsync()
    {
        Console.WriteLine("\n\n----------  Object Merging example  ----------");

        var conf = new ConfigurationOptions { EndPoints = { "localhost:6379" } };
        await using var redis = await ConnectionMultiplexer.ConnectAsync(conf);
        var json = redis.GetDatabase().JSON();
        
        // Create a user object and store it in Redis
        var user = new Common.User(Guid.CreateVersion7(), "John Doe", "john.doe@gmail.com");
        var key = $"user:{user.Id}";
        await json.SetAsync(key, "$", user);
        Console.WriteLine($"Original user : {json.GetAsync(key)}");
        
        // Create a profile object
        var profile = new { Profile = new Common.UserProfile("SWE", "Redmond")};
        
        // Merge the profile with user
        await json.MergeAsync(key, "$", profile);
        var userWithProfile = json.GetAsync(key);
        Console.WriteLine($"Merged user object : {userWithProfile}");

        var userWithProfileValue = JsonSerializer.Deserialize<Common.UserWithProfile>(userWithProfile.ToString()!);
        Console.WriteLine($"Deserialized user bio : {userWithProfileValue!.Profile.Bio}");
    }
}