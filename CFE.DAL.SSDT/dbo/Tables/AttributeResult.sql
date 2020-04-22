CREATE TABLE [dbo].[AttributeResult] (
    [Id]          INT            IDENTITY (100, 1) NOT NULL,
    [Value]       NVARCHAR (MAX) NOT NULL,
    [AttributeId] INT            NOT NULL,
    CONSTRAINT [PK_AttributeResult] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO


