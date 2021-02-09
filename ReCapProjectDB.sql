CREATE TABLE Colors(
	Id int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
)

CREATE TABLE Brands(
	Id int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50),
)

CREATE TABLE Cars(
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(50),
	BrandId int,
	ColorId int,
	DailyPrice decimal,
	ModelYear int,
	Description nvarchar(50),
	FOREIGN KEY (ColorId) REFERENCES Colors(Id),
	FOREIGN KEY (BrandId) REFERENCES Brands(Id)
)
