﻿namespace Fase1.API.DTO.Results
{
    public class ContatoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int RegiaoId { get; set; }
        public DateTime CadastradoEm { get; set; }
    }
}
