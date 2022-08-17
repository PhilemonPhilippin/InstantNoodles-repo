CREATE PROCEDURE [dbo].[PPSP_GetAll]
AS
	SELECT [NoodleID], [Name], [Meat], [Vegetable], [Sauce] FROM [Noodle];
RETURN 0
