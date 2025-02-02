using System.Runtime.CompilerServices;

namespace Crosscutting.Interfaces.Log;

public interface ILoggerDomainServices
{
    void LogInformation<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogInfoWithData<TSource>(string message, object sourceData, [CallerMemberName] string sourceMethod = "");
    void LogWarning<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogWarningWithData<TSource>(string message, object sourceData, [CallerMemberName] string sourceMethod = "");
    void LogError<TSource>(System.Exception exception, string message, [CallerMemberName] string sourceMethod = "");
    void LogErrorWithData<TSource>(System.Exception exception, string message, object sourceData, [CallerMemberName] string sourceMethod = "");
    void LogErrorWithoutException<TSource>(string message, [CallerMemberName] string sourceMethod = "");
}