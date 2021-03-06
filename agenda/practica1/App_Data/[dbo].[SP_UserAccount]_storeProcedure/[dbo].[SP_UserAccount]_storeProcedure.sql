USE [TiendaDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_UserAccount]    Script Date: 11/11/2017 23:05:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_UserAccount]
	@Opcion as numeric(10) = 0,
	@UserName as varchar(100) = NULL,
	@Password as varchar(100) = NULL,
	@codigo as numeric(10) = null output,
	@mensaje as varchar(8000) = null output
AS
BEGIN
	SET NOCOUNT ON;
	if @Opcion = 0 begin
		if (SELECT count(*)  --[UserId],[FirstName],[SecondName],[LastName],[Code],[Email],[UserName],[Password],[AdmissionDate],[Status]
		FROM [UserAccount]
		where [UserName] = @UserName
		and [Password] = @Password) > 0 begin
			set @codigo = 0;
			set @mensaje = 'OK';
		end
		else begin
			set @codigo = 9999;
			set @mensaje = 'No existe usuario, compruebe sus credenciales';
		end
	end
	
	if @Opcion = 1 begin
		SELECT [UserId],[FirstName],[SecondName],[LastName],([FirstName] + ' ' + [SecondName] + ' ' + [LastName]) CompleteName,
			   [Code],[Email],[UserName],[Password],[AdmissionDate],[Status]
		FROM [UserAccount]
		order by [UserId];
	end

	if @Opcion = 2 begin
		SELECT [UserId],[FirstName],[SecondName],[LastName],([FirstName] + ' ' + [SecondName] + ' ' + [LastName]) CompleteName,
			   [Code],[Email],[UserName],[Password],[AdmissionDate],[Status]
		FROM [UserAccount]
		where [UserName] = @UserName
		and [Password] = @Password;
	end
END

/*
declare @codigo as numeric(10),@mensaje as varchar(8000)
exec [dbo].[SP_UserAccount] 0,'eamora','P@ssw0rd',@codigo output,@mensaje output
print @codigo
print @mensaje

exec [dbo].[SP_UserAccount] 1

exec [dbo].[SP_UserAccount] 2,'eamora','P@ssw0rd'
*/
