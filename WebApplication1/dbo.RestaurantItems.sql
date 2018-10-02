USE [Zeedb]
CREATE TABLE [dbo].[RestaurantItems]
(
	[Id] TINYINT NOT NULL IDENTITY(101, 1), 

    [Name] VARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL 
		CONSTRAINT DF_RestaurantItems_Price DEFAULT (0.0), 
    CONSTRAINT [PK_RestaurantItems] PRIMARY KEY ([Id]) 
)
GO

INSERT INTO [dbo].[RestaurantItems]
([Name], [Price])
VALUES
	('Idly', 20),
	('Vada', 15),
	('Biryani', 120),
	('Masala Dosa', 50),
	('Roti Curry', 50)
GO