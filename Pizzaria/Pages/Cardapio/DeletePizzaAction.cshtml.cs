using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Data;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class DeletePizzaActionModel : PageModel
    {
        private readonly ILogger<DeletePizzaActionModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;
		private readonly IPizzaData _pizzaData;

		public DeletePizzaActionModel(ILogger<DeletePizzaActionModel> logger,
            IPizzaRepository pizzaRepository,
            IPizzaData pizzaData)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
			_pizzaData = pizzaData;
		}
        public PizzaModel PizzaItem { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            await _pizzaData.DeletePizza(id);
            _logger.LogInformation("Pizza was successfully deleted");

            return RedirectToPage("./Index");
        }
    }
}
