CREATE OR ALTER PROCEDURE [App].[DetailsById] 
		(@Id INT)
AS
SELECT
	[Id],
	[UserId],
	[FirstName],
	[LastName],
	[EGN],
	[Nationality],
	[Address]
FROM [App].[Profile]
WHERE [Id] = @Id
GO

EXEC [App].DetailsById @Id = 1;
