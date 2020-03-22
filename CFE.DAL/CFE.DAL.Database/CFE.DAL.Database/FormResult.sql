CREATE TABLE [dbo].[FormResult]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DTResult] DATETIME NULL, 
    [FormId] INT NULL FOREIGN KEY REFERENCES Form(Id), 
    [UserId] INT NULL 
)
