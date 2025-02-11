namespace Crosscutting.Constants;

public static class LoginMessage
{
    public const string InvalidLoginTitle = "Invalid login or password";
    public const string ServerFailureTitle = "Failed to communicate with the server";
    public const string ContactITTitle = "Contact IT support";
    public const string TokenGenerationFailureTitle = "Failed to generate internal token";
    public const string TokenRenewalFailureTitle = "Failed to renew user authentication on the server";
    public const string UserNotFoundLoginDescription = "Check your credentials and try logging in again";
    public const string LoginProcessingFailureDescription = "Please try again in a few minutes";
    public const string UnauthorizedProfileLoginDescription = "Verify the user's profile";
    public const string AuthenticationFailureDescription = "Failed to communicate with the authentication server";
    public const string ReloginRequiredDescription = "Please log in again";
}