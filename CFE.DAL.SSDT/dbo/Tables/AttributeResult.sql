CREATE TABLE [dbo].[AttributeResult] (
    [Id]          INT            IDENTITY (100, 1) NOT NULL,
    [Value]       NVARCHAR (MAX) NOT NULL,
    [AttributeId] INT            NOT NULL,
    CONSTRAINT [PK_AttributeResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AttributeResult_Attribute_AttributeId] FOREIGN KEY ([AttributeId]) REFERENCES [dbo].[Attribute] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AttributeResult_AttributeId]
    ON [dbo].[AttributeResult]([AttributeId] ASC);

