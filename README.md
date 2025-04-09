# ShopProductManagerApp
A training sample application that includes a data table, simple local authorization, and registration functionality.

## Database Initialization

Follow the steps below to set up the database for the application:

```sql
-- Create the database
CREATE DATABASE ShopDB;

-- Use the created database
USE ShopDB;

-- Create the 'Rol' table for roles
CREATE TABLE Rol (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);

-- Create the 'Users' table with auto-increment
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Login NVARCHAR(50) NOT NULL,
    Pass NVARCHAR(50) NOT NULL,
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES Rol(RoleID)
);

-- Create the 'Products' table with auto-increment
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Description NVARCHAR(100)
);

-- Insert roles into the 'Rol' table
INSERT INTO Rol (RoleID, RoleName) VALUES
(1, 'Admin'),
(2, 'Manager');
```
