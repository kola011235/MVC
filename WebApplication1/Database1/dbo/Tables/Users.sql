
CREATE TABLE [dbo].[Users] (
ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name varchar(30) NOT NULL,
DateIfBirth Date NOT NULL,
Age int NOT NULL
);