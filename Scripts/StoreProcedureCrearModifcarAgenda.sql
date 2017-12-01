USE [TiendaDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 28/11/2017 20:43:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter Procedure [Agenda].[CrearModificarAgenda]    
(    
     @TipoOperacion as int = 0,
	 @Id as int = 0,
	 @nombres [varchar](100) NULL,
	 @apellidos [varchar](100) NULL,
	 @extension [varchar](100) NULL,
	 @email [varchar](200) NULL,
	 @sucursal [int] NULL,
	 @direccion [varchar](1000) NULL,
	 @pbx [varchar](100) NULL,
	 @fax [varchar](100) NULL,
	 @lineaCelular [varchar](100) NULL,
	 @lineaCelularAdicional [varchar](100) NULL,
	 @estado int = 1
)    
as     
Begin    
		if @TipoOperacion = 0 begin
			INSERT INTO [AGENDA].[AgendaTelefonica]
           ([nombres]
           ,[apellidos]
           ,[extension]
           ,[email]
           ,[sucursal]
           ,[direccion]
           ,[pbx]
           ,[fax]
           ,[lineaCelular]
           ,[lineaCelularAdicional]
           )
     VALUES
           (@nombres
           ,@apellidos
           ,@extension
           ,@email
           ,@sucursal
           ,@direccion
           ,@pbx
           ,@fax
           ,@lineaCelular
           ,@lineaCelularAdicional
           )
		end
		
		if @TipoOperacion = 1 begin
			UPDATE [AGENDA].[AgendaTelefonica]
		   SET [nombres] = @nombres
			  ,[apellidos] = @apellidos
			  ,[extension] = @extension
			  ,[email] = @email
			  ,[sucursal] = @sucursal
			  ,[direccion] = @direccion
			  ,[pbx] = @pbx
			  ,[fax] = @fax
			  ,[lineaCelular] = @lineaCelular
			  ,[lineaCelularAdicional] = @lineaCelularAdicional
			  ,[estado] = @estado
		 WHERE [id] = @Id
		end
End  


/*
exec [Agenda].[ConsultarAgenda]
*/
