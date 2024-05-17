using System.Text.Json.Serialization;

namespace ExportJsonLargeToExcel.Models
{

    public class AmazonRating
    {
        [JsonPropertyName("user_id")] public string UserId { get; set; } = string.Empty;
        [JsonPropertyName("asin")] public string Asin { get; set; } = string.Empty;
        [JsonPropertyName("parent_asin")] public string ParentAsin { get; set; } = string.Empty;
        [JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
        [JsonPropertyName("text")] public string Text { get; set; } = string.Empty;
        [JsonPropertyName("rating")] public double Rating { get; set; }
        [JsonPropertyName("timestamp")] public long Timestamp { get; set; }
        [JsonPropertyName("helpful_vote")] public int HelpfulVote { get; set; }
        [JsonPropertyName("verified_purchase")] public bool VerifiedPurchase { get; set; }
    }
}
