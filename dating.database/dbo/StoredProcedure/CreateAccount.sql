CREATE PROCEDURE [dbo].[CreateAccount]
@UserName NVARCHAR (50),
@Password NVARCHAR (50),
@IsDeleted INT

AS

BEGIN
INSERT INTO Account(UserName,[Password],IsDeleted)
VALUES(@UserName,@Password,@IsDeleted)
SELECT SCOPE_IDENTITY() AS AccountId
END
