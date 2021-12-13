USE [master]
GO
/****** Object:  Database [LibraryDb]    Script Date: 13.12.2021 12:33:23 ******/
CREATE DATABASE [LibraryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDb', FILENAME = N'C:\Users\Denis\LibraryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryDb_log', FILENAME = N'C:\Users\Denis\LibraryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LibraryDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDb] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryDb] SET QUERY_STORE = OFF
GO
USE [LibraryDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LibraryDb]
GO
/****** Object:  Table [dbo].[AbonentsBooksTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbonentsBooksTable](
	[Id] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[TakenDate] [datetime] NULL,
	[StateId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AbonentTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbonentTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[GenderId] [int] NOT NULL,
	[BirthDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AbonentTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorTable](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuthorTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthorsTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthorsTable](
	[Id] [int] NOT NULL,
	[AuthorId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookTable](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[GenreId] [int] NULL,
 CONSTRAINT [PK_BookTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenderType]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenderType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GenderType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenreTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenreTable](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GenreTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatesTable]    Script Date: 13.12.2021 12:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatesTable](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_BookStatesTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [LibraryDb] SET  READ_WRITE 
GO
