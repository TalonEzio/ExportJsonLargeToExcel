using System.Globalization;
using System.Text;
using System.Text.Json;
using CsvHelper;
using ExportJsonLargeToExcel.Extensions;
using ExportJsonLargeToExcel.Models;

namespace ExportJsonLargeToExcel
{
    internal class Program
    {


        private static async Task Main(string[] args)
        {
            if (!args.Any() || args[0] != "-i")
            {
                Console.WriteLine("Usage: -i <.jsonl path>");
                Console.WriteLine("If absolute .jsonl path contains \" \", please wrap it on \"\".Ex: \"C:\\Test Path\\test.jsonl\"");
                return;
            }

            var path = args[1];
            if (path.EndsWith(".jsonl") && (string.IsNullOrEmpty(path) || !File.Exists(path)))
            {
                Console.WriteLine("Cannot find .jsonl File");
                return;
            }
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;


            await using var fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            await using var bs = new BufferedStream(fs);
            using var sr = new StreamReader(bs);

            var writerStream = File.CreateText(Path.ChangeExtension(path, ".csv"));

            List<AmazonRating> ratingList = [];
            while (await sr.ReadLineAsync() is { } currentLine)
            {
                var rating = JsonSerializer.Deserialize(currentLine,SourceGenerationContext.Default.AmazonRating);
                if (rating == null) continue;

                ratingList.Add(rating);
            }
            var csvWriter = new CsvWriter(writerStream, CultureInfo.CurrentCulture);

            csvWriter.WriteHeader<AmazonRating>();

            await csvWriter.NextRecordAsync();
            await csvWriter.WriteRecordsAsync(ratingList);
            await csvWriter.FlushAsync();

            Console.WriteLine("Chuyển đổi file thành công");
            writerStream.Close();
            fs.Close();
        }
    }

}
