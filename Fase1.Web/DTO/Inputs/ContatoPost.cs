namespace Fase1.Web.DTO.Inputs
{
    public class ContatoPost
    {
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public int RegiaoId { get; set; }
    }
}
