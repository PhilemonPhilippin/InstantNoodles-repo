CREATE PROCEDURE [dbo].[PPSP_Delete]
	@NoodleID int
AS
	DELETE FROM [Noodle] WHERE [NoodleID] = @NoodleID;
RETURN 0
