SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='Y12S1B3')
		drop database Y12S1B3
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE Y12S1B3
  ON PRIMARY (NAME = N''Y12S1B3'', FILENAME = N''' + @device_directory + N'Y12S1B3.mdf'')
  LOG ON (NAME = N''Y12S1B3_log'',  FILENAME = N''' + @device_directory + N'Y12S1B3.ldf'')')
go

ALTER DATABASE Y12S1B3 SET RECOVERY SIMPLE
GO

USE [Y12S1B3]
GO
/****** Object:  Table [dbo].[Zombies]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zombies](
	[ZombieID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ToughnessID] [int] NOT NULL,
	[Speed] [nvarchar](30) NOT NULL,
	[Note] [nvarchar](50) NOT NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_Zombies] PRIMARY KEY CLUSTERED 
(
	[ZombieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Zombies] ON
INSERT [dbo].[Zombies] ([ZombieID], [Name], [ToughnessID], [Speed], [Note], [Cost]) VALUES (1, N'Pole Vaulting Zombie', 2, N'fast, then normal (after jump)', N' jumps the first plant he runs into', 75)
SET IDENTITY_INSERT [dbo].[Zombies] OFF
/****** Object:  Table [dbo].[Toughness]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toughness](
	[ToughnessID] [int] NOT NULL,
	[Toughness] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Toughness] PRIMARY KEY CLUSTERED 
(
	[ToughnessID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Toughness] ([ToughnessID], [Toughness]) VALUES (1, N'low')
INSERT [dbo].[Toughness] ([ToughnessID], [Toughness]) VALUES (2, N'medium')
INSERT [dbo].[Toughness] ([ToughnessID], [Toughness]) VALUES (3, N'high')
INSERT [dbo].[Toughness] ([ToughnessID], [Toughness]) VALUES (4, N'very high')
INSERT [dbo].[Toughness] ([ToughnessID], [Toughness]) VALUES (5, N'extremely high')
INSERT [dbo].[Toughness] ([ToughnessID], [Toughness]) VALUES (6, N'extreme')
/****** Object:  Table [dbo].[Recharge]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recharge](
	[RechargeID] [int] NOT NULL,
	[Recharge] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Recharge] PRIMARY KEY CLUSTERED 
(
	[RechargeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Recharge] ([RechargeID], [Recharge]) VALUES (1, N'very slow')
INSERT [dbo].[Recharge] ([RechargeID], [Recharge]) VALUES (2, N'slow')
INSERT [dbo].[Recharge] ([RechargeID], [Recharge]) VALUES (3, N'fast')
/****** Object:  Table [dbo].[Platforms]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[PlatformID] [int] NOT NULL,
	[Platform] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[PlatformID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (1, N'PC game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (2, N'Online game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (3, N'Handheld game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (4, N'Mobile game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (5, N'Arcade game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (6, N'Audio game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (7, N'Console game')
INSERT [dbo].[Platforms] ([PlatformID], [Platform]) VALUES (8, N'Video console game')
/****** Object:  Table [dbo].[Plants]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plants](
	[PlantID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Damage] [nvarchar](30) NOT NULL,
	[Range] [nvarchar](30) NOT NULL,
	[RechargeID] [int] NOT NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_Plants] PRIMARY KEY CLUSTERED 
(
	[PlantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Plants] ON
INSERT [dbo].[Plants] ([PlantID], [Name], [Damage], [Range], [RechargeID], [Cost]) VALUES (1, N'Cherry Bomb', N'massive', N'all zombies in a medium area', 1, 150)
SET IDENTITY_INSERT [dbo].[Plants] OFF
/****** Object:  Table [dbo].[Genres]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] NOT NULL,
	[GenreName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (1, N'Action game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (2, N'Shooter game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (3, N'Action-adventure game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (4, N'Adventure game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (5, N'Role-playing game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (6, N'Simulation game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (7, N'Sports game')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (8, N'Strategy name')
/****** Object:  Table [dbo].[Gardens]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gardens](
	[GardenID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Slots] [int] NOT NULL,
	[Plans] [int] NOT NULL,
	[Tools] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Gardens] PRIMARY KEY CLUSTERED 
(
	[GardenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Gardens] ON
INSERT [dbo].[Gardens] ([GardenID], [Name], [Slots], [Plans], [Tools], [Price]) VALUES (1, N'Mushroom Garden', 8, 8, N'Watering can, glove, wheel barrow', 30000.0000)
SET IDENTITY_INSERT [dbo].[Gardens] OFF
/****** Object:  Table [dbo].[GameTypes]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameTypes](
	[TypeID] [int] NOT NULL,
	[TypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GameTypes] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[GameTypes] ([TypeID], [TypeName]) VALUES (1, N'Puzzle')
INSERT [dbo].[GameTypes] ([TypeID], [TypeName]) VALUES (2, N'Adventure')
INSERT [dbo].[GameTypes] ([TypeID], [TypeName]) VALUES (3, N'Mini-Games')
INSERT [dbo].[GameTypes] ([TypeID], [TypeName]) VALUES (4, N'Survival')
/****** Object:  Table [dbo].[Games]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[GameID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[TypeID] [int] NOT NULL,
	[Difficulty] [nvarchar](20) NOT NULL,
	[Cells] [int] NOT NULL,
	[ExtraLine] [bit] NOT NULL,
 CONSTRAINT [PK_Games_1] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Games] ON
INSERT [dbo].[Games] ([GameID], [Name], [TypeID], [Difficulty], [Cells], [ExtraLine]) VALUES (1, N'Vasebreaker', 1, N'normal', 45, 0)
SET IDENTITY_INSERT [dbo].[Games] OFF
/****** Object:  Table [dbo].[ComputerGames]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputerGames](
	[GameID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GenreID] [int] NOT NULL,
	[PlatformID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ComputerGames] ON
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (1, N'Bejeweled 3', 1, 1, 1)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (2, N'Bookworm Adventures ', 4, 1, 2)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (3, N'Vacation Quest Australia', 4, 1, 4)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (4, N'Vacation Quest™ - The Hawaiian Islands', 4, 1, 4)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (5, N'Amazing Adventures Around the World™', 4, 1, 4)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (6, N'Amazing Adventures The Caribbean Secret™', 4, 1, 4)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (7, N'Amazing Adventures The Forgotten Dynasty™ ', 4, 1, 4)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (8, N'Plants vs. Zombies', 3, 1, 3)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (9, N'Plants vs. Zombies', 3, 3, 3)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (10, N'Plants vs. Zombies', 3, 4, 3)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (11, N'Zuma''s Revenge!', 4, 1, 7)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (12, N'Zuma''s Revenge!', 4, 3, 7)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (13, N'Zuma''s Revenge!', 4, 4, 7)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (14, N'Zuma', 4, 1, 7)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (15, N'Big Money™', 3, 2, 5)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (16, N'Chuzzle®', 3, 2, 5)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (17, N'Insaniquarium™', 3, 2, 5)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (18, N'Peggle®', 3, 2, 6)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (19, N'Peggle®', 3, 1, 6)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (20, N'Peggle®', 3, 3, 6)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (21, N'Peggle® ', 3, 4, 6)
INSERT [dbo].[ComputerGames] ([GameID], [Name], [GenreID], [PlatformID], [CategoryID]) VALUES (22, N'Peggle® Nights', 3, 1, 6)
SET IDENTITY_INSERT [dbo].[ComputerGames] OFF
/****** Object:  Table [dbo].[Categories]    Script Date: 04/19/2012 11:37:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Bejeweled')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Bookworm')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Plans vs. Zombies')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Hidden Object')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Vintage Games')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Peggle')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (7, N'Zuma')
select * from Toughness , Zombies