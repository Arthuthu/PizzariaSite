CREATE PROCEDURE [dbo].[spPizza_Update]
	@Id int,
	@Nome nvarchar(50),
	@Descricao nvarchar(500),
	@Tipo nvarchar(20),
	@Valor decimal(18,2)
AS
BEGIN
	UPDATE dbo.[Pizzas] SET Nome = @Nome, Descricao = @Descricao, Tipo = @Tipo, Valor = @Valor
	WHERE Id = @Id;
END
