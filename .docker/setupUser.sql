CREATE DATABASE UserServiceDb;
GO
USE UserServiceDb;

 
CREATE TABLE CLIENT
(
  ClientId int not null primary key identity(1,1),
  Username varchar (50) not null,
  Password varchar (50) not null,
  FirstName varchar (50) not null,
  LastName varchar (50) not null,
  EmailAddress varchar (50) not null
);
GO