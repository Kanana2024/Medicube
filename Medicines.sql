
CREATE TABLE Medicines (
    MedicineID INT IDENTITY(1,1) PRIMARY KEY,

    MedicineName VARCHAR(150) NOT NULL,
    BatchNumber VARCHAR(50) NOT NULL,

    CategoryID INT NOT NULL,
    SupplierID INT NOT NULL,

    UnitPrice DECIMAL(10,2) NOT NULL,
    QuantityInStock INT NOT NULL DEFAULT 0,
    ReorderLevel INT NOT NULL DEFAULT 10,

    ManufactureDate DATE,
    ExpiryDate DATE NOT NULL,

    CONSTRAINT UQ_Medicines_Name_Batch
        UNIQUE (MedicineName, BatchNumber),

    CONSTRAINT FK_Medicines_Category
        FOREIGN KEY (CategoryID)
        REFERENCES Category(CategoryID),

    CONSTRAINT FK_Medicines_Suppliers
        FOREIGN KEY (SupplierID)
        REFERENCES Suppliers(SupplierID),

    CONSTRAINT CHK_Medicines_UnitPrice
        CHECK (UnitPrice >= 0),

    CONSTRAINT CHK_Medicines_Quantity
        CHECK (QuantityInStock >= 0),

    CONSTRAINT CHK_Medicines_ReorderLevel
        CHECK (ReorderLevel >= 0)
);
