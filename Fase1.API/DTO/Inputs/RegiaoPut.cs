using System.ComponentModel.DataAnnotations;

namespace Fase1.API.DTO.Inputs
{
    public class RegiaoPut
    {
        public required int Id { get; set; }
        public string Nome { get; set; }

        [MaxLength(3, ErrorMessage = "O DDD deve conter até 3 caracteres!")]
        public string DDD { get; set; }
    }
}
