CREATE TABLE [dbo].[Attribute] (
    [Id]          INT            IDENTITY (100, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [DisplayName] NVARCHAR (MAX) NOT NULL,
    [ElementId]   INT            NOT NULL,
    CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attribute_Element_ElementId] FOREIGN KEY ([ElementId]) REFERENCES [dbo].[Element] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Attribute_ElementId]
    ON [dbo].[Attribute]([ElementId] ASC);

