using Crosscutting.Constants;
using Crosscutting.Interfaces.Log;
using Domain._Base.Interfaces;
using Domain._Base.Models;

namespace Domain._Base.Services;

public class DomainErrorHandler(ILoggerDomainServices logger) : IDomainErrorHandler
{
    private List<DomainError> Errors { get; set; } = [];

    public void AddError(DomainError error)
    {
        Errors.Add(error);
    }
    
    public List<DomainError> GetErrors() => Errors.ToList();

    public bool HasErrors() => Errors.Count != 0;

    public void ClearErrors()
    {
        Errors = [];
    }

    public void LogErrors()
    {
        foreach (var error in Errors)
        {
            logger.LogErrorWithoutException<DomainErrorHandler>(string.Format(ErrorLogMessages.DomainError, error.Code,
                error.Message));
        }
    }
}