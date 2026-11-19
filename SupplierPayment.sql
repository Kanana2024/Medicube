CREATE TABLE SupplierPayment
(
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,

    SupplierID INT NOT NULL,

    PaymentDate DATE NOT NULL,

    AmountPaid DECIMAL(10,2) NOT NULL,

    PaymentMethod VARCHAR(30) NOT NULL,

    TransactionReference VARCHAR(100),

    Description VARCHAR(255),

    CONSTRAINT FK_SupplierPayment_Supplier
    FOREIGN KEY (SupplierID)
    REFERENCES Suppliers(SupplierID),

    CONSTRAINT CHK_PaymentAmount
    CHECK (AmountPaid > 0),

    CONSTRAINT CHK_PaymentMethod
    CHECK (PaymentMethod IN
    ('Cash', 'Bank Transfer', 'M-Pesa', 'Cheque'))
);