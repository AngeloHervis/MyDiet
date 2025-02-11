namespace Domain._Base.Notification;

public class DomainNotification(string key, string value)
{
    public string Key { get; } = key;
    public string Value { get; } = value;
}