using System.ComponentModel.DataAnnotations;

namespace Fase1.API.DTO.Inputs
{
    public class ContatoPut
    {
        public required int Id { get; set; }
        public string Nome { get; set; }

        [Phone(ErrorMessage = "Telefone em formato incorreto!")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Email em formato incorreto!")]
        public string Email { get; set; }
        public int RegiaoId { get; set; }
    }
}
