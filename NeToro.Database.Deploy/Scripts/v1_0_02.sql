CREATE TABLE [App].[Profile]
(
	[Id]			INT				IDENTITY(1,1),
	[UserId]		INT				NOT NULL,
	[FirstName]		NVARCHAR(MAX) 	NOT NULL,
	[LastName]		NVARCHAR(MAX)	NOT NULL,
	[EGN]			NVARCHAR(10)	NOT NULL,
	[Nationality]	NVARCHAR(60)	NOT NULL,
	[Address]		NVARCHAR(MAX)	NOT NULL,

	CONSTRAINT PK_ProfileId PRIMARY KEY CLUSTERED([Id] ASC)
	);
GO

CREATE OR ALTER PROCEDURE [App].[CreateProfile]
		(@UserId		INT,
		@FirstName		NVARCHAR(MAX),
		@LastName		NVARCHAR(MAX),
		@EGN			NVARCHAR(10),
		@Nationality	NVARCHAR(60),
		@Address		NVARCHAR(MAX))
AS
INSERT INTO [App].[CreateProfile]
	([UserId],
	[FirstName],
	[LastName],
	[EGN],
	[Nationality],
	[Address])
	VALUES
	(@UserId,
	@FirstName,
	@LastName,
	@EGN,
	@Nationality,
	@Addressd)

SELECT SCOPE_IDENTITY()
GO