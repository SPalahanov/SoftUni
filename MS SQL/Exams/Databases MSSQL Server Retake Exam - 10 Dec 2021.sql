CREATE DATABASE [Airport]

USE [Airport]
GO

--01.
CREATE TABLE [Passengers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FullName] VARCHAR(100) UNIQUE NOT NULL,
	[Email] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Pilots]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) UNIQUE NOT NULL,
	[LastName] VARCHAR(30) UNIQUE NOT NULL,
	[Age] TINYINT NOT NULL,
		CHECK([Age] BETWEEN 21 AND 62),
	[Rating] FLOAT
		CHECK([Rating] BETWEEN 0.0 AND 10.0)
)

CREATE TABLE [AircraftTypes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[TypeName] VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE [Aircraft]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Manufacturer] VARCHAR(25) NOT NULL,
	[Model] VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	[FlightHours] INT,
	[Condition] CHAR(1) NOT NULL,
	[TypeId] INT FOREIGN KEY REFERENCES [AircraftTypes](Id) NOT NULL
)

CREATE TABLE [PilotsAircraft]
(
	[AircraftId] INT NOT NULL,
	[PilotId] INT NOT NULL,
	PRIMARY KEY ([AircraftId], [PilotId]),
	FOREIGN KEY ([AircraftId]) REFERENCES [Aircraft](Id),
	FOREIGN KEY ([PilotId]) REFERENCES [Pilots](Id)
)

CREATE TABLE [Airports]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AirportName] VARCHAR(70) UNIQUE NOT NULL,
	[Country] VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE [FlightDestinations]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AirportId] INT FOREIGN KEY REFERENCES [Airports](Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	[AircraftId] INT FOREIGN KEY REFERENCES [Aircraft](Id) NOT NULL,
	[PassengerId] INT FOREIGN KEY REFERENCES [Passengers](Id) NOT NULL,
	[TicketPrice] DECIMAL(18, 2) NOT NULL
)


--02.
INSERT INTO [Passengers]([FullName], [Email])
SELECT CONCAT_WS(' ', [FirstName], [LastName])
	  ,CONCAT([FirstName], [LastName], '@gmail.com')
  FROM [Pilots]
 WHERE [Id] BETWEEN 5 AND 15


--03.
UPDATE [Aircraft]
   SET [Condition] = 'A'
 WHERE [Condition] IN ('C', 'B') AND 
	   ([FlightHours] IS NULL OR [FlightHours] <= 100) AND
	   [Year] >= 2013


--04.
DELETE
  FROM [Passengers]
 WHERE LEN([FullName]) < = 10


--05.
  SELECT [Manufacturer]
		,[Model]
		,[FlightHours]
		,Condition
	FROM [Aircraft]
ORDER BY [FlightHours] DESC


--06.
  SELECT p.[FirstName]
		,p.[LastName]
		,a.[Manufacturer]
		,a.[Model]
		,a.[FlightHours]
	FROM [Pilots] AS p
	JOIN [PilotsAircraft] AS pa ON p.[Id] = pa.[PilotId]
	JOIN [Aircraft] AS a ON pa.[AircraftId] = a.[Id]
   WHERE a.[FlightHours] IS NOT NULL AND a.[FlightHours] < 304
ORDER BY a.[FlightHours] DESC, p.[FirstName] ASC


--07.
  SELECT TOP(20) fd.[Id]
		,fd.[Start]
		,p.[FullName]
		,a.[AirportName]
		,fd.[TicketPrice]
	FROM [FlightDestinations] AS fd
	JOIN [Passengers] AS p ON fd.[PassengerId] = p.[Id]
	JOIN [Airports] AS a ON fd.[AirportId] = a.[Id]
   WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
ORDER BY fd.[TicketPrice] DESC, a.[AirportName] ASC


--08.
  SELECT a.[Id] AS [AircraftId]
		,a.[Manufacturer]
		,a.[FlightHours]
		,COUNT(fd.[Id]) AS [FlightDestinationsCount]
		,ROUND(AVG(fd.[TicketPrice]), 2) AS [AvgPrice]
	FROM [Aircraft] AS a
	JOIN [FlightDestinations] AS fd ON a.[Id] = fd.[AircraftId]
GROUP BY a.[Id] ,a.[Manufacturer] ,a.[FlightHours]
  HAVING COUNT(fd.[Id]) >= 2
ORDER BY [FlightDestinationsCount] DESC, a.[Id] ASC


--09.
  SELECT p.[FullName]
		,COUNT(a.[Id]) AS [CountOfAircraft]
		,SUM(fd.[TicketPrice]) AS [TotalPayed]
	FROM [Passengers] AS p
	JOIN [FlightDestinations] AS fd ON p.[Id] = fd.[PassengerId]
	JOIN [Aircraft] AS a ON fd.[AircraftId] = a.[Id]
   WHERE p.[FullName] LIKE '_a%'
GROUP BY p.[FullName]
  HAVING COUNT(a.[Id]) > 1
ORDER BY p.[FullName] ASC


--10.
  SELECT ap.[AirportName]
		,fd.[Start] AS [DayTime]
		,fd.[TicketPrice]
		,p.[FullName]
		,ac.[Manufacturer]
		,ac.[Model]
	FROM [FlightDestinations] AS fd
	JOIN [Airports] AS ap ON fd.[AirportId] = ap.[Id]
	JOIN [Passengers] AS p ON fd.[PassengerId] = p.[Id]
	JOIN [Aircraft] AS ac ON fd.[AircraftId] = ac.[Id]
   WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20 AND fd.[TicketPrice] > 2500
ORDER BY ac.[Model] ASC


--11.
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM [FlightDestinations] AS fd
	  JOIN [Passengers] AS p ON fd.[PassengerId] = p.[Id]
	 WHERE p.[Email] = @email

	RETURN @result
END


--12.
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN

  SELECT ap.[AirportName]
		,p.[FullName]
		,CASE
				WHEN fd.[TicketPrice] < 400 THEN 'Low'
				WHEN fd.[TicketPrice] BETWEEN 401 AND 1500 THEN 'Medium'
				WHEN fd.[TicketPrice] > 1501 THEN 'High'
		 END AS [LevelOfTicketPrice]
		,ac.[Manufacturer]
		,ac.[Condition]
		,aty.[TypeName]
	FROM [Airports] AS ap
	JOIN [FlightDestinations] AS fd ON ap.[Id] = fd.[AirportId]
	JOIN [Passengers] AS p ON fd.[PassengerId] = p.[Id]
	JOIN [Aircraft] AS ac ON fd.[AircraftId] = ac.[Id]
	JOIN [AircraftTypes] AS aty ON ac.[TypeId] = aty.[Id]
   WHERE ap.[AirportName] = @airportName
ORDER BY ac.[Manufacturer] ASC, p.[FullName] ASC

END