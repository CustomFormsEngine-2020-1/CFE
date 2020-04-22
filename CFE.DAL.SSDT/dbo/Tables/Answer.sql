CREATE TABLE [dbo].[Answer] (
    [Id]         INT            IDENTITY (100, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [QuestionId] INT            NOT NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO


