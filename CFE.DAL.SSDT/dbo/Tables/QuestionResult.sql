CREATE TABLE [dbo].[QuestionResult] (
    [Id]           INT IDENTITY (100, 1) NOT NULL,
    [QuestionId]   INT NOT NULL,
    [FormResultId] INT NOT NULL,
    CONSTRAINT [PK_QuestionResult] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO



GO


