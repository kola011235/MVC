CREATE PROCEDURE AwardUsers @AwardID int, @UserID int
AS
INSERT INTO Awarded VALUES (@UserID, @AwardID)