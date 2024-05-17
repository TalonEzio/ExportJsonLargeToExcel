using System.Text.Json.Serialization;
using ExportJsonLargeToExcel.Models;

namespace ExportJsonLargeToExcel.Extensions
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(AmazonRating))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
}
