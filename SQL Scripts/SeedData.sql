USE DogTracker
Go

DELETE FROM Litter  WHERE LitterId <= 5 
DELETE FROM MamaDog  WHERE MamaDogId <= 5
DELETE FROM PapaDog  WHERE PapaDogId <= 5

SET IDENTITY_INSERT MamaDog ON

INSERT INTO MamaDog (MamaDogId, BirthDate, Breed, Name)
	VALUES (1, '2014-3-1', 'Dasch Hound', 'Sparkles'),
		   (2, '2016-6-1', 'Poodle', 'Zues'),
		   (3, '2017-4-5', 'Lab', 'Cat')

SET IDENTITY_INSERT MamaDog OFF


SET IDENTITY_INSERT PapaDog ON

INSERT INTO PapaDog (PapaDogId, BirthDate, Breed, Name)
	VALUES (1, '2016-8-9', 'Poodle', 'Sir Barks'),
		   (2, '2012-4-8', 'Germen Sheperd', 'Sif Woofertin'),
		   (3, '2014-6-1', 'Horse', 'Fred')

SET IDENTITY_INSERT PapaDog OFF


SET IDENTITY_INSERT Litter ON

INSERT INTO Litter(LitterId, BirthDate, MamaDogId, PapaDogId, PuppyCount)
	VALUES (1, '2016-8-9', 1, 1, 7),
	       (2, '2016-8-9', 1, 2, 5),
		   (3, '2016-8-9', 3, 3, 9),
		   (4, '2016-8-9', 2, 1, 3),
		   (5, '2016-8-9', 2, 2, 5)

SET IDENTITY_INSERT Litter OFF


