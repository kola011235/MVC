CREATE PROCEDURE AddUser @Name varchar(30), @DateIfBirth date, @Age int
AS
INSERT INTO Users VALUES(@Name,@DateIfBIrth,@Age)