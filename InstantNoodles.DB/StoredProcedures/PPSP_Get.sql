CREATE PROCEDURE [dbo].[PPSP_Get]
	@NoodleID int
AS
	SELECT [NoodleID], [Name], [Meat], [Vegetable], [Sauce] FROM [Noodle] WHERE [NoodleID] = @NoodleID;
RETURN 0

