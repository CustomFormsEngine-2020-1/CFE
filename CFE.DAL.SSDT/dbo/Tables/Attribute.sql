CREATE TABLE [dbo].[Attribute] (
    [Id]          INT            IDENTITY (100, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [DisplayName] NVARCHAR (MAX) NOT NULL,
    [QuestionId]   INT            NOT NULL,
    CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attribute_Element_ElementId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Attribute_ElementId]
    ON [dbo].[Attribute]([QuestionId] ASC);

