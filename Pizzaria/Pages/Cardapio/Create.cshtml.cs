using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            //_pizzaRepository.Create();

            _logger.LogInformation("The create pizza method was successfull");

            return RedirectToPage("./Index");
        }
    }
}
