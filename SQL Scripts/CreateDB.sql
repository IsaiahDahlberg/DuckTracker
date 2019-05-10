use master
go

if exists (select * from sys.databases where name = N'DogTracker')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DogTracker';
	ALTER DATABASE DogTracker SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE DogTracker;

end
GO

CREATE Database DogTracker
GO

USE DogTracker
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='LitterNote')
	DROP TABLE LitterNote
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Litter')
	DROP TABLE Litter
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PapaDogNote')
	DROP TABLE PapaDogNote
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PapaDog')
	DROP TABLE PapaDog
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='MamaDogNote')
	DROP TABLE MamaDogNote
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='MamaDog')
	DROP TABLE MamaDog
GO


CREATE TABLE MamaDog(
	MamaDogId int primary key identity(1,1) not null,
	[Name] varchar(15) not null,
	BirthDate DateTime2 not null,
	Breed varchar(15) not null
)
GO

CREATE TABLE MamaDogNote(
	MamaDogNoteId int primary key identity(1,1) not null,
	MamaDogId int foreign key references MamaDog(MamaDogId) not null,
	NoteTitle varchar(25) not null,
	Note varchar(255) not null,
	DateCreated DATETIME NOT NULL DEFAULT (GETDATE())
)

CREATE TABLE PapaDog(
	PapaDogId int primary key identity(1,1) not null,
	[Name] varchar(15) not null,
	BirthDate DateTime2 not null,
	Breed varchar(15) not null
)
GO

CREATE TABLE PapaDogNote(
	PapaDogNoteId int primary key identity(1,1) not null,
	PapaDogId int foreign key references PapaDog(PapaDogId) not null,
	NoteTitle varchar(25) not null,
	Note varchar(255) not null,
	DateCreated DATETIME NOT NULL DEFAULT (GETDATE())
)

CREATE TABLE Litter(
	LitterId int primary key identity(1,1) not null,
	MamaDogId int foreign key references MamaDog(MamaDogId) not null,
	PapaDogId int foreign key references PapaDog(PapaDogId) not null,
	BirthDate DateTime2 not null,
	PuppyCount TINYINT not null
)

CREATE TABLE LitterNote(
	LitterNoteId int primary key identity(1,1) not null,
	LitterId int foreign key references Litter(LitterId) not null,
	NoteTitle varchar(25) not null,
	Note varchar(255) not null,
	DateCreated DATETIME NOT NULL DEFAULT (GETDATE())
)