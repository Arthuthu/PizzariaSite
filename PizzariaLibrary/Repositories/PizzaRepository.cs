using Dapper;
using Microsoft.Extensions.Configuration;
using PizzariaLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace PizzariaLibrary.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IConfiguration _config;
        private const string pizzariaDatabase = "Pizzaria";

        public PizzaRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<Pizza>> Get()
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            var results = await connection.QueryAsync<Pizza>("select * from Pizzas");

            return results.ToList();
        }

        public Pizza Search(int id)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            Pizza pizza = connection.Query<Pizza>("select * from Pizzas where id=@id", new { id }).SingleOrDefault();

            return pizza;
        }

        public async Task<bool> Create(Pizza pizza)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            await connection.ExecuteAsync("insert into Pizzas values (@Nome, @Descricao, @Tipo, @Valor)", pizza);

            return true;
        }

        public bool Delete(int id)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            return connection.Execute("delete from Pizzas where id=@pID",
            new { pID = id }) == 1;
        }

        public bool Update(Pizza pizza)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(pizzariaDatabase));

            connection.Execute(
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
