CREATE TABLE [dbo].[Users](
    [UserID] INT identity(1,1) NOT NULL PRIMARY KEY,
    [FullName] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Phone] VARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL, 
    [Gender] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL
);