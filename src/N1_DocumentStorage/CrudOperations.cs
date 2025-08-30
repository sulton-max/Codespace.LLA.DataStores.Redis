using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace N1_DocumentStorage;

public static class CrudOperations
{
    public static async ValueTask RunExampleAsync()
    {
        Console.WriteLine("----------  CRUD Operations example  ----------");

        var conf = new ConfigurationOptions
        {
            EndPoints = { "localhost:6379" }
        };
        await using var redis = await ConnectionMultiplexer.ConnectAsync(conf);
        var json = redis.GetDatabase().JSON();

        // Create 
        var user = new Common.User(Guid.CreateVersion7(), "John Doe", "john.doe@gmail.com");
        await json.SetAsync($"user:{user.Id.ToString()}", "$", user);

        // Read
        var retrievedUser = await json.GetAsync($"user:{user.Id}");
        Console.WriteLine($"Retrieved user - {retrievedUser}");

        // Read specific fields
        var name = await json.GetAsync($"user:{user.Id}", ["$.Name"]);
        Console.WriteLine($"Name : {name}");

        // Update specific field
        await json.SetAsync($"user:{user.Id}", "$.Name", "\"Jane Doe\""); 
        Console.WriteLine("Updated name");

        // Update to add a new field
        await json.SetAsync($"user:{user.Id}", "$.LastLogin", DateTime.UtcNow.ToString("O"));
        Console.WriteLine("Added LastLogin field");
        var updatedUser = await json.GetAsync($"user:{user.Id}");
        Console.WriteLine($"Updated user - {updatedUser}");

        // Delete specific field
        await json.DelAsync($"user:{user.Id}", "$.LastLogin");
        Console.WriteLine("Deleted LastLogin field");
        var userAfterFieldDelete = await json.GetAsync($"user:{user.Id}");
        Console.WriteLine($"User after field deletion - {userAfterFieldDelete}");

        // Delete entire document
        await json.DelAsync($"user:{user.Id}");
        Console.WriteLine("Deleted entire document");

        // Verify deletion
        var deletedUser = await json.GetAsync($"user:{user.Id}");
        Console.WriteLine($"User is null after document deletion - {deletedUser.IsNull}");
    }
}