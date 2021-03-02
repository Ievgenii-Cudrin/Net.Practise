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
(N'������ �.�.', 1),
(N'������ �.�.', 2),
(N'������� �.�.', 3),
(N'������� �.�.', 4),
(N'���������� �.�.', 1),
(N'������ �.�.', 2),
(N'������ �.�.', 3),
(N'������� �.�.', 4)

INSERT Roles(RoleName) VALUES
(N'��������'),
(N'�����������'),
(N'�����������'),
(N'������� �����������')
