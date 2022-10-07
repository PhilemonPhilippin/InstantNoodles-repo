CREATE PROCEDURE [dbo].[PPSP_GetNoSauceWithMushroom]
AS
	BEGIN
		SELECT * FROM [Noodle] WHERE Sauce = 0 AND Vegetable IN ('Mushroom');
	END
RETURN 0
