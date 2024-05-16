using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;

namespace Fase1.Web.Interfaces
{
    public interface IRegiaoService
    {
        Task<IEnumerable<RegiaoResult>> GetRegioes();
        Task<RegiaoResult> GetRegiaoPorId(int id);
        bool Cadastrar(RegiaoPost regiao);
        bool Atualizar(RegiaoPut regiao);
        Task Excluir(int id);
    }
}
