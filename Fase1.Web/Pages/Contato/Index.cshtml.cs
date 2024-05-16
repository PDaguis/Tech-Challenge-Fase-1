using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using Fase1.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fase1.Web.Pages.Contato
{
    public class IndexModel : PageModel
    {
        private readonly IContatoService _contatoService;
        public IList<ContatoResult> Contatos { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchDDD { get; set; }

        public IndexModel(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public async void OnGet()
        {
            Contatos = new List<ContatoResult>();
            IEnumerable<ContatoResult> contatos;

            if (string.IsNullOrEmpty(SearchDDD))
                contatos = await _contatoService.GetContatos();
            else
                contatos = await _contatoService.GetContatosPorDDD(SearchDDD);

            foreach (var contato in contatos)
            {
                Contatos.Add(contato);
            }
        }
    }
}
