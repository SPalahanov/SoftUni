USE [SoftUni]
GO

-- 01.
  SELECT TOP(5)
		 e.[EmployeeID],
		 e.[JobTitle],
		 e.[AddressID],
		 a.[AddressText]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
ORDER BY [AddressID] ASC


-- 02.
  SELECT TOP(50)
		 e.[FirstName],
		 e.[LastName],
		 t.[Name] AS [Town],
		 a.[AddressText]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
	JOIN [Towns] AS t ON a.TownID = t.TownID
ORDER BY [FirstName] ASC, [LastName]


-- 03.
  SELECT e.[EmployeeId],
		 e.[FirstName],
		 e.[LastName],
		 d.[Name] AS [DepartmentName]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID]


-- 04.
  SELECT TOP(5)
		 e.[EmployeeId],
		 e.[FirstName],
		 e.[Salary],
		 d.[Name] AS [DepartmentName]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE [Salary] > 15000
ORDER BY e.[DepartmentID] ASC


-- 05.
  SELECT TOP(3)
		 e.[EmployeeId],
		 e.[FirstName]
	FROM [Employees] AS e
   WHERE e.[EmployeeID] NOT IN 
   (
		SELECT DISTINCT [EmployeeID] 
				   FROM [EmployeesProjects]
   )
ORDER BY e.[EmployeeID] ASC


-- 06.
  SELECT e.[FirstName],
		 e.[LastName],
		 e.[HireDate],
		 d.[Name] AS [DeptName]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE [HireDate] > '01-01-1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.[HireDate] ASC


-- 07.
  SELECT TOP(5)
		 e.[EmployeeId],
		 e.[FirstName],
		 p.[Name] AS [ProjectName]
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
   WHERE CONVERT(varchar(8), p.[StartDate], 112) > '13-08-2002' AND P.[EndDate] IS NULL
ORDER BY e.[EmployeeID] ASC


-- 08.
  SELECT e.[EmployeeId],
		 e.[FirstName],
		 [ProjectName] =
		 CASE 
			WHEN DATEPART(YEAR, p.[StartDate]) >= 2005 THEN NULL
			ELSE p.[Name]
		 END
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
   WHERE e.[EmployeeID] = 24


-- 09.
  SELECT e.[EmployeeId],
		 e.[FirstName],
		 e.[ManagerID],
		 m.[FirstName] AS [MenagerName]
	FROM [Employees] AS e
	JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
   WHERE e.[ManagerID] IN (3, 7)
ORDER BY e.[EmployeeID] ASC


-- 10.
  SELECT TOP(50)
		 e.[EmployeeId],
		 CONCAT_WS(' ', e.[FirstName], e.[LastName]) AS [EmployeeName],
		 CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [ManagerName],
		 d.[Name] AS [DepartmentName]
	FROM [Employees] AS e
	JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
	JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID] ASC

-- 10.
  SELECT TOP(1)
		 AVG(e.[Salary]) [MinAverageSalary]
	from [Employees] AS e
GROUP BY e.[DepartmentID]
ORDER BY [MinAverageSalary]


------------------------------
USE [Geography]
GO

-- 12.
 -- Solution 1 - Search by Country Name
  SELECT mc.[CountryCode],
		 m.[MountainRange],
		 p.[PeakName],
		 p.[Elevation]
	FROM [Countries] AS c
	JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
	JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
   WHERE c.[CountryName] = 'Bulgaria' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

 -- Solution 2 - Search by Country Cade
 SELECT mc.[CountryCode],
		 m.[MountainRange],
		 p.[PeakName],
		 p.[Elevation]
	FROM [MountainsCountries] AS mc
	JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
	JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]
   WHERE mc.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC


-- 13.
 -- Solution 1 - Search by Country Name
  SELECT c.[CountryCode], 
		 COUNT(m.[MountainRange]) AS [MountainRanges]
	FROM [Countries] AS c
	JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
   WHERE c.[CountryName] IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.[CountryCode]

-- Solution 2 - Search by Country Cade
  SELECT mc.[CountryCode], 
		 COUNT(m.[MountainRange]) AS [MountainRanges]
	FROM [MountainsCountries] AS mc
	JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
   WHERE mc.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY mc.[CountryCode]


-- 14.
SELECT TOP (5)
	c.[CountryName],
	r.[RiverName]
  FROM [Countries] AS c
	LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
WHERE c.ContinentCode = 'AF'
ORDER BY c.[CountryName] ASC



--15.
WITH [CurrencyCounter] As
(
	  SELECT [ContinentCode],
			 [CurrencyCode],
			 COUNT([CurrencyCode]) AS [CurrencyUsage],
			 DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY COUNT([CurrencyCode]) DESC) AS [CurrencyRank]
		FROM [Countries]
	GROUP BY [ContinentCode], [CurrencyCode]
)

  SELECT [ContinentCode],
		 [CurrencyCode],
		 [CurrencyUsage]
	FROM [CurrencyCounter]
   WHERE [CurrencyRank] = 1 AND [CurrencyUsage] > 1
ORDER BY [ContinentCode]


--16.
SELECT COUNT(*) AS [Count]
  FROM [Countries]
WHERE [CountryCode] NOT IN
	  (SELECT DISTINCT [CountryCode] FROM [MountainsCountries])


--17.
WITH PeaksRankedByElevationAndRiversRankedByLength As
(
	   SELECT c.[CountryName],
			  p.[Elevation],
			  r.[Length],
			  DENSE_RANK() OVER
					(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank],
			  DENSE_RANK() OVER
					(PARTITION BY c.[CountryName] ORDER BY r.[Length] DESC) AS [RiverRank]
		 FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId]
	LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]

	LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
)

  SELECT TOP (5)
		 [CountryName],
		 ISNULL([Elevation], NULL) AS [HighestPeakElevation],
		 ISNULL([Length], NULL) AS [LongestRiverLength]
	FROM PeaksRankedByElevationAndRiversRankedByLength
   WHERE [PeakRank] = 1 AND [RiverRank] = 1
ORDER BY [Elevation] DESC, [Length] DESC


-- 18.	
WITH PeaksRankedByElevation As
(
	   SELECT c.[CountryName] ,
			  p.[PeakName],
			  p.[Elevation],
			  m.[MountainRange],
			  DENSE_RANK() OVER
					(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank]
		 FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId]
	LEFT JOIN [Peaks] AS p ON m.[Id] = p.[MountainId]  
)

  SELECT TOP (5)
		 [CountryName] AS [Country],
		 ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
		 ISNULL([Elevation], 0) AS [Highest Peak Elevation],
		 ISNULL([MountainRange], '(no mountain)') AS [Mountain]
	FROM PeaksRankedByElevation
   WHERE [PeakRank] = 1
ORDER BY [CountryName]





