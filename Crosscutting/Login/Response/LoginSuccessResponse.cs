using Crosscutting.Dto.User;

namespace Crosscutting.Login.Response;

public class LoginSuccessResponse(
    string email,
    string refreshToken,
    DateTime expiration,
    UserDto user)
{
    
}