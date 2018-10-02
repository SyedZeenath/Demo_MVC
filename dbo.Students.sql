CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL , 
    [Name] VARCHAR(50) NOT NULL, 
    [Subjects] VARCHAR(50) NOT NULL, 
    [MarksObtained] TINYINT NOT NULL DEFAULT 0 , 
    [MaxMarks] TINYINT NOT NULL DEFAULT 100 , 
    CONSTRAINT [PK_Students] PRIMARY KEY ([Id]) 
)
