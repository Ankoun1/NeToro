 sp_rename '[App].[User].[IsDelited]','IsDeleted', 'COLUMN';

 GO

 ALTER TABLE [App].[User] 
    ADD CONSTRAINT [DF_IsDeleted] 
    DEFAULT (0) 
    FOR [IsDeleted]
 GO
