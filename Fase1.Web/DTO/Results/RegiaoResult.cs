using System.Text.Json.Serialization;

namespace Fase1.Web.DTO.Results
{
    public class RegiaoResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("ddd")]
        public string DDD { get; set; }
    }
}
