--01. Create Database
CREATE DATABASE	Minions

--02. Create Tables
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50)
)

--03. Alter Minions Table
	--Option 1
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

	--Option 2
ALTER TABLE Minions
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id)

--04. Insert Records
INSERT INTO Towns (Id, [Name])
VALUES(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId)
VALUES(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

--05. Truncate Table Minions
TRUNCATE TABLE Minions

--06. Drop All Tables
DROP TABLE Minions
DROP TABLE Towns

--07. Create Table People
	--Option 1
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
		CHECK(Gender in('m', 'f')),
	Birthdate DATETIME2 NOT NULL,
	Biography VARCHAR(MAX)
)

INSERT INTO People ([Name], Gender, Birthdate)
VALUES('Pesho', 'm', '1998-05-05'),
	('Radka', 'f', '1994-01-01'),
	('Ivan', 'm', '1998-12-08'),
	('Dragan', 'm', '1993-09-11'),
	('Petkan', 'm', '1996-11-06')

	--Option 2
CREATE TABLE People
(
	Id INT IDENTITY NOT NULL,
	[Name] NVARCHAR(200),
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
		CHECK(Gender in('m', 'f')),
	Birthdate DATETIME2 NOT NULL,
	Biography VARCHAR(MAX)
)

ALTER TABLE People
ADD CONSTRAINT PK_People
PRIMARY KEY(Id)

INSERT INTO People ([Name], Gender, Birthdate)
VALUES('Pesho', 'm', '1998-05-05'),
	('Radka', 'f', '1994-01-01'),
	('Ivan', 'm', '1998-12-08'),
	('Dragan', 'm', '1993-09-11'),
	('Petkan', 'm', '1996-11-06')

--08. 08. Create Table Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password])
VALUES('Pe6ho34', 'm2r34'),
	('Radka12', 'f44321c'),
	('Ivan4o', 'diud2y87y'),
	('Dragan40', 'sijiot'),
	('5kan', '353321kkjdss')

--09. Change Primary Key
	--Delete primary key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC077E35E483

	--Set new composite primary key
ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id, Username)

--10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordIsAtleastFiveSymbols
	CHECK(LEN([Password]) >= 5)

--11. Set Default Value of a Field
UPDATE Users
	SET LastLoginTime = CURRENT_TIMESTAMP

--12. Set Unique Field
	--Delete primary key
ALTER TABLE Users
DROP CONSTRAINT PK_UsersTable

	--Set new Id primary key
ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY(Id)

	--Set new check Username constraint 
ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameIsAtleast3Symbols
	CHECK(LEN(Username) >= 3)

	--Incorect Username
INSERT INTO Users (Username, [Password])
VALUES('Pe4t32', 'm2r34')

--13. Movies Database
CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Directors (DirectorName)
VALUES('Alex'),
	('Tosho'),
	('Pesho'),
	('Dani'),
	('Dimo')


CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Genres (GenreName)
VALUES('Fiction'),
	('Drama'),
	('Comedy '),
	('Crime'),
	('Adventure')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Categories (CategoryName)
VALUES('Categorie1'),
	('Categorie2'),
	('Categorie3 '),
	('Categorie4'),
	('Categorie5')

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(30) NOT NULL,
	DirectorId INT,
	CopyrightYear DATETIME2,
	[Length] INT NOT NULL,
	GenreId INT,
	CategoryId INT,
	Rating DECIMAL(1,1),
	Notes NVARCHAR(200)
)

INSERT INTO Movies (Title, DirectorId, [Length], GenreId, CategoryId)
VALUES('Fight  Club', 5, 110, 2, 1),
	('Finding Nemo', 2, 123, 4, 2),
	('El correo ', 4, 141, 5, 5),
	('Blackhat', 1, 136, 3, 3),
	('8 Mile', 3, 106, 2, 4)

--14. Car Rental Database
CREATE DATABASE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(5) NOT NULL,
	DailyRate DECIMAL(1,1),
	WeeklyRate DECIMAL(1,1),
	MonthlyRate DECIMAL(1,1),
	WeekendRate DECIMAL(1,1),
	Notes NVARCHAR(200)
)

INSERT INTO Categories (CategoryName)
VALUES('Sedan'),
	('Coupe'),
	('SUV')

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear INT,
	CategoryId INT NOT NULL,
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(30),
	Available BIT,
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CategoryId)
VALUES(2345, 'BMW', 'Z4', 2),
	(8338, 'Lexus', 'IS', 1),
	(2969, 'Toyota', 'Venza', 3)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30),
	Notes NVARCHAR(200),
)

