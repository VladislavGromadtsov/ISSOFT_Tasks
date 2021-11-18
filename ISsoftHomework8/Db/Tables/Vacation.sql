CREATE TABLE [dbo].[Vacation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [StartDate] DATE NOT NULL CHECK (StartDate >= '2001-01-01'), 
    [EndDate] DATE NOT NULL CHECK (EndDate >= StartDate),
    [EmployeeId] UNIQUEIDENTIFIER NULL CONSTRAINT [FK_dbo_Vacation_dbo_Employee] FOREIGN KEY REFERENCES [dbo].[Employee] ([Id]) ON DELETE SET NULL,
)
