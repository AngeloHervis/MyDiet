using System.Runtime.CompilerServices;

namespace Crosscutting.Interfaces.Log;

public interface IStandardLogger
{
    void LogError<TSource>(string message, System.Exception exception, [CallerMemberName] string sourceMethod = "");
    void LogError<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogErrorWithData<TSource>(string message, string data, System.Exception exception, [CallerMemberName] string sourceMethod = "");
    void LogWarning<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogStandardInfo<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogStandardInfoWithData<TSource>(string message, string data, [CallerMemberName] string sourceMethod = "");
    void LogStandardWarning<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogErrorWithoutException<TSource>(string message, [CallerMemberName] string sourceMethod = "");
    void LogErrorWithoutExceptionWithData<TSource>(string message, object data, [CallerMemberName] string sourceMethod = "");
}