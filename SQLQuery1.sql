create database news

use news

go
create table users(
userId int primary key identity(1,1),
userName nvarchar(50),
email nvarchar(50),
[password] nvarchar(50),
photo nvarchar(max),
constraint c1 unique (email)

)

go 
create table category(
categoryId int primary key identity(1,1),
categoryName nvarchar(50)
)


go 
create table news(
newsId int primary key identity(1,1),
title nvarchar(100),
brief nvarchar(max),
[description] nvarchar(max),
[datetime] datetime,
photo nvarchar(max),
userId int ,
categoryId int,

constraint c2 foreign key(userId) references users (userId) on delete set null on update cascade,
constraint c3 foreign key(categoryId) references category (categoryId) on delete set null on update cascade

)

