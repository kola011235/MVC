CREATE PROCEDURE UpdateUser @ID int, @Name varchar(30), @DateIfBirth date, @Age int
AS
UPDATE Users
SET
Name = @Name,
DateIfBirth = @DateIfBirth,
Age = @Age
WHERE
ID = @ID