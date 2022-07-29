ALTER TABLE App.[PaymentCard] 
   ALTER COLUMN [CVC] VARCHAR(3);
GO

 CREATE OR ALTER PROCEDURE [App].[CreatePaymentCard] 
	(@UserId         INT, 
	 @TypeId         INT, 
	 @CVC            VARCHAR(3), 
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