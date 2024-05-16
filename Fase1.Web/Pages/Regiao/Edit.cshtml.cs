using Fase1.Web.DTO.Inputs;
using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fase1.Web.Pages.Regiao
{
    public class EditModel : PageModel
    {
        private readonly IRegiaoService _regiaoService;

        public EditModel(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public RegiaoResult RegiaoEdit { get; set; } = default!;

        public async void OnGet()
        {
            RegiaoEdit = _regiaoService.GetRegiaoPorId(Id).Result;
        }

        public async Task<IActionResult> OnPost()
        {
            _regiaoService.Atualizar(new RegiaoPut() { Id = RegiaoEdit.Id, Nome = RegiaoEdit.Nome, DDD = RegiaoEdit.DDD});

            return RedirectToPage("../Index");
        }
    }
}
