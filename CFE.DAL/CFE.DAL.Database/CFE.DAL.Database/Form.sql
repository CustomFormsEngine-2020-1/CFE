CREATE TABLE [dbo].[Form]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NULL, 
    [Description] TEXT NULL, 
    [DTCreate] DATETIME NULL, 
    [DTStart] DATETIME NULL, 
    [DTFinish] DATETIME NULL, 
    [IsPrivate] BIT NULL, 
    [IsAnonymity] BIT NULL, 
    [IsEditingAfterSaving] BIT NULL, 
    [UserId] INT NULL
)
