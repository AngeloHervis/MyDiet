using System.Runtime.CompilerServices;
using Crosscutting.Constants;
using Crosscutting.Interfaces.Log;
using Infra.Log._Base;
using Infra.Log.Interfaces;

namespace Infra.Log.Loggers;

public class LoggerDomainServices(ILogWriter logger) : LoggerBase(logger), ILoggerDomainServices
{
    public void LogInformation<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogInfo<TSource>(message, sourceMethod);

    public void LogInfoWithData<TSource>(string message, object sourceData, [CallerMemberName] string sourceMethod = "")
    {
        try
        {
            LogInfoWithSourceData<TSource>(message, sourceData, sourceMethod);
        }
        catch (Exception e)
        {
            LogError<TSource>(e, string.Format(ErrorLogMessages.LoggingError, e.Message), sourceMethod);
        }
    }

    public void LogWarning<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogWarning<TSource>(message, sourceMethod);

    public void LogWarningWithData<TSource>(string message, object sourceData, [CallerMemberName] string sourceMethod = "")
    {
        try
        {
            LogWarningWithSourceData<TSource>(message, sourceData, sourceMethod);
        }
        catch (Exception e)
        {
            LogError<TSource>(e, string.Format(ErrorLogMessages.LoggingError, e.Message), sourceMethod);
        }
    }

    public void LogError<TSource>(Exception exception, string message, [CallerMemberName] string sourceMethod = "")
        => LogError<TSource>(exception, message, sourceMethod);

    public void LogErrorWithData<TSource>(
        Exception exception, string message, object sourceData, [CallerMemberName] string sourceMethod = "")
    {
        try
        {
            LogErrorWithSourceData<TSource>(exception, message, sourceData, sourceMethod);
        }
        catch (Exception e)
        {
            LogError<TSource>(e, string.Format(ErrorLogMessages.LoggingError, e.Message), sourceMethod);
        }
    }

    public void LogErrorWithoutException<TSource>(string message, [CallerMemberName] string sourceMethod = "")
        => LogError<TSource>(message, sourceMethod);
}
