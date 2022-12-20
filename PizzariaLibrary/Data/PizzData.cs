using PizzariaLibrary.DbAccess;
using PizzariaLibrary.Models;

namespace PizzariaLibrary.Data
{
	public class PizzData : IPizzData
	{
		private readonly ISqlDataAccess _db;

		public PizzData(ISqlDataAccess db)
		{
			_db = db;
		}

		public Task<IEnumerable<PizzaModel>> GetAllPizzas()
		{
			return _db.LoadData<PizzaModel, dynamic>("dbo.spPizza_GetAll", new { });
		}

		public async Task<PizzaModel?> GetPizzaById(int id)
		{
			var results = await _db.LoadData<PizzaModel, dynamic>("dbo.spPizza_Get", new { Id = id });

			return results.FirstOrDefault();
		}

		public Task InsertPizza(PizzaModel pizza)
		{
			return _db.SaveData("dbo.spPizza_Create", new
			{
				pizza.Nome,
				pizza.Descricao,
				pizza.Tipo,
				pizza.Valor
			});
		}

		public Task UpdatePizza(PizzaModel pizza)
		{
			return _db.SaveData("dbo.spPizza_Update", pizza);
		}

		public Task DeletePizza(int id)
		{
			return _db.SaveData("dbo.spPizza_Delete", new { Id = id });
		}
	}
}
