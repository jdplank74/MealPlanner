CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [Middlename] VARCHAR(50) NULL, 
    [Email] VARCHAR(254) NOT NULL, 
    [Username] VARCHAR(254) NULL
)
