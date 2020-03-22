CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NULL, 
    [QuestionId] INT NULL FOREIGN KEY REFERENCES Question(Id)
)
