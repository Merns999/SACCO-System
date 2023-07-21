-- Insert Data into "Member" Table
INSERT INTO Member (Member_ID, Name, Phone_number, Email, Date_Of_Birth, Delete_Request, Membership_Status, Address, Occupation, password)
VALUES
    (1, 'John Doe', '+254749538274', 'john.doe@example.com', '1985-08-15', 0, 'Active', '123 Main Street, Cityville', 'Software Engineer', 'password123'),
    (2, 'Jane Smith', '+254743928537', 'jane.smith@example.com', '1990-03-22', 1, 'Inactive', '456 Oak Avenue, Townsville', 'Teacher', 'pass456'),
    (3, 'Mike Johnson', '+254728437528', 'mike.johnson@example.com', '1989-11-10', 0, 'Active', '789 Elm Road, Villagetown', 'Accountant', 'm1k3pass');

-- Insert Data into "Account" Table
INSERT INTO Account (Account_Number, Member_ID, Account_Name, Lock_Status, Account_Type, Created_At, Account_Balance, Last_TransactionTimestamp)
VALUES
    (101, 1, 'Savings', 0, 'Savings', '2023-07-15 09:30:00', 5000.00, '2023-07-18 14:45:00'),
    (102, 2, 'Checking', 1, 'Checking', '2023-07-16 11:20:00', 2500.00, '2023-07-18 09:15:00'),
    (103, 3, 'Fixed Deposit', 0, 'Fixed Deposit', '2023-07-17 14:00:00', 10000.00, '2023-07-18 17:30:00');

-- Insert Data into "DeposiType" table
INSERT INTO DepositType (Deposit_Type_ID, Name)
VALUES
    (1, 'Cash'),
    (2, 'Cheque'),
    (3, 'Online');
	
-- Insert Data into "Deposit" table
INSERT INTO Deposit (Deposit_ID, Account_Number, Amount, Deposit_Type_ID, Timestamp, Transaction_Reference_Number, Transaction_Status)
VALUES
    ('a1b2c3d4-e5f6-g7h8-i9j0-k1l2m3n4o5p6', 101, 1000.00, 1, '2023-07-18 14:45:00', 'RGJ1W7S3DN', 'Successful'),
    ('b1c2d3e4-f5g6-h7i8-j9k0l1m2n3o4p5', 102, 500.00, 2, '2023-07-18 09:15:00', 'RGI7V2FVXF', 'Pending'),
    ('c1d2e3f4-g5h6-i7j8-k9l0m1n2o3p4q5', 103, 2000.00, 3, '2023-07-18 17:30:00', 'RGI3UCN36T', 'Successful');

-- Insert Data into "Withdrawal" Table
INSERT INTO Withdrawal (Withdrawal_ID, Account_Number, Amount, Phone_Number, Time_stamp, Transaction_Reference_Number, Transaction_Status)
VALUES
    ('w1x2y3z4-a5b6-c7d8-e9f0-g1h2i3j4k5l6m7n8', 101, 300.00, '+254749538274', '2023-07-18 12:30:00', 'RGI3U1AWG9', 'Successful'),
    ('x1y2z3a4-b5c6-d7e8-f9g0-h1i2j3k4l5m6n7o8', 102, 100.00, '+254743928537', '2023-07-18 09:30:00', 'RGI3U1E85Z', 'Successful'),
    ('y1z2a3b4-c5d6-e7f8-g9h0-i1j2k3l4m5n6o7p8', 103, 500.00, '+254728437528', '2023-07-18 16:00:00', 'RGI7U0WTSN', 'Pending');

-- Insert Data into "Loan_Application" Table
INSERT INTO Loan_Application (Loan_Application_ID, Member_ID, Guarantor, Type_Of_Loan, Annual_Income, Loan_Period, Loan_Principle, Time_stamp, Application_Status, Reason_For_Rejection)
VALUES
    ('l1m2n3o4-p5q6r7s8-t9u0v1w2x3y4z5a6b7c8', 1, 'Jane Smith', 'Personal Loan', 60000, 12, 5000, '2023-07-17 14:00:00', 'Pending', NULL),
    ('m1n2o3p4-q5r6s7t8-u9v0w1x2y3z4a5b6c7d8', 2, 'Mike Johnson', 'Car Loan', 75000, 24, 10000, '2023-07-16 11:20:00', 'Approved', NULL),
    ('n1o2p3q4-r5s6t7u8-v9w0x1y2z3a4b5c6d7e8', 3, 'John Doe', 'Home Loan', 90000, 36, 15000, '2023-07-15 09:30:00', 'Rejected', 'Insufficient income');

