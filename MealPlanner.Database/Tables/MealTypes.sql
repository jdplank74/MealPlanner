CREATE TABLE [dbo].[MealTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
	[Code] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(80) NOT NULL, 
	[IsActive] bit NOT NULL  ,
    [version] ROWVERSION NOT NULL
)
