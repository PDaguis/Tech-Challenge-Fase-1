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
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Método genérico para retornar todos os objetos 
        /// </summary>
        /// <returns>Retorna todos os objetos da classe informada em <T></returns>
        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Método genérico para consulta por Id
        /// </summary>
        /// <param name="id">Código identificador do objeto</param>
        /// <returns>Retorna o objeto informado em <T> pelo código informado</returns>
        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Método genérico para atualizar uma entidade no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade genérica</param>
        public void Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método genérico para cadastra uma entidade no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade genérica</param>
        public void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método genérico para excluir um objeto
        /// </summary>
        /// <param name="id">Código identificador do objeto</param>
        public void Excluir(int id)
        {
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
