USE [Ziekenhuis]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE uspUpdateClientDatabase
as

begin
	update dbo.Clients set 
		FirstName = 'Voornaam client ' + cast(ClientNumber as varchar(6)),
		LastName =  'Achternaam client ' + cast(ClientNumber as varchar(6)),
		Street = 'Straat client ' + cast(ClientNumber as varchar(6)),
		City = 'Stad client ' + cast(ClientNumber as varchar(6)),
		CommentForDoctor = 'CommentForDoctor client ' + cast(ClientNumber as varchar(6)) 
end
 