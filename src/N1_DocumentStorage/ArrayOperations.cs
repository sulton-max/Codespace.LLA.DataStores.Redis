using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace N1_DocumentStorage;

public static class ArrayOperations
{
    public static async ValueTask RunExampleAsync()
    {
        Console.WriteLine("\n\n----------  Array Operations example  ----------");

        var conf = new ConfigurationOptions { EndPoints = { "localhost:6379" } };
        await using var redis = await ConnectionMultiplexer.ConnectAsync(conf);
        var json = redis.GetDatabase().JSON();

        var user = new Common.UserWithTags(Guid.CreateVersion7(), "Alice", ["developer", "reviewer"]);
        var key = $"user:{user.Id}";
        await json.SetAsync(key, "$", user);
        Console.WriteLine($"Created user with tags: {await json.GetAsync(key)}");

        // Append an element to the array
        await json.ArrAppendAsync(key, "$.Tags", "architecht");
        Console.WriteLine($"After appending 'architect' : {await json.GetAsync(key)}");

        // Get the length of the array
        var length = await json.ArrLenAsync(key, "$.Tags");
        Console.WriteLine($"New array length: {length[0]}");

        // Remove the last element from the array
        var poppedValue = await json.ArrPopAsync(key, "$.Tags");
        Console.WriteLine($"Popped value: {poppedValue[0]}");
        Console.WriteLine($"After popping: {await json.GetAsync(key, ["$.Tags"])}");
    }
}