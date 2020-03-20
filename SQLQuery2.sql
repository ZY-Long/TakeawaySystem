CREATE DATABASE TakeOutDB

USE TakeOutDB

--1.��Ʒ��
CREATE TABLE MenuInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Img VARCHAR(200),
Price DECIMAL(18,2),
TypeId INT DEFAULT(1),--Ĭ��Ϊ1�ǲ�Ʒ  Ĭ��Ϊ2�Ǿ�ˮ  Ĭ��Ϊ3���ײ�
Remark VARCHAR(20),
BusinessInfo INT not null,
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)


--4.�ײͲ�Ʒ����
CREATE TABLE MenuPackageInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
PackageId  INT,
TypeId INT,
DetailsId INT,--�����Id,
Count Int,
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)

--5.������
CREATE TABLE SalesInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeId INT,
DetailsId INT,--�����Id,
Sales INT,
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)

--6.ʡ
CREATE TABLE ProvinceInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),

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
Content VARCHAR(200),
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)

--10.��ζ��
CREATE TABLE TasteInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(20),
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
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
RealName varchar(50),
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)

--12.�û���ַ��
CREATE TABLE AddressInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
ProvinceId INT,
CityId INT,
Area INT,
Content VARCHAR(200),
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)

--13.���ﳵ
CREATE TABLE CartInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
UserId INT,
BusinessInfo INT not null,
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)

--14.���ﳵ�����
CREATE TABLE CartDetails
(
Id INT PRIMARY KEY IDENTITY(1,1),
TypeId INT,
DetailsId INT,--�����Id,
Count INT,
TasteId INT,
ToPrice DECIMAL(18,2),
CartId int,
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)
drop table CartDetails

select m.Name ��Ʒ����,m.Img ��ƷͼƬ,m.Price ��Ʒ��Ǯ,d.Name ��ˮ����,d.Img ��ˮͼƬ,d.Price ��ˮ��Ǯ,t.Name ��ζ,p.Name �ײ�����,p.Img �ײ�ͼƬ,p.Price �ײͼ�Ǯ from CartDetails as c
join MenuInfo as m on c.Id=m.TypeId
join DrinkInfo as d on c.Id=d.TypeId
join TasteInfo as t on t.Id=c.TasteId
join PackageInfo as p on p.TypeId=c.Id
select m.Name,m.Img,m.Price,d.Name,d.Img,d.Price,t.Name,p.Name,p.Img,p.Price from CartDetails as c
join MenuInfo as m on c.Id=m.TypeId
join DrinkInfo as d on c.Id=d.TypeId
join TasteInfo as t on t.Id=c.TasteId
join PackageInfo as p on p.TypeId=c.Id

insert into CartDetails (TypeId,DetailsId,Count,TasteId,ToPrice) values()
--15.������
CREATE TABLE OrderInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
UserId int,
AddressId INT,
DataState INT,
Freight INT,--�˷�
PackagingFee INT, --��װ��
TablewareCount INT,--�;�����
ActivityId INT,--�Id
TotalPrice decimal(18,2),--�ܼ�
Consignee VARCHAR(50),--�ջ���
BusinessInfo INT NOT NULL,--�̼�ID
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
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
Content VARCHAR(200),
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)
--17.�̼ұ�
CREATE TABLE BusinessInfo
(
Id INT PRIMARY KEY IDENTITY(1,1),
Img varchar(200),
Name varchar(50),
PhoneNumber varchar(50),
ContactPerson VARCHAR(50),
Merchataddress varchar(100),
Sates int DEFAULT (1),
CreateTime datetime default(GETDATE()),
UpdateTime datetime default(GETDATE()),
CreaterId int DEFAULT(1),
UpdaterId int DEFAULT(1)
)