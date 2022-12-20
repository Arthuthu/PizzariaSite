using PizzariaLibrary.Models;

namespace PizzariaLibrary.Repositories
{
    public interface IPizzaRepository
    {
        Task<bool> Create(PizzaModel pizza);
        Task<bool> Delete(int id);
        Task<List<PizzaModel>> Get();
        PizzaModel Search(int id);
        Task<bool> Update(PizzaModel pizza);
    }
}