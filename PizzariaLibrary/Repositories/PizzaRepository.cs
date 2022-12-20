using Dapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using PizzariaLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace PizzariaLibrary.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IConfiguration _config;
		private readonly IMemoryCache _memoryCache;
		private const string pizzariaDatabase = "Pizzaria";

        public PizzaRepository(IConfiguration config, IMemoryCache memoryCache)
        {
            _config = config;
			_memoryCache = memoryCache;
		}

        public async Task<List<PizzaModel>> Get()
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            var results = await connection.QueryAsync<PizzaModel>("select * from Pizzas");

            return results.ToList();
        }

        public PizzaModel Search(int id)
        {
            var output = _memoryCache.Get<PizzaModel>("pizza");

            if (output is null)
            {
				using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

                output = connection.Query<PizzaModel>("select * from Pizzas where id=@id", new { id }).SingleOrDefault();

                _memoryCache.Set("pizza", output, TimeSpan.FromHours(1));
			}

            return output;
        }

        public async Task<bool> Create(PizzaModel pizza)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            await connection.ExecuteAsync("insert into Pizzas values (@Nome, @Descricao, @Tipo, @Valor)", pizza);

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            return await connection.ExecuteAsync("delete from Pizzas where id=@pID",
            new { pID = id }) == 1;
        }

        public async Task<bool> Update(PizzaModel pizza)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            await connection.ExecuteAsync(
            @"update Pizzas set 
            Nome = @Nome,
            Descricao = @Descricao,
            Tipo = @Tipo,
            Valor = @Valor where Id = @Id ", new
            {
                id = pizza.Id,
                Nome = pizza.Nome,
                Descricao = pizza.Descricao,
                Tipo = pizza.Tipo,
                Valor = pizza.Valor,
            });

            return true;
        }
    }
}
