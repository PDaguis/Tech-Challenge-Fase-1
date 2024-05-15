using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Core.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            CadastradoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CadastradoEm { get; }
    }
}
