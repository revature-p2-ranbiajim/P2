CREATE DATABASE UserServiceDb;
GO
USE UserServiceDb;

 
CREATE TABLE CLIENT
(
  ClientId int not null primary key identity(1,1),
  Username int not null,
  password varchar (50) not null
);
GO