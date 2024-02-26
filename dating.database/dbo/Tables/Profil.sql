CREATE TABLE [dbo].[Profil]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AccountId] INT NOT NULL UNIQUE, 
    [CityId] INT NOT NULL, 
    [ProfilName] NVARCHAR(50) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [Gender] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Profil_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Profil_City] FOREIGN KEY ([CityId]) REFERENCES [City]([Id])
)