-- Insert Data into "Guarantor" table
INSERT INTO Guarantor (Guarantor_ID, Loan_ID, Member_ID)
VALUES
    (1, 'm1n2o3p4-q5r6s7t8-u9v0w1x2y3z4a5b6c7d8', 3),
    (2, 'n1o2p3q4-r5s6t7u8-v9w0x1y2z3a4b5c6d7e8', 1);

-- Insert Data into "Loan" Table
INSERT INTO Loan (Loan_ID, Loan_Application_ID, Type_Of_Loan, Annual_Income, Loan_Period, Loan_Principle, Compound_Interest, Guarantor_ID, Loan_Status, Time_stamp, Repayment_Schedule, Last_Payment_Timestamp)
VALUES
    ('m1n2o3p4-q5r6s7t8-u9v0w1x2y3z4a5b6c7d8', 'm1n2o3p4-q5r6s7t8-u9v0w1x2y3z4a5b6c7d8', 'Car Loan', 75000, 24, 10000, 500.00, 1, 1, '2023-07-16 11:20:00', 'Monthly', '2023-08-16 11:20:00'),
    ('n1o2p3q4-r5s6t7u8-v9w0x1y2z3a4b5c6d7e8', 'n1o2p3q4-r5s6t7u8-v9w0x1y2z3a4b5c6d7e8', 'Home Loan', 90000, 36, 15000, 900.00, 2, 0, '2023-07-15 09:30:00', 'Monthly', NULL);

-- Insert Data into "Dividend" Table
INSERT INTO Dividend (Dividend_ID, Account_Number, Amount, Time_stamp, Dividend_Status, Dividend_Calculation_Method)
VALUES
    ('d1e2f3g4-h5i6j7k8-l9m0n1o2p3q4r5s6t7u8', 101, 100.00, '2023-07-18 09:00:00', 'Paid', 'Proportional'),
    ('e1f2g3h4-i5j6k7l8-m9n0o1p2q3r4s5t6u7v8', 102, 50.00, '2023-07-18 10:30:00', 'Pending', 'Proportional');

-- Insert Data into "ShareHolder" Table
INSERT INTO Shareholder (Shareholder_ID, Member_ID, Share_Count)
VALUES
    ('s1t2u3v4-w5x6y7z8-a9b0c1d2e3f4g5h6i7j8', 1, 100),
    ('t1u2v3w4-x5y6z7a8-b9c0d1e2f3g4h5i6j7k8', 2, 50);

-- Insert Data into "Share_Transfer" table
INSERT INTO Share_Transfer (Transfer_ID, Sender_Member_ID, Receiver_Member_ID, Share_Count, Time_stamp)
VALUES
    ('u1v2w3x4-y5z6a7b8-c9d0e1f2g3h4i5j6k7l8m9n0', 1, 2, 50, '2023-07-18 14:00:00'),
    ('v1w2x3y4-z5a6b7c8-d9e0f1g2h3i4j5k6l7m8n9', 2, 1, 20, '2023-07-18 15:30:00');

-- Insert Data into "Dividend_Payment" Table
INSERT INTO Dividend_Payment (Dividend_Payment_ID, Dividend_ID, Account_Number, Amount, Time_stamp)
VALUES
    ('w1x2y3z4-a5b6-c7d8-e9f0-g1h2i3j4k5l6m7n8', 'd1e2f3g4-h5i6j7k8-l9m0n1o2p3q4r5s6t7u8', 101, 20.00, '2023-07-18 10:00:00'),
    ('x1y2z3a4-b5c6-d7e8-f9g0-h1i2j3k4l5m6n7o8', 'e1f2g3h4-i5j6k7l8-m9n0o1p2q3r4s5t6u7v8', 102, 10.00, '2023-07-18 11:30:00');


-- Insert Data into "Delete_Request" Table
INSERT INTO Delete_Request (Delete_Request_ID, Account_Number, Time_stamp)
VALUES
    ('y1z2a3b4-c5d6-e7f8-g9h0-i1j2k3l4m5n6o7p8', 101, '2023-07-18 12:00:00'),
    ('z1a2b3c4-d5e6-f7g8-h9i0j1k2l3m4n5o6p7q8', 102, '2023-07-18 13:30:00');


-- Insert Data into "Admin" Table

INSERT INTO Admin (Admin_ID, Name, Phone_Number, Email, password)
VALUES
    (1, 'Admin User', '+254773829563', 'admin@example.com', 'admin_pass'),
    (2, 'Super Admin', '+254736957362', 'superadmin@example.com', 'super_pass');
