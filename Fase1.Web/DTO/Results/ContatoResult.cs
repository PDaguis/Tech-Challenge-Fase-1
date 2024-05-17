using System.Text.Json.Serialization;

namespace Fase1.Web.DTO.Results
{
    public class ContatoResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("regiaoId")]
        public int RegiaoId { get; set; }

        [JsonPropertyName("cadastradoEm")]
        public DateTime CadastradoEm { get; set; }
    }
}
