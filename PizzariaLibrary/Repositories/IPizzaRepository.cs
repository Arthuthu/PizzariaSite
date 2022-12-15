using PizzariaLibrary.Models;

namespace PizzariaLibrary.Repositories
{
    public interface IPizzaRepository
    {
        Task<bool> Create(Pizza pizza);
        Task<bool> Delete(int id);
        Task<List<Pizza>> Get();
        Pizza Search(int id);
        Task<bool> Update(Pizza pizza);
    }
}