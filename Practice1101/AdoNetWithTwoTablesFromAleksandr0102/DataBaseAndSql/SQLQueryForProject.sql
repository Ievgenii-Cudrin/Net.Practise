drop table Users

drop table Roles

CREATE TABLE Roles(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Departments PRIMARY KEY,
  RoleName nvarchar(30) NOT NULL
)

CREATE TABLE Users(
  ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Positions PRIMARY KEY,
  UserName nvarchar(30) NOT NULL,
  RolesId int,
  CONSTRAINT FK_Users_RolesID FOREIGN KEY(RolesId) REFERENCES Roles(ID)
ON DELETE SET NULL
)


INSERT Users(UserName,RolesId) VALUES
('Иванов И.И.', 1),
('Петров П.П.', 2),
('Сидоров С.С.', 3),
('Андреев А.А.', 4),
('Владимиров И.И.', 1),
('Игорев П.П.', 2),
('Павлов С.С.', 3),
('Сергеев А.А.', 4)

INSERT Roles(RoleName) VALUES
('Директор'),
('Программист'),
('Бухгалтерия'),
('Старший программист')
