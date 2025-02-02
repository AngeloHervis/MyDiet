namespace Crosscutting.Constants;

public static class ErrorLogMessages
{
    public const string InvalidCredentials = "The user '{0}' was not authenticated. Invalid credentials.";
    public const string DomainError = "Domain error. Code: '{0}', Message: '{1}'";
    public const string LoggingError = "Error during logging. Error message: {0}";
    public const string InvalidEmail = "The email is invalid.";
    public const string InvalidPassword = "The password is invalid.";
}