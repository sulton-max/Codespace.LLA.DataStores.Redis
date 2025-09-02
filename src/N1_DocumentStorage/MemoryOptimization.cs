using System.Text.Json;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace N1_DocumentStorage;

public static class MemoryOptimization
{
    public static async ValueTask RunExampleAsync()
    {
        Console.WriteLine("\n\n----------  Memory Optimization example  ----------");

        var conf = new ConfigurationOptions { EndPoints = { "localhost:6379" } };
        await using var redis = await ConnectionMultiplexer.ConnectAsync(conf);
        var db = redis.GetDatabase();
        var json = db.JSON();
        var userId = Guid.CreateVersion7();

        // Standard approach - store the entire object structure
        var userWithSettings = new Common.UserWithSettings(
            userId,
            "Jane Doe",
            "jane.doe@gmail.com",
            new Common.Settings("dark", "en"));
        var standardKey = $"user-standard:{userId}";
        await json.SetAsync(standardKey, "$", userWithSettings);

        var standardMemory = (long)await db.ExecuteAsync("MEMORY", "USAGE", standardKey);
        Console.WriteLine($"Standard approach memory usage: {standardMemory} bytes");
        Console.WriteLine($"Can query nested field 'Theme' : {await json.GetAsync(standardKey, ["$.Settings.Theme"])}");

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
        await json.SetAsync(optimizedKey, "$", userWithSerializedSettings);

        var optimizedMemory = await db.ExecuteAsync("MEMORY", "USAGE", optimizedKey);
        Console.WriteLine($"Optimized approach memory usage: {optimizedMemory} bytes");
        Console.WriteLine("Cannot query nested field 'Theme'");
    }
}