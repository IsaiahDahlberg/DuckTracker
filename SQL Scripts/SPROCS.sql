Use DogTracker
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateMamaDog')
      DROP PROCEDURE CreateMamaDog
GO
CREATE PROCEDURE CreateMamaDog(
	@Name varchar(15),
	@BirthDate DateTime2,
	@Breed varchar(15),
	@Id int output
)
AS
BEGIN
	INSERT INTO MamaDog(Name,BirthDate,Breed)
		VALUES(@Name,@BirthDate,@Breed)
		SET @Id = SCOPE_IDENTITY();
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllMamaDogs')
      DROP PROCEDURE GetAllMamaDogs
GO
CREATE PROCEDURE GetAllMamaDogs
AS
BEGIN
	Select DISTINCT
	    m.MamaDogId MamaDogId,
		m.Name [Name],
		m.Breed Breed,
		m.BirthDate BirthDate,
	    (Select SUM(Litter.PuppyCount) PuppyCount FROM Litter INNER JOIN MamaDog ON Litter.MamaDogId = MamaDog.MamaDogId  WHERE Litter.MamaDogId = m.MamaDogId) PuppyCount,
		(Select Count(*) LitterCount FROM Litter INNER JOIN MamaDog ON Litter.MamaDogId = MamaDog.MamaDogId  WHERE Litter.MamaDogId = m.MamaDogId) LitterCount
	FROM MamaDog m
	LEFT JOIN Litter ON Litter.MamaDogId = m.MamaDogId
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMamaDogById')
      DROP PROCEDURE GetMamaDogById
GO
CREATE PROCEDURE GetMamaDogById
	@MamaDogId int
AS
BEGIN
	Select DISTINCT
	    m.MamaDogId MamaDogId,
		m.Name [Name],
		m.Breed Breed,
		m.BirthDate BirthDate,
	    (Select SUM(Litter.PuppyCount) PuppyCount FROM Litter INNER JOIN MamaDog ON Litter.MamaDogId = MamaDog.MamaDogId  WHERE Litter.MamaDogId = m.MamaDogId) PuppyCount,
		(Select Count(*) LitterCount FROM Litter INNER JOIN MamaDog ON Litter.MamaDogId = MamaDog.MamaDogId  WHERE Litter.MamaDogId = m.MamaDogId) LitterCount
	FROM MamaDog m
	LEFT JOIN Litter ON Litter.MamaDogId = m.MamaDogId
	WHERE m.MamaDogId = @MamaDogId
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateMamaDog')
      DROP PROCEDURE UpdateMamaDog
GO
CREATE PROCEDURE UpdateMamaDog
	@MamaDogId int,
	@Name varchar(15),
	@Breed varchar(15),
	@BirthDate datetime2
AS
BEGIN
	UPDATE MamaDog
	SET Name = @Name, Breed = @Breed, BirthDate = @BirthDate
	WHERE MamaDog.MamaDogId = @MamaDogId
END 
GO 


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteMamaDog')
      DROP PROCEDURE DeleteMamaDog
GO
CREATE PROCEDURE DeleteMamaDog
	@MamaDogId int
AS
BEGIN
	DELETE Litter
	WHERE Litter.MamaDogId = @MamaDogId	
	DELETE MamaDogNote 
	WHERE MamaDogNote.MamaDogId = @MamaDogId
	DELETE HeatPrediction
	WHERE HeatPrediction.MamaDogId = @MamaDogId
	DELETE MamaDog
	WHERE MamaDog.MamaDogId = @MamaDogId	
END 
GO 


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreatePapaDog')
      DROP PROCEDURE CreatePapaDog
GO
CREATE PROCEDURE CreatePapaDog(
	@Name varchar(15),
	@BirthDate DateTime2,
	@Breed varchar(15),
	@Id int output
)
AS
BEGIN
	INSERT INTO PapaDog(Name,BirthDate,Breed)
		VALUES(@Name,@BirthDate,@Breed)
		SET @Id = SCOPE_IDENTITY();
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllPapaDogs')
      DROP PROCEDURE GetAllPapaDogs
