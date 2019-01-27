USE [master]
GO
/****** Object:  Database [MMMGame]    Script Date: 27/01/2019 23:19:53 ******/
CREATE DATABASE [MMMGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MMMGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MMMGame.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MMMGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MMMGame_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MMMGame] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MMMGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MMMGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MMMGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MMMGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MMMGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MMMGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [MMMGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MMMGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MMMGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MMMGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MMMGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MMMGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MMMGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MMMGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MMMGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MMMGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MMMGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MMMGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MMMGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MMMGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MMMGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MMMGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MMMGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MMMGame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MMMGame] SET  MULTI_USER 
GO
ALTER DATABASE [MMMGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MMMGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MMMGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MMMGame] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MMMGame] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MMMGame] SET QUERY_STORE = OFF
GO
USE [MMMGame]
GO
/****** Object:  Table [dbo].[ContactMessages]    Script Date: 27/01/2019 23:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactMessages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Message] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ContactMessages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 27/01/2019 23:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[Content] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_feedbacks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 27/01/2019 23:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 27/01/2019 23:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Duration] [int] NOT NULL,
	[MovesCount] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Difficulty] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GameRounds] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27/01/2019 23:19:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NULL,
	[RegisterDate] [date] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContactMessages] ON 

INSERT [dbo].[ContactMessages] ([ID], [Date], [PhoneNumber], [Email], [Message]) VALUES (1, CAST(N'2019-01-27' AS Date), N'0566665959', N'lihishola@walla.com', N'great game! i really enjoyed it')
INSERT [dbo].[ContactMessages] ([ID], [Date], [PhoneNumber], [Email], [Message]) VALUES (2, CAST(N'2019-01-27' AS Date), N'0547649697', N'syrelmichael@gmail.com', N'Looking for my next challenge as a fullstack developer! :)')
SET IDENTITY_INSERT [dbo].[ContactMessages] OFF
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([ID], [Username], [Date], [Subject], [Content]) VALUES (1, N'lihishola', CAST(N'2019-01-27T20:32:00.073' AS DateTime), N'Best game i ever played!', N'It''s a great game! + i think the developer is very cute')
INSERT [dbo].[Feedbacks] ([ID], [Username], [Date], [Subject], [Content]) VALUES (2, N'MichaelSy', CAST(N'2019-01-27T21:13:17.967' AS DateTime), N'really cool game!', N'Hope you enjoyed it!')
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([ID], [Name]) VALUES (1, N'cat.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (2, N'mm.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (3, N'om.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (4, N'om2.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (5, N'om3.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (6, N'ow.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (7, N'yb.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (8, N'yb2.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (9, N'ym.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (10, N'ym2.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (11, N'ym3.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (12, N'ym4.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (13, N'ym5.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (14, N'ym6.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (15, N'yw.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (16, N'yw2.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (17, N'yw3.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (18, N'yw4.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (19, N'yw5.jpg')
INSERT [dbo].[Images] ([ID], [Name]) VALUES (20, N'yw6.jpg')
SET IDENTITY_INSERT [dbo].[Images] OFF
SET IDENTITY_INSERT [dbo].[Results] ON 

INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (1, 1, CAST(N'2019-01-27T22:37:32.330' AS DateTime), 101, 27, 15, 2, N'lihishola', N'lihi shola')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (2, 1, CAST(N'2019-01-27T22:38:57.720' AS DateTime), 79, 31, 13, 2, N'lihishola', N'lihi shola')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (3, 1, CAST(N'2019-01-27T22:40:14.477' AS DateTime), 73, 29, 21, 3, N'lihishola', N'lihi shola')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (4, 3, CAST(N'2019-01-27T22:44:35.060' AS DateTime), 49, 19, 11, 1, N'pizzapazz', N'pizza pazz')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (5, 7, CAST(N'2019-01-27T22:55:54.337' AS DateTime), 36, 16, 13, 1, N'POLINA SYS', N'POLINA SYS')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (6, 8, CAST(N'2019-01-27T23:14:36.757' AS DateTime), 31, 13, 16, 1, N'MichaelSy', N'Michael Syrel')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (7, 8, CAST(N'2019-01-27T23:15:23.743' AS DateTime), 44, 18, 23, 2, N'MichaelSy', N'Michael Syrel')
INSERT [dbo].[Results] ([ID], [UserID], [Date], [Duration], [MovesCount], [Score], [Difficulty], [Username], [FullName]) VALUES (8, 8, CAST(N'2019-01-27T23:16:47.770' AS DateTime), 78, 35, 18, 3, N'MichaelSy', N'Michael Syrel')
SET IDENTITY_INSERT [dbo].[Results] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (1, N'lihishola', N'12345678', N'lihishola@walla.com', N'lihi', N'shola', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (2, N'bazazaliz', N'88888888888', N'liziza_baza@walla.com', N'liza', N'zaza', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (3, N'pizzapazz', N'8888888888', N'pizapazz@walla.com', N'pizza', N'pazz', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (4, N'LIZA PIZA', N'12345678', N'LIZA_BOO@WALLA.COM', N'LIZ', N'CHEN', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (5, N'SARABRARA', N'12345678', N'SARABRARA@WALLA.COM', N'SARA', N'JENSEN', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (6, N'GALYASHKED', N'12345678', N'SHAKED_GALYA@WALLA.COM', N'GALYA', N'SHAKED', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (7, N'POLINA SYS', N'12345678', N'POLINASYS@WALLA.COM', N'POLINA', N'SYS', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([ID], [Username], [Password], [Email], [FirstName], [LastName], [BirthDate], [RegisterDate]) VALUES (8, N'MichaelSy', N'155155155', N'syrelmichael@gmail.com', N'Michael', N'Syrel', CAST(N'0001-01-01' AS Date), CAST(N'2019-01-27' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [MMMGame] SET  READ_WRITE 
GO
