CREATE TABLE [dbo].[Like]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [FromProfilId] INT NOT NULL, 
    [ToProfilId] INT NOT NULL, 
    [IsMutual] INT NOT NULL, 
    CONSTRAINT [FK_Like_FromProfil] FOREIGN KEY ([FromProfilId]) REFERENCES [Profil]([Id]), 
    CONSTRAINT [FK_Like_ToProfil] FOREIGN KEY ([ToProfilId]) REFERENCES [Profil]([Id]) 
)
