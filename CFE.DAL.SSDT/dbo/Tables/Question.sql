CREATE TABLE [dbo].[Question] (
    [Id]        INT            IDENTITY (100, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [FormId]    INT            NOT NULL,
    [ElementId] INT            NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_Element_ElementId] FOREIGN KEY ([ElementId]) REFERENCES [dbo].[Element] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Question_Form_FormId] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Question_ElementId]
    ON [dbo].[Question]([ElementId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Question_FormId]
    ON [dbo].[Question]([FormId] ASC);

