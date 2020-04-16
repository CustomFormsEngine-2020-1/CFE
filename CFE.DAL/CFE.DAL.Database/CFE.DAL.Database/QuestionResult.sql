CREATE TABLE [dbo].[QuestionResult]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [QuestionId] INT NULL FOREIGN KEY REFERENCES Question(Id), 
    [FormResultId] INT NULL FOREIGN KEY REFERENCES FormResult(Id)
)
