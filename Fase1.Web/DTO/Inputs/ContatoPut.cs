namespace Fase1.Web.DTO.Inputs
{
    public class ContatoPut
    {
        public required int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }
    }
}
