use EquipmentRepairSystem;

INSERT INTO Roles (nameOfRole) 
VALUES 
(N'Administrator'),
(N'Customer'),
(N'Master'),
(N'Manager');

INSERT INTO Specializations (nameOfSpecialization) 
VALUES
(N'������������'),
(N'���������� ������'),
(N'�����'),
(N'������������� ����'),
(N'�������');

INSERT INTO Users (fio, phone, _login, _password, _type) 
VALUES
(N'���� ������', N'123-456-7890', N'ivanov', N'password123', 2),  -- ������
(N'������� ��������', N'123-654-7980', N'pentrovich', N'passwd123', 2),  -- ������
(N'���������� ����������', N'123-7890-456', N'mickailovich', N'123', 2),  -- ������
(N'���� ������', N'234-567-8901', N'petrov', N'12', 3),  -- ������
(N'������ ������������', N'234-000-1111', N'konstantinov', N'and12', 3),  -- ������
(N'����� ��������', N'111-222-222', N'sidorova', N'23', 4),  -- ��������
(N'������ ���������', N'333-111-222', N'hubabuba', N'333', 4),  -- ��������
(N'������� �����������', N'333-222-111', N'alexandrov', N'admin', 1); -- �������������

INSERT INTO Customers (registrationDate, userID) 
VALUES
('2024-01-01', 1),  -- ������ ���� ������
('2024-02-01', 2),  -- ������ ������� ��������
('2024-03-01', 3);  -- ������ ���������� ����������

INSERT INTO Masters (specialization, userID) 
VALUES
(1, 4),  -- ������ ���� ������, ������������� ������������
(2, 5);  -- ������ ������ ������������, ������������� ���������� ������

INSERT INTO Managers (userID) 
VALUES
(6),  -- �������� ����� ��������
(7);  -- �������� ������ ���������

INSERT INTO RepairParts (partName, price, stockQuantity) 
VALUES
(N'��������� ��� ������������', 1500, 10),
(N'����� ��� ���������� ������', 1200, 5),
(N'��������� ��� �����', 800, 8);

INSERT INTO Requests (startDate, completionDate, typeOfRequest, technicType, technicModel, problemDescription, _status, sparePartID, customerID, masterID, managerID) 
VALUES
('2024-03-01', '2024-03-05', N'������ ������������', N'�����������', N'Samsung RS68N8941B1', N'�� ���������', N'� ��������', 1, 1, 1, 1),  
('2024-03-02', '2024-03-06', N'������ ���������� ������', N'���������� ������', N'Bosch WAW28540BY', N'�� ��������', N'���������', 2, 2, 1, 1),   
('2024-03-03', '2024-03-07', N'������ �����', N'�����', N'Gorenje EC5111W', N'�� ����������', N'� ��������', 3, 3, 2, 2);  

