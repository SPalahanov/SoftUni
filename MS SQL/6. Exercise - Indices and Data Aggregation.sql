USE [Gringotts]
GO

-- 01.
SELECT COUNT(*) AS [Count]
  FROM [WizzardDeposits]


-- 02.
SELECT MAX([MagicWandSize]) AS [LongestMagicWang]
  FROM [WizzardDeposits]


-- 03.
  SELECT [DepositGroup]
		,MAX([MagicWandSize]) AS [LongestMagicWang]
	FROM [WizzardDeposits]
GROUP BY [DepositGroup]


-- 04.
  SELECT TOP(2) [DepositGroup]
	FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize]) ASC


-- 05.
  SELECT [DepositGroup]
		,SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
GROUP BY [DepositGroup]


-- 06.
  SELECT [DepositGroup]
		,SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]


-- 07.
  SELECT [DepositGroup]
		,SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC


-- 08.
  SELECT [DepositGroup]
		,[MagicWandCreator]
		,MIN([DepositCharge]) AS [MinDepositCharge]
	FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]


-- 09.
WITH [AgeCounter] AS
(
	SELECT CASE
				WHEN [Age] BETWEEN 0 and 10 THEN '[0-10]'
				WHEN [Age] BETWEEN 11 and 20 THEN '[11-20]'
				WHEN [Age] BETWEEN 21 and 30 THEN '[21-30]'
				WHEN [Age] BETWEEN 31 and 40 THEN '[31-40]'
				WHEN [Age] BETWEEN 41 and 50 THEN '[41-50]'
				WHEN [Age] BETWEEN 51 and 60 THEN '[51-60]'
				WHEN [Age] >+ 61 THEN '[61+]'
			END AS [AgeCategory]
	FROM [WizzardDeposits] 
)

  SELECT [AgeCategory]
		,COUNT(*) AS [WizardCount]
	FROM [AgeCounter]
   WHERE [AgeCategory] IS NOT NULL
GROUP BY [AgeCategory]


-- 10.
  SELECT [FirstLetter]
	FROM
	(
		SELECT SUBSTRING([FirstName], 1, 1) AS [FirstLetter]
		  FROM [WizzardDeposits]
		 WHERE [DepositGroup] = 'Troll Chest'
	) AS [SubQuery]
GROUP BY [FirstLetter]


-- 11.
  SELECT [DepositGroup]
		,[IsDepositExpired]
		,AVG([DepositInterest])
	FROM [WizzardDeposits]
   WHERE [DepositStartDate] >= '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]


-- 12.
SELECT SUM([Host Wizard Deposit]-[Guest Wizard Deposit]) AS SumDifference
  FROM (
	   SELECT [FirstName] AS [Host Wizard]
			 ,[DepositAmount] AS [Host Wizard Deposit],
			 LEAD([FirstName]) OVER (ORDER BY [id]) AS [Guest Wizard],
			 LEAD([DepositAmount]) OVER (ORDER BY [id]) AS [Guest Wizard Deposit]
		 FROM [WizzardDeposits]
		) AS [SubQuery]


 -- Fancy Solution
SELECT A.[SumDifference]-B.[SumDifference] AS [SumDifference]
  FROM (
	  SELECT SUM([DepositAmount]) AS [SumDifference]
	  FROM [WizzardDeposits]
	  WHERE [Id] = 1
  ) AS A,
  (
	  SELECT SUM([DepositAmount]) AS [SumDifference]
	  FROM [WizzardDeposits]
	  WHERE [Id] = 162
  ) AS B


-------------------------------------------------------------------
USE [SoftUni]
GO

-- 13.
  SELECT [DepartmentID]
		,SUM([Salary])
	FROM [Employees]
GROUP BY [DepartmentID]


-- 14.
  SELECT [DepartmentID]
		,MIN([Salary]) AS [MinimumSalary]
	FROM [Employees]
	WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]

-- 15.
SELECT * INTO [RichEmployees]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE
  FROM [RichEmployees]
 WHERE [ManagerID] = 42

UPDATE [RichEmployees]
   SET [Salary] = [Salary] + 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID]
		,AVG([Salary]) AS [AverageSalary]
	FROM [RichEmployees]
GROUP BY [DepartmentID]


-- 16.
  SELECT [DepartmentID]
		,MAX([Salary]) AS [MaxSalary] 
	FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000


-- 17.
SELECT COUNT([Salary]) AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL


-- 18.
SELECT [DepartmentID]
	  ,[ThirdHighestSalary]
  FROM 
	   (
		  SELECT [DepartmentID]
				,MAX([Salary]) AS [ThirdHighestSalary] 
				,RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [SalaryRanking]
			FROM [Employees]
		GROUP BY DepartmentID, [Salary]
	   ) AS [SubQuery]
 WHERE [SubQuery].[SalaryRanking] = 3


 -- 19.
WITH [Dept. Avg. Salary] AS
(
	  SELECT [DepartmentID]
			,AVG([Salary]) AS [Department Avg. Salary]
		FROM [Employees]
	GROUP BY [DepartmentID]
)

  SELECT TOP (10)
		 e.[FirstName]
		,e.[LastName]
		,das.[DepartmentID]
	FROM [Employees] AS e
	JOIN [Dept. Avg. Salary] AS das ON das.[DepartmentID] = e.[DepartmentID]
   WHERE e.[Salary] > [Department Avg. Salary]
ORDER BY [DepartmentID]