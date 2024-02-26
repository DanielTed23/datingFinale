CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [FromProfilId] INT NOT NULL, 
    [ToProfilId] INT NOT NULL, 
    [MessageText] NVARCHAR(250) NOT NULL, 
    [SentDate] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Message_FromProfil] FOREIGN KEY ([FromProfilId]) REFERENCES [Profil]([Id]), 
    CONSTRAINT [FK_Message_ToProfil] FOREIGN KEY ([ToProfilId]) REFERENCES [Profil]([Id])
)
