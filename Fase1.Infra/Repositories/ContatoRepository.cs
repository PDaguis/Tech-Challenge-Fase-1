using Fase1.Core.Entities;
using Fase1.Core.Interfaces;
using Fase1.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Infra.Repositories
{
    public class ContatoRepository : GenericRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Contato> GetContatosPorDDD(string ddd)
        {
            var contatos = _context.Contatos
                                   .Include(c => c.Regiao)
                                       .Where(c => c.Regiao.DDD == ddd)
                                           .ToList();

            return contatos;
        }
    }
}
