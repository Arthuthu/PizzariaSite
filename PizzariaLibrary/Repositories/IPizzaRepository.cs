using PizzariaLibrary.Models;

namespace PizzariaLibrary.Repositories
{
    public interface IPizzaRepository
    {
        bool Create(Pizza pizza);
        bool Delete(int id);
        List<Pizza> Get();
        Pizza Search(int id);
        bool Update(Pizza pizza);
    }
}