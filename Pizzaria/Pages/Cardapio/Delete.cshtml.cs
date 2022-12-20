using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Data;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;

		public DeleteModel(ILogger<DeleteModel> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
		}

        public PizzaModel PizzaItem { get; set; }

        public void OnGet(int id)
        {
            PizzaItem = _pizzaRepository.GetPizzaById(id);
            _logger.LogInformation("Loading the delete pizza page");
        }
    }
}
