using System.Runtime.CompilerServices;
using Crosscutting.Constants;
using Crosscutting.Interfaces.Log;
using Infra.Log._Base;
using Infra.Log.Interfaces;

namespace Infra.Log.Loggers;

public class StandardLogger : LoggerBase, IStandardLogger
{
    public StandardLogger(ILogWriter logger) : base(logger) { }

    public void LogWarning<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogInfo<TSource>(message, sourceMethod);

    public void LogError<TSource>(string message, Exception exception, [CallerMemberName] string sourceMethod = "")
        => LogError<TSource>(exception, message, sourceMethod);

    public void LogError<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogError<TSource>(message, sourceMethod);
        
    public void LogErrorWithData<TSource>(string message, string data, Exception exception, [CallerMemberName] string sourceMethod = "")
        => LogError<TSource>(exception, message, sourceMethod, data);

    public void LogStandardInfo<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogInfo<TSource>(message, sourceMethod);

    public void LogStandardInfoWithData<TSource>(string message, string data, string sourceMethod = "")
        => LogInfoWithSourceData<TSource>(message, data, sourceMethod);

    public void LogStandardWarning<TSource>(string message, string sourceMethod = "")
        => LogWarning<TSource>(message, sourceMethod);

    public void LogErrorWithoutException<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogError<TSource>(message, sourceMethod);

    public void LogErrorWithoutExceptionWithData<TSource>(
        string message, object data, [CallerMemberName] string sourceMethod = "")
    {
        try
        {
            LogError<TSource>(message, sourceMethod, data);
        }
        catch (Exception e)
        {
            LogError<TSource>(string.Format(ErrorLogMessages.LoggingError, e.Message), e, sourceMethod);
        }
    }
}
