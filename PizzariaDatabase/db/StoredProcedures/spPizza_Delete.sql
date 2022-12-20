CREATE PROCEDURE [dbo].[spPizza_Delete]
	@Id int
AS
BEGIN
	DELETE FROM dbo.[Pizzas]
	WHERE Id = @Id;
END

