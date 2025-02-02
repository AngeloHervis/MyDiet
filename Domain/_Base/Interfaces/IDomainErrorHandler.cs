using Domain._Base.Models;

namespace Domain._Base.Interfaces;

public interface IDomainErrorHandler
{
    void AddError(DomainError error);
    List<DomainError> GetErrors();
    bool HasErrors();
    void ClearErrors();
    void LogErrors();
}