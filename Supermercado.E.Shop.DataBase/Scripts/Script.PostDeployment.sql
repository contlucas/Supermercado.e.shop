/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Rol] ON
GO
INSERT INTO [dbo].[Rol] ([ID], [Description]) VALUES (1, 'Administrator'),
	(2, 'Guest');
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO

INSERT INTO [dbo].[User] ([Username], [Password], [Email], [IDRol]) VALUES
	('admin', 'D033E22AE348AEB5660FC2140AEC35850C4DA997', 'admin@admin.com', 1)
GO

INSERT INTO [dbo].[Product] ([Description], [Name], [Quantity], [UrlImage]) VALUES
	('Cerealitas', 'Cookies', 10, '/Products/Images/cerealitas1.png')
GO