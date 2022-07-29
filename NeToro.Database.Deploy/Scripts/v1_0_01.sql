CREATE TABLE [App].[PaymentCard]
(
	[Id]		     INT	        IDENTITY(1,1),	
	[UserId]	     INT	        NOT NULL,
	[TypeId]         INT            NOT NULL,
	[CVC]            INT            NOT NULL,
	[BankName]       NVARCHAR(MAX)  NOT NULL,
	[CardHolder]     NVARCHAR(50)   NOT NULL,
	[CardNumber]     NVARCHAR(20)   NOT NULL,
	[ExpirationDate] DATE           NOT NULL,
	[LastUpdated]    DATETIME2(4)   ,
	[IsDeleted]      BIT DEFAULT 0  NOT NULL,

	CONSTRAINT PK_PaymentCardId PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE OR ALTER PROCEDURE [App].[CreatePaymentCard] 
	(@UserId         INT, 
	 @TypeId         INT, 
	 @CVC            INT, 
	 @BankName       NVARCHAR(MAX), 
	 @CardHolder     NVARCHAR(50), 
	 @CardNumber     NVARCHAR(20), 
	 @ExpirationDate DATE)
AS
INSERT INTO [App].[PaymentCard] 
	([UserId],
	 [TypeId],        
	 [CVC],           
	 [BankName],      
	 [CardHolder],    
	 [CardNumber],    
	 [ExpirationDate])
VALUES
	(@UserId,        
	 @TypeId,        
	 @CVC,           
	 @BankName,      
	 @CardHolder,    
	 @CardNumber,    
	 @ExpirationDate)

SELECT SCOPE_IDENTITY()
GO