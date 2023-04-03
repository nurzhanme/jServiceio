using System.Text.Json.Serialization;

namespace jServiceio.Responses;

public class QuestionResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("answer")]
    public string Answer { get; set; }

    [JsonPropertyName("question")]
    public string Question { get; set; }

    [JsonPropertyName("value")]
    public object Value { get; set; }

    [JsonPropertyName("airdate")]
    public DateTime Airdate { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("game_id")]
    public int GameId { get; set; }

    [JsonPropertyName("invalid_count")]
    public object InvalidCount { get; set; }

    [JsonPropertyName("category")]
    public Category Category { get; set; }
}

public class Category
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("clues_count")]
    public int CluesCount { get; set; }
}