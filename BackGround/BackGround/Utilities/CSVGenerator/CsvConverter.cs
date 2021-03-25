using System;
using System.Collections.Generic;

namespace BackGround.Utilities.CSVGenerator
{
    public static class CsvConverter
    {
        public static string Serialize<T>(IEnumerable<T> values)
        {
            var serializer = new CsvSerializer<T>();
            return serializer.Serialize(values);
        }
    }
}
