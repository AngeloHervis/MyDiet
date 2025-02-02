namespace Crosscutting.Constants;

public static class InfoLogMessages
{
    // Authentication
    public const string GenerateTokenForUserSuccess = "The token for user {0} was successfully generated.";
    public const string SuccessfulLogin = "Login was successful for user {0}";
    
    // User
    public const string ChangeUserPasswordInvalidFormat = "The password change for external user ID {0} failed because the new password is in an invalid format.";
    public const string ChangeUserPasswordMismatch = "The password change for external user ID {0} failed because the passwords do not match.";
    public const string ChangeUserPasswordSuccess = "The password change for external user ID {0} was successful.";
    public const string PasswordResetSuccess = "The password for external user ID {0} was successfully reset.";
}