INSERT INTO Employees (FirstName, LastName)
VALUES('Ivan', 'Ivanov'),
	('Pesho', 'Peshev'),
	('Asen', 'Asenov')

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(200),
	City NVARCHAR(50),
	ZIPCode INT,
	Notes NVARCHAR(200),
)

INSERT INTO Customers (DriverLicenceNumber, FullName)
VALUES(1234567, 'Varadin varadinov'),
	(8903245, 'Stamat Stamatov'),
	(7698008, 'Qsen Qsenov')

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(8,1) NOT NULL,
	TaxRate DECIMAL(8,1),
	OrderStatus BIT,
	Notes NVARCHAR(200),
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TotalDays, RateApplied)
VALUES(2, 3, 2, 7, 234.4),
	(1, 1, 3, 35, 4555.9),
	(3, 2, 1, 13, 2300.4)

--15. Hotel Database
CREATE DATABASE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(200)
)

INSERT INTO Employees (FirstName, LastName)
VALUES('Ivan', 'Ivanov'),
	('Pesho', 'Peshev'),
	('Asen', 'Asenov')

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber BIGINT,
	EmergencyName NVARCHAR(20) NOT NULL,
	EmergencyNumber INT NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Customers (FirstName, LastName, EmergencyName, EmergencyNumber)
VALUES('Ivan', 'Ivanov', 'qwe', 123),
	('Pesho', 'Peshev', 'asd', 256),
	('Asen', 'Asenov', 'zxc', 943)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO RoomStatus (RoomStatus)
VALUES('dirty'),
	('dirty'),
	('clean')

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO RoomTypes (RoomType)
VALUES('delux'),
	('suite'),
	('apartment')

CREATE TABLE BedTypes
(
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO BedTypes (BedType)
VALUES('double bed'),
	('single bed'),
	('king size')

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(20) NOT NULL,
	BedType NVARCHAR(20) NOT NULL,
	Rate DECIMAL(1,1),
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(200)
)

INSERT INTO Rooms (RoomType, BedType, RoomStatus)
VALUES('suite', 'double bed', 'clean'),
	('delux', 'single bed', 'dirty'),
	('apartment', 'king size', 'clean')

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME2,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME2,
	LastDateOccupied DATETIME2,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(8,2),
	TaxRate DECIMAL(5,2),
	TaxAmount DECIMAL(5,2),
	PaymentTotal DECIMAL(8,2) NOT NULL,
	Notes NVARCHAR(200),
)

INSERT INTO Payments (EmployeeId, AccountNumber, TotalDays, PaymentTotal)
VALUES(2, 5435, 8, 10034.4),
	(1, 9643, 3, 4555.9),
	(3, 7233, 10, 12300.4)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME2 NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(5,2),
	PhoneCharge DECIMAL(5,2),
	Notes NVARCHAR(200),
)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber)
VALUES(3, '2021-12-31', 5435, 31),
	(2, '2022-04-19', 9643, 56),
	(1, '2023-07-01', 7233, 34)

--16. Create SoftUni Database
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(60) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(MAX) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(60) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(60) NOT NULL,
	MiddleName NVARCHAR(60) NOT NULL,
	LastName NVARCHAR(60) NOT NULL,
	JobTitle NVARCHAR(60) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME2 NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId  INT FOREIGN KEY REFERENCES Addresses(Id)
)

--18. Basic Insert
INSERT INTO Departments ([Name])
VALUES('Software Developmen'),
	('Engineerin'),
	('Quality Assurance'),
	('Sales'),
	('Marketing')

INSERT INTO Towns ([Name])
VALUES('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 1, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Enginee', 2, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 3, '2016-08-28', 525.25),
	('Georgi', 'Teziev', 'Ivano', 'CEO', 4, '2007-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 5, '2016-08-28', 599.88)

select * from Employees

--19. Basic Select All Fields
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20. Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY [Name] ASC;

SELECT * FROM Departments
ORDER BY [Name] ASC;

SELECT * FROM Employees
ORDER BY Salary DESC;

--21. Basic Select Some Fields
SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22. Increase Employees Salary
UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees

--23. Decrease Tax Rate
UPDATE Payments
SET TaxRate = TaxRate / 1.03

SELECT TaxRate FROM Payments

--24. Delete All Records
DELETE FROM Occupancies