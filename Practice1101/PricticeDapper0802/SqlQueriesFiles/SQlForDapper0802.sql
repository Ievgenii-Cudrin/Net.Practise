Use DapperPractice

CREATE TABLE Users(
  Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
  Name nvarchar(30),
  Surname nvarchar(30),
  Email nvarchar(30),
  DateOfBirth nvarchar(30)
)

CREATE TABLE Mails(
Id int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Mails PRIMARY KEY,
Object nvarchar(1000),
);

CREATE TABLE UserMails(
UserId int NOT NULL,
MailId int NOT NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (MailId) REFERENCES Mails(Id) ON DELETE CASCADE,
UNIQUE (UserId, MailId)
);


Drop Table UserMails

Drop Table Users

Drop Table Mails



Truncate Table Users
Truncate Table Mails
Truncate Table UserMails


Select * from Users

Select * from Mails

select * from UserMails 