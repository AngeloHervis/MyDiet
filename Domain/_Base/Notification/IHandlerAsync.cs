namespace Domain._Base.Notification;

public interface IHandlerAsync<in T>
{
    Task HandleAsync(T message);
}