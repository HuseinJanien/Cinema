INSERT INTO Halls (Name) VALUES
('Hall_1'),
('Hall_2')
GO

INSERT INTO Plases(HallId, Row) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),

(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(2, 10)
GO

INSERT INTO Plases(HallId, Row) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),

(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(2, 10)
GO

INSERT INTO Category(Name) VALUES
('Name_1'),
('Name_2'),
('Name_3'),
('Name_4'),
('Name_5')
GO

INSERT INTO AgeRestriction(Age) VALUES
(3),
(6),
(12),
(16),
(18)
GO

INSERT INTO Films(Name, CategoryId, AgeId) VALUES
('F_Name1', 1, 1),
('F_Name2', 2, 2),
('F_Name3', 3, 3),
('F_Name4', 4, 4),
('F_Name5', 5, 5)
GO

INSERT INTO Session (HallId, Date, Time, FilmId)VALUES
(1, '2020-03-03', '18:40', 4),
(2, '2020-03-03', '16:40', 5),
(1, '2020-03-03', '15:40', 6),
(2, '2020-03-03', '18:40', 7),
(1, '2020-03-03', '20:40', 8)
GO