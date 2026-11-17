CREATE TABLE [dbo].[Category]
(
	[CategoryID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [CategoryName] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(150), 
)