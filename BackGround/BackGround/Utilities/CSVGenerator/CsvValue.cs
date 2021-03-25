using System;
using System.Globalization;

namespace BackGround.Utilities.CSVGenerator
{
    internal static class CsvValue
    {
        public static String FromDate(DateTime value)
        {
            return value.TimeOfDay.TotalSeconds == 0 ?
                value.ToString("yyyy-MM-dd") : value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static String FromNullableDate(DateTime? cell)
        {
            return cell.HasValue ? FromDate(cell.Value) : String.Empty;
        }

        public static String FromString(String value)
        {
            var comma = value.Contains(",");
            var quote = value.Contains("\"");

            return (comma || quote) ?
                QuoteString(quote ? EscapeQuotes(value) : value) : value;
        }

        public static String From<T>(T obj)
        {
            return FromString(Convert.ToString(obj, CultureInfo.InvariantCulture));
        }

        private static String QuoteString(String value)
        {
            return '"' + value + '"';
        }

        private static String EscapeQuotes(String value)
        {
            return value.Replace("\"", "\"\"");
        }
    }
}
