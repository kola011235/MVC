

CREATE TABLE [dbo].[Awarded](
    UserID int,
	AwardID int,
	CONSTRAINT FK_Awarded_Users FOREIGN KEY (UserID)
        REFERENCES Users (ID) ON DELETE CASCADE,
	CONSTRAINT FK_Awarded_Awards FOREIGN KEY (AwardID)
        REFERENCES Awards (ID) ON DELETE CASCADE,
	CONSTRAINT PK_Awarded PRIMARY KEY(UserID,AwardID)
	)