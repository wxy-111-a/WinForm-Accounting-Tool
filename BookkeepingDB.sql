-- 创建数据库
CREATE DATABASE BookkeepingDB;
GO

-- 使用新创建的数据库
USE BookkeepingDB;
GO

-- 1. 创建用户信息表 (UserInfo)
CREATE TABLE UserInfo (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL -- 按照要求，使用明文密码
);
GO

-- 2. 创建账户信息表 (Accounts)
CREATE TABLE Accounts (
    AccountID INT IDENTITY(1,1) PRIMARY KEY,
    AccountName NVARCHAR(50) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0.00
);
GO

-- 3. 创建分类信息表 (Categories)
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL,
    Type NVARCHAR(10) NOT NULL CHECK (Type IN ('收入', '支出')) -- 约束类型只能是'收入'或'支出'
);
GO

-- 4. 创建交易记录表 (Transactions)
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

--- 插入测试数据 ---

-- 插入用户 (用户名: admin, 密码: 123456)
INSERT INTO UserInfo (UserName, Password) VALUES ('admin', '123456');
GO

-- 插入账户
INSERT INTO Accounts (AccountName, Balance) VALUES
(N'现金', 1500.00),
(N'支付宝', 5800.50),
(N'招商银行储蓄卡', 12000.00);
GO

-- 插入分类
-- 支出分类
INSERT INTO Categories (CategoryName, Type) VALUES
(N'餐饮美食', N'支出'),
(N'交通出行', N'支出'),
(N'生活日用', N'支出'),
(N'通讯网络', N'支出'),
(N'房租水电', N'支出');
-- 收入分类
INSERT INTO Categories (CategoryName, Type) VALUES
(N'工资收入', N'收入'),
(N'理财收益', N'收入'),
(N'其他收入', N'收入');
GO

-- 插入交易记录 (关联到用户ID为1的用户)
-- 支出记录
INSERT INTO Transactions (Amount, TransactionDate, Description, CategoryID, AccountID, UserID) VALUES
(35.00, GETDATE(), N'午餐：肯德基', 1, 2, 1), -- 餐饮美食, 支付宝
(150.00, DATEADD(day, -1, GETDATE()), N'购买生活用品', 3, 1, 1), -- 生活日用, 现金
(3000.00, DATEADD(day, -5, GETDATE()), N'交房租', 5, 3, 1); -- 房租水电, 银行卡
-- 收入记录
INSERT INTO Transactions (Amount, TransactionDate, Description, CategoryID, AccountID, UserID) VALUES
(8000.00, DATEADD(day, -4, GETDATE()), N'5月工资', 6, 3, 1), -- 工资收入, 银行卡
(200.00, DATEADD(day, -2, GETDATE()), N'基金收益', 7, 2, 1); -- 理财收益, 支付宝
GO

-- 更新账户余额 (这是一个简化的示例，实际项目中应通过事务处理)
-- 支付宝: 5800.50 - 35 + 200 = 5965.50
UPDATE Accounts SET Balance = 5965.50 WHERE AccountID = 2;
-- 现金: 1500 - 150 = 1350
UPDATE Accounts SET Balance = 1350.00 WHERE AccountID = 1;
-- 银行卡: 12000 - 3000 + 8000 = 17000
UPDATE Accounts SET Balance = 17000.00 WHERE AccountID = 3;
GO

PRINT '数据库和测试数据创建成功！';