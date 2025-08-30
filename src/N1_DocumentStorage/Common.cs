namespace N1_DocumentStorage;

public static class Common
{
    public record User(Guid Id, string Name, string EmailAddress);

    public record UserProfile(string Bio, string Location);

    public record UserWithProfile(Guid Id, string Name, string EmailAddress, UserProfile Profile);

    public record Settings(string Theme, string Language);

    public record UserWithSettings(Guid Id, string Name, string EmailAddress, Settings Settings);
}