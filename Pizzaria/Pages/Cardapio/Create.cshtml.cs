using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;

        public CreateModel(ILogger<CreateModel> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Pizza pizza)
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _pizzaRepository.Create(pizza);

            _logger.LogInformation("The pizza was successfully created");

            return RedirectToPage("./Index");
        }
    }
}
