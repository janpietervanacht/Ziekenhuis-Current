USE [Ziekenhuis]
GO
 --set nocount ON; -- niet weergave van # rows selected (is sneller)
/****** Object:  StoredProcedure [dbo].[uspCreate3ConsultsPerClient]    Script Date: 19/11/2020 13:38:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[uspCreate3ConsultsPerClient]

as

begin
	declare
		@id int,
		@clientNumber int,
		@firstName varchar(MAX)
	
	delete from Consults

	declare client_cursor scroll cursor for
		select
			c.Id, c.ClientNumber, c.FirstName
			  from Clients c

	open client_cursor
	fetch next from client_cursor into @id, @clientNumber, @firstName
	while @@FETCH_STATUS = 0
	begin
		Print 'Klant met nummer: ' + cast(@clientNumber as varchar(6)) 

		insert into dbo.Consults 
		-- Primary key niet includen!
			(ActionCode, ClientId, DoctorId, ConsultDate, 
			ConsultDescr, CommentForDoctor, Price ) 
			values('A', @id, 1, '19-Nov-2020',  
			@firstName + ' - Consult 1' , 
			@firstName + ' - Doctor Comment 1', 45.09 ) 

			insert into dbo.Consults 
		-- Primary key niet includen!
			(ActionCode, ClientId, DoctorId, ConsultDate, 
			ConsultDescr, CommentForDoctor, Price ) 
			values('A', @ID, 1, '19-Nov-2020',  
			@firstname + ' - Consult 2' , 
			@firstName + ' - Doctor Comment 2', 45.09 ) 

			insert into dbo.Consults 
		-- Primary key niet includen!
			(ActionCode, ClientId, DoctorId, ConsultDate, 
			ConsultDescr, CommentForDoctor, Price ) 
			values('A', @id, 1, '19-Nov-2020',  
			@firstName + ' - Consult 3' , 
			@firstName + ' - Doctor Comment 3', 45.09 ) 

		fetch next from client_cursor into @id, @clientNumber, @firstName
	end; 

	close client_cursor;
	deallocate client_cursor 
end
 