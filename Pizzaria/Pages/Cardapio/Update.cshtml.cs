using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Data;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class UpdateModel : PageModel
    {
        private readonly ILogger<UpdateModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaData _pizzaData;

        public UpdateModel(ILogger<UpdateModel> logger,
            IPizzaRepository pizzaRepository,
            IPizzaData pizzaData)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
            _pizzaData = pizzaData;

		}
        public PizzaModel PizzaItem { get; set; }

        public void OnGet(int id)
        {
            PizzaItem = _pizzaRepository.Search(id);
            _logger.LogInformation("Loading the update page");
        }

        public async Task<IActionResult> OnPost(PizzaModel PizzaItem)
        {

            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _pizzaData.UpdatePizza(PizzaItem);

            _logger.LogInformation("The pizza was successfully updated");

            return RedirectToPage("./Index");
        }
    }
}
