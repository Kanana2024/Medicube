CREATE TABLE [dbo].[Suppliers]
(
	[SupplierID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [SupplierName] VARCHAR(50) NOT NULL, 
    [ContactPerson] VARCHAR(50) NOT NULL, 
    [Phone] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(50) NOT NULL
)