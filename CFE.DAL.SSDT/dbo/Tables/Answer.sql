CREATE TABLE [dbo].[Answer] (
    [Id]         INT            IDENTITY (100, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [QuestionId] INT            NOT NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Answer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Answer_QuestionId]
    ON [dbo].[Answer]([QuestionId] ASC);

