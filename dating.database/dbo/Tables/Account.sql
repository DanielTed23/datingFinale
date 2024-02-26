CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(50) NOT NULL UNIQUE, 
    [Password] NVARCHAR(50) NOT NULL, 
    [IsDeleted] INT NULL

)
