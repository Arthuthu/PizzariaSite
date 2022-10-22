using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzariaLibrary.Repositories;

namespace Pizzaria.Pages.Cardapio
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ILogger<CreateModel> logger)
        {
            _logger = logger;
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

            _logger.LogInformation("The create pizza method was successfull");

            return RedirectToPage("./Index");
        }
    }
}
