using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Data;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaData _pizzaData;

		public CreateModel(ILogger<CreateModel> logger, IPizzaRepository pizzaRepository, IPizzaData pizzaData)
		{
			_logger = logger;
			_pizzaRepository = pizzaRepository;
			_pizzaData = pizzaData;
		}

		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(PizzaModel pizza)
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _pizzaData.InsertPizza(pizza);

            _logger.LogInformation("The pizza was successfully created");

            return RedirectToPage("./Index");
        }
    }
}
