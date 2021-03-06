USE [Ziekenhuis]
GO
/****** Object:  StoredProcedure [dbo].[uspCreate3ConsultsPerClient]    Script Date: 19/11/2020 13:38:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[uspCreate3ConsultsPerClient]

as

begin

	DECLARE @Max INT, @Counter INT, 
	@ClientFirstName nvarchar(MAX),
	@ClientId int

	CREATE TABLE #TempTable
    (
        ROWID INT IDENTITY(1, 1) PRIMARY KEY,
		ClientId int,
		DoctorId int,
		ClientFirstName nvarchar(max)
	)

	insert into #TempTable
	(
		ClientId,
		DoctorId,
		ClientFirstName 
	)
		select
			Id,
			DoctorId,
			FirstName
		from Clients
		order by Id 

SET @Counter = 1

    SELECT @Max = COUNT(*) FROM #TempTable  

    WHILE(@Counter <= @Max)

	BEGIN
			
		SELECT
			@ClientFirstName = ClientFirstName, @ClientId = ClientId 
			FROM #TempTable WHERE ROWID = @Counter  

		insert into dbo.Consults 
		-- Primary key niet includen!
			(ActionCode, ClientId, DoctorId, ConsultDate, 
			ConsultDescr, CommentForDoctor, Price ) 
			values('A', @ClientId, 1, '19-Nov-2020',  
			@ClientFirstName + ' - Consult 1' , 
			@ClientFirstName + ' - Doctor Comment 1', 45.09 ) 

			insert into dbo.Consults 
		-- Primary key niet includen!
			(ActionCode, ClientId, DoctorId, ConsultDate, 
			ConsultDescr, CommentForDoctor, Price ) 
			values('A', @ClientId, 1, '19-Nov-2020',  
			@ClientFirstName + ' - Consult 2' , 
			@ClientFirstName + ' - Doctor Comment 2', 45.09 ) 

			insert into dbo.Consults 
		-- Primary key niet includen!
			(ActionCode, ClientId, DoctorId, ConsultDate, 
			ConsultDescr, CommentForDoctor, Price ) 
			values('A', @ClientId, 1, '19-Nov-2020',  
			@ClientFirstName + ' - Consult 3' , 
			@ClientFirstName + ' - Doctor Comment 3', 45.09 ) 

		SET @Counter = @Counter + 1
	end   

		-- Algemene admin tempdb.. opruimen temp tabel: 
	IF(OBJECT_ID('tempdb..#TempTable') IS NOT NULL)
    BEGIN
        DROP TABLE #TempTable
    END
end
 