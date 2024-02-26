CREATE TABLE [dbo].[ProfilDetail]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ProfilId] INT NOT NULL unique, 
    [Height] FLOAT NULL, 
    [Weight] FLOAT NULL, 
    [ProfilText] NVARCHAR(250) NULL, 
    CONSTRAINT [FK_ProfilDetail_Profil] FOREIGN KEY (ProfilId) REFERENCES [Profil]([Id])
)
