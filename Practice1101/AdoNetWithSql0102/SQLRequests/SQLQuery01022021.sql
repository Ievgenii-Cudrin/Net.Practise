/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/

/*1*/
SELECT [EmployeeID]
      ,[LastName]
      ,[FirstName]
  FROM [Northwind].[dbo].[Employees]
  WHERE City = 'London'

  /*2*/
SELECT TOP 1 COUNT(Distinct [Orders].[CustomerID]) as Count_Customers
	FROM [Employees]
	JOIN [Orders]
	ON [Employees].[EmployeeID] = [Orders].[EmployeeID]
	GROUP BY [Employees].[EmployeeID]
	ORDER BY Count_Customers DESC 

  /*3*/
SELECT  [ShipCity]
      , [ShipCountry]
  FROM [Northwind].[dbo].[Orders]
  GROUP BY [ShipCity], [ShipCountry]
  HAVING COUNT([OrderID])>2

/*4*/
Select Distinct [ProductName]
	FROM [Northwind].[dbo].[Products], [Northwind].[dbo].[Categories]
	Where [UnitPrice] = 
	(SELECT MAX([UnitPrice]) 
	FROM [Northwind].[dbo].[Products], [Northwind].[dbo].[Categories] 
	Where [CategoryName] = 'Seafood');

/*6*/
SELECT [c].[ContactName]
FROM [Northwind].[dbo].[Customers] AS c
JOIN [Northwind].[dbo].[Orders] AS o ON [c].[CustomerID] = [o].[CustomerID]
WHERE EXISTS(SELECT 1 FROM [Northwind].[dbo].[Orders] WHERE [CustomerID] = [o].[CustomerID] AND [OrderDate] > DATEADD(MONTH, 6, [o].[OrderDate]))
GROUP BY [c].[ContactName]

	