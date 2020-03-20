CREATE DATABASE TakeawayDb

USE TakeawayDb

--1.��Ʒ��
CREATE TABLE MenuInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(1),--Ĭ��Ϊ1
Remark VARCHAR(20),
BusinessInfo INT not null
)
--2.��ˮ��
CREATE TABLE DrinkInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(2),--Ĭ��Ϊ2
Remark VARCHAR(20),
BusinessInfo INT not null
)

--3.�ײͱ�
CREATE TABLE PackageInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(3),--Ĭ��Ϊ3
Remark VARCHAR(20),
BusinessInfo INT not null
)


--4.�ײͲ�Ʒ����
CREATE TABLE MenuPackageInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
PackageId  INT,
TypeId INT,
DetailsId INT,--�����Id,
Count Int
)

--5.������
CREATE TABLE SalesInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeId INT,
DetailsId INT,--�����Id,
Sales INT
)

--6.ʡ
CREATE TABLE ProvinceInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20)
)

--7.��
CREATE TABLE CityInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
ProvinceId INT NOT NULL
)

--8.��
CREATE TABLE Arealnfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
CityId INT NOT NULL
)

--9.���
CREATE TABLE Activity
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Content VARCHAR(200)
)

--10.��ζ��
CREATE TABLE TasteInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20)
)

--11.�û���Ϣ��
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

--12.�û���ַ��
CREATE TABLE AddressInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
ProvinceId INT,
CityId INT,
Area INT,
Content VARCHAR(200)
)

--13.���ﳵ
CREATE TABLE CartInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
UserId INT,
BusinessInfo INT not null
)

--14.���ﳵ�����
CREATE TABLE CartDetails
(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeId INT,
DetailsId INT,--�����Id,
Count INT,
TasteId INT,
ToPrice DECIMAL(18,2)
)

--15.������
CREATE TABLE OrderInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
UserId int,
CreateTime DATETIME,
AddressId INT,
DataState INT,
Freight INT,--�˷�
PackagingFee INT, --��װ��
TablewareCount INT,--�;�����
ActivityId INT,--�Id
TotalPrice decimal(18,2),--�ܼ�
Consignee VARCHAR(50),--�ջ���
BusinessInfo INT NOT NULL--�̼�ID
)

--16.���������
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
--17.�̼ұ�
CREATE TABLE BusinessInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Img varchar(200),
Name varchar(50),
PhoneNumber varchar(50),
ContactPerson VARCHAR(50),
Merchataddress varchar(100)
)
