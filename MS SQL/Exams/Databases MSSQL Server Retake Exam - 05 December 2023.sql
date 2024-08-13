CREATE DATABASE RailwaysDb

USE RailwaysDb
GO

--01.
CREATE TABLE [Passengers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE [Towns]

(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [RailwayStations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns](Id)
)

CREATE TABLE [Trains]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[HourOfDeparture] VARCHAR(5) NOT NULL,
	[HourOfArrival] VARCHAR(5) NOT NULL,
	[DepartureTownId] INT FOREIGN KEY REFERENCES [Towns](Id),
	[ArrivalTownId] INT FOREIGN KEY REFERENCES [Towns](Id)
)

CREATE TABLE [TrainsRailwayStations]
(
	[TrainId] INT NOT NULL,
	[RailwayStationId] INT NOT NULL,
	CONSTRAINT PK_TrainsRailwayStations PRIMARY KEY ([TrainId], [RailwayStationId]),
	CONSTRAINT FK_TrainsRailwayStations_Trains FOREIGN KEY (TrainId) REFERENCES [Trains](Id),
	CONSTRAINT FK_TrainsRailwayStations_RailwayStations FOREIGN KEY ([RailwayStationId]) REFERENCES [RailwayStations](Id)
)

CREATE TABLE [MaintenanceRecords]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DateOfMaintenance] DATETIME NOT NULL,
	[Details] VARCHAR(2000) NOT NULL,
	[TrainId] INT FOREIGN KEY REFERENCES [Trains](Id)
)

CREATE TABLE [Tickets]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Price] DECIMAL(18, 2) NOT NULL,
	[DateOfDeparture] DATETIME2 NOT NULL,
	[DateOfArrival] DATETIME2 NOT NULL,
	[TrainId] INT FOREIGN KEY REFERENCES [Trains](Id),
	[PassengerId] INT FOREIGN KEY REFERENCES [Passengers](Id)
)


--02.
INSERT INTO [Trains]
VALUES
	('07:00', '19:00', 1, 3),
	('08:30', '20:30', 5, 6),
	('09:00', '21:00', 4, 8),
	('06:45', '03:55', 27, 7),
	('10:15', '12:15', 15, 5)

INSERT INTO [TrainsRailwayStations]
VALUES
	(36, 1),
	(36, 4),
	(36, 31),
	(36, 57),
	(36, 7),
	(37, 13),
	(37, 54),
	(37, 60),
	(37, 16),
	(38, 10),
	(38, 50),
	(38, 52),
	(38, 22),
	(39, 68),
	(39, 3),
	(39, 31),
	(39, 19),
	(40, 41),
	(40, 7),
	(40, 52),
	(40, 13)

INSERT INTO [Tickets]
VALUES
(90.00, '2023-12-01','2023-12-01',36,1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22)


--03.
 --03.
UPDATE [Tickets]
	SET 
	[DateOfDeparture] = DATEADD(DAY, 7, [DateOfDeparture]),
	[DateOfArrival] = DATEADD(DAY, 7, [DateOfArrival])
	WHERE [DateOfDeparture] > '2023-10-31'


 --04.
DECLARE @TrainsToDelete TABLE ([Id] INT)

INSERT INTO @TrainsToDelete([Id])
	SELECT [Id]
	  FROM [Towns]
	 WHERE [Name] = 'Berlin'

DELETE FROM Tickets 
WHERE TrainId IN (
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT [Id] FROM @TrainsToDelete)
);

DELETE FROM MaintenanceRecords 
WHERE TrainId IN (
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT [Id] FROM @TrainsToDelete)
);

DELETE FROM TrainsRailwayStations 
WHERE TrainId IN (
    SELECT Id 
    FROM Trains 
    WHERE DepartureTownId = (SELECT [Id] FROM @TrainsToDelete)
);

DELETE FROM Trains 
WHERE DepartureTownId = (SELECT [Id] FROM @TrainsToDelete)

-----------------------------------------------------------


--05.
SELECT [DateOfDeparture]
	  ,[Price] AS [TicketPrice]
  FROM [Tickets]
ORDER BY [Price] ASC, [DateOfDeparture] DESC


--06.
SELECT p.[Name]
	  ,t.[Price] AS [TicketPrice]
	  ,[DateOfDeparture]
	  ,t.[TrainId]
  FROM [Tickets] AS t
  JOIN [Passengers] AS p ON t.PassengerId = p.[Id]
ORDER BY t.[Price] DESC, p.[Name] ASC


--07.
  SELECT t.[Name]
		,rs.[Name]
	FROM [RailwayStations] AS rs
	LEFT JOIN [TrainsRailwayStations] AS trs ON rs.[Id] = trs.[RailwayStationId]
	LEFT JOIN [Trains] as tr ON trs.TrainId = tr.Id
	LEFT JOIN [Towns] AS t On rs.[TownId] = t.[Id]
   WHERE trs.[TrainId] IS NULL
ORDER BY t.[Name], rs.[Name]


--08.
  SELECT TOP (3) 
		 tr.[Id] AS [TrainId]
		,tr.[HourOfDeparture]
		,ti.[Price] AS [TicketPrice]
		,t.[Name]
	FROM [Trains] AS tr
	JOIN [Tickets] AS ti ON tr.[Id] = ti.[TrainId]
	JOIN [Towns] AS t ON tr.[ArrivalTownId] = t.[Id]
   WHERE tr.[HourOfDeparture] BETWEEN '08:00' AND '08:59' AND ti.[Price] > 50.00
ORDER BY ti.[Price] ASC



--09.
  SELECT t.[Name]
		,COUNT(p.[Name])
	FROM [Passengers] AS p
	JOIN [Tickets] AS ti ON p.Id = ti.[PassengerId]
	JOIN [Trains] AS tr ON ti.[TrainId] = tr.[Id]
	JOIN [Towns] AS t ON tr.ArrivalTownId = t.Id
   WHERE ti.[Price] > 76.99
GROUP BY t.[Name]
ORDER BY t.[Name]


--10.
  SELECT tr.[Id]
		,t.[Name] AS [DepartureTown]
		,[Details]
	FROM [MaintenanceRecords] AS m
	JOIN [Trains] AS tr ON m.[TrainId] = tr.[Id]
	JOIN [Towns] AS t On tr.[DepartureTownId] = t.[Id]
   WHERE m.[Details] LIKE '%inspection%'
ORDER BY tr.[Id]


--11.
CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM [Trains] AS tr
	  JOIN [Towns] AS t On tr.[DepartureTownId] = t.[Id] OR tr.[ArrivalTownId] = t.[Id]
	 WHERE t.[Name] = @name

	RETURN @result
END

SELECT dbo.udf_TownsWithTrains ('Paris')


--12.
CREATE OR ALTER PROCEDURE usp_SearchByTown(@townName VARCHAR(MAX))
AS
BEGIN
	  SELECT p.[Name] AS [PassengerName]
			,ti.[DateOfDeparture]
			,tr.[HourOfDeparture]
		FROM [Passengers] AS p
		JOIN [Tickets] AS ti ON p.[Id] = ti.[PassengerId]
		JOIN [Trains] AS tr ON ti.[TrainId] = tr.[Id]
		JOIN [Towns] AS t ON tr.[ArrivalTownId] = t.[Id]
	   WHERE t.[Name] = @townName
	ORDER BY ti.[DateOfDeparture] DESC, t.[Name] ASC
END

EXEC usp_SearchByTown 'Berlin'