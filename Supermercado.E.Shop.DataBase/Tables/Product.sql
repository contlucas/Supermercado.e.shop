﻿CREATE TABLE [dbo].[Product]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(200) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [UrlImage] NVARCHAR(200) NOT NULL
)
