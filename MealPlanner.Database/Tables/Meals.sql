CREATE TABLE [dbo].[Meals]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(80) NOT NULL, 
    [Description] VARCHAR(200) NOT NULL, 
    [OwnerId] INT NOT NULL,
	CONSTRAINT [FK_Meals_Users] FOREIGN KEY ([OwnerId]) REFERENCES [Users]([Id]), 
	[MealTypeId] INT NOT NULL,
    [version] ROWVERSION NOT NULL, 
    CONSTRAINT [FK_Meals_MealTypes] FOREIGN KEY ([MealTypeId]) REFERENCES [MealTypes]([Id])
)
