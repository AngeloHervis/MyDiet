using Crosscutting.Interfaces.Log;

namespace Domain._Base.Notification;

public class DomainNotificationHandlerAsync(IStandardLogger standardLogger) :
    IDomainNotificationHandlerAsync<DomainNotification>
{
    private List<DomainNotification> _notifications = [];

    public Task HandleAsync(DomainNotification message)
    {
        _notifications.Add(message);
        return Task.CompletedTask;
    }


    public List<DomainNotification> GetNotifications() => _notifications;

    public bool HasNotifications() => GetNotifications().Count != 0;

    public void Clear()
    {
        _notifications = [];
    }

    public void GravarLog()
    {
        foreach (var notification in GetNotifications())
            standardLogger.LogError<DomainNotificationHandlerAsync>(notification.Value);
    }
}