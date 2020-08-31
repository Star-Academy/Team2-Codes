using System.Text.Json.Serialization;

namespace InvertedIndex.Models
{
    public class Document
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("content")] public string Content { get; set; }
    }
}