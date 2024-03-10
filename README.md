# Table of Content

---

# Overview

The BankBank mobile banking app aims to provide customers with convenient and secure access to their banking services through their smartphones. It will offer essential features such as account management, fund transfers, bill payments, transaction history, and alerts. The app will be developed using SQL Server for database management, ensuring robustness, scalability, and data security.

# Key Features

- **Account Management:** Users can view account balances, transaction history, and manage their accounts.
- **Fund Transfers:** Facilitate transfers between the user's accounts, to other accounts within the bank, or external accounts.
- **Bill Payments:** Allow users to pay bills directly from their accounts, schedule recurring payments, and view payment history.
- TBA…

# Database Design

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/7bb450e2-b62c-48f5-91e8-020c36a328d9/5e3429ba-9dde-4ace-a2d2-c707983955e4/Untitled.png)

## Entities

### Users

- UserID (PK) (INT)
- Username (VARCHAR(50), UNIQUE)
- Password (VARCHAR(180) HASHED)
- Email (VARCHAR(255), UNIQUE)
- Phone (VARCHAR(20) UNIQUE)
- DateOfBirth (DATE)
- RegistrationDate (DATETIME2)
- LastLoginDate (DATETIME2)

### Accounts

- AccountID (PK) (INT)
- UserID (FK) → Users.UserID (INT)
- AccountNumber (VARCHAR(20) UNIQUE)
- Balance (MONEY)
- AccountType (FK) → Users.AccountTypes
- InterestRate (DECIMAL(5,2)) (applicable for savings accounts)
- CreditLimit (DECIMAL(18,2)) (applicable for credit accounts)
- Currency (VARCHAR(3)) - ISO currency code
- Status (Active / Inactive) (VARCHAR(20))

### Transactions

- TransactionID (PK) (INT)
- SourceAccountID (FK) → Accounts.AccountID (INT)
- ReceiverAccountID (FK) → Accounts.AccountID (INT)
- BillID
- Amount (DECIMAL(18, 2))
- Description (VARCHAR(255))
- TransactionType (FK) → Transactions.TransactionCategories
- TransactionDate (DATETIME2)
- Status (e.g., Completed, Pending, Failed) (VARCHAR(20))

### Billers

- BillerID (PK) (INT)
- BillerName (VARCHAR(100))
- BillerAccountNumber (VARCHAR(20) UNIQUE)

### Bills

- BillID (PK) (INT)
- UserID (FK) → Users.UserID (INT)
- BillerID (FK) → Billers.BillerID (INT)
- Amount (DECIMAL(18, 2))
- DueDate (DATETIME2)
- Status (e.g., Paid, Unpaid)  (VARCHAR(20))

## Relationships

1. **One-to-Many Relationship: Users to Accounts**
    - Each user can have multiple accounts (e.g., checking, savings, credit card).
    - Each account belongs to only one user.
2. **One-to-Many Relationship: Users to Transactions**
    - Each user can perform multiple transactions.
    - Each transaction involves two accounts: sender and receiver.
3. **One-to-Many Relationship: Users to Bills**
    - Each user can have multiple bills to pay.
    - Each bill is associated with only one user.
4. **Many-to-One Relationship: Bills to Billers** 
    - Each bill is associated with only one biller.
    - The `BillerID` in the `Bills` table serves as a foreign key referencing the `BillerID` in the `Billers` table.
    - This relationship allows each bill to be associated with a specific biller.

## Indexing and Constraints

1. Primary Key Constraints:
    - UserID in Users table
    - AccountID in Accounts table
    - TransactionID in Transactions table
    - BillID in Bills table
2. Foreign Key Constraints:
    - UserID in Accounts table references UserID in Users table
    - SenderAccountID and ReceiverAccountID in Transactions table reference AccountID in Accounts table
    - UserID in Bills table references UserID in Users table
3. Indexes:
    - Indexes on UserID in Users table for faster retrieval of user-related data.
    - Indexes on AccountNumber for quick access to account details.
    - Indexes on TransactionDate for efficient querying of transaction history.

# Additional Considerations

- Implement appropriate data validation and constraints to ensure data integrity and security.
- Use stored procedures or parameterized queries to prevent SQL injection attacks.
- Regularly backup the database to prevent data loss.
- Consider implementing data encryption for sensitive information such as passwords and transaction details.

This database design provides a foundation for managing user accounts, transactions, and bill payments in the mobile banking app. Depending on specific requirements and future enhancements, the database schema can be further optimized and expanded.
