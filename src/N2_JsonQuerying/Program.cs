using N2_JsonQuerying;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

var conf = new ConfigurationOptions { EndPoints = { "localhost:6379" } };
await using var redis = await ConnectionMultiplexer.ConnectAsync(conf);
var redisDb = redis.GetDatabase();
var jsonCommands = redisDb.JSON();

// await PathQueries.RunExampleAsync(jsonCommands);
await ConditionalQueries.RunExampleAsync(jsonCommands);
