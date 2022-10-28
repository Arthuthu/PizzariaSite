using Castle.Core.Logging;
using FluentAssertions;
using NSubstitute;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaSiteTests
{
    public class CardapioTests
    {
        private readonly IPizzaRepository _pizzaRepository;

        public CardapioTests(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [Fact]
        public void CardapioCreate_ShouldCreatePizza_WhenAllParametersAreValid()
        {
            //Arrange
            var pizzaModel = new Pizza
            {
                Id = 1,
                Nome = "Calabresa",
                Descricao = "Ingredientes",
                Tipo = "Salgada",
                Valor = 23
            };

            //Act
            var result = _pizzaRepository.Create(pizzaModel);

            //Assert
            //result.Should().BeTrue();
        }
    }
}
