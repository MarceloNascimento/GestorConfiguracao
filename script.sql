/*    ==Parâmetros de Script==

    Versão do Servidor de Origem : SQL Server 2016 (13.0.4206)
    Edição do Mecanismo de Banco de Dados de Origem : Microsoft SQL Server Enterprise Edition
    Tipo do Mecanismo de Banco de Dados de Origem : SQL Server Autônomo

    Versão do Servidor de Destino : SQL Server 2017
    Edição de Mecanismo de Banco de Dados de Destino : Microsoft SQL Server Standard Edition
    Tipo de Mecanismo de Banco de Dados de Destino : SQL Server Autônomo
*/
USE [ClientDB]
GO
/****** Object:  Table [dbo].[Configuracao]    Script Date: 15/10/2017 21:44:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuracao](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](200) NULL,
	[valor] [nvarchar](50) NULL,
	[perfil_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 15/10/2017 21:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/10/2017 21:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](200) NULL,
	[nickName] [nvarchar](50) NULL,
	[perfil_id] [int] NULL,
	[senha] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Configuracao]  WITH CHECK ADD  CONSTRAINT [FK_Perfil_Conf] FOREIGN KEY([perfil_id])
REFERENCES [dbo].[Perfil] ([codigo])
GO
ALTER TABLE [dbo].[Configuracao] CHECK CONSTRAINT [FK_Perfil_Conf]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_perfil_users] FOREIGN KEY([perfil_id])
REFERENCES [dbo].[Perfil] ([codigo])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_perfil_users]
GO
