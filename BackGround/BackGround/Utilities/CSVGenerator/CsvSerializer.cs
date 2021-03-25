using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BackGround.Utilities.CSVGenerator
{
    internal class CsvSerializer<T>
    {
        private IEnumerable<Tuple<PropertyInfo, Func<Object, String>>> PropertyValueConverters { get; set; }

        public CsvSerializer()
        {
            this.PropertyValueConverters = typeof(T).GetProperties().Select(x =>
            {
                if (x.PropertyType == typeof(DateTime))
                    return Tuple.Create(x, (Func<Object, String>)(o => CsvValue.FromDate((DateTime)o)));
                else if (x.PropertyType == typeof(DateTime?))
                    return Tuple.Create(x, (Func<Object, String>)(o => CsvValue.FromNullableDate((DateTime?)o)));
                else
                    return Tuple.Create(x, (Func<Object, String>)CsvValue.From);
            }).ToList();
        }

        private IEnumerable<String> ExtractPropertyValues(T obj)
        {
            return this.PropertyValueConverters.Select(x => x.Item2(x.Item1.GetValue(obj, null)));
        }

        private IEnumerable<String> ExtractHeaders()
        {
            return this.PropertyValueConverters.Select(x => x.Item1.Name);
        }

        private String ToCsvRow(IEnumerable<String> values)
        {
            return String.Join(",", values);
        }

        public String Serialize(IEnumerable<T> entries)
        {
            using (var stream = new StringWriter() { NewLine = "\n" })
            {
                stream.WriteLine(ToCsvRow(ExtractHeaders()));
                foreach (var entry in entries)
                    stream.WriteLine(ToCsvRow(ExtractPropertyValues(entry)));
                return stream.ToString();
            }
        }
    }
}
