CREATE TABLE [dbo].[Attribute]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NOT NULL, 
    [DisplayName] TEXT NULL, 
    [ElementId] INT NULL FOREIGN KEY REFERENCES Element(Id)
)
