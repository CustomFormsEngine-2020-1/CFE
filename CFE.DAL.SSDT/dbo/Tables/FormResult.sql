CREATE TABLE [dbo].[FormResult] (
    [Id]       INT            IDENTITY (100, 1) NOT NULL,
    [DTResult] DATETIME2 (7)  NOT NULL,
    [FormId]   INT            NOT NULL,
    [UserId]   INT            NOT NULL,
    [UserId1]  NVARCHAR (450) NULL,
    CONSTRAINT [PK_FormResult] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FormResult_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_FormResult_Form_FormId] FOREIGN KEY ([FormId]) REFERENCES [dbo].[Form] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FormResult_FormId]
    ON [dbo].[FormResult]([FormId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FormResult_UserId1]
    ON [dbo].[FormResult]([UserId1] ASC);

