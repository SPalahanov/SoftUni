CREATE DATABASE [NationalTouristSitesOfBulgaria]

USE [NationalTouristSitesOfBulgaria]
GO

--01.
CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Locations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50)
)

CREATE TABLE [Sites]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT FOREIGN KEY REFERENCES [Locations](Id) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Establishment] VARCHAR(15)
)

CREATE TABLE [Tourists]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT CHECK ([Age] >= 0 AND [Age] <= 120) NOT NULL,
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20)
)

CREATE TABLE [SitesTourists]
(
	[TouristId] INT NOT NULL,
	[SiteId] INT NOT NULL,
	PRIMARY KEY ([TouristId], [SiteId]),
	FOREIGN KEY ([TouristId]) REFERENCES [Tourists](Id),
	FOREIGN KEY ([SiteId]) REFERENCES [Sites](Id)
)

CREATE TABLE [BonusPrizes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes]
(
	[TouristId] INT NOT NULL,
	[BonusPrizeId] INT NOT NULL,
	PRIMARY KEY ([TouristId], [BonusPrizeId]),
	FOREIGN KEY ([TouristId]) REFERENCES [Tourists](Id),
	FOREIGN KEY ([BonusPrizeId]) REFERENCES [BonusPrizes](Id)
)


--02.
INSERT INTO [Tourists]
VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO [Sites]
VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')


--03.
UPDATE [Sites]
   SET [Establishment] = '(not defined)'
 WHERE [Establishment] IS NULL


--04.
----------- Solution 1 ---------
SELECT [Id] FROM [BonusPrizes] WHERE [Name] = 'Sleeping bag'

DELETE
  FROM [TouristsBonusPrizes]
 WHERE [BonusPrizeId] = 5

DELETE
  FROM [BonusPrizes]
 WHERE [Id] = 5

----------- Solution 2 ---------
DELETE
  FROM [TouristsBonusPrizes]
 WHERE [BonusPrizeId] IN (
		SELECT [Id] 
		  FROM [BonusPrizes] 
		 WHERE [Name] = 'Sleeping bag')

DELETE
  FROM [BonusPrizes]
 WHERE [Id] IN (
		SELECT [Id] 
		  FROM [BonusPrizes] 
		 WHERE [Name] = 'Sleeping bag')


--05.
  SELECT [Name]
		,[Age]
		,[PhoneNumber]
		,[Nationality]
	FROM [Tourists]
ORDER BY [Nationality] ASC, [Age] DESC


--06.
  SELECT s.[Name]
		,l.[Name]
		,[Establishment]
		,c.[Name]
	FROM [Sites] AS s
	JOIN [Locations] AS l ON s.[LocationId] = l.[Id]
	JOIN [Categories] AS c ON s.[CategoryId] = c.[Id]
ORDER BY c.[Name] DESC, l.[Name] ASC, s.[Name] ASC


--07.
  SELECT l.[Province]
		,l.[Municipality]
		,l.[Name]
		,COUNT(s.[Id]) AS [CountOfSites]
	FROM [Locations] AS l
	JOIN [Sites] AS s ON l.[Id] =s.[LocationId]
   WHERE l.[Province] = 'Sofia'
GROUP BY l.[Province],l.[Municipality]
		,l.[Name]
ORDER BY [CountOfSites] DESC, l.[Name] ASC


--08.
  SELECT s.[Name]
		,l.[Name]
		,l.[Municipality]
		,l.[Province]
		,s.[Establishment]
	FROM [Sites] AS s
	JOIN [Locations] AS l ON s.[LocationId] = l.[Id]
   WHERE l.[Name] NOT LIKE 'B%' AND l.[Name] NOT LIKE 'M%' AND l.[Name] NOT LIKE 'D%' AND s.[Establishment] LIKE '%BC'
ORDER BY s.[Name] ASC


--09.
  SELECT t.[Name]
		,t.[Age]
		,t.[PhoneNumber]
		,t.[Nationality]
		,COALESCE(bp.[Name], '(no bonus prize)') AS [Reward]
	FROM [Tourists] AS t
	LEFT JOIN [TouristsBonusPrizes] AS tbp ON t.[Id] = tbp.[TouristId]
	LEFT JOIN [BonusPrizes] AS bp ON tbp.[BonusPrizeId] = bp.[Id]
ORDER BY t.[Name] ASC


--10.
  SELECT SUBSTRING(t.[Name], CHARINDEX(' ',t.[Name]) + 1, LEN(t.[Name]) - CHARINDEX(' ', t.[Name])) AS [LastName]
		,t.[Nationality]
		,t.[Age]
		,t.[PhoneNumber]
	FROM [Tourists] AS t
	JOIN [SitesTourists] AS st ON t.[Id] = st.[TouristId]
	JOIN [Sites] AS s ON st.[SiteId] = s.[Id]
	JOIN [Categories] AS c ON s.[CategoryId] = c.[Id]
   WHERE c.[Name] = 'History and archaeology'
GROUP BY t.[Name], t.[Nationality] ,t.[Age] ,t.[PhoneNumber]
ORDER BY [LastName] ASC


--11.
CREATE FUNCTION udf_GetTouristsCountOnATouristSite(@Site VARCHAR(MAX)) 
RETURNS INT
AS
BEGIN
	DECLARE @result INt

	SELECT @result = COUNT(*)
	  FROM [Tourists] AS t
	  JOIN [SitesTourists] AS st ON t.[Id] = st.[TouristId]
	  JOIN [Sites] AS s ON st.[SiteId] = s.[Id]
	 WHERE s.[Name] = @Site

	RETURN @result
END


--12.
CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(MAX))
AS
BEGIN

DECLARE @count INT
DECLARE @reward VARCHAR(MAX)

SELECT @count = [Count]
  FROM (
		  SELECT t.[Name]
				,t.[Reward]
				,COUNT(s.[Id]) AS [Count]
			FROM [Tourists] AS t
			JOIN [SitesTourists] AS st ON t.[Id] = st.[TouristId]
			JOIN [Sites] AS s ON st.[SiteId] = s.[Id]
		GROUP BY t.[Name] , t.[Reward] 
		) AS [GetCount]
 WHERE [Name] = @TouristName

IF @count >= 100
BEGIN
	UPDATE [Tourists]
	   SET [Reward] = 'Gold badge'
	 WHERE [Name] = @TouristName
END

ELSE IF @count >= 50
BEGIN
	UPDATE [Tourists]
	   SET [Reward] = 'Silver badge'
	 WHERE [Name] = @TouristName
END

ELSE IF @count >= 25
BEGIN
	UPDATE [Tourists]
	   SET [Reward] = 'Bronze badge'
	 WHERE [Name] = @TouristName
END

SELECT [Name]
	   ,[Reward]
  FROM [Tourists]
 WHERE [Name] = @TouristName

END