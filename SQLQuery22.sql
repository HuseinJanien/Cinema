INSERT INTO Films(Name, CategoryId, AgeId) VALUES
('F_Name1', 1, 1),
('F_Name2', 2, 2),
('F_Name3', 3, 3),
('F_Name4', 4, 4),
('F_Name5', 5, 5)
GO

INSERT INTO Session (HallId, DateTime, FilmId)VALUES
(1, '2020-03-03 18:40', 1),
(2, '2020-03-03 16:40', 2),
(1, '2020-03-03 15:40', 3),
(2, '2020-03-03 18:40', 4),
(1, '2020-03-03 20:40', 5)
GO