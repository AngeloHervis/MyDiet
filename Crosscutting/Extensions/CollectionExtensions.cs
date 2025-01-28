namespace Crosscutting.Extensions;

public static class CollectionExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T>? source)
    {
        if (source == null)
            return true;
        return !source.Any();
    }
}