using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Core.Entities
{
    public class Regiao : EntityBase
    {
        public required string Nome { get; set; }
        public required string DDD { get; set; }
        public virtual ICollection<Contato>? Contatos { get; set; }
    }
}
