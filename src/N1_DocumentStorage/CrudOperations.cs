using NRedisStack;

namespace N1_DocumentStorage;

public static class CrudOperations
{
    public static async ValueTask RunExampleAsync(JsonCommands jsonCommands)
    {
        Console.WriteLine("----------  CRUD Operations example  ----------");

        // Create 
        var user = new Common.User(Guid.CreateVersion7(), "John Doe", "john.doe@gmail.com");
        await jsonCommands.SetAsync($"user:{user.Id.ToString()}", "$", user);

        // Read
        var retrievedUser = await jsonCommands.GetAsync($"user:{user.Id}");
        Console.WriteLine($"Retrieved user - {retrievedUser}");

        // Read specific fields
        var name = await jsonCommands.GetAsync($"user:{user.Id}", ["$.Name"]);
        Console.WriteLine($"Name : {name}");

        // Update specific field
        await jsonCommands.SetAsync($"user:{user.Id}", "$.Name", "\"Jane Doe\""); 
        Console.WriteLine("Updated name");

        // Update to add a new field
        await jsonCommands.SetAsync($"user:{user.Id}", "$.LastLogin", DateTime.UtcNow.ToString("O"));
        Console.WriteLine("Added LastLogin field");
        var updatedUser = await jsonCommands.GetAsync($"user:{user.Id}");
        Console.WriteLine($"Updated user - {updatedUser}");

        // Delete specific field
        await jsonCommands.DelAsync($"user:{user.Id}", "$.LastLogin");
        Console.WriteLine("Deleted LastLogin field");
        var userAfterFieldDelete = await jsonCommands.GetAsync($"user:{user.Id}");
        Console.WriteLine($"User after field deletion - {userAfterFieldDelete}");

        // Delete entire document
        await jsonCommands.DelAsync($"user:{user.Id}");
        Console.WriteLine("Deleted entire document");

        // Verify deletion
        var deletedUser = await jsonCommands.GetAsync($"user:{user.Id}");
        Console.WriteLine($"User is null after document deletion - {deletedUser.IsNull}");
    }
}