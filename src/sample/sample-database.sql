CREATE TABLE Teacher (
	[Id] INT NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(256) NOT NULL,
	[LastName] NVARCHAR(256) NOT NULL,
	[CreatedDate] DATETIME2(1) NOT NULL
)

CREATE TABLE Classroom (
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[GradeLevel] INT NOT NULL,
	[CreatedDate] DATETIME2(1) NOT NULL,

	[TeacherId] INT NULL

	CONSTRAINT [FK_Classroom_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES Teacher([Id])
)


INSERT INTO Teacher VALUES (1, 'Frank', 'Frankfort', GETUTCDATE())
INSERT INTO Teacher VALUES (2, 'Sarah', 'Sarahson', GETUTCDATE())

INSERT INTO Classroom VALUES (1, '503', 5, GETUTCDATE(), 1)