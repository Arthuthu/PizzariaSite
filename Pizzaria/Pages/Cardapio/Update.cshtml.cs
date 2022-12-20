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

            await _pizzaRepository.Update(PizzaItem);

            _logger.LogInformation("The pizza was successfully updated");

            return RedirectToPage("./Index");
        }
    }
}
