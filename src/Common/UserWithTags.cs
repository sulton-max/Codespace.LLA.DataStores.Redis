namespace Common;

public record UserWithTags(Guid Id, string Name, int? Age, string[] Tags);