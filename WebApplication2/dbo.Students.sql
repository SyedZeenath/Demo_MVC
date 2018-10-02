CREATE TABLE [dbo].[Students] (
    [Id]            INT          NOT NULL IDENTITY,
    [Name]          VARCHAR (50) NOT NULL,
    [Subjects]      VARCHAR (50) NOT NULL,
    [MarksObtained] TINYINT      DEFAULT ((0)) NOT NULL,
    [MaxMarks]      TINYINT      DEFAULT ((100)) NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([Id] ASC)
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