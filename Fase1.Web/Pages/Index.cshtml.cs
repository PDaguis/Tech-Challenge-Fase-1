using Fase1.Web.DTO.Results;
using Fase1.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fase1.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRegiaoService _regiaoService;

        public IList<RegiaoResult> Regioes { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, IRegiaoService regiaoService)
        {
            _logger = logger;
            _regiaoService = regiaoService;
        }

        public async void OnGet()
        {
            Regioes = await GetRegioes();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _regiaoService.Excluir(id);

            Regioes = await GetRegioes();

            return Page();
        }

        public async Task<List<RegiaoResult>> GetRegioes()
        {
            Regioes = new List<RegiaoResult>();
            var regioes = await _regiaoService.GetRegioes();

            foreach (var regiao in regioes)
            {
                Regioes.Add(regiao);
            }

            return [.. Regioes];
        }
    }
}
