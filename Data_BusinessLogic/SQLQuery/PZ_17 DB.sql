CREATE DATABASE EquipmentRepairSystem;
use EquipmentRepairSystem;

create table Roles(
	roleID int IDENTITY(1,1)  PRIMARY KEY,
	nameOfRole NVARCHAR(255) NOT NULL
);

create table Specializations(
	specializationID int IDENTITY(1,1)  PRIMARY KEY,
	nameOfSpecialization NVARCHAR(255) NOT NULL
);

CREATE TABLE Users (   
	userID int IDENTITY(1,1)  PRIMARY KEY,
    fio NVARCHAR(255) NOT NULL,  
	phone NVARCHAR(255),
    _login NVARCHAR(255) NOT NULL UNIQUE,   
	_password NVARCHAR(255) NOT NULL,
    _type int NOT NULL,
	FOREIGN KEY (_type) REFERENCES Roles(roleID)
);

CREATE TABLE Customers ( 
	customerID INT  IDENTITY(1,1) PRIMARY KEY,
    registrationDate DATE NOT NULL,    
	userID INT NOT NULL,
    FOREIGN KEY (userID) REFERENCES Users(userID)
);

CREATE TABLE Masters ( 
	masterID INT  IDENTITY(1,1) PRIMARY KEY,
    specialization INT NOT NULL,   
	userID INT NOT NULL,
    FOREIGN KEY (userID) REFERENCES Users(userID),
	FOREIGN KEY (specialization) REFERENCES Specializations(specializationID)
);

CREATE TABLE Managers (
    managerID INT  IDENTITY(1,1) PRIMARY KEY,
    userID INT NOT NULL,   
	FOREIGN KEY (userID) REFERENCES Users(userID)
);

CREATE TABLE RepairParts (
    sparePartID INT  IDENTITY(1,1) PRIMARY KEY,  
	partName NVARCHAR(255) NOT NULL,
    price DECIMAL(19, 0) NOT NULL, 
	stockQuantity INT NOT NULL
);

CREATE TABLE Requests (
    requestID INT  IDENTITY(1,1) PRIMARY KEY,    
	startDate DATE NOT NULL,
	completionDate DATE,
    typeOfRequest NVARCHAR(255) NOT NULL,   
	technicType NVARCHAR(255) NOT NULL,
    technicModel NVARCHAR(255) NOT NULL, 
	problemDescription NVARCHAR(255),
    _status NVARCHAR(255) NOT NULL,    
    sparePartID INT,    
	customerID INT NOT NULL,
    masterID INT NOT NULL,    
	managerID INT NOT NULL,
    FOREIGN KEY (sparePartID) REFERENCES RepairParts(sparePartID),    
	FOREIGN KEY (customerID) REFERENCES Customers(customerID),
    FOREIGN KEY (masterID) REFERENCES Masters(masterID),
	FOREIGN KEY (managerID) REFERENCES Managers(managerID)
);