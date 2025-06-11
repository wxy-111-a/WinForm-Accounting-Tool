-- �������ݿ�
CREATE DATABASE BookkeepingDB;
GO

-- ʹ���´��������ݿ�
USE BookkeepingDB;
GO

-- 1. �����û���Ϣ�� (UserInfo)
CREATE TABLE UserInfo (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL -- ����Ҫ��ʹ����������
);
GO

-- 2. �����˻���Ϣ�� (Accounts)
CREATE TABLE Accounts (
    AccountID INT IDENTITY(1,1) PRIMARY KEY,
    AccountName NVARCHAR(50) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0.00
);
GO

-- 3. ����������Ϣ�� (Categories)
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL,
    Type NVARCHAR(10) NOT NULL CHECK (Type IN ('����', '֧��')) -- Լ������ֻ����'����'��'֧��'
);
GO

-- 4. �������׼�¼�� (Transactions)
CREATE TABLE Transactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    Amount DECIMAL(18, 2) NOT NULL,
    TransactionDate DATE NOT NULL,
    Description NVARCHAR(200),
    CategoryID INT NOT NULL,
    AccountID INT NOT NULL,
    UserID INT NOT NULL,
    CONSTRAINT FK_Transactions_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_Transactions_Accounts FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
    CONSTRAINT FK_Transactions_UserInfo FOREIGN KEY (UserID) REFERENCES UserInfo(UserID)
);
GO

--- ����������� ---

-- �����û� (�û���: admin, ����: 123456)
INSERT INTO UserInfo (UserName, Password) VALUES ('admin', '123456');
GO

-- �����˻�
INSERT INTO Accounts (AccountName, Balance) VALUES
(N'�ֽ�', 1500.00),
(N'֧����', 5800.50),
(N'�������д��', 12000.00);
GO

-- �������
-- ֧������
INSERT INTO Categories (CategoryName, Type) VALUES
(N'������ʳ', N'֧��'),
(N'��ͨ����', N'֧��'),
(N'��������', N'֧��'),
(N'ͨѶ����', N'֧��'),
(N'����ˮ��', N'֧��');
-- �������
INSERT INTO Categories (CategoryName, Type) VALUES
(N'��������', N'����'),
(N'�������', N'����'),
(N'��������', N'����');
GO

-- ���뽻�׼�¼ (�������û�IDΪ1���û�)
-- ֧����¼
INSERT INTO Transactions (Amount, TransactionDate, Description, CategoryID, AccountID, UserID) VALUES
(35.00, GETDATE(), N'��ͣ��ϵ»�', 1, 2, 1), -- ������ʳ, ֧����
(150.00, DATEADD(day, -1, GETDATE()), N'����������Ʒ', 3, 1, 1), -- ��������, �ֽ�
(3000.00, DATEADD(day, -5, GETDATE()), N'������', 5, 3, 1); -- ����ˮ��, ���п�
-- �����¼
INSERT INTO Transactions (Amount, TransactionDate, Description, CategoryID, AccountID, UserID) VALUES
(8000.00, DATEADD(day, -4, GETDATE()), N'5�¹���', 6, 3, 1), -- ��������, ���п�
(200.00, DATEADD(day, -2, GETDATE()), N'��������', 7, 2, 1); -- �������, ֧����
GO

-- �����˻���� (����һ���򻯵�ʾ����ʵ����Ŀ��Ӧͨ��������)
-- ֧����: 5800.50 - 35 + 200 = 5965.50
UPDATE Accounts SET Balance = 5965.50 WHERE AccountID = 2;
-- �ֽ�: 1500 - 150 = 1350
UPDATE Accounts SET Balance = 1350.00 WHERE AccountID = 1;
-- ���п�: 12000 - 3000 + 8000 = 17000
UPDATE Accounts SET Balance = 17000.00 WHERE AccountID = 3;
GO

PRINT '���ݿ�Ͳ������ݴ����ɹ���';