CREATE TABLE [dbo].[AnswerResult] (
    [Id]               INT            IDENTITY (100, 1) NOT NULL,
    [Value]            NVARCHAR (MAX) NOT NULL,
    [QuestionResultId] INT            NOT NULL,
    CONSTRAINT [PK_AnswerResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AnswerResult_QuestionResult_QuestionResultId] FOREIGN KEY ([QuestionResultId]) REFERENCES [dbo].[QuestionResult] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AnswerResult_QuestionResultId]
    ON [dbo].[AnswerResult]([QuestionResultId] ASC);

