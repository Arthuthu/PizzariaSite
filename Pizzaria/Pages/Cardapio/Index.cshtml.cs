using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pizzaria.Pages.Cardapio
{
    public class CardapioModel : PageModel
    {
        private readonly ILogger<CardapioModel> _logger;

        public CardapioModel(ILogger<CardapioModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Loading the Cardapio page");
        }
    }
}
