/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP 1000 [UserId]
      ,[FirstName]
      ,[SecondName]
      ,[LastName]
      ,[SecondLastName]
      ,[Code]
      ,[Email]
      ,[UserName]
      ,[Password]
      ,[AdmissionDate]
      ,[Status]
      ,[Perfil]
  FROM [TiendaDB].[dbo].[UserAccount]

  select * from [TiendaDB].agenda.agendatelefonica



--  alter table [TiendaDB].[dbo].[UserAccount] add Perfil int 