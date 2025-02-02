namespace Domain._Base.Models;

public class DomainError
{
    public string Code { get; set; }
    public string Message { get; set; }

    public DomainError(string code, string message)
    {
        Code = code;
        Message = message;
    }
}