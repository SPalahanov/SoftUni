USE [SoftUni]
GO

 -- 01.
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT [FirstName]
		  ,[LastName]
	  FROM [Employees]
	 WHERE [Salary] > 35000
END	

EXEC usp_GetEmployeesSalaryAbove35000


 -- 02.
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS
	SELECT [FirstName]
		  ,[LastName]
	  FROM [Employees]
	 WHERE [Salary] >= @number 

EXEC usp_GetEmployeesSalaryAboveNumber 30000


 -- 03.
CREATE PROC usp_GetTownsStartingWith(@string VARCHAR(MAX))
AS
BEGIN
	SELECT [Name] AS [Town]
	  FROM [Towns]
	 WHERE LEFT([Name], LEN(@string)) = @string
	 --WHERE [Name] LIKE CONCAT(@string, '%')
END

EXEC usp_GetTownsStartingWith 'b'


 -- 04.
CREATE PROC usp_GetEmployeesFromTown(@string VARCHAR(MAX))
AS
BEGIN
	SELECT [FirstName]
		  ,[LastName]
	  FROM [Employees] AS e
	  JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
	  JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
	 WHERE t.[Name] = @string
END

EXEC usp_GetEmployeesFromTown 'Sofia'


 -- 05.
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS 
BEGIN
	DECLARE @result VARCHAR(10)

	IF(@salary < 30000)
	BEGIN
		SET @result = 'Low'
	END

	IF(@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @result = 'Average'
	END

	IF(@salary > 50000)
	BEGIN
		SET @result = 'High'
	END

	RETURN @result
END

SELECT [Salary]
	  ,dbo.ufn_GetSalaryLevel([Salary]) AS [SalaryLevel]
  FROM [SoftUni].[dbo].[Employees]


 -- 06.
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(10))
AS
BEGIN
	SELECT [FirstName]
		  ,[LastName]
	  FROM [Employees]
	 WHERE dbo.ufn_GetSalaryLevel([Salary]) = @salaryLevel
END

EXEC usp_EmployeesBySalaryLevel 'Low'


 -- 07.
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @WordLength INT = LEN(@word)
	DECLARE @Iterator INT = 1

	WHILE(@Iterator <= @WordLength)
		BEGIN
			IF(CHARINDEX(SUBSTRING(@word, @Iterator, 1), @setOfLetters) = 0)
				RETURN 0
			SET @Iterator += 1
		END
	RETURN 1
END


 -- 08.
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	--1. Make Manager ID in Departments nullable
	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerId] INT NULL

	--2. Nullify the ManagerID of Departments ManagerID
	UPDATE [Departments]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN
	 (
		SELECT [EmployeeID]
		  FROM [Employees]
	 )

	--3. Delete from EmployeesProjects
	DELETE 
	  FROM [EmployeesProjects]
	 WHERE [EmployeeID] IN
	(
		SELECT [EmployeeID]
		  FROM [Employees]
	)

	--4. Set employees manager id to null
	UPDATE [Employees]
	   SET [ManagerID] = NULL
	 WHERE [EmployeeID] IN
	 (
		SELECT [EmployeeID]
		  FROM [Employees]
	 )

	 DELETE 
	   FROM [Employees]
	  WHERE [DepartmentID] = @departmentId

	 DELETE 
	   FROM [Departments]
	  WHERE [DepartmentID] = @departmentId

	  SELECT COUNT(*)
	    FROM [Employees]
	   WHERE [DepartmentID] = @departmentId
END


-----------------------------------------------
USE [Bank]
GO

 --09.
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT_WS(' ', [FirstName], [LastName]) AS [FullName]
	  FROM [AccountHolders]
END


 --10.
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number money)
AS
BEGIN
	  SELECT [FirstName]  AS [First Name]
			,[LastName] AS [Last Name]
		FROM [AccountHolders] AS ah
		JOIN [Accounts] AS a ON ah.Id = a.AccountHolderId
	GROUP BY [FirstName], [LastName]
	  HAVING SUM(a.[Balance]) > @number
	ORDER BY [FirstName], [LastName]
END


 --11.
CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(10, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(10, 4)
AS
BEGIN
	RETURN @initialSum * (POWER((1 + @yearlyInterestRate), @numberOfYears))
END


 --12.
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
BEGIN
	DECLARE @numberOfYears INT = 5
	
	SELECT ah.[Id] AS [Account Id]
		  ,ah.[FirstName] AS [First Name]
		  ,ah.[LastName] AS [Last Name]
		  ,a.[Balance] AS [Current Balance]
		  ,dbo.ufn_CalculateFutureValue([Balance], @interestRate, @numberOfYears) AS [Balance in 5 years]
	  FROM [AccountHolders] AS ah
	  JOIN [Accounts]  AS a ON ah.Id = a.[AccountHolderId]
	  WHERE a.[Id] = @accountId
END


-----------------------------------------------
USE [Diablo]
GO

 --13.
CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(MAX))
RETURNS TABLE
AS
RETURN
(
	SELECT SUM([Cash]) AS [SumCash]
	  FROM 
	  (SELECT ROW_NUMBER() OVER(ORDER BY [Cash] DESC) AS [Row#]
			 ,g.[Name]
			 ,ug.[Cash]
		 FROM [Games] AS g
		 JOIN [UsersGames] AS ug ON g.[Id] = ug.[GameId]
		WHERE g.[Name] = @gameName) AS NestedQuery
	 WHERE [Row#] % 2 = 1
)