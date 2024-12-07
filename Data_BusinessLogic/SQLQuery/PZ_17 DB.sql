--CREATE DATABASE PZ17_117
USE PZ17_117
CREATE TABLE [UserType](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Role] NVARCHAR(25)
);
CREATE TABLE [ReqStatusType](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(75)
);
CREATE TABLE [HomeTechType](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(75)
);
CREATE TABLE [HomeTechModel](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(75)
);
CREATE TABLE [RepairParts](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(75),
	[Price] INT
);
CREATE TABLE [Users](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Login] NVARCHAR(125) UNIQUE,
	[Password] NVARCHAR(50),
	[Phone] BIGINT,
	[Name] NVARCHAR(256),
	[S_Name] NVARCHAR(256),
	[L_Name] NVARCHAR(256),
	[userType] INT FOREIGN KEY REFERENCES [UserType]([ID])
);
CREATE TABLE [Requests](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[startDate] DATETIME,
	[problemDescryption] NVARCHAR(2048),
	[completionDate] DATETIME,
	[homeTechType] INT FOREIGN KEY REFERENCES [HomeTechType]([ID]),
	[homeTechModel] INT FOREIGN KEY REFERENCES [HomeTechModel]([ID]),
	[repairParts] INT FOREIGN KEY REFERENCES [RepairParts]([ID]),
	[clientID] INT FOREIGN KEY REFERENCES [Users]([ID]),
	[masterID] INT FOREIGN KEY REFERENCES [Users]([ID]),
	[status] INT FOREIGN KEY REFERENCES [ReqStatusType]([ID])
);
CREATE TABLE [Comments](
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[message] NVARCHAR(2048),
	[requestID] INT FOREIGN KEY REFERENCES [Requests]([ID]),
	[masterID] INT FOREIGN KEY REFERENCES [Users]([ID])
);