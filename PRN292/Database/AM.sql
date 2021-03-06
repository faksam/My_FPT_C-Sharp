USE master
GO
if exists (select * from sysdatabases where name='Y12S3B1')
		drop database Y12S3B1
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE Y12S3B1
  ON PRIMARY (NAME = N''Y12S3B1'', FILENAME = N''' + @device_directory + N'Y12S3B1.mdf'')
  LOG ON (NAME = N''Y12S3B1_log'',  FILENAME = N''' + @device_directory + N'Y12S3B1.ldf'')')
go

USE [Y12S3B1]
GO
/****** Object:  Table [dbo].[Mops]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mops](
	[MopID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[Length] [smallint] NOT NULL,
	[Diameter] [tinyint] NOT NULL,
	[ColorID] [smallint] NOT NULL,
 CONSTRAINT [PK_Mops] PRIMARY KEY CLUSTERED 
(
	[MopID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Mops] ON
INSERT [dbo].[Mops] ([MopID], [Label], [Price], [Length], [Diameter], [ColorID]) VALUES (1, N'Smart MegaMop 360o', 0.5150, 120, 16, 2)
SET IDENTITY_INSERT [dbo].[Mops] OFF
/****** Object:  Table [dbo].[Irons]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Irons](
	[IronID] [int] IDENTITY(1,1) NOT NULL,
	[BrandID] [smallint] NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[Voltage] [varchar](20) NOT NULL,
	[Power] [smallint] NOT NULL,
 CONSTRAINT [PK_Irons] PRIMARY KEY CLUSTERED 
(
	[IronID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Irons] ON
INSERT [dbo].[Irons] ([IronID], [BrandID], [Label], [Price], [Voltage], [Power]) VALUES (1, 12, N'Travel steam irons', 0.2300, N'220-240V', 700)
SET IDENTITY_INSERT [dbo].[Irons] OFF
/****** Object:  Table [dbo].[HouseTypes]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HouseTypes](
	[TypeID] [tinyint] NOT NULL,
	[TypeName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_HouseTypes] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[HouseTypes] ([TypeID], [TypeName]) VALUES (1, N'Detached single-unit')
INSERT [dbo].[HouseTypes] ([TypeID], [TypeName]) VALUES (2, N'Semi-detached dwellings')
INSERT [dbo].[HouseTypes] ([TypeID], [TypeName]) VALUES (3, N'Attached Multi-unit housing')
INSERT [dbo].[HouseTypes] ([TypeID], [TypeName]) VALUES (4, N'Movable dwellings')
/****** Object:  Table [dbo].[Houses]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Houses](
	[HouseID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[TypeID] [tinyint] NOT NULL,
	[NumberOfFloors] [smallint] NOT NULL,
	[UsedArea] [real] NOT NULL,
	[BuiltYear] [smallint] NOT NULL,
 CONSTRAINT [PK_Houses] PRIMARY KEY CLUSTERED 
(
	[HouseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Houses] ON
INSERT [dbo].[Houses] ([HouseID], [Address], [TypeID], [NumberOfFloors], [UsedArea], [BuiltYear]) VALUES (1, N'8 Ton That Thuyet, Ha Noi', 3, 4, 1234.56, 2005)
SET IDENTITY_INSERT [dbo].[Houses] OFF
/****** Object:  Table [dbo].[FanTypes]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FanTypes](
	[TypeID] [tinyint] NOT NULL,
	[TypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FanTypes] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FanTypes] ([TypeID], [TypeName]) VALUES (1, N'Wall fan')
INSERT [dbo].[FanTypes] ([TypeID], [TypeName]) VALUES (2, N'Desk fan')
INSERT [dbo].[FanTypes] ([TypeID], [TypeName]) VALUES (3, N'Celling fan')
INSERT [dbo].[FanTypes] ([TypeID], [TypeName]) VALUES (4, N'Tower fan')
INSERT [dbo].[FanTypes] ([TypeID], [TypeName]) VALUES (5, N'No-Wing fan')
/****** Object:  Table [dbo].[Fans]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fans](
	[FanID] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](20) NOT NULL,
	[TypeID] [tinyint] NOT NULL,
	[Model] [varchar](20) NOT NULL,
	[Power] [smallint] NOT NULL,
 CONSTRAINT [PK_Fans] PRIMARY KEY CLUSTERED 
(
	[FanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Fans] ON
INSERT [dbo].[Fans] ([FanID], [Brand], [Color], [TypeID], [Model], [Power]) VALUES (1, N'Mitsubishi', N'Light gray', 4, N'LV16RP', 53)
SET IDENTITY_INSERT [dbo].[Fans] OFF
/****** Object:  Table [dbo].[Colors]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorID] [smallint] NOT NULL,
	[ColorName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Colors] ([ColorID], [ColorName]) VALUES (1, N'White')
INSERT [dbo].[Colors] ([ColorID], [ColorName]) VALUES (2, N'Black')
INSERT [dbo].[Colors] ([ColorID], [ColorName]) VALUES (3, N'Gray')
INSERT [dbo].[Colors] ([ColorID], [ColorName]) VALUES (4, N'Blue')
INSERT [dbo].[Colors] ([ColorID], [ColorName]) VALUES (5, N'Green')
/****** Object:  Table [dbo].[Brands]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandID] [smallint] NOT NULL,
	[BrandName] [nvarchar](50) NOT NULL,
	[Category] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (1, N'Ariston', N'waterheater')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (2, N'Joven', N'waterheater')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (3, N'Ferroli', N'waterheater')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (4, N'Electrolux', N'waterheater')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (5, N'Alpha', N'waterheater')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (6, N'Hstrong', N'waterheater')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (12, N'Phillips', N'irons')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (13, N'Panasonic', N'irons')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (14, N'Tefal', N'irons')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (15, N'Bluestone', N'irons')
INSERT [dbo].[Brands] ([BrandID], [BrandName], [Category]) VALUES (16, N'Luckystar', N'irons')
/****** Object:  Table [dbo].[WaterHeaterTypes]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterHeaterTypes](
	[TypeID] [tinyint] NOT NULL,
	[TypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_WaterHeaterTypes] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[WaterHeaterTypes] ([TypeID], [TypeName]) VALUES (1, N'Indirect')
INSERT [dbo].[WaterHeaterTypes] ([TypeID], [TypeName]) VALUES (2, N'Solar')
INSERT [dbo].[WaterHeaterTypes] ([TypeID], [TypeName]) VALUES (3, N'Direct')
/****** Object:  Table [dbo].[WaterHeaters]    Script Date: 10/11/2012 22:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterHeaters](
	[WaterHeaterID] [int] IDENTITY(1,1) NOT NULL,
	[TypeID] [tinyint] NOT NULL,
	[BrandID] [smallint] NOT NULL,
	[Capacity] [smallint] NOT NULL,
	[Power] [smallint] NULL,
	[Material] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_WaterHeaters] PRIMARY KEY CLUSTERED 
(
	[WaterHeaterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[WaterHeaters] ON
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (1, 1, 1, 20, 2500, N'Titanium', 2.7600)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (2, 1, 1, 15, 2500, N'Silver', 2.9600)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (3, 1, 1, 30, 2500, N'Silver', 3.9600)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (4, 1, 3, 15, 2500, N'Plastic', 2.5100)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (5, 1, 3, 20, 2500, N'ABS', 2.6900)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (6, 1, 4, 30, 2500, N'Titanium', 3.0150)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (7, 1, 4, 15, 2500, N'Titanium', 2.6500)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (8, 2, 6, 205, NULL, N'SUS 304-2B', 12.3000)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (9, 2, 6, 150, NULL, N'SUS 304-2B', 7.8000)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (10, 1, 3, 150, 2600, N'Enamel', 18.9900)
INSERT [dbo].[WaterHeaters] ([WaterHeaterID], [TypeID], [BrandID], [Capacity], [Power], [Material], [Price]) VALUES (11, 1, 1, 50, 2500, N'ABS', 5.4800)
SET IDENTITY_INSERT [dbo].[WaterHeaters] OFF
/****** Object:  ForeignKey [FK_WaterHeaters_Brands]    Script Date: 10/11/2012 22:54:42 ******/
ALTER TABLE [dbo].[WaterHeaters]  WITH CHECK ADD  CONSTRAINT [FK_WaterHeaters_Brands] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brands] ([BrandID])
GO
ALTER TABLE [dbo].[WaterHeaters] CHECK CONSTRAINT [FK_WaterHeaters_Brands]
GO
/****** Object:  ForeignKey [FK_WaterHeaters_WaterHeaterTypes]    Script Date: 10/11/2012 22:54:42 ******/
ALTER TABLE [dbo].[WaterHeaters]  WITH CHECK ADD  CONSTRAINT [FK_WaterHeaters_WaterHeaterTypes] FOREIGN KEY([TypeID])
REFERENCES [dbo].[WaterHeaterTypes] ([TypeID])
GO
ALTER TABLE [dbo].[WaterHeaters] CHECK CONSTRAINT [FK_WaterHeaters_WaterHeaterTypes]
GO
