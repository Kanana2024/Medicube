CREATE TABLE StockTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    MedicineID INT NOT NULL,
    UserID INT NOT NULL,
    TransactionType VARCHAR(3) NOT NULL,
    Quantity INT NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    Notes VARCHAR(255),

    CONSTRAINT FK_StockTransactions_Medicine
        FOREIGN KEY (MedicineID)
        REFERENCES Medicines(MedicineID),

    CONSTRAINT FK_StockTransactions_Users
        FOREIGN KEY (UserID)
        REFERENCES Users(UserID),

    CONSTRAINT CK_StockTransactions_Type
        CHECK (TransactionType IN ('IN', 'OUT')),

    CONSTRAINT CK_StockTransactions_Quantity
        CHECK (Quantity > 0)
);