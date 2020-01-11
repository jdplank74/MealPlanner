CREATE TABLE [dbo].[MealPlans]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(80) NOT NULL,
    [UserId] INT NOT NULL,
	[StartDate] datetime NOT NULL,
	[EndDate] datetime NOT NULL,
	[version] rowversion NOT NULL, 
    CONSTRAINT [FK_MealPlans_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
