﻿CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NULL, 
    [FormId] INT NULL FOREIGN KEY REFERENCES Form(Id), 
    [ElementId] INT NULL FOREIGN KEY REFERENCES Element(Id)
)
