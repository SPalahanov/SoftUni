CREATE DATABASE Accounting

USE Accounting
GO

--01.
CREATE TABLE [Countries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(20) NOT NULL,
	[StreetNumber] INT,
	[PostCode] INT NOT NULL,
	[City] VARCHAR(25) NOT NULL,
	[CountryId] INT FOREIGN KEY REFERENCES [Countries](Id)
)

CREATE TABLE [Vendors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[NumberVAT] NVARCHAR(15) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
)

CREATE TABLE [Clients]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	[NumberVAT] NVARCHAR(15) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Products]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	[Price] DECIMAL(18, 2) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors](Id)
)

CREATE TABLE [Invoices]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Number] INT UNIQUE NOT NULL,
	[IssueDate] DATETIME2 NOT NULL,
	[DueDate] DATETIME2 NOT NULL,
	[Amount] DECIMAL(18, 2) NOT NULL,
	[Currency] VARCHAR(5) NOT NULL,
	[ClientId] INT FOREIGN KEY REFERENCES [Clients](Id)
)

CREATE TABLE [ProductsClients]
(
	[ProductId] INT NOT NULL,
	[ClientId] INT NOT NULL,
	CONSTRAINT PK_ProductsClients PRIMARY KEY ([ProductId], [ClientId]),
	CONSTRAINT FK_ProductsClients_Products FOREIGN KEY ([ProductId]) REFERENCES [Products](Id),
	CONSTRAINT FK_ProductsClients_Clients FOREIGN KEY ([ClientId]) REFERENCES [Clients](Id)
)


--02.
INSERT INTO [Products]
VALUES
('SCANIA Oil Filter XD01', 78.69, 1, 1),
('MAN Air Filter XD01',	97.38, 1, 5),
('DAF Light Bulb 05FG87', 55.00, 2, 13),
('ADR Shoes 47-47.5', 49.85, 3, 5),
('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO [Invoices]
VALUES
(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)



--03.
UPDATE [Invoices]
   SET [DueDate] = '2023-04-01'
 WHERE Year([IssueDate]) = 2022 AND Month([IssueDate]) = 11

UPDATE [Clients]
   SET [AddressId] = 3
 WHERE [Name] LIKE '%CO%'


--04.
DELETE 
  FROM [ProductsClients]
 WHERE [ClientId] = 11

DELETE 
  FROM [Invoices]
 WHERE [ClientId] = 11

DELETE 
  FROM [Clients]
 WHERE [NumberVat] LIKE 'IT%'


--05.
  SELECT [Number]
		,[Currency]
	FROM [Invoices]
ORDER BY [Amount] DESC, [DueDate] ASC


--06.
  SELECT p.[Id]
		,p.[Name]
		,p.[Price]
		,c.[Name]
	FROM [Products] AS p
	JOIN [Categories] AS c ON p.[CategoryId] = c.[Id]
   WHERE c.[Name] = 'ADR' OR c.[Name] = 'Others'
ORDER BY [Price] DESC


--07.
  SELECT c.[Id]
		,c.[Name] AS [Client]
		,CONCAT_WS(' ', a.[StreetName], CONCAT(a.[StreetNumber], ','), CONCAT(a.[City], ','),  CONCAT(a.[PostCode], ','), co.[Name]) AS [Address]
	FROM [Clients] AS c
	LEFt JOIN [Addresses] AS a ON c.[AddressId] = a.[Id]
	LEFT JOIN [Products] AS p ON c.Id = p.[CategoryId]
	
	LEFT JOIN [Countries] AS co ON a.[CountryId] = co.[Id]
   WHERE p.[Id] IS NULL AND c.[Id] = 8 OR c.[Id] = 12
ORDER BY c.[Name] ASC


--08.
  SELECT TOP (7) i.[Number]
		,i.[Amount]
		,c.[Name] AS [Client]
	FROM [Invoices] AS i
	JOIN [Clients] AS c ON i.[ClientId] = c.[Id]
   WHERE i.[IssueDate] < '2023-01-01' AND (i.[Currency] = 'EUR' OR (i.[Amount] > 500.00 AND c.[NumberVAT] LIKE 'DE%'))
ORDER BY i.[Number] ASC, i.[Amount] DESC;


--09.
  SELECT [Name] AS [Client]
		,[Price]
		,[NumberVAT] AS [VAT Number]
	FROM (SELECT c.[Name]
				,p.[Price]
				,ROW_NUMBER() OVER (PARTITION BY c.[NumberVAT] ORDER BY p.[Price] DESC) AS [Rank]
				,c.[NumberVAT]
			FROM [Clients] AS c
			JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
			JOIN [Products] AS p ON pc.[ProductId] = p.[Id]
		   WHERE c.[Name] NOT LIKE '%KG') AS [PriceRanking]
   WHERE [Rank] = 1
ORDER BY [Price] DESC


--10.
SELECT c.[Name]
		,FLOOR(AVG(p.[Price])) AS [Average Price]
  FROM [Clients] AS c
  JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
  JOIN [Products] AS p ON pc.[ProductId] = p.[Id]
  JOIN [Vendors] AS v ON p.[VendorId] = v.[Id]
WHERE v.[NumberVAT] LIKE 'FR%'
GROUP BY c.[Name]
ORDER BY FLOOR(AVG(p.[Price])) ASC, c.[Name] DESC


--11.
CREATE FUNCTION udf_ProductWithClients(@name VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM [Clients] AS c
	  JOIN [ProductsClients] AS pc ON c.[Id] = pc.[ClientId]
	  JOIN [Products] AS p ON pc.[ProductId] = p.[Id]
	 WHERE p.[Name] = @name
	
	RETURN @result
END


--12.
CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(MAX))
AS
BEGIN
SELECT v.[Name]
		,v.[NumberVat] AS [VAT]
		,CONCAT_WS(' ', a.[StreetName], a.[StreetNumber])
		,CONCAT_WS(' ', a.[City], a.[PostCode])
  FROM [Vendors] AS v
  JOIN [Addresses] AS a ON v.[AddressId] = a.[Id]
  JOIN [Countries] As c ON a.[CountryId] = c.[Id]
WHERE c.[Name] = @country
ORDER BY v.[Name], a.[City]
END

EXEC usp_SearchByCountry 'France'
