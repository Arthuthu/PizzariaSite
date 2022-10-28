using Dapper;
using PizzariaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaLibrary.Repositories
{
    public class PizzaRepository : Connection, IPizzaRepository
    {
        public List<Pizza> Get()
        {
            List<Pizza> pizzas = connection.Query<Pizza>("select * from Pizzas").ToList();

            return pizzas;
        }

        public Pizza Search(int id)
        {
            Pizza pizza = connection.Query<Pizza>("select * from Pizzas where id=@id", new { id }).SingleOrDefault();

            return pizza;
        }

        public bool Create(Pizza pizza)
        {
            connection.Execute("insert into Pizzas values (@Nome, @Descricao, @Tipo, @Valor)", pizza);

            return true;
        }

        public bool Delete(int id)
        {
            return connection.Execute("delete from Pizzas where id=@pID",
            new { pID = id }) == 1;
        }

        public bool Update(Pizza pizza)
        {
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
