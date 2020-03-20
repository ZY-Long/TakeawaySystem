CREATE DATABASE TakeawayDb

USE TakeawayDb

--1.菜品表
CREATE TABLE MenuInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(1),--默认为1
Remark VARCHAR(20),
BusinessInfo INT not null
)
--2.酒水表
CREATE TABLE DrinkInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(2),--默认为2
Remark VARCHAR(20),
BusinessInfo INT not null
)

--3.套餐表
CREATE TABLE PackageInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(3),--默认为3
Remark VARCHAR(20),
BusinessInfo INT not null
)


--4.套餐菜品关联
CREATE TABLE MenuPackageInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
PackageId  INT,
TypeId INT,
DetailsId INT,--具体的Id,
Count Int
)

--5.销量表
CREATE TABLE SalesInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeId INT,
DetailsId INT,--具体的Id,
Sales INT
)

--6.省
CREATE TABLE ProvinceInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20)
)

--7.市
CREATE TABLE CityInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
ProvinceId INT NOT NULL
)

--8.区
CREATE TABLE Arealnfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
CityId INT NOT NULL
)

--9.活动表
CREATE TABLE Activity
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Content VARCHAR(200)
)

--10.口味表
CREATE TABLE TasteInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20)
)

--11.用户信息表
CREATE TABLE UserInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
NickName VARCHAR(20),
Img VARCHAR(200),
PhoneNumber VARCHAR(40),
PassWord VARCHAR(50),
SaIt VARCHAR(200),
Email VARCHAR(50),
RealName varchar(50)
)
drop table UserInfo

--12.用户地址表
CREATE TABLE AddressInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
ProvinceId INT,
CityId INT,
Area INT,
Content VARCHAR(200)
)

--13.购物车
CREATE TABLE CartInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
UserId INT,
BusinessInfo INT not null
)

--14.购物车详情表
CREATE TABLE CartDetails
(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeId INT,
DetailsId INT,--具体的Id,
Count INT,
TasteId INT,
ToPrice DECIMAL(18,2)
)

--15.订单表
CREATE TABLE OrderInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
UserId int,
CreateTime DATETIME,
AddressId INT,
DataState INT,
Freight INT,--运费
PackagingFee INT, --包装费
TablewareCount INT,--餐具数量
ActivityId INT,--活动Id
TotalPrice decimal(18,2),--总价
Consignee VARCHAR(50),--收货人
BusinessInfo INT NOT NULL--商家ID
)

--16.订单详情表
CREATE TABLE OrderDetails
(
Id INT PRIMARY KEY IDENTITY(1,1),
OrderId INT,
TypeId INT,
DetailsId INT,
Count INT,
TasteId INT,
Content VARCHAR(200)
)
--17.商家表
CREATE TABLE BusinessInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Img varchar(200),
Name varchar(50),
PhoneNumber varchar(50),
ContactPerson VARCHAR(50),
Merchataddress varchar(100)
)
