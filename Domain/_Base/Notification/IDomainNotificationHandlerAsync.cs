namespace Domain._Base.Notification;

public interface IDomainNotificationHandlerAsync<T> : IHandlerAsync<T>
{
    bool HasNotifications();
    List<T> GetNotifications();
    void Clear();
    void GravarLog();
}