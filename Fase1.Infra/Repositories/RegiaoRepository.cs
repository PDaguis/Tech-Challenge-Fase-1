using Fase1.Core.Entities;
using Fase1.Core.Interfaces;
using Fase1.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Infra.Repositories
{
    public class RegiaoRepository : GenericRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
