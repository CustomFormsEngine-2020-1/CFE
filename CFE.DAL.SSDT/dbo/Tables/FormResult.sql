CREATE TABLE [dbo].[FormResult] (
    [Id]       INT           IDENTITY (100, 1) NOT NULL,
    [DTResult] DATETIME2 (7) NOT NULL,
    [FormId]   INT           NOT NULL,
    [UserId]   NVARCHAR(MAX)           NOT NULL,
    CONSTRAINT [PK_FormResult] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO



GO


