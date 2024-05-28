using System.ComponentModel.DataAnnotations;

namespace Fase1.API.DTO.Inputs
{
    public class ContatoPost
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression("^(?:((?:9\\d|[2-9])\\d{3})\\-?(\\d{4}))$", ErrorMessage = "Telefone em formato incorreto!")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato incorreto!")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Região é obrigatório!")]
        public int RegiaoId { get; set; }
    }
}
