using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaModel PizzaItem{ get; set; }

        public DetailsModel(ILogger<DetailsModel> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
        }
        public void OnGet(int id)
        {
            PizzaItem = _pizzaRepository.Search(id);
            _logger.LogInformation("Loading the details page");
        }
    }
}
