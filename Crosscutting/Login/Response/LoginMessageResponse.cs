using System.Text.Json.Serialization;
using Crosscutting.Constants;
using Crosscutting.Enums;

namespace Crosscutting.Login.Response;

public class LoginMessageResponse
{
    public string Title { get; init; }
    public string Description { get; init; }

    [JsonIgnore] public LoginMessageType TypeLoginMessage { get; init; }

    public static LoginMessageResponse WithDefaultServerFailure()
        => new()
        {
            Title = LoginMessage.ServerFailureTitle,
            Description = LoginMessage.LoginProcessingFailureDescription,
            TypeLoginMessage = LoginMessageType.ServerFailure
        };
}