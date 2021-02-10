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
(N'Иванов И.И.', 1),
(N'Петров П.П.', 2),
(N'Сидоров С.С.', 3),
(N'Андреев А.А.', 4),
(N'Владимиров И.И.', 1),
(N'Игорев П.П.', 2),
(N'Павлов С.С.', 3),
(N'Сергеев А.А.', 4)

INSERT Roles(RoleName) VALUES
(N'Директор'),
(N'Программист'),
(N'Бухгалтерия'),
(N'Старший программист')
