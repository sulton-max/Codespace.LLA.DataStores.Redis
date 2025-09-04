namespace Common;

public record UserWithProfile(Guid Id, string Name, string EmailAddress, UserProfile Profile);