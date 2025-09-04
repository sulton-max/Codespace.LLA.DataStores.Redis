using System.Text.Json;
using NRedisStack;
using StackExchange.Redis;

namespace N1_DocumentStorage;

public static class MemoryOptimization
{
    public static async ValueTask RunExampleAsync(IDatabase redisDb, JsonCommands jsonCommands)
    {
        Console.WriteLine("\n\n----------  Memory Optimization example  ----------");

        var userId = Guid.CreateVersion7();

        // Standard approach - store the entire object structure
        var userWithSettings = new Common.UserWithSettings(
            userId,
            "Jane Doe",
            "jane.doe@gmail.com",
            new Common.Settings("dark", "en"));
        var standardKey = $"user-standard:{userId}";
        await jsonCommands.SetAsync(standardKey, "$", userWithSettings);

        var standardMemory = (long)await redisDb.ExecuteAsync("MEMORY", "USAGE", standardKey);
        Console.WriteLine($"Standard approach memory usage: {standardMemory} bytes");
        Console.WriteLine($"Can query nested field 'Theme' : {await jsonCommands.GetAsync(standardKey, ["$.Settings.Theme"])}");

        // Optimized approach - stored the nested object as a serialized string
        var settings = new Common.Settings("dark", "en");
        var userWithSerializedSettings = new
        {
            userWithSettings.Id,
            userWithSettings.Name,
            userWithSettings.EmailAddress,
            Settings = JsonSerializer.Serialize(settings)
        };
        var optimizedKey = $"user-optimized:{userId}";
        await jsonCommands.SetAsync(optimizedKey, "$", userWithSerializedSettings);

        var optimizedMemory = await redisDb.ExecuteAsync("MEMORY", "USAGE", optimizedKey);
        Console.WriteLine($"Optimized approach memory usage: {optimizedMemory} bytes");
        Console.WriteLine("Cannot query nested field 'Theme'");
    }
}