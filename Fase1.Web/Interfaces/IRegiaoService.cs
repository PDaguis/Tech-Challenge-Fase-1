using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;

namespace Fase1.Web.Interfaces
{
    public interface IRegiaoService
    {
        Task<IEnumerable<RegiaoResult>> GetRegioes();
        bool Cadastrar(RegiaoPost regiao);
    }
}
