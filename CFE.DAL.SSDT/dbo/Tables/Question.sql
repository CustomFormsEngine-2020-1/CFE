CREATE TABLE [dbo].[Question] (
    [Id]        INT            IDENTITY (100, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [FormId]    INT            NOT NULL,
    [ElementId] INT            NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO



GO


