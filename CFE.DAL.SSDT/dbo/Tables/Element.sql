CREATE TABLE [dbo].[Element] (
    [Id]          INT            IDENTITY (100, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Element] PRIMARY KEY CLUSTERED ([Id] ASC)
);

