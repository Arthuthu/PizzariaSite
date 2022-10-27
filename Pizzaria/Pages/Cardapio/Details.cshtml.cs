using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<CardapioModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;

        public DetailsModel(ILogger<CardapioModel> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
        }
        public void OnGet(int id)
        {
            _logger.LogInformation("Loading the details page");
        }
    }
}
