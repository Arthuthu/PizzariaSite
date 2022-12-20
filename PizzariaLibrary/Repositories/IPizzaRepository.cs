using PizzariaLibrary.Models;

namespace PizzariaLibrary.Repositories
{
    public interface IPizzaRepository
    {
        Task<bool> CreatePizza(PizzaModel pizza);
        Task<bool> DeletePizza(int id);
        Task<List<PizzaModel>> GetAllPizzas();
        PizzaModel GetPizzaById(int id);
        Task<bool> UpdatePizza(PizzaModel pizza);
    }
}