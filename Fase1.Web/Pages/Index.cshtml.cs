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
            Regioes = new List<RegiaoResult>();
            var regioes = await _regiaoService.GetRegioes();

            foreach (var regiao in regioes)
            {
                Regioes.Add(regiao);
            }
        }
    }
}
