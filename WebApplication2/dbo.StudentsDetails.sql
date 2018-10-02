CREATE TABLE [dbo].[StudentsDetails]
(
	[Id] INT NOT NULL , 
    [Name] VARCHAR(50) NOT NULL, 
    [Subjects] VARCHAR(50) NOT NULL, 
    [MarksObtained] TINYINT NOT NULL DEFAULT 0 , 
    [MaxMarks] TINYINT NOT NULL DEFAULT 100 , 
    CONSTRAINT [PK_StudentsDetails] PRIMARY KEY ([Id]) 
)
GO

INSERT INTO [dbo].[Students]
([Name],[Subjects],[MarksObtained])
VALUES
('Student1', 'English', 98),
('Student2', 'Maths', 99),
('Student3', 'Science', 92),
('Student4', 'Social', 90)
GO