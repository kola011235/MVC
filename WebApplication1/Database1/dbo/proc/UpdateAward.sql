CREATE PROCEDURE UpdateAward @ID int, @Title varchar(30)
AS
UPDATE Awards
SET 
Title = @Title
WHERE
ID = @ID