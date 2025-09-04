using Common;
using NRedisStack;

namespace N2_JsonQuerying;

public static class ConditionalQueries
{
    public static async ValueTask RunExampleAsync(JsonCommands jsonCommands)
    {
        Console.WriteLine("\n\n----------  JSON Conditional Queries Example  ----------");

        var users = new List<UserWithTags>
        {
            new(Guid.CreateVersion7(), "John Doe", 35, ["manager", "developer"]),
            new(Guid.CreateVersion7(), "Jane Doe", null, ["developer", "mentor"]),
            new(Guid.CreateVersion7(), "John Smith", 33, [])
        };

        var key = "users:collection-conditional";
        await jsonCommands.SetAsync(key, "$", users);

        // Filter by equality
        var userJohnDoe = await jsonCommands.GetAsync(key, ["$[?(@.Name == 'John Doe')]"]);
        Console.WriteLine($"\nUser with exact name 'John Doe': {userJohnDoe}");

        // Filter by inequality
        var usersNotJohnDoe = await jsonCommands.GetAsync(key, ["$[?(@.Name != 'John Doe')]"]);
        Console.WriteLine($"\nUsers not named 'John Doe': {usersNotJohnDoe}");

        // Filter by string contents using regex
        var usersWithDoeInName = await jsonCommands.GetAsync(key, ["$[?(@.Name =~ '.*Doe.*')]"]);
        Console.WriteLine($"\nUsers with 'Doe' in their name: {usersWithDoeInName}");

        // Filter by numerical comparison - greater than
        var usersOlderThan34 = await jsonCommands.GetAsync(key, ["$[?(@.Age > 34)]"]);
        Console.WriteLine($"\nUsers older than 34: {usersOlderThan34}");

        // Filter by numerical comparison - less than
        var usersYoungerThan35 = await jsonCommands.GetAsync(key, ["$[?(@.Age < 35)]"]);
        Console.WriteLine($"\nUsers younger than 35: {usersYoungerThan35}");

        // Filter with a logical AND - range query
        var usersBetween30And34 = await jsonCommands.GetAsync(key, ["$[?(@.Age > 30 && @.Age < 34)]"]);
        Console.WriteLine($"\nUsers with age between 30 and 34: {usersBetween30And34}");

        // Filter with logical OR - multiple conditions
        var usersNamedJohnOrOlderThan34 = await jsonCommands.GetAsync(key, ["$[?(@.Name =~ 'John.*' || @.Age > 34)]"]);
        Console.WriteLine($"\nUsers named 'John' OR older than 34: {usersNamedJohnOrOlderThan34}");

        // Combined Filter and Selection - get names of users older than 32
        var namesOfUsersOlderThan32 = await jsonCommands.GetAsync(key, ["$[?(@.Age > 32)].Name"]);
        Console.WriteLine($"\nNames of users older than 32: {namesOfUsersOlderThan32}");
    }
}