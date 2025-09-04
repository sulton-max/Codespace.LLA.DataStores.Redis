using NRedisStack;

namespace N1_DocumentStorage;

public static class ArrayOperations
{
    public static async ValueTask RunExampleAsync(JsonCommands jsonCommands)
    {
        Console.WriteLine("\n\n----------  Array Operations example  ----------");

        var user = new Common.UserWithTags(Guid.CreateVersion7(), "Alice", 30, ["developer", "reviewer"]);
        var key = $"user:{user.Id}";
        await jsonCommands.SetAsync(key, "$", user);
        Console.WriteLine($"Created user with tags: {await jsonCommands.GetAsync(key)}");

        // Append an element to the array
        await jsonCommands.ArrAppendAsync(key, "$.Tags", "architecht");
        Console.WriteLine($"After appending 'architect' : {await jsonCommands.GetAsync(key)}");

        // Get the length of the array
        var length = await jsonCommands.ArrLenAsync(key, "$.Tags");
        Console.WriteLine($"New array length: {length[0]}");

        // Remove the last element from the array
        var poppedValue = await jsonCommands.ArrPopAsync(key, "$.Tags");
        Console.WriteLine($"Popped value: {poppedValue[0]}");
        Console.WriteLine($"After popping: {await jsonCommands.GetAsync(key, ["$.Tags"])}");
    }
}