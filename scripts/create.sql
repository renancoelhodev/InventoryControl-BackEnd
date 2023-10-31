CREATE DATABASE stock;

CREATE TABLE Category (
    CategoryId int PRIMARY KEY,
    CategoryName varchar(30)
);

CREATE TABLE Product (
    ProductId int PRIMARY KEY,
    ProductName varchar(30),
    CategoryId int,
    FOREIGN KEY(CategoryId) REFERENCES Category(CategoryId)
);

