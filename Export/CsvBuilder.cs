using CsvHelper;
using System.Globalization;

namespace CsvSample.Export
{
    public class CsvBuilder<TRecord> where TRecord : class
    {
        public static string Build(List<TRecord> records, List<string> headers, string path, string fileName)
        {
            string[] fileNameSplits = fileName.Split('.');
            if (fileNameSplits.Length == 0) throw new ArgumentOutOfRangeException(nameof(fileName));

            fileName = fileNameSplits[0];

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path = Path.Combine(path, $"{fileName}.csv");

            if (File.Exists(path)) File.Delete(path);

            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            CsvMap<TRecord>.Headers = headers;
            csv.Context.RegisterClassMap<CsvMap<TRecord>>();
            csv.WriteRecords(records);

            return path;
        }
    }
}
