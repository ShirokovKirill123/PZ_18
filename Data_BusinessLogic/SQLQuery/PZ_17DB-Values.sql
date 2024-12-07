USE PZ17_117
INSERT INTO [UserType] ([Role]) 
VALUES 
(N'Администратор'),
(N'Мастер'),
(N'Клиент');
INSERT INTO [ReqStatusType] ([Name]) 
VALUES 
(N'Ожидает'),
(N'В процессе'),
(N'Завершено');
INSERT INTO [HomeTechType] ([Name]) 
VALUES 
(N'Телевизор'),
(N'Холодильник'),
(N'Стиральная машина');
INSERT INTO [HomeTechModel] ([Name]) 
VALUES 
(N'LG OLED55CX6LA'),
(N'Samsung QLED Q80T'),
(N'Bosch KGV36VWEAS'),
(N'Samsung RB37J5000SA');
INSERT INTO [RepairParts] ([Name], [Price]) 
VALUES 
(N'Матрица для телевизора', 15000),
(N'Термостат для холодильника', 3000),
(N'Помпа для стиральной машины', 2500),
(N'Ремень для стиральной машины', 800);
INSERT INTO [Users] ([Login], [Password], [Phone], [Name], [S_Name], [L_Name], [userType]) 
VALUES 
(N'admin', N'admin123', 79001234567, N'Иван', N'Иванов', N'Иван', 1),
(N'master1', N'master123', 79007654321, N'Петр', N'Петров', N'Петр', 2),
(N'client1', N'client123', 79009876543, N'Сергей', N'Сергеев', N'Сергей', 3);
INSERT INTO [Requests] ([startDate], [problemDescryption], [completionDate], [homeTechType], [homeTechModel], [repairParts], [clientID], [masterID], [status]) 
VALUES 
('2024-12-01 10:00:00', N'Не работает экран телевизора', NULL, 1, 1, 1, 3, 2, 1),
('2024-12-02 14:00:00', N'Холодильник не охлаждает', NULL, 2, 3, 2, 3, 2, 2),
('2024-12-03 09:00:00', N'Не отжимает стиральная машина', NULL, 3, 4, 3, 3, 2, 1);
INSERT INTO [Comments] ([message], [requestID], [masterID]) 
VALUES 
(N'Принял заявку, ожидаю детали', 1, 2),
(N'Заменил термостат, работает нормально', 2, 2),
(N'Проблема решена, заменен ремень', 3, 2);
