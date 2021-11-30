using CsvHelper.Configuration;
using System.Globalization;

namespace CsvSample.Export
{
    internal class CsvMap<TRecord> : ClassMap<TRecord>
    {
        public static List<string> Headers = new List<string>();

        public CsvMap()
        {
            AutoMap(CultureInfo.InvariantCulture);

            if (Headers is null || Headers.Count is 0) return;

            var recordType = typeof(TRecord);

            var properties = recordType.GetProperties();
            var index = 0;
            foreach (var property in properties)
            {
                var member = recordType.GetMember(property.Name);
                if (!Headers.Any(h => h.Equals(property.Name)))
                {
                    Map(recordType, member[0]).Ignore();
                }
                else
                {
                    Map(recordType, member[0]).Index(index).Name(Headers[index]);
                    index++;
                }
            }
        }
    }
}
