using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class UpdateModel : PageModel
    {
        private readonly ILogger<UpdateModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;

        public UpdateModel(ILogger<UpdateModel> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
        }
        public void OnGet(int id)
        {
            _pizzaRepository.Search(id);
        }

        public IActionResult OnPost(Pizza pizza)
        {

            if (ModelState.IsValid == false)
            {
                return Page();
            }

            _pizzaRepository.Update(pizza);

            _logger.LogInformation("The pizza was successfully updated");

            return RedirectToPage("./Index");
        }
    }
}
