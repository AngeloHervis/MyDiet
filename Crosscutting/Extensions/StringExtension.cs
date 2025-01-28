using System.Text;

namespace Crosscutting.Extensions;

public static class StringExtension
{
    public static string ToSnakeCase(this string text, bool isAcronym = false)
    {
        ArgumentNullException.ThrowIfNull(text);

        if (text.Length < 2)
        {
            return text.ToUpper();
        }

        if (isAcronym)
        {
            return text.ToLower();
        }

        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));

        foreach (var c in text[1..])
        {
            if (char.IsUpper(c))
            {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
                continue;
            }

            sb.Append(c);
        }

        return sb.ToString();
    }
}