GO
CREATE PROCEDURE GetAllPapaDogs
AS
BEGIN
	Select DISTINCT
	    p.PapaDogId PapaDogId,
		p.Name [Name],
		p.Breed Breed,
		p.PapaDogId PapaDogId,
		p.BirthDate BirthDate,
	    (Select SUM(Litter.PuppyCount) PuppyCount FROM Litter INNER JOIN PapaDog ON Litter.PapaDogId = PapaDog.PapaDogId  WHERE Litter.PapaDogId = p.PapaDogId) PuppyCount,
		(Select Count(*) LitterCount FROM Litter INNER JOIN PapaDog ON Litter.PapaDogId = PapaDog.PapaDogId  WHERE Litter.PapaDogId = p.PapaDogId) LitterCount
	FROM PapaDog p
	LEFT JOIN Litter ON Litter.PapaDogId = p.PapaDogId
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetPapaDogById')
      DROP PROCEDURE GetPapaDogById
GO
CREATE PROCEDURE GetPapaDogById
	@PapaDogId int
AS
BEGIN
	Select DISTINCT
	    p.PapaDogId PapaDogId,
		p.Name [Name],
		p.Breed Breed,
		p.PapaDogId PapaDogId,
		p.BirthDate BirthDate,
	    (Select SUM(Litter.PuppyCount) PuppyCount FROM Litter INNER JOIN PapaDog ON Litter.PapaDogId = PapaDog.PapaDogId  WHERE Litter.PapaDogId = p.PapaDogId) PuppyCount,
		(Select Count(*) LitterCount FROM Litter INNER JOIN PapaDog ON Litter.PapaDogId = PapaDog.PapaDogId  WHERE Litter.PapaDogId = p.PapaDogId) LitterCount
	FROM PapaDog p
	LEFT JOIN Litter ON Litter.PapaDogId = p.PapaDogId
	WHERE p.PapaDogId = @PapaDogId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdatePapaDog')
      DROP PROCEDURE UpdatePapaDog
GO
CREATE PROCEDURE UpdatePapaDog
	@PapaDogId int,
	@Name varchar(15),
	@Breed varchar(15),
	@BirthDate datetime2
AS
BEGIN
	UPDATE PapaDog
	SET Name = @Name, Breed = @Breed, BirthDate = @BirthDate
	WHERE PapaDog.PapaDogId = @PapaDogId
END 
GO 


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeletePapaDog')
      DROP PROCEDURE DeletePapaDog
GO
CREATE PROCEDURE DeletePapaDog
	@PapaDogId int
AS
BEGIN
	DELETE PapaDogNote 
	WHERE PapaDogNote.PapaDogId = @PapaDogId
	DELETE PapaDog
	WHERE PapaDog.PapaDogId = @PapaDogId
END 
GO 


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CreateLitter')
      DROP PROCEDURE CreateLitter
GO
CREATE PROCEDURE CreateLitter(
	@MamaDogId int,
	@PapaDogId int,
	@BirthDate DateTime2,
	@PuppyCount tinyint,
	@Id int output
)
AS
BEGIN
	INSERT INTO Litter(MamaDogId,PapaDogId,BirthDate,PuppyCount)
		VALUES(@MamaDogId,@PapaDogId,@BirthDate,@PuppyCount)
		SET @Id = SCOPE_IDENTITY();
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
		  WHERE ROUTINE_NAME = 'GetAllLitters')
			DROP PROCEDURE GetAllLitters
GO
CREATE PROCEDURE GetAllLitters
AS
BEGIN
	SELECT 
		L.LitterId LitterId,
		L.MamaDogId MamaDogId,
		MamaDog.Name MamaDogName,
		L.PapaDogId PapaDogId,
		PapaDog.Name PapaDogName,
		L.BirthDate BirthDate,
		L.PuppyCount PuppyCount
	FROM Litter L
	INNER JOIN MamaDog ON L.MamaDogId = MamaDog.MamaDogId
	INNER JOIN PapaDog ON L.PapaDogId = PapaDog.PapaDogId
END
Go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
		  WHERE ROUTINE_NAME = 'GetRecentLitters')
			DROP PROCEDURE GetRecentLitters
GO
CREATE PROCEDURE GetRecentLitters
AS
BEGIN
	SELECT top 5
		L.LitterId LitterId,
		L.MamaDogId MamaDogId,
		MamaDog.Name MamaDogName,
		L.PapaDogId PapaDogId,
		PapaDog.Name PapaDogName,
		L.BirthDate BirthDate,
		L.PuppyCount PuppyCount
	FROM Litter L
	INNER JOIN MamaDog ON L.MamaDogId = MamaDog.MamaDogId
	INNER JOIN PapaDog ON L.PapaDogId = PapaDog.PapaDogId
	order by L.BirthDate Desc
END
Go




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
		  WHERE ROUTINE_NAME = 'GetLitterById')
			DROP PROCEDURE GetLitterById
GO
CREATE PROCEDURE GetLitterById
	@LitterId int
AS
BEGIN
	SELECT 
		L.LitterId LitterId,
		L.MamaDogId MamaDogId,
		MamaDog.Name MamaDogName,
		L.PapaDogId PapaDogId,
		PapaDog.Name PapaDogName,
		L.BirthDate BirthDate,
		L.PuppyCount PuppyCount
	FROM Litter L
	INNER JOIN MamaDog ON L.MamaDogId = MamaDog.MamaDogId
	INNER JOIN PapaDog ON L.PapaDogId = PapaDog.PapaDogId
	WHERE L.LitterId = @LitterId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
		  WHERE ROUTINE_NAME = 'GetLittersByMamaId')
			DROP PROCEDURE GetLittersByMamaId
GO
CREATE PROCEDURE GetLittersByMamaId
	@MamaDogId int
AS
BEGIN
	SELECT 
		L.LitterId LitterId,
		L.MamaDogId MamaDogId,
		MamaDog.Name MamaDogName,
		L.PapaDogId PapaDogId,
		PapaDog.Name PapaDogName,
		L.BirthDate BirthDate,
		L.PuppyCount PuppyCount
	FROM Litter L
	INNER JOIN MamaDog ON L.MamaDogId = MamaDog.MamaDogId
	INNER JOIN PapaDog ON L.PapaDogId = PapaDog.PapaDogId
	WHERE L.MamaDogId = @MamaDogId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
		  WHERE ROUTINE_NAME = 'GetLittersByPapaId')
			DROP PROCEDURE GetLittersByPapaId
GO
CREATE PROCEDURE GetLittersByPapaId
	@PapaDogId int
AS
BEGIN
	SELECT 
		L.LitterId LitterId,
		L.MamaDogId MamaDogId,
		MamaDog.Name MamaDogName,
		L.PapaDogId PapaDogId,
		PapaDog.Name PapaDogName,
		L.BirthDate BirthDate,
		L.PuppyCount PuppyCount
	FROM Litter L
	INNER JOIN MamaDog ON L.MamaDogId = MamaDog.MamaDogId
	INNER JOIN PapaDog ON L.PapaDogId = PapaDog.PapaDogId
	WHERE L.PapaDogId = @PapaDogId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'UpdateLitter')
				DROP PROCEDURE UpdateLitter
GO
CREATE PROCEDURE UpdateLitter
	@LitterId int,
	@MamaDogId int,
	@PapaDogId int,
	@BirthDate Datetime2,
	@PuppyCount tinyint
AS
BEGIN
	UPDATE Litter
	SET MamaDogId = @MamaDogId, PapaDogId = @PapaDogId, BirthDate = @BirthDate, PuppyCount = @PuppyCount
	WHERE Litter.LitterId = @LitterId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'DeleteLitter')
				DROP PROCEDURE DeleteLitter
GO
CREATE PROCEDURE DeleteLitter
	@LitterId int
AS
BEGIN
	DELETE LitterNote 
	WHERE LitterNote.LitterId = @LitterId
	DELETE Litter
	WHERE Litter.LitterId = @LitterId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'CreateMamaDogNote')
				DROP PROCEDURE CreateMamaDogNote
GO
CREATE PROCEDURE CreateMamaDogNote
	@Note varchar(255),
	@NoteTitle varchar(25),
	@MamaDogiD int,
	@Id int output
AS
BEGIN
	
	INSERT INTO MamaDogNote(Note,NoteTitle,MamaDogId)
		VALUES(@Note,@NoteTitle,@MamaDogId)	
		SET @Id = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetAllMamaDogNotes')
				DROP PROCEDURE GetAllMamaDogNotes
GO
CREATE PROCEDURE GetAllMamaDogNotes
AS
BEGIN
	SELECT 
		MamaDogNote.MamaDogNoteId MamaDogNoteId,
		MamaDogNote.MamaDogId MamaDogId,
		MamaDogNote.Note Note,
		MamaDogNote.NoteTitle NoteTitle,
		MamaDogNote.DateCreated DateCreated
	FROM MamaDogNote
	order by  MamaDogNote.DateCreated DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetRecentMamaDogNotes')
				DROP PROCEDURE GetRecentMamaDogNotes
GO
CREATE PROCEDURE GetRecentMamaDogNotes
AS
BEGIN
	SELECT top 5
		MamaDogNote.MamaDogNoteId MamaDogNoteId,
		MamaDogNote.MamaDogId MamaDogId,
		MamaDogNote.Note Note,
		MamaDogNote.NoteTitle NoteTitle,
		MamaDogNote.DateCreated DateCreated
	FROM MamaDogNote
	order by  MamaDogNote.DateCreated DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetMamaDogNoteById')
				DROP PROCEDURE GetMamaDogNoteById
GO
CREATE PROCEDURE GetMamaDogNoteById
	@MamaDogNoteId int
AS
BEGIN
	SELECT 
		MamaDogNote.MamaDogNoteId MamaDogNoteId,
		MamaDogNote.MamaDogId MamaDogId,
		MamaDogNote.Note Note,
		MamaDogNote.NoteTitle NoteTitle,
		MamaDogNote.DateCreated DateCreated
	FROM MamaDogNote
	WHERE MamaDogNote.MamaDogNoteId = @MamaDogNoteId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetMamaDogNotesByMamaId')
				DROP PROCEDURE GetMamaDogNotesByMamaId
GO
CREATE PROCEDURE GetMamaDogNotesByMamaId
	@MamaDogId int
AS
BEGIN
	SELECT 
		MamaDogNote.MamaDogNoteId MamaDogNoteId,
		MamaDogNote.MamaDogId MamaDogId,
		MamaDogNote.Note Note,
		MamaDogNote.NoteTitle NoteTitle,
		MamaDogNote.DateCreated DateCreated
	FROM MamaDogNote
	WHERE MamaDogNote.MamaDogId = @MamaDogId
	order by  MamaDogNote.DateCreated DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'UpdateMamaDogNote')
				DROP PROCEDURE UpdateMamaDogNote
GO
CREATE PROCEDURE UpdateMamaDogNote
	@MamaDogNoteId int,
	@Note varchar(255),
	@NoteTitle Varchar(25)
AS
BEGIN
	UPDATE MamaDogNote
	SET Note = @Note, NoteTitle = @NoteTitle
	WHERE MamaDogNote.MamaDogNoteId = @MamaDogNoteId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'DeleteMamaDogNote')
				DROP PROCEDURE DeleteMamaDogNote
GO
CREATE PROCEDURE DeleteMamaDogNote
	@MamaDogNoteId int
AS
BEGIN
	DELETE MamaDogNote
	WHERE MamaDogNote.MamaDogNoteId = @MamaDogNoteId
END
GO




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'CreatePapaDogNote')
				DROP PROCEDURE CreatePapaDogNote
GO
CREATE PROCEDURE CreatePapaDogNote
	@Note varchar(255),
	@NoteTitle varchar(25),
	@PapaDogId int,
	@Id int output
AS
BEGIN
	INSERT INTO PapaDogNote(Note,NoteTitle,PapaDogId)
		VALUES(@Note,@NoteTitle,@PapaDogId)
		SET @Id = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetAllPapaDogNotes')
				DROP PROCEDURE GetAllPapaDogNotes
GO
CREATE PROCEDURE GetAllPapaDogNotes
AS
BEGIN
	SELECT 
		PapaDogNote.PapaDogNoteId PapaDogNoteId,
		PapaDogNote.PapaDogId PapaDogId,
		PapaDogNote.Note Note,
		PapaDogNote.NoteTitle NoteTitle,
		PapaDogNote.DateCreated DateCreated
	FROM PapaDogNote
	order by  PapaDogNote.DateCreated DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetRecentPapaDogNotes')
				DROP PROCEDURE GetRecentPapaDogNotes
GO
CREATE PROCEDURE GetRecentPapaDogNotes
AS
BEGIN
	SELECT top 5
		PapaDogNote.PapaDogNoteId PapaDogNoteId,
		PapaDogNote.PapaDogId PapaDogId,
		PapaDogNote.Note Note,
		PapaDogNote.NoteTitle NoteTitle,
		PapaDogNote.DateCreated DateCreated
	FROM PapaDogNote
	order by  PapaDogNote.DateCreated DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetPapaDogNoteById')
				DROP PROCEDURE GetPapaDogNoteById
GO
CREATE PROCEDURE GetPapaDogNoteById
	@PapaDogNoteId int
AS
BEGIN
	SELECT 
		PapaDogNote.PapaDogNoteId PapaDogNoteId,
		PapaDogNote.PapaDogId PapaDogId,
		PapaDogNote.Note Note,
		PapaDogNote.NoteTitle NoteTitle,
		PapaDogNote.DateCreated DateCreated
	FROM PapaDogNote
	WHERE PapaDogNote.PapaDogNoteId = @PapaDogNoteId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetPapaDogNotesByPapaId')
				DROP PROCEDURE GetPapaDogNotesByPapaId
GO
CREATE PROCEDURE GetPapaDogNotesByPapaId
	@PapaDogId int
AS
BEGIN
	SELECT 
		PapaDogNote.PapaDogNoteId PapaDogNoteId,
		PapaDogNote.PapaDogId PapaDogId,
		PapaDogNote.Note Note,
		PapaDogNote.NoteTitle NoteTitle,
		PapaDogNote.DateCreated DateCreated
	FROM PapaDogNote
	WHERE PapaDogNote.PapaDogId = @PapaDogId
	order by  PapaDogNote.DateCreated DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'UpdatePapaDogNote')
				DROP PROCEDURE UpdatePapaDogNote
GO
CREATE PROCEDURE UpdatePapaDogNote
	@PapaDogNoteId int,
	@Note varchar(255),
	@NoteTitle Varchar(25)
AS
BEGIN
	UPDATE PapaDogNote
	SET Note = @Note, NoteTitle = @NoteTitle
	WHERE PapaDogNote.PapaDogNoteId = @PapaDogNoteId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'DeletePapaDogNote')
				DROP PROCEDURE DeletePapaDogNote
GO
CREATE PROCEDURE DeletePapaDogNote
	@PapaDogNoteId int
AS
BEGIN
	DELETE PapaDogNote
	WHERE PapaDogNote.PapaDogNoteId = @PapaDogNoteId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'CreateLitterNote')
				DROP PROCEDURE CreateLitterNote
GO
CREATE PROCEDURE CreateLitterNote
	@Note varchar(255),
	@NoteTitle varchar(25),
	@LitteriD int,
	@Id int output
AS
BEGIN
	INSERT INTO LitterNote(Note,NoteTitle,LitterId)
		VALUES(@Note,@NoteTitle,@LitterId)
		SET @Id = SCOPE_IDENTITY();
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetAllLitterNotes')
				DROP PROCEDURE GetAllLitterNotes
GO
CREATE PROCEDURE GetAllLitterNotes
AS
BEGIN
	SELECT 
		LitterNote.LitterNoteId LitterNoteId,
		LitterNote.LitterId LitterId,
		LitterNote.Note Note,
		LitterNote.NoteTitle NoteTitle,
		LitterNote.DateCreated DateCreated
	FROM LitterNote
	order by  LitterNote.DateCreated DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetRecentLitterNotes')
				DROP PROCEDURE GetRecentLitterNotes
GO
CREATE PROCEDURE GetRecentLitterNotes
AS
BEGIN
	SELECT top 5
		LitterNote.LitterNoteId LitterNoteId,
		LitterNote.LitterId LitterId,
		LitterNote.Note Note,
		LitterNote.NoteTitle NoteTitle,
		LitterNote.DateCreated DateCreated
	FROM LitterNote
	order by  LitterNote.DateCreated DESC
END
GO



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetLitterNoteById')
				DROP PROCEDURE GetLitterNoteById
GO
CREATE PROCEDURE GetLitterNoteById
	@LitterNoteId int
AS
BEGIN
	SELECT 
		LitterNote.LitterNoteId LitterNoteId,
		LitterNote.LitterId LitterId,
		LitterNote.Note Note,
		LitterNote.NoteTitle NoteTitle,
		LitterNote.DateCreated DateCreated
	FROM LitterNote
	WHERE LitterNote.LitterNoteId = @LitterNoteId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetLitterNotesByLitterId')
				DROP PROCEDURE GetLitterNotesByLitterId
GO
CREATE PROCEDURE GetLitterNotesByLitterId
	@LitterId int
AS
BEGIN
	SELECT 
		LitterNote.LitterNoteId LitterNoteId,
		LitterNote.LitterId LitterId,
		LitterNote.Note Note,
		LitterNote.NoteTitle NoteTitle,
		LitterNote.DateCreated DateCreated
	FROM LitterNote
	WHERE LitterNote.LitterId = @LitterId
	order by  LitterNote.DateCreated DESC
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'UpdateLitterNote')
				DROP PROCEDURE UpdateLitterNote
GO
CREATE PROCEDURE UpdateLitterNote
	@LitterNoteId int,
	@Note varchar(255),
	@NoteTitle Varchar(25)
AS
BEGIN
	UPDATE LitterNote
	SET Note = @Note, NoteTitle = @NoteTitle
	WHERE LitterNote.LitterNoteId = @LitterNoteId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'DeleteLitterNote')
				DROP PROCEDURE DeleteLitterNote
GO
CREATE PROCEDURE DeleteLitterNote
	@LitterNoteId int
AS
BEGIN
	DELETE LitterNote
	WHERE LitterNote.LitterNoteId = @LitterNoteId
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'CreateHeatPrediction')
				DROP PROCEDURE CreateHeatPrediction
GO
CREATE PROCEDURE CreateHeatPrediction
	@MamaDogId int,
	@Date DateTime2 output
AS
BEGIN
	DELETE HeatPrediction Where HeatPrediction.MamaDogId = @MamaDogId
	INSERT INTO HeatPrediction(MamaDogId ,[Date])
		VALUES(@MamaDogId,@Date)
END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetUpComingHeatPredictions')
				DROP PROCEDURE GetUpComingHeatPredictions
GO
CREATE PROCEDURE GetUpComingHeatPredictions
AS
BEGIN
	Select 
		h.MamaDogId MamaDogId,
		h.Date Date,
		m.Name MamaName

	FROM HeatPrediction H
	INNER JOIN MamaDog M  ON M.MamaDogId = H.MamaDogId
	ORDER BY h.Date ASC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
			WHERE ROUTINE_NAME = 'GetHeatPredictionByMamaDogId')
				DROP PROCEDURE GetHeatPredictionByMamaDogId
GO
CREATE PROCEDURE GetHeatPredictionByMamaDogId
	@MamaDogId int
AS
BEGIN
	Select 
		h.MamaDogId MamaDogId,
		h.Date Date,
		h.HeatPredictionId HeatPredictionId
	FROM HeatPrediction H
	WHERE H.MamaDogId = @MamaDogId
END
GO


