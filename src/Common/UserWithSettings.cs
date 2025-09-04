namespace Common;

public record UserWithSettings(Guid Id, string Name, string EmailAddress, Settings Settings);
