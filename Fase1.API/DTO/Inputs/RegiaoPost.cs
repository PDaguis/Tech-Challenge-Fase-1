using System.ComponentModel.DataAnnotations;

namespace Fase1.API.DTO.Inputs
{
    public class RegiaoPost
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "DDD é obrigatório!")]
        public string DDD { get; set; }
    }
}
