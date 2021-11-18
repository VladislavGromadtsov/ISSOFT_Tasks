CREATE TABLE [dbo].[Training]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(64) NOT NULL, 
    [StartDate] DATE NOT NULL CHECK (StartDate >= '2001-01-01'), 
    [EndDate] DATE NOT NULL CHECK (EndDate > StartDate), 
    [Description] NVARCHAR(MAX) NULL,
)
