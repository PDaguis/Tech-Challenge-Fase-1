namespace Fase1.API.DTO.Inputs
{
    public class ContatoPut
    {
        public required int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
