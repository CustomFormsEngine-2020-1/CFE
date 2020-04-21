CREATE TABLE [dbo].[QuestionResult] (
    [Id]           INT IDENTITY (100, 1) NOT NULL,
    [QuestionId]   INT NOT NULL,
    [FormResultId] INT NOT NULL,
    CONSTRAINT [PK_QuestionResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QuestionResult_FormResult_FormResultId] FOREIGN KEY ([FormResultId]) REFERENCES [dbo].[FormResult] ([Id]),
    CONSTRAINT [FK_QuestionResult_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_QuestionResult_FormResultId]
    ON [dbo].[QuestionResult]([FormResultId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_QuestionResult_QuestionId]
    ON [dbo].[QuestionResult]([QuestionId] ASC);

