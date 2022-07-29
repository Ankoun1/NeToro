CREATE OR ALTER PROC [app].[CreateUser]
(
     @username   NVARCHAR(25)
	,@password   VARCHAR(max)
	,@salt       VARCHAR(max)	
)
AS
    INSERT INTO [App].[User]
	(
	    Username
	    ,[Password]
	    ,Salt
	    ,CreatedOn	
	) 
	VALUES
	(
	    @username
	    ,@password
	    ,@salt
	    ,GETDATE()	
	)
    SELECT SCOPE_IDENTITY()
GO
