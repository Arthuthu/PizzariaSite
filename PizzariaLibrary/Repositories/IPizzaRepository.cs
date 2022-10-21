using PizzariaLibrary.Models;

namespace PizzariaLibrary.Repositories
{
    public interface IPizzaRepository
    {
        Pizza Create(Pizza pizza);
        bool Delete(int id);
        List<Pizza> Get();
        Pizza Search(int id);
        void Update(Pizza pizza);
    }
}