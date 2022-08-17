CREATE PROCEDURE [dbo].[PPSP_Create]
	@Name NVARCHAR(100),
	@Meat NVARCHAR(50),
	@Vegetable NVARCHAR(50),
	@Sauce BIT
AS
	INSERT INTO [Noodle] ([Name], [Meat], [Vegetable], [Sauce]) VALUES (@Name, @Meat, @Vegetable, @Sauce);
RETURN 0
