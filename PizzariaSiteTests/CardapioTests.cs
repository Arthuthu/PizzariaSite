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
using Xunit;

namespace PizzariaSiteTests
{
    public class CardapioTests
    {
        private readonly PizzaRepository _sut;

        public CardapioTests()
        {
            _sut = new PizzaRepository();
        }

        [Fact]
        public void CardapioCreate_ShouldCreatePizza_WhenAllParametersAreValid()
        {
            //Arrange
            var pizza = new Pizza
            {
                Nome = "Calabresa",
                Descricao = "Ingredientes",
                Tipo = "Salgada",
                Valor = 23
            };

            //Act
            var result = _sut.Create(pizza);


            //Assert
            result.Should().BeTrue();
        }
    }
}
