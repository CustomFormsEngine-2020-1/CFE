CREATE TABLE [dbo].[Form] (
    [Id]                   INT            IDENTITY (100, 1) NOT NULL,
    [Name]                 NVARCHAR (MAX) NOT NULL,
    [Description]          NVARCHAR (MAX) NULL,
    [DTCreate]             DATETIME2 (7)  NULL,
    [DTStart]              DATETIME2 (7)  NULL,
    [DTFinish]             DATETIME2 (7)  NULL,
    [IsPrivate]            BIT            NOT NULL,
    [IsAnonymity]          BIT            NOT NULL,
    [IsEditingAfterSaving] BIT            NOT NULL,
    [UserId]               NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED ([Id] ASC)
);



