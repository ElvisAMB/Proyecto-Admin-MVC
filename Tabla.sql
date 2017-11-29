USE [CONFIANZA_DESARROLLO]
GO

/****** Object:  Table [AGENDA].[AgendaTelefonica]    Script Date: 28/11/2017 18:58:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [AGENDA].[AgendaTelefonica](
	[nombres] [varchar](100) NULL,
	[apellidos] [varchar](100) NULL,
	[extension] [varchar](100) NULL,
	[estado] [int] NULL,
	[sucursal] [int] NULL,
	[direccion] [varchar](1000) NULL,
	[pbx] [varchar](100) NULL,
	[fax] [varchar](100) NULL,
	[lineaCelular] [varchar](100) NULL,
	[lineaCelularAdicional] [varchar](100) NULL,
	[fechaCreacion] [datetime] NULL DEFAULT (getdate())
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


