CREATE TABLE [dbo].[AttributeResult]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Value] TEXT NOT NULL, 
    [AttributeId] INT NOT NULL FOREIGN KEY REFERENCES Attribute(Id)
)
