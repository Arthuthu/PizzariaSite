using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class DeletePizzaActionModel : PageModel
    {
        private readonly ILogger<DeletePizzaActionModel> _logger;
        private readonly IPizzaRepository _pizzaRepository;

        public DeletePizzaActionModel(ILogger<DeletePizzaActionModel> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
        }
        public PizzaModel PizzaItem { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            await _pizzaRepository.Delete(id);
            _logger.LogInformation("Pizza was successfully deleted");

            return RedirectToPage("./Index");
        }
    }
}
