CREATE PROCEDURE [dbo].[spPizza_Create]
	@Nome nvarchar(50),
	@Descricao nvarchar(500),
	@Tipo nvarchar(20),
	@Valor decimal(18,2)
AS
BEGIN
	INSERT INTO dbo.[Pizzas] (Nome, Descricao, Tipo, Valor)
	VALUES (@Nome, @Descricao, @Tipo, @Valor);
END
