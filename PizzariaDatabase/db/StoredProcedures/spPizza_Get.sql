CREATE PROCEDURE [dbo].[spPizza_Get]
	@Id int
AS
BEGIN
	SELECT * FROM dbo.[Pizzas]
	WHERE Id = @Id;
END