using FluentAssertions;
using PizzariaLibrary.Models;
using PizzariaLibrary.Repositories;

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

        [Fact]
        public void CardapioUpdate_ShouldCreatePizza_WhenAllParametersAreValid()
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
            var result = _sut.Update(pizza);

            //Assert
            result.Should().BeTrue();
        }
    }
}
