CREATE TABLE [dbo].[ScheduledMeals]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
	[MealPlanId] BIGINT NOT NULL,
    [MealId] BIGINT NOT NULL, 
    [ScheduledDateTime] DATETIME NOT NULL, 
	[version] ROWVERSION NOT NULL,
    CONSTRAINT [FK_ScheduledMeals_MealPlans] FOREIGN KEY ([MealPlanId]) REFERENCES [MealPlans]([Id]), 
    CONSTRAINT [FK_ScheduledMeals_Meals] FOREIGN KEY ([MealId]) REFERENCES [Meals]([Id])
)
