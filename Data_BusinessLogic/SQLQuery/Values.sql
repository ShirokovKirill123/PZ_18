use EquipmentRepairSystem;

INSERT INTO Roles (nameOfRole) 
VALUES 
(N'Administrator'),
(N'Customer'),
(N'Master'),
(N'Manager');

INSERT INTO Specializations (nameOfSpecialization) 
VALUES
(N'Холодильники'),
(N'Стиральные машины'),
(N'Плиты'),
(N'Микроволновые печи'),
(N'Сушилки');

INSERT INTO Users (fio, phone, _login, _password, _type) 
VALUES
(N'Иван Иванов', N'123-456-7890', N'ivanov', N'password123', 2),  -- Клиент
(N'Дмитрий Петрович', N'123-654-7980', N'pentrovich', N'passwd123', 2),  -- Клиент
(N'Константин Михайлович', N'123-7890-456', N'mickailovich', N'123', 2),  -- Клиент
(N'Петр Петров', N'234-567-8901', N'petrov', N'12', 3),  -- Мастер
(N'Андрей Константинов', N'234-000-1111', N'konstantinov', N'and12', 3),  -- Мастер
(N'Ольга Сидорова', N'111-222-222', N'sidorova', N'23', 4),  -- Менеджер
(N'Даниил Хабибулин', N'333-111-222', N'hubabuba', N'333', 4),  -- Менеджер
(N'Алексей Александров', N'333-222-111', N'alexandrov', N'admin', 1); -- Администратор

INSERT INTO Customers (registrationDate, userID) 
VALUES
('2024-01-01', 1),  -- Клиент Иван Иванов
('2024-02-01', 2),  -- Клиент Дмитрий Петрович
('2024-03-01', 3);  -- Клиент Константин Михайлович

INSERT INTO Masters (specialization, userID) 
VALUES
(1, 4),  -- Мастер Петр Петров, специализация Холодильники
(2, 5);  -- Мастер Андрей Константинов, специализация Стиральные машины

INSERT INTO Managers (userID) 
VALUES
(6),  -- Менеджер Ольга Сидорова
(7);  -- Менеджер Даниил Хабибулин

INSERT INTO RepairParts (partName, price, stockQuantity) 
VALUES
(N'Термостат для холодильника', 1500, 10),
(N'Насос для стиральной машины', 1200, 5),
(N'Платформа для плиты', 800, 8);

INSERT INTO Requests (startDate, completionDate, typeOfRequest, technicType, technicModel, problemDescription, _status, sparePartID, customerID, masterID, managerID) 
VALUES
('2024-03-01', '2024-03-05', N'Ремонт холодильника', N'Холодильник', N'Samsung RS68N8941B1', N'Не охлаждает', N'В процессе', 1, 1, 1, 1),  
('2024-03-02', '2024-03-06', N'Ремонт стиральной машины', N'Стиральная машина', N'Bosch WAW28540BY', N'Не отжимает', N'Завершено', 2, 2, 1, 1),   
('2024-03-03', '2024-03-07', N'Ремонт плиты', N'Плита', N'Gorenje EC5111W', N'Не включается', N'В процессе', 3, 3, 2, 2);  

