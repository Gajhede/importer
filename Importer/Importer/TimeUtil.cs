using System.Globalization;

namespace Importer
{
    internal static class TimeUtil
    {
        public static string ToApiFormat(DateTime timestamp)
        {
            return timestamp.ToString(
            "yyyy-MM-ddTHH:mm",
            CultureInfo.InvariantCulture);
        }

        public static bool IsApiTimestamp(string? value, out DateTime timestamp)
        {
            return DateTime.TryParseExact(
                value,
                "yyyy-MM-ddTHH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out timestamp);
        }
    }
}
