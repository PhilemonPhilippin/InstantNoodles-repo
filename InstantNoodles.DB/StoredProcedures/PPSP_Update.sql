CREATE PROCEDURE [dbo].[PPSP_Update]
	@NoodleID INT,
	@Name NVARCHAR(100),
	@Meat NVARCHAR(50),
	@Vegetable NVARCHAR(50),
	@Sauce BIT
AS
	UPDATE [Noodle] SET [Name] = @Name, [Meat] = @Meat, [Vegetable] = @Vegetable, [Sauce] = @Sauce WHERE [NoodleID] = @NoodleID;
RETURN 0
