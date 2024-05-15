using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Core.Entities
{
    public class Contato : EntityBase
    {
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public virtual required Regiao Regiao { get; set; }
    }
}
