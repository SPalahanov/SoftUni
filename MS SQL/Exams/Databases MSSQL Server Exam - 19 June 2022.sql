CREATE DATABASE [Zoo]

USE [Zoo]
GO

--01.
CREATE TABLE [Owners]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE [AnimalTypes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE [Cages]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
)

CREATE TABLE [Animals]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id]),
	[AnimalTypeId] INT FOREIGN KEY REFERENCES [AnimalTypes]([Id]) NOT NULL
)

CREATE TABLE [AnimalsCages]
(
	[CageId] INT NOT NULL,
	[AnimalId] INT NOT NULL,
	CONSTRAINT PK_AnimalsCages PRIMARY KEY ([CageId], [AnimalId]),
	CONSTRAINT FK_AnimalsCages_Cages FOREIGN KEY ([CageId]) REFERENCES [Cages](Id),
	CONSTRAINT FK_AnimalsCages_Animals FOREIGN KEY ([AnimalId]) REFERENCES [Animals](Id)
)

CREATE TABLE [VolunteersDepartments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE [Volunteers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]),
	[DepartmentId] INT FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]) NOT NULL
)


--02.
INSERT INTO [Volunteers]
VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', null, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', null, 31, 5)

INSERT INTO [Animals]
VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', null, 1),
('Tuatara', '2021-06-30', 2, 4)


--03.
UPDATE [Animals]
   SET [OwnerId] = (SELECT [Id] FROM [Owners] WHERE [Name] = 'Kaloqn Stoqnov')
 WHERE [OwnerId] IS NULL


--04.
DELETE
  FROM [Volunteers]
 WHERE [DepartmentId] = (SELECT [Id] 
						   FROM [VolunteersDepartments] 
						  WHERE [DepartmentName] = 'Education program assistant')

DELETE
  FROM [VolunteersDepartments]
 WHERE [Id] = (SELECT [Id] 
				 FROM [VolunteersDepartments] 
				WHERE [DepartmentName] = 'Education program assistant')


--05.
SELECT [Name]
	  ,[PhoneNumber]
	  ,[Address]
	  ,[AnimalId]
	  ,[DepartmentId]
  FROM [Volunteers]
ORDER BY [Name] ASC, [AnimalId] ASC, [DepartmentId] ASC


--06.
  SELECT a.[Name]
		,aty.[AnimalType]
		,FORMAT([BirthDate], 'dd.MM.yyyy')
	FROM [Animals] AS a
	JOIN [AnimalTypes] AS aty ON a.[AnimalTypeId] = aty.[Id]
ORDER BY a.[Name] ASC


--07.
  SELECT TOP (5) o.[Name] AS [Owner]
		,COUNT(a.[Id]) AS [CountOfAnimals]
	FROM [Owners] AS o
	JOIN [Animals] AS a ON o.[Id] = a.[OwnerId]
GROUP BY o.[Name]
ORDER BY [CountOfAnimals] DESC


--08.
  SELECT CONCAT_WS('-', o.[Name], a.[Name]) AS [OwnersAnimals]
		,o.[PhoneNumber]
		,ac.[CageId]
	FROM [Owners] AS o
	JOIN [Animals] AS a ON o.[Id] = a.[OwnerId]
	JOIN [AnimalsCages] AS ac ON a.[Id] = ac.[AnimalId]
	JOIN [AnimalTypes] AS aty ON a.[AnimalTypeId] = aty.[Id]
   WHERE aty.[AnimalType] = 'mammals'
ORDER BY o.[Name] ASC, a.[Name] DESC


--09.
  SELECT v.[Name]
		,v.[PhoneNumber]
		,SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + LEN(','), LEN(v.[Address])) AS [Address]
	FROM [Volunteers] AS v
	JOIN [VolunteersDepartments] AS vd ON v.[DepartmentId] = vd.[Id]
   WHERE vd.[DepartmentName] = 'Education program assistant' AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name] ASC


--10.
  SELECT a.[Name]
		,DATEPART(YEAR, a.[BirthDate]) AS [BirthYear]
		,aty.[AnimalType]
	FROM [Animals] AS a
	LEFT JOIN [AnimalTypes] AS aty ON a.[AnimalTypeId] = aty.[Id]
   WHERE a.[OwnerId] IS NULL AND DATEPART(YEAR, a.[BirthDate]) > '2017' AND aty.[AnimalType] != 'Birds'
ORDER BY a.[Name] ASC


--11.
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @result INT

	SELECT @result = COUNT(*)
	  FROM [Volunteers] AS v
	  JOIN [VolunteersDepartments] AS vd ON v.[DepartmentId] = vd.[Id]
	 WHERE vd.[DepartmentName] = @VolunteersDepartment

	RETURN @result
END


--12.
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(MAX))
AS
BEGIN
IF (SELECT [OwnerId] FROM [Animals]
	 WHERE [Name] = @AnimalName) IS NULL

	BEGIN 
		SELECT [Name], 'For adoption' AS [OwnerName]
		  FROM [Animals]
		 WHERE [Name] = @AnimalName
	END

	ELSE
	BEGIN
		SELECT a.[Name], o.[Name] as [OwnerName]
		  FROM [Animals] AS a
		  JOIN [Owners] AS o ON o.[Id] = a.[OwnerId]
		 WHERE a.[Name] = @AnimalName
	END
END