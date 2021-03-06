SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='Y12S2B3')
		drop database Y12S2B3
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE Y12S2B3
  ON PRIMARY (NAME = N''Y12S2B3'', FILENAME = N''' + @device_directory + N'Y12S2B3.mdf'')
  LOG ON (NAME = N''Y12S2B3_log'',  FILENAME = N''' + @device_directory + N'Y12S2B3.ldf'')')
go

exec sp_dboption 'Y12S2B3','trunc. log on chkpt.','true'
exec sp_dboption 'Y12S2B3','select into/bulkcopy','true'
GO

USE [Y12S2B3]
GO
/****** Object:  Table [dbo].[Watches]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Watches](
	[WatchID] [int] IDENTITY(1,1) NOT NULL,
	[Model] [varchar](20) NOT NULL,
	[BrandID] [smallint] NOT NULL,
	[Origin] [nvarchar](50) NOT NULL,
	[WaterResistant] [varchar](20) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Watches] PRIMARY KEY CLUSTERED 
(
	[WatchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Watches] ON
INSERT [dbo].[Watches] ([WatchID], [Model], [BrandID], [Origin], [WaterResistant], [Price]) VALUES (1, N'LIN-163', 3, N'Japan', N'5 Bar', 1.0240)
SET IDENTITY_INSERT [dbo].[Watches] OFF
/****** Object:  Table [dbo].[Suitcases]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suitcases](
	[SuitcaseID] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[SizeID] [tinyint] NOT NULL,
	[Dimensions] [varchar](20) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Suitcases] PRIMARY KEY CLUSTERED 
(
	[SuitcaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Suitcases] ON
INSERT [dbo].[Suitcases] ([SuitcaseID], [Brand], [SizeID], [Dimensions], [Capacity], [Description]) VALUES (1, N'Miti', 3, N'47 x 32 x 32', 10, N'Elegant style, luxurious')
SET IDENTITY_INSERT [dbo].[Suitcases] OFF
/****** Object:  Table [dbo].[Sizes]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[SizeID] [tinyint] NOT NULL,
	[SizeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Sizes] ([SizeID], [SizeName]) VALUES (1, N'Large')
INSERT [dbo].[Sizes] ([SizeID], [SizeName]) VALUES (2, N'Medium')
INSERT [dbo].[Sizes] ([SizeID], [SizeName]) VALUES (3, N'Small')
INSERT [dbo].[Sizes] ([SizeID], [SizeName]) VALUES (4, N'Portable')
/****** Object:  Table [dbo].[Regions]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[RegionID] [smallint] NOT NULL,
	[Region] [nvarchar](15) NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (1, N'AK')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (2, N'OR')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (3, N'Co. Cork')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (4, N'Québec')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (5, N'DF')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (6, N'BC')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (7, N'ID')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (8, N'CA')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (9, N'Isle of Wight')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (10, N'RJ')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (11, N'Lara')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (12, N'SP')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (13, N'MT')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (14, N'Táchira')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (15, N'NM')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (16, N'WA')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (17, N'Nueva Esparta')
INSERT [dbo].[Regions] ([RegionID], [Region]) VALUES (18, N'WY')
/****** Object:  Table [dbo].[NotebookTypes]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotebookTypes](
	[NotebookTypeID] [tinyint] NOT NULL,
	[TypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_NotebookTypes] PRIMARY KEY CLUSTERED 
(
	[NotebookTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NotebookTypes] ([NotebookTypeID], [TypeName]) VALUES (1, N'Class')
INSERT [dbo].[NotebookTypes] ([NotebookTypeID], [TypeName]) VALUES (2, N'School')
INSERT [dbo].[NotebookTypes] ([NotebookTypeID], [TypeName]) VALUES (3, N'Trạng Nguyên')
INSERT [dbo].[NotebookTypes] ([NotebookTypeID], [TypeName]) VALUES (4, N'Pupil')
INSERT [dbo].[NotebookTypes] ([NotebookTypeID], [TypeName]) VALUES (5, N'Study')
INSERT [dbo].[NotebookTypes] ([NotebookTypeID], [TypeName]) VALUES (6, N'Sao Mai')
/****** Object:  Table [dbo].[Notebooks]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notebooks](
	[NotebookID] [int] IDENTITY(1,1) NOT NULL,
	[NotebookTypeID] [tinyint] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Dimensions] [varchar](20) NOT NULL,
	[NumberOfPages] [smallint] NOT NULL,
	[Whiteness] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Notebooks] PRIMARY KEY CLUSTERED 
(
	[NotebookID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Notebooks] ON
INSERT [dbo].[Notebooks] ([NotebookID], [NotebookTypeID], [Name], [Dimensions], [NumberOfPages], [Whiteness]) VALUES (1, 1, N'Ami', N'156 x 205 (± 2mm)', 96, N'95% ISO')
SET IDENTITY_INSERT [dbo].[Notebooks] OFF
/****** Object:  Table [dbo].[Customers]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [nchar](5) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitleID] [tinyint] NOT NULL,
	[Address] [nvarchar](60) NULL,
	[CityID] [int] NOT NULL,
	[RegionID] [smallint] NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'ALFKI', N'Alfreds Futterkiste', N'Maria Anders', 12, N'Obere Str. 57', 8, NULL, N'12209', N'030-0074321', N'030-0076545')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'ANATR', N'Ana Trujillo Emparedados y helados', N'Ana Trujillo', 9, N'Avda. de la Constitución 2222', 42, NULL, N'05021', N'(5) 555-4729', N'(5) 555-3745')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'ANTON', N'Antonio Moreno Taquería', N'Antonio Moreno', 9, N'Mataderos  2312', 42, NULL, N'05023', N'(5) 555-3932', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'AROUT', N'Around the Horn', N'Thomas Hardy', 12, N'120 Hanover Sq.', 36, NULL, N'WA1 1DP', N'(171) 555-7788', N'(171) 555-6750')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BERGS', N'Berglunds snabbköp', N'Christina Berglund', 7, N'Berguvsvägen  8', 37, NULL, N'S-958 22', N'0921-12 34 65', N'0921-12 34 67')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BLAUS', N'Blauer See Delikatessen', N'Hanna Moos', 12, N'Forsterstr. 57', 40, NULL, N'68306', N'0621-08460', N'0621-08924')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BLONP', N'Blondesddsl père et fils', N'Frédérique Citeaux', 5, N'24, place Kléber', 61, NULL, N'67000', N'88.60.15.31', N'88.60.15.32')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BOLID', N'Bólido Comidas preparadas', N'Martín Sommer', 9, N'C/ Araquil, 67', 39, NULL, N'28023', N'(91) 555 22 82', N'(91) 555 91 99')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BONAP', N'Bon app''', N'Laurence Lebihan', 9, N'12, rue des Bouchers', 41, NULL, N'France', N'91.24.45.40', N'91.24.45.41')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BOTTM', N'Bottom-Dollar Markets', N'Elizabeth Lincoln', 1, N'23 Tsawassen Blvd.', 65, 6, N'T2F 8M4', N'(604) 555-4729', N'(604) 555-3745')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'BSBEV', N'B''s Beverages', N'Victoria Ashworth', 12, N'Fauntleroy Circus', 36, NULL, N'EC2 5NT', N'(171) 555-1212', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'CACTU', N'Cactus Comidas para llevar', N'Patricio Simpson', 2, N'Cerrito 333', 14, NULL, N'1010', N'(1) 135-5555', N'(1) 135-4892')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'CENTC', N'Centro comercial Moctezuma', N'Francisco Chang', 5, N'Sierras de Granada 9993', 42, NULL, N'05022', N'(5) 555-3392', N'(5) 555-7293')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'CHOPS', N'Chop-suey Chinese', N'Yang Wang', 9, N'Hauptstr. 29', 9, NULL, N'3012', N'0452-076545', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'COMMI', N'Comércio Mineiro', N'Pedro Afonso', 4, N'Av. dos Lusíadas, 23', 57, 12, N'05432-043', N'(11) 555-7647', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'CONSH', N'Consolidated Holdings', N'Elizabeth Brown', 12, N'Berkeley Gardens 12  Brewery', 36, NULL, N'WX1 6LT', N'(171) 555-2282', N'(171) 555-9199')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'DRACD', N'Drachenblut Delikatessen', N'Sven Ottlieb', 7, N'Walserweg 21', 1, NULL, N'52066', N'0241-039123', N'0241-059428')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'DUMON', N'Du monde entier', N'Janine Labrune', 9, N'67, rue des Cinquante Otages', 46, NULL, N'44000', N'40.67.88.88', N'40.67.89.89')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'EASTC', N'Eastern Connection', N'Ann Devon', 2, N'35 King George', 36, NULL, N'WX3 6FW', N'(171) 555-0297', N'(171) 555-3373')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'ERNSH', N'Ernst Handel', N'Roland Mendel', 10, N'Kirchgasse 6', 26, NULL, N'8010', N'7675-3425', N'7675-3426')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FAMIA', N'Familia Arquibaldo', N'Aria Cruz', 3, N'Rua Orós, 92', 57, 12, N'05442-030', N'(11) 555-9857', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FISSA', N'FISSA Fabrica Inter. Salchichas S.A.', N'Diego Roel', 1, N'C/ Moralzarzal, 86', 39, NULL, N'28034', N'(91) 555 94 44', N'(91) 555 55 93')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FOLIG', N'Folies gourmandes', N'Martine Rancé', 6, N'184, chaussée de Tournai', 34, NULL, N'59000', N'20.16.10.16', N'20.16.10.17')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FOLKO', N'Folk och fä HB', N'Maria Larsson', 9, N'Åkergatan 24', 11, NULL, N'S-844 67', N'0695-34 67 21', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FRANK', N'Frankenversand', N'Peter Franken', 5, N'Berliner Platz 43', 44, NULL, N'80805', N'089-0877310', N'089-0877451')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FRANR', N'France restauration', N'Carine Schmitt', 5, N'54, rue Royale', 46, NULL, N'44000', N'40.32.21.21', N'40.32.21.20')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FRANS', N'Franchi S.p.A.', N'Paolo Accorti', 12, N'Via Monte Bianco 34', 63, NULL, N'10100', N'011-4988260', N'011-4988261')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'FURIB', N'Furia Bacalhau e Frutos do Mar', N'Lino Rodriguez', 10, N'Jardim das rosas n. 32', 35, NULL, N'1675', N'(1) 354-2534', N'(1) 354-2535')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'GALED', N'Galería del gastrónomo', N'Eduardo Saavedra', 5, N'Rambla de Cataluña, 23', 5, NULL, N'08022', N'(93) 203 4560', N'(93) 203 4561')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'GODOS', N'Godos Cocina Típica', N'José Pedro Freyre', 10, N'C/ Romero, 33', 59, NULL, N'41101', N'(95) 555 82 82', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'GOURL', N'Gourmet Lanchonetes', N'André Fonseca', 4, N'Av. Brasil, 442', 16, 12, N'04876-786', N'(11) 555-9482', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'GREAL', N'Great Lakes Food Market', N'Howard Snyder', 5, N'2732 Baker Blvd.', 23, 2, N'97403', N'(503) 555-7555', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'GROSR', N'GROSELLA-Restaurante', N'Manuel Pereira', 9, N'5ª Ave. Los Palos Grandes', 17, 5, N'1081', N'(2) 283-2951', N'(2) 283-3397')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'HANAR', N'Hanari Carnes', N'Mario Pontes', 1, N'Rua do Paço, 67', 53, 10, N'05454-876', N'(21) 555-0091', N'(21) 555-8765')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'HILAA', N'HILARION-Abastos', N'Carlos Hernández', 12, N'Carrera 22 con Ave. Carlos Soublette #8-35', 55, 14, N'5022', N'(5) 555-1340', N'(5) 555-1948')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'HUNGC', N'Hungry Coyote Import Store', N'Yoshi Latimer', 12, N'City Center Plaza 516 Main St.', 22, 2, N'97827', N'(503) 555-6874', N'(503) 555-2376')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'HUNGO', N'Hungry Owl All-Night Grocers', N'Patricia McKenna', 4, N'8 Johnstown Road', 19, 3, NULL, N'2967 542', N'2967 3333')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'ISLAT', N'Island Trading', N'Helen Bennett', 5, N'Garden House Crowther Way', 20, 9, N'PO31 7PJ', N'(198) 555-8888', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'KOENE', N'Königlich Essen', N'Philip Cramer', 4, N'Maubelstr. 90', 12, NULL, N'14776', N'0555-09876', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LACOR', N'La corne d''abondance', N'Daniel Tonini', 12, N'67, avenue de l''Europe', 67, NULL, N'78000', N'30.59.84.10', N'30.59.85.11')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LAMAI', N'La maison d''Asie', N'Annette Roulet', 10, N'1 rue Alsace-Lorraine', 64, NULL, N'31000', N'61.77.61.10', N'61.77.61.11')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LAUGB', N'Laughing Bacchus Wine Cellars', N'Yoshi Tannamuri', 3, N'1900 Oak St.', 66, 6, N'V3F 2K1', N'(604) 555-3392', N'(604) 555-7293')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LAZYK', N'Lazy K Kountry Store', N'John Steel', 5, N'12 Orchestra Terrace', 68, 16, N'99362', N'(509) 555-7969', N'(509) 555-6221')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LEHMS', N'Lehmanns Marktstand', N'Renate Messner', 12, N'Magazinweg 7', 24, NULL, N'60528', N'069-0245984', N'069-0245874')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LETSS', N'Let''s Stop N Shop', N'Jaime Yorres', 9, N'87 Polk St. Suite 5', 56, 8, N'94117', N'(415) 555-5938', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LILAS', N'LILA-Supermercado', N'Carlos González', 1, N'Carrera 52 con Ave. Bolívar #65-98 Llano Largo', 6, 11, N'3508', N'(9) 331-6954', N'(9) 331-7256')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LINOD', N'LINO-Delicateses', N'Felipe Izquierdo', 9, N'Ave. 5 de Mayo Porlamar', 28, 17, N'4980', N'(8) 34-56-12', N'(8) 34-93-93')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'LONEP', N'Lonesome Pine Restaurant', N'Fran Wilson', 10, N'89 Chiaroscuro Rd.', 49, 2, N'97219', N'(503) 555-9573', N'(503) 555-9646')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'MAGAA', N'Magazzini Alimentari Riuniti', N'Giovanni Rovelli', 5, N'Via Ludovico il Moro 22', 7, NULL, N'24100', N'035-640230', N'035-640231')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'MAISD', N'Maison Dewey', N'Catherine Dewey', 2, N'Rue Joseph-Bens 532', 13, NULL, N'B-1180', N'(02) 201 24 67', N'(02) 201 24 68')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'MEREP', N'Mère Paillarde', N'Jean Fresnière', 3, N'43 rue St. Laurent', 43, 4, N'H1J 1C3', N'(514) 555-8054', N'(514) 555-8055')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'MORGK', N'Morgenstern Gesundkost', N'Alexander Feuer', 3, N'Heerstr. 22', 33, NULL, N'04179', N'0342-023176', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'NORTS', N'North/South', N'Simon Crowther', 4, N'South House 300 Queensbridge', 36, NULL, N'SW7 1RZ', N'(171) 555-7733', N'(171) 555-2530')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'OCEAN', N'Océano Atlántico Ltda.', N'Yvonne Moncada', 2, N'Ing. Gustavo Moncada 8585 Piso 20-A', 14, NULL, N'1010', N'(1) 135-5333', N'(1) 135-5535')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'OLDWO', N'Old World Delicatessen', N'Rene Phillips', 12, N'2743 Bering St.', 3, 1, N'99508', N'(907) 555-7584', N'(907) 555-2880')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'OTTIK', N'Ottilies Käseladen', N'Henriette Pfalzheim', 9, N'Mehrheimerstr. 369', 31, NULL, N'50739', N'0221-0644327', N'0221-0765721')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'PARIS', N'Paris spécialités', N'Marie Bertrand', 9, N'265, boulevard Charonne', 48, NULL, N'75012', N'(1) 42.34.22.66', N'(1) 42.34.22.77')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'PERIC', N'Pericles Comidas clásicas', N'Guillermo Fernández', 12, N'Calle Dr. Jorge Cash 321', 42, NULL, N'05033', N'(5) 552-3745', N'(5) 545-3745')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'PICCO', N'Piccolo und mehr', N'Georg Pipps', 10, N'Geislweg 14', 54, NULL, N'5020', N'6562-9722', N'6562-9723')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'PRINI', N'Princesa Isabel Vinhos', N'Isabel de Castro', 12, N'Estrada da saúde n. 58', 35, NULL, N'1756', N'(1) 356-5634', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'QUEDE', N'Que Delícia', N'Bernardo Batista', 1, N'Rua da Panificadora, 12', 53, 10, N'02389-673', N'(21) 555-4252', N'(21) 555-4545')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'QUEEN', N'Queen Cozinha', N'Lúcia Carvalho', 3, N'Alameda dos Canàrios, 891', 57, 12, N'05487-020', N'(11) 555-1189', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'QUICK', N'QUICK-Stop', N'Horst Kloss', 1, N'Taucherstraße 10', 21, NULL, N'01307', N'0372-035188', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'RANCH', N'Rancho grande', N'Sergio Gutiérrez', 12, N'Av. del Libertador 900', 14, NULL, N'1010', N'(1) 123-5555', N'(1) 123-5556')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'RATTC', N'Rattlesnake Canyon Grocery', N'Paula Wilson', 8, N'2817 Milton Dr.', 2, 15, N'87110', N'(505) 555-5939', N'(505) 555-3620')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'REGGC', N'Reggiani Caseifici', N'Maurizio Moroni', 4, N'Strada Provinciale 124', 50, NULL, N'42100', N'0522-556721', N'0522-556722')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'RICAR', N'Ricardo Adocicados', N'Janete Limeira', 6, N'Av. Copacabana, 267', 53, 10, N'02389-890', N'(21) 555-3412', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'RICSU', N'Richter Supermarkt', N'Michael Holz', 10, N'Grenzacherweg 237', 25, NULL, N'1203', N'0897-034214', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'ROMEY', N'Romero y tomillo', N'Alejandra Camino', 1, N'Gran Vía, 1', 39, NULL, N'28001', N'(91) 745 6200', N'(91) 745 6210')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SANTG', N'Santé Gourmet', N'Jonas Bergulfsen', 9, N'Erling Skakkes gate 78', 60, NULL, N'4110', N'07-98 92 35', N'07-98 92 47')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SAVEA', N'Save-a-lot Markets', N'Jose Pavarotti', 12, N'187 Suffolk Ln.', 10, 7, N'83720', N'(208) 555-8097', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SEVES', N'Seven Seas Imports', N'Hari Kumar', 10, N'90 Wadhurst Rd.', 36, NULL, N'OX15 4NB', N'(171) 555-1717', N'(171) 555-5646')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SIMOB', N'Simons bistro', N'Jytte Petersen', 9, N'Vinbæltet 34', 30, NULL, N'1734', N'31 12 34 56', N'31 13 35 57')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SPECD', N'Spécialités du monde', N'Dominique Perrier', 5, N'25, rue Lauriston', 48, NULL, N'75016', N'(1) 47.55.60.10', N'(1) 47.55.60.20')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SPLIR', N'Split Rail Beer & Ale', N'Art Braunschweiger', 10, N'P.O. Box 555', 32, 18, N'82520', N'(307) 555-4680', N'(307) 555-6525')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'SUPRD', N'Suprêmes délices', N'Pascale Cartrain', 1, N'Boulevard Tirou, 255', 18, NULL, N'B-6000', N'(071) 23 67 22 20', N'(071) 23 67 22 21')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'THEBI', N'The Big Cheese', N'Liz Nixon', 5, N'89 Jefferson Way Suite 2', 49, 2, N'97201', N'(503) 555-3612', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'THECR', N'The Cracker Box', N'Liu Wong', 3, N'55 Grizzly Peak Rd.', 15, 13, N'59801', N'(406) 555-5834', N'(406) 555-8083')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'TOMSP', N'Toms Spezialitäten', N'Karin Josephs', 5, N'Luisenstr. 48', 45, NULL, N'44087', N'0251-031259', N'0251-035695')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'TORTU', N'Tortuga Restaurante', N'Miguel Angel Paolino', 9, N'Avda. Azteca 123', 42, NULL, N'05033', N'(5) 555-2933', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'TRADH', N'Tradição Hipermercados', N'Anabela Domingues', 12, N'Av. Inês de Castro, 414', 57, 12, N'05634-030', N'(11) 555-2167', N'(11) 555-2168')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'TRAIH', N'Trail''s Head Gourmet Provisioners', N'Helvetius Nagy', 4, N'722 DaVinci Blvd.', 29, 16, N'98034', N'(206) 555-8257', N'(206) 555-2174')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'VAFFE', N'Vaffeljernet', N'Palle Ibsen', 10, N'Smagsloget 45', 4, NULL, N'8200', N'86 21 32 43', N'86 22 33 44')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'VICTE', N'Victuailles en stock', N'Mary Saveley', 2, N'2, rue du Commerce', 38, NULL, N'69004', N'78.32.54.86', N'78.32.54.87')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'VINET', N'Vins et alcools Chevalier', N'Paul Henriot', 1, N'59 rue de l''Abbaye', 51, NULL, N'51100', N'26.47.15.10', N'26.47.15.11')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'WANDK', N'Die Wandernde Kuh', N'Rita Müller', 12, N'Adenauerallee 900', 62, NULL, N'70563', N'0711-020361', N'0711-035428')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'WARTH', N'Wartian Herkku', N'Pirkko Koskitalo', 1, N'Torikatu 38', 47, NULL, N'90110', N'981-443655', N'981-443655')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'WELLI', N'Wellington Importadora', N'Paula Parente', 10, N'Rua do Mercado, 12', 52, 12, N'08737-363', N'(14) 555-8122', NULL)
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'WHITC', N'White Clover Markets', N'Karl Jablonski', 9, N'305 - 14th Ave. S. Suite 3B', 58, 16, N'98128', N'(206) 555-4112', N'(206) 555-4115')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'WILMK', N'Wilman Kala', N'Matti Karttunen', 11, N'Keskuskatu 45', 27, NULL, N'21240', N'90-224 8858', N'90-224 8858')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitleID], [Address], [CityID], [RegionID], [PostalCode], [Phone], [Fax]) VALUES (N'WOLZA', N'Wolski  Zajazd', N'Zbyszek Piestrzeniewicz', 9, N'ul. Filtrowa 68', 69, NULL, N'01-012', N'(26) 642-7012', N'(26) 642-7012')
/****** Object:  Table [dbo].[Cups]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cups](
	[CupID] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[MadeIn] [smallint] NOT NULL,
	[Material] [nvarchar](20) NOT NULL,
	[Capacity] [smallint] NOT NULL,
	[Height] [float] NOT NULL,
 CONSTRAINT [PK_Cups] PRIMARY KEY CLUSTERED 
(
	[CupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cups] ON
INSERT [dbo].[Cups] ([CupID], [Brand], [MadeIn], [Material], [Capacity], [Height]) VALUES (1, N'Starbucks', 3, N'Ware', 280, 9.5)
SET IDENTITY_INSERT [dbo].[Cups] OFF
/****** Object:  Table [dbo].[Countries]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [smallint] NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (1, N'Vietnam')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'Thailand')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (3, N'China')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (4, N'Japan')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (5, N'Switzerland')
/****** Object:  Table [dbo].[ContactTitles]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactTitles](
	[ContactTitleID] [tinyint] NOT NULL,
	[ContactTitle] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_ContactTitles] PRIMARY KEY CLUSTERED 
(
	[ContactTitleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (1, N'Accounting Manager')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (2, N'Sales Agent')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (3, N'Marketing Assistant')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (4, N'Sales Associate')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (5, N'Marketing Manager')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (6, N'Assistant Sales Agent')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (7, N'Order Administrator')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (8, N'Assistant Sales Representative')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (9, N'Owner')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (10, N'Sales Manager')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (11, N'Owner/Marketing Assistant')
INSERT [dbo].[ContactTitles] ([ContactTitleID], [ContactTitle]) VALUES (12, N'Sales Representative')
/****** Object:  Table [dbo].[Cities]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](15) NULL,
	[Country] [nvarchar](15) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (1, N'Aachen', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (2, N'Albuquerque', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (3, N'Anchorage', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (4, N'Århus', N'Denmark')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (5, N'Barcelona', N'Spain')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (6, N'Barquisimeto', N'Venezuela')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (7, N'Bergamo', N'Italy')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (8, N'Berlin', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (9, N'Bern', N'Switzerland')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (10, N'Boise', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (11, N'Bräcke', N'Sweden')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (12, N'Brandenburg', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (13, N'Bruxelles', N'Belgium')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (14, N'Buenos Aires', N'Argentina')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (15, N'Butte', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (16, N'Campinas', N'Brazil')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (17, N'Caracas', N'Venezuela')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (18, N'Charleroi', N'Belgium')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (19, N'Cork', N'Ireland')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (20, N'Cowes', N'UK')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (21, N'Cunewalde', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (22, N'Elgin', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (23, N'Eugene', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (24, N'Frankfurt a.M.', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (25, N'Genève', N'Switzerland')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (26, N'Graz', N'Austria')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (27, N'Helsinki', N'Finland')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (28, N'I. de Margarita', N'Venezuela')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (29, N'Kirkland', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (30, N'Kobenhavn', N'Denmark')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (31, N'Köln', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (32, N'Lander', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (33, N'Leipzig', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (34, N'Lille', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (35, N'Lisboa', N'Portugal')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (36, N'London', N'UK')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (37, N'Luleå', N'Sweden')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (38, N'Lyon', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (39, N'Madrid', N'Spain')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (40, N'Mannheim', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (41, N'Marseille', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (42, N'México D.F.', N'Mexico')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (43, N'Montréal', N'Canada')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (44, N'München', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (45, N'Münster', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (46, N'Nantes', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (47, N'Oulu', N'Finland')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (48, N'Paris', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (49, N'Portland', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (50, N'Reggio Emilia', N'Italy')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (51, N'Reims', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (52, N'Resende', N'Brazil')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (53, N'Rio de Janeiro', N'Brazil')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (54, N'Salzburg', N'Austria')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (55, N'San Cristóbal', N'Venezuela')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (56, N'San Francisco', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (57, N'Sao Paulo', N'Brazil')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (58, N'Seattle', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (59, N'Sevilla', N'Spain')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (60, N'Stavern', N'Norway')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (61, N'Strasbourg', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (62, N'Stuttgart', N'Germany')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (63, N'Torino', N'Italy')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (64, N'Toulouse', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (65, N'Tsawassen', N'Canada')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (66, N'Vancouver', N'Canada')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (67, N'Versailles', N'France')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (68, N'Walla Walla', N'USA')
INSERT [dbo].[Cities] ([CityID], [City], [Country]) VALUES (69, N'Warszawa', N'Poland')
SET IDENTITY_INSERT [dbo].[Cities] OFF
/****** Object:  Table [dbo].[Brands]    Script Date: 08/21/2012 14:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[BrandID] [smallint] NOT NULL,
	[BrandName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (1, N'Citizen')
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (2, N'Orient')
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (3, N'Casio')
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (4, N'Titan')
INSERT [dbo].[Brands] ([BrandID], [BrandName]) VALUES (5, N'Senko')
