using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fase1.Web.Pages.Contato
{
    public class CreateModel : PageModel
    {
        private readonly IContatoService _contatoService;
        private readonly IRegiaoService _regiaoService;

        public CreateModel(IContatoService contatoService, IRegiaoService regiaoService)
        {
            _contatoService = contatoService;
            _regiaoService = regiaoService;
        }

        [BindProperty]
        public ContatoPost Contato { get; set; } = default!;

        public SelectList Regioes { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? RegiaoId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (RegiaoId == null)
                return Page();

            Contato.RegiaoId = RegiaoId.Value;

            var contato = _contatoService.Cadastrar(Contato);

            if (contato)
                return RedirectToPage("./Index");

            return Page();
        }

        public async void OnGet()
        {
            var regioes = await _regiaoService.GetRegioes();

            Regioes = new SelectList(regioes, nameof(RegiaoResult.Id), nameof(RegiaoResult.Nome));
        }
    }
}
