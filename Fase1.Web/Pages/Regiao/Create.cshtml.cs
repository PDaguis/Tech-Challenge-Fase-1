using Fase1.Web.DTO.Inputs;
using Fase1.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fase1.Web.Pages.Regiao
{
    public class CreateModel : PageModel
    {
        private readonly IRegiaoService _regiaoService;

        public CreateModel(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        [BindProperty]
        public RegiaoPost Regiao { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (Regiao == null)
                return Page();
            
            var regiao = _regiaoService.Cadastrar(Regiao);

            if(regiao)
                return RedirectToPage("/Index");

            return Page();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
