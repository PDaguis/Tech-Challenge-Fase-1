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
        public Regiao(string nome, string dDD)
        {
            Nome = nome;
            DDD = dDD;

            ValidateEntity();
        }

        public Regiao()
        {
            
        }

        public string Nome { get; set; }
        public string DDD { get; set; }
        public virtual ICollection<Contato>? Contatos { get; set; }

        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "O nome não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(DDD, "O DDD não pode estar vazio!");
            AssertionConcern.AssertDDDIsValid(DDD, "O DDD é inválido!");
        }
    }
}
