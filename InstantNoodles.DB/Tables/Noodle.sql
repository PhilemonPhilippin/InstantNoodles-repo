﻿CREATE TABLE [dbo].[Noodle]
(
	[NoodleID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Meat] NVARCHAR(50) NOT NULL,
	[Vegetable] NVARCHAR(50) NOT NULL,
	[Sauce] BIT NOT NULL
)
