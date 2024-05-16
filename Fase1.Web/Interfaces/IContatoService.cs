using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;

namespace Fase1.Web.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoResult>> GetContatos();
        Task<IEnumerable<ContatoResult>> GetContatosPorDDD(string ddd);
        bool Cadastrar(ContatoPost contato);
    }
}
