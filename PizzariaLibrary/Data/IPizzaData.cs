using PizzariaLibrary.Models;

namespace PizzariaLibrary.Data
{
	public interface IPizzaData
	{
		Task DeletePizza(int id);
		Task<IEnumerable<PizzaModel>> GetAllPizzas();
		Task<PizzaModel> GetPizzaById(int id);
		Task InsertPizza(PizzaModel pizza);
		Task UpdatePizza(PizzaModel pizza);
	}
}