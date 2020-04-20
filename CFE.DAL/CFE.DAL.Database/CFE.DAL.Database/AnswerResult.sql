CREATE TABLE [dbo].[AnswerResult]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Value] TEXT NULL, 
    [QuestionResultId] INT NULL FOREIGN KEY REFERENCES QuestionResult(Id)
)
