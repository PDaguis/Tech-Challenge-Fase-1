using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using Fase1.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fase1.Web.Pages.Contato
{
    public class EditModel : PageModel
    {
        private readonly IContatoService _contatoService;
        private readonly IRegiaoService _regiaoService;

        public EditModel(IContatoService contatoService, IRegiaoService regiaoService)
        {
            _contatoService = contatoService;
            _regiaoService = regiaoService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RegiaoId { get; set; }

        [BindProperty]
        public ContatoResult ContatoEdit { get; set; } = default!;

        public SelectList Regioes { get; set; }

        public async void OnGet()
        {
            ContatoEdit = _contatoService.GetContatoPorId(Id).Result;

            var regioes = await _regiaoService.GetRegioes();

            RegiaoId = ContatoEdit.RegiaoId;

            //Regioes = new SelectList(regioes, nameof(RegiaoResult.Id), nameof(RegiaoResult.DDD));

            Regioes = new SelectList(regioes.ToDictionary(x => x.Id, y => y.DDD + " - " + y.Nome), "Key", "Value");
        }

        public async Task<IActionResult> OnPost() 
        {
            _contatoService.Atualizar(new DTO.Inputs.ContatoPut() { Id = ContatoEdit.Id, Nome = ContatoEdit.Nome, Telefone = ContatoEdit.Telefone, Email = ContatoEdit.Email, RegiaoId = RegiaoId});

            return RedirectToPage("./Index");
        }
    }
}
