CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(10) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
	[Email] NVARCHAR(200) NOT NULL, 
	[State] NCHAR(1) NOT NULL DEFAULT 'A',
    [AttemptsQuantity] INT NOT NULL DEFAULT 3, 
	[CreatedDateTime] DATETIME2 NOT NULL DEFAULT getdate(), 
    [LastLoginDateTime] DATETIME2 NULL, 
    [IDRol] INT NOT NULL, 
    CONSTRAINT [FK_User_Rol] FOREIGN KEY ([IDRol]) REFERENCES [Rol]([ID])
)
