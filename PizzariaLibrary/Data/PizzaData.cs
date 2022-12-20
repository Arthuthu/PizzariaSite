using Microsoft.Extensions.Caching.Memory;
using PizzariaLibrary.DbAccess;
using PizzariaLibrary.Models;

namespace PizzariaLibrary.Data
{
	public class PizzaData : IPizzaData
	{
		private readonly ISqlDataAccess _db;
		private readonly IMemoryCache _memoryCache;

		public PizzaData(ISqlDataAccess db, IMemoryCache memoryCache)
		{
			_db = db;
			_memoryCache = memoryCache;
		}

		public Task<IEnumerable<PizzaModel>> GetAllPizzas()
		{
			var output = _memoryCache.Get<Task<IEnumerable<PizzaModel>>>("pizzas");

			if (output is null)
			{
				output = _db.LoadData<PizzaModel, dynamic>("dbo.spPizza_GetAll", new { });

				_memoryCache.Set("pizzas", output, TimeSpan.FromHours(1));
			}

			return output;
		}

		public async Task<PizzaModel?> GetPizzaById(int id)
		{
			var output = _memoryCache.Get<IEnumerable<PizzaModel>>("pizza");

			if (output is null)
			{
				output = await _db.LoadData<PizzaModel, dynamic>("dbo.spPizza_Get", new { Id = id });
			}

			return output.FirstOrDefault();
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
