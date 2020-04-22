CREATE TABLE [dbo].[AnswerResult] (
    [Id]               INT            IDENTITY (100, 1) NOT NULL,
    [Value]            NVARCHAR (MAX) NOT NULL,
    [QuestionResultId] INT            NOT NULL,
    CONSTRAINT [PK_AnswerResult] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO


