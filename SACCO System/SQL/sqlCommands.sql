-- Create Database 
CREATE DATABASE Sharesid_Sacco;

-- Change database context to the current one
USE Sharesid_Sacco;

-- Create Member Table
CREATE TABLE Member (
    Member_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Phone_number VARCHAR(20),
    Email VARCHAR(255),
    Date_Of_Birth DATE,
    Delete_Request TINYINT,
    Membership_Status VARCHAR(20),
    Address VARCHAR(255),
    Occupation VARCHAR(255),
	password VARCHAR(100)
);

-- Create Account Table
CREATE TABLE Account (
    Account_Number INT PRIMARY KEY,
    Member_ID INT,
    Account_Name VARCHAR(255),
    Lock_Status TINYINT,
    Account_Type VARCHAR(255),
    Created_At DATETIME,
    Account_Balance DECIMAL(18, 2),
    Last_TransactionTimestamp DATETIME,
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID)
);

-- Create DepositType Table
CREATE TABLE DepositType (
    Deposit_Type_ID INT PRIMARY KEY,
    Name VARCHAR(255)
);

-- Create Deposit Table
CREATE TABLE Deposit (
    Deposit_ID INT PRIMARY KEY,
    Account_Number INT,
    Amount DECIMAL(18, 2),
    Deposit_Type_ID INT,
    Timestamp DATETIME,
    Transaction_Reference_Number VARCHAR(255),
    Transaction_Status VARCHAR(20),
    FOREIGN KEY (Account_Number) REFERENCES Account(Account_Number),
    FOREIGN KEY (Deposit_Type_ID) REFERENCES DepositType(Deposit_Type_ID)
);

-- Create Withdrawal Table
CREATE TABLE Withdrawal (
    Withdrawal_ID INT PRIMARY KEY,
    Account_Number INT,
    Amount DECIMAL(18, 2),
    Phone_Number VARCHAR(20),
    Time_stamp DATETIME,
    Transaction_Reference_Number VARCHAR(255),
    Transaction_Status VARCHAR(20),
    FOREIGN KEY (Account_Number) REFERENCES Account(Account_Number)
);

-- Create Loan Application Table
CREATE TABLE Loan_Application (
    Loan_Application_ID INT PRIMARY KEY,
    Member_ID INT,
    Guarantor VARCHAR(255),
    Type_Of_Loan VARCHAR(255),
    Annual_Income INT,
    Loan_Period INT,
    Loan_Principle INT,
    Time_stamp DATETIME,
    Application_Status VARCHAR(20),
    Reason_For_Rejection VARCHAR(255),
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID)
);

-- Create Guarantor Table
CREATE TABLE Guarantor (
    Guarantor_ID INT PRIMARY KEY,
    Loan_ID INT,
    Member_ID INT,
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID)
);

-- Create Loan Table
CREATE TABLE Loan (
    Loan_ID INT PRIMARY KEY,
    Loan_Application_ID INT,
    Type_Of_Loan VARCHAR(255),
    Annual_Income INT,
    Loan_Period INT,
    Loan_Principle INT,
    Compound_Interest DECIMAL(18, 2),
    Guarantor_ID INT,
    Loan_Status TINYINT,
    Time_stamp DATETIME,
    Repayment_Schedule VARCHAR(255),
    Last_Payment_Timestamp DATETIME,
    FOREIGN KEY (Loan_Application_ID) REFERENCES Loan_Application(Loan_Application_ID),
    FOREIGN KEY (Guarantor_ID) REFERENCES Guarantor(Guarantor_ID)
);

-- Add a foreign key to the guarantor table that references the loan table
ALTER TABLE Guarantor ADD FOREIGN KEY (Loan_ID) REFERENCES Loan(Loan_ID);


-- Create Dividend Table
CREATE TABLE Dividend (
    Dividend_ID INT PRIMARY KEY,
    Account_Number INT,
    Amount DECIMAL(18, 2),
    Time_stamp DATETIME,
    Dividend_Status VARCHAR(20),
    Dividend_Calculation_Method VARCHAR(255),
    FOREIGN KEY (Account_Number) REFERENCES Account(Account_Number)
);

-- Create Shareholder Table
CREATE TABLE Shareholder (
    Shareholder_ID INT PRIMARY KEY,
    Member_ID INT,
    Share_Count INT,
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID)
);

-- Create ShareTransfer Table
CREATE TABLE Share_Transfer (
    Transfer_ID INT PRIMARY KEY,
    Sender_Account_Number INT,
    Receiver_Account_Number INT,
    Share_Count INT,
    Time_stamp DATETIME,
    FOREIGN KEY (Sender_Account_Number) REFERENCES Account(Account_Number),
    FOREIGN KEY (Receiver_Account_Number) REFERENCES Account(Account_Number)
);

-- Create DividendPayment Table
CREATE TABLE Dividend_Payment (
    Dividend_Payment_ID INT PRIMARY KEY,
    Dividend_ID INT,
    Account_Number INT,
    Amount DECIMAL(18, 2),
    Time_stamp DATETIME,
    FOREIGN KEY (Dividend_ID) REFERENCES Dividend(Dividend_ID),
    FOREIGN KEY (Account_Number) REFERENCES Account(Account_Number)
);

-- Create DeleteRequest Table
CREATE TABLE Delete_Request (
    Delete_Request_ID INT PRIMARY KEY,
    Account_Number INT,
    Time_stamp DATETIME,
    FOREIGN KEY (Account_Number) REFERENCES Account(Account_Number)
);

-- Create Admin Table
CREATE TABLE Admin (
    Admin_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Phone_Number VARCHAR(20),
    Email VARCHAR(255),
	password VARCHAR(100)
);





