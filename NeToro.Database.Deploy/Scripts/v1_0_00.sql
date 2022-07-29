CREATE SCHEMA [App]
	AUTHORIZATION [dbo];
GO

CREATE TABLE [App].[User]
(
	[Id]		 INT	        IDENTITY(1,1),	
	[Username]	 NVARCHAR(25)	NOT NULL,
	[Password]   VARCHAR(MAX)   NOT NULL,
	[Salt]       VARCHAR(MAX)   NOT NULL,
	[CreatedOn]  DATETIME2(4)   NOT NULL,
	[IsDelited]  BIT            NOT NULL,
	[LastUpdate] DATETIME2(4)   ,

	CONSTRAINT PK_UserId PRIMARY KEY CLUSTERED([Id] ASC),
	UNIQUE ([Username])	
);
GO
