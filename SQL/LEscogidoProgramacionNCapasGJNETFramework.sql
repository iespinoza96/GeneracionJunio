USE [master]
GO
/****** Object:  Database [LEscogidoProgramacionNCapasGJ]    Script Date: 6/26/2023 5:18:35 PM ******/
CREATE DATABASE [LEscogidoProgramacionNCapasGJ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LEscogidoProgramacionNCapasGJ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LEscogidoProgramacionNCapasGJ.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LEscogidoProgramacionNCapasGJ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LEscogidoProgramacionNCapasGJ_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LEscogidoProgramacionNCapasGJ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET ARITHABORT OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET RECOVERY FULL 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET  MULTI_USER 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LEscogidoProgramacionNCapasGJ', N'ON'
GO
USE [LEscogidoProgramacionNCapasGJ]
GO
/****** Object:  StoredProcedure [dbo].[GrupoGetByIdPlantel]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GrupoGetByIdPlantel]
@IdPlantel INT
AS
SELECT 
IdGrupo,
Nombre,
IdPlantel
FROM Grupo
WHERE IdPlantel = @IdPlantel
GO
/****** Object:  StoredProcedure [dbo].[MateriaAdd]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaAdd]
@Nombre VARCHAR(50),
@Creditos TINYINT,
@IdSemestre TINYINT

--DML
AS
 INSERT INTO Materia (Nombre,Creditos,IdSemestre) VALUES (@Nombre,@Creditos,@IdSemestre)
GO
/****** Object:  StoredProcedure [dbo].[MateriaGetAll]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaGetAll] --SELECT
AS
--DML
	SELECT [IdMateria]
      ,[Nombre]
      ,[Creditos]
	  ,IdSemestre
	FROM Materia
GO
/****** Object:  StoredProcedure [dbo].[MateriaGetById]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

--DDL
CREATE PROCEDURE [dbo].[MateriaGetById] 
@IdMateria INT 
AS
SELECT M.[IdMateria]
      ,M.[Nombre] 
      ,M.[Creditos]
      ,M.[IdSemestre]
	  ,S.Nombre AS NombreSemestre
  FROM [Materia] AS M
  INNER JOIN Semestre AS S ON M.IdSemestre = S.IdSemestre
  WHERE IdMateria = @IdMateria --Condición
GO
/****** Object:  StoredProcedure [dbo].[MateriaUpdate]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MateriaUpdate]
@IdMateria int,
@Nombre varchar(50),
@Creditos tinyint,
@IdSemestre tinyint
AS
UPDATE [dbo].[Materia]
   SET [Nombre] = @Nombre 
      ,[Creditos] = @Creditos 
      ,[IdSemestre] = @IdSemestre 
 WHERE IdMateria = @IdMateria

GO
/****** Object:  StoredProcedure [dbo].[PlantelGetAll]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PlantelGetAll]
AS
SELECT IdPlantel,Nombre FROM Plantel


GO
/****** Object:  StoredProcedure [dbo].[SemestreGetAll]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SemestreGetAll]
AS
SELECT 
IdSemestre,
Nombre
FROM
Semestre
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[IdPlantel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Creditos] [tinyint] NULL,
	[IdSemestre] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Plantel]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plantel](
	[IdPlantel] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPlantel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semestre]    Script Date: 6/26/2023 5:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semestre](
	[IdSemestre] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSemestre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Grupo] ON 

INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (1, N'A101', 1)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (2, N'B101', 1)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (3, N'C101', 1)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (4, N'D101', 1)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (5, N'A101', 2)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (6, N'B101', 2)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (7, N'C101', 2)
INSERT [dbo].[Grupo] ([IdGrupo], [Nombre], [IdPlantel]) VALUES (8, N'D101', 2)
SET IDENTITY_INSERT [dbo].[Grupo] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (1, N'Historia', 5, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (2, N'Programacion', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (3, N'Matematicas', 5, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (5, N'Base de datos', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (6, N'Español', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (7, N'Geografía', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (8, N'Educación Fisica', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (9, N'Educación Fisica', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (11, N'Civismo', 5, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (12, N'Ingles', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (13, N'Ingles', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (14, N'Programacion .NET', 10, 1)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (15, N'Biologia', 10, 2)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (16, N'Quimica', 10, 2)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (17, N'Robotica', 5, 3)
INSERT [dbo].[Materia] ([IdMateria], [Nombre], [Creditos], [IdSemestre]) VALUES (19, N'Frances', 5, 4)
SET IDENTITY_INSERT [dbo].[Materia] OFF
SET IDENTITY_INSERT [dbo].[Plantel] ON 

INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (1, N'Prepa Uno')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (2, N'Prepa Dos')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (3, N'Prepa Tres')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (4, N'Prepa Cuatro')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (5, N'Prepa Cinco')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (6, N'Prepa Seis')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (7, N'Prepa Siete')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (8, N'CCH Sur')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (9, N'CCH Oriente')
INSERT [dbo].[Plantel] ([IdPlantel], [Nombre]) VALUES (10, N'CCH Norte')
SET IDENTITY_INSERT [dbo].[Plantel] OFF
SET IDENTITY_INSERT [dbo].[Semestre] ON 

INSERT [dbo].[Semestre] ([IdSemestre], [Nombre]) VALUES (1, N'Primero')
INSERT [dbo].[Semestre] ([IdSemestre], [Nombre]) VALUES (2, N'Segundo')
INSERT [dbo].[Semestre] ([IdSemestre], [Nombre]) VALUES (3, N'Tercero')
INSERT [dbo].[Semestre] ([IdSemestre], [Nombre]) VALUES (4, N'Cuarto')
SET IDENTITY_INSERT [dbo].[Semestre] OFF
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD FOREIGN KEY([IdPlantel])
REFERENCES [dbo].[Plantel] ([IdPlantel])
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD FOREIGN KEY([IdSemestre])
REFERENCES [dbo].[Semestre] ([IdSemestre])
GO
USE [master]
GO
ALTER DATABASE [LEscogidoProgramacionNCapasGJ] SET  READ_WRITE 
GO
