using Fase1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Core.Interfaces
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IList<T> GetAll();
        void Cadastrar(T entidade);
        void Atualizar(T entidade);
        void Excluir(int id);
    }
}
