﻿CREATE PROCEDURE AddAward @Title varchar(100), @ID int OUTPUT
AS
BEGIN
INSERT INTO Awards VALUES (@Title)
SELECT @ID = SCOPE_IDENTITY()
END
