CREATE DATABASE [Boardgames]

USE [Boardgames]
GO

--01.
CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(100) NOT NULL,
	[StreetNumber] INT NOT NULL,
	[Town] VARCHAR(30) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	[ZIP] INT NOT NULL,
)

CREATE TABLE [Publishers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id),
	[Website] NVARCHAR(40),
	[Phone] NVARCHAR(20)
)

CREATE TABLE [PlayersRanges]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlayersMin] INT NOT NULL,
	[PlayersMax] INT NOT NULL
)

CREATE TABLE [Boardgames]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[YearPublished] INT NOT NULL,
	[Rating] DECIMAL(20, 2) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
	[PublisherId] INT FOREIGN KEY REFERENCES [Publishers](Id),
	[PlayersRangeId] INT FOREIGN KEY REFERENCES [PlayersRanges](Id)
)

CREATE TABLE [Creators]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(30) NOT NULL
)

CREATE TABLE [CreatorsBoardgames]
(
	[CreatorId] INT NOT NULL,
	[BoardgameId] INT NOT NULL,
	CONSTRAINT PK_ProductsClients PRIMARY KEY ([CreatorId], [BoardgameId]),
	CONSTRAINT FK_ProductsClients_Products FOREIGN KEY ([CreatorId]) REFERENCES [Creators](Id),
	CONSTRAINT FK_ProductsClients_Clients FOREIGN KEY ([BoardgameId]) REFERENCES [Boardgames](Id)
)


--02.
INSERT INTO [Boardgames]
VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas',	2020, 3.25, 3, 7, 4),
('One Small Step',	2019, 5.75, 5, 9, 2)

INSERT INTO [Publishers]
VALUES
('Agman Games',	5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


--03.
UPDATE [PlayersRanges]
   SET [PlayersMax] += 1
 WHERE [PlayersMax] = 2 AND [PlayersMin] = 2

UPDATE [Boardgames]
   SET [Name] = [Name] + 'V2'
 WHERE [YearPublished] >= 2020


--04.
DELETE 
  FROM [CreatorsBoardgames]
 WHERE [BoardgameId] IN (1, 16, 31, 47)

DELETE 
  FROM [Boardgames]
 WHERE [PublisherId] IN (1, 16)

DELETE 
  FROM [Publishers]
 WHERE [AddressId] = 5

DELETE 
  FROM [Addresses]
 WHERE [Id] = 5


--05.
SELECT [Name]
	  ,[Rating]
  FROM [Boardgames]
ORDER BY [YearPublished] ASC ,[Name] DESC


--06.
  SELECT b.[Id]
		,b.[Name]
		,b.[YearPublished]
		,c.[Name] AS [CategoryName]
	FROM [Boardgames] AS b
	JOIN [Categories] AS c ON b.[CategoryId] = c.[Id]
   WHERE c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY [YearPublished] DESC


--07.
  SELECT c.[Id]
		,CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [CreatorName]
		,c.[Email]
	FROM [Creators] AS c
	LEFT JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
	LEFT JOIN [Boardgames] AS b ON cb.[BoardgameId] = b.[Id]
   WHERE b.[Id] IS NULL
ORDER BY [CreatorName]


--08.
  SELECT TOP (5) b.[Name]
		,b.[Rating]
		,c.[Name] AS [CategoryName]
	FROM [Boardgames] AS b
	JOIN [Categories] AS c ON b.[CategoryId] = c.[Id]
	JOIN [PlayersRanges] AS pr ON b.[PlayersRangeId] = pr.[Id]
   WHERE b.[Rating] > 7.00 AND b.[Name] LIKE '%a%' OR (b.[Rating] > 7.50 AND pr.[PlayersMin] = 2 AND pr.[PlayersMax] = 5)
ORDER BY b.[Name] ASC, b.[Rating] DESC


--09.
  SELECT [FullName]
		,[Email]
		,[Rating] 
	FROM (
		SELECT CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [FullName]
			  ,c.[Email]
			  ,b.[Rating]
			  ,ROW_NUMBER() OVER (PARTITION BY c.[FirstName] ORDER BY b.[Rating] DESC) AS [Rank]
		  FROM [Creators] AS c
		  LEFT JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
		  LEFT JOIN [Boardgames] AS b ON cb.[BoardgameId] = b.[Id]
		 WHERE c.[Email] LIKE '%.com' ) AS [RatingRank]
   WHERE [Rank] = 1 AND [Rating] IS NOT NULL
ORDER BY [FullName]


--10.
  SELECT [LastName]
		,CEILING([AverageRating])
		,[PublisherName]
	FROM (
		  SELECT c.[LastName]
				,AVG(b.[Rating]) AS [AverageRating]
				,p.[Name] AS [PublisherName]
			FROM [Creators] AS c
			JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
			JOIN [Boardgames] AS b ON cb.[BoardgameId] = b.[Id]
			JOIN [Publishers] AS p ON b.[PublisherId] = p.[Id]
		   WHERE p.[Name] = 'Stonemaier Games'
		GROUP BY c.[LastName],p.[Name]
		 ) AS [OrderRating]
ORDER BY [AverageRating] DESC


--11.
CREATE FUNCTION udf_CreatorWithBoardgames(@name VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM [Creators] AS c
	  JOIN [CreatorsBoardgames] AS cb ON c.[Id] = cb.[CreatorId]
	  JOIN [Boardgames] AS b ON cb.[BoardgameId] = b.[Id]
	 WHERE c.[FirstName] = @name

	RETURN @result
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')


--12.
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(MAX)) 
AS
BEGIN
	  SELECT b.[Name]
			,b.[YearPublished]
			,b.[Rating]
			,c.[Name] AS [CategoryName]
			,p.[Name] AS [PublisherName]
			,CONCAT_WS(' ', pr.[PlayersMin], 'people') AS [MinPlayers]
			,CONCAT_WS(' ', pr.[PlayersMax], 'people') AS [MaxPlayers]
		FROM [Boardgames] AS b
		JOIN [Categories] AS c ON b.[CategoryId] = c.[Id]
		JOIN [Publishers] AS p ON b.[PublisherId] = p.[Id]
		JOIN [PlayersRanges] AS pr ON b.[PlayersRangeId] = pr.[Id]
	   WHERE c.[Name] = @category
	ORDER BY [PublisherName] ASC, b.[YearPublished] DESC
END