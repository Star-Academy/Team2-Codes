using System.Text.Json.Serialization;

namespace InvertedIndex.Models
{
    public class Document
    {
        public static Document Null = new NullDocument();
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("content")] public string Content { get; set; }

        private class NullDocument : Document
        {
        }
    }
}