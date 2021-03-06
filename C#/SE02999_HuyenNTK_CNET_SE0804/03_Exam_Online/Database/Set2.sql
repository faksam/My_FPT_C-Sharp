SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='PE0503')
		drop database PE0503
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE PE0503
  ON PRIMARY (NAME = N''PE0503'', FILENAME = N''' + @device_directory + N'PE0503.mdf'')
  LOG ON (NAME = N''PE0501_log'',  FILENAME = N''' + @device_directory + N'PE0503.ldf'')')
go

exec sp_dboption 'PE0503','trunc. log on chkpt.','true'
exec sp_dboption 'PE0503','select into/bulkcopy','true'
GO

set quoted_identifier on
GO

USE [PE0503]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[RegionID] [smallint] IDENTITY(1,1) NOT NULL,
	[RegionName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Regions] ON
INSERT [dbo].[Regions] ([RegionID], [RegionName]) VALUES (1, N'Korea')
INSERT [dbo].[Regions] ([RegionID], [RegionName]) VALUES (2, N'Thailand')
INSERT [dbo].[Regions] ([RegionID], [RegionName]) VALUES (3, N'Vietnam')
INSERT [dbo].[Regions] ([RegionID], [RegionName]) VALUES (4, N'China')
INSERT [dbo].[Regions] ([RegionID], [RegionName]) VALUES (5, N'Malaysia')
SET IDENTITY_INSERT [dbo].[Regions] OFF
/****** Object:  Table [dbo].[Pots]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pots](
	[PotID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[NumberOfPots] [tinyint] NOT NULL,
	[Origin] [smallint] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Pots] PRIMARY KEY CLUSTERED 
(
	[PotID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pots] ON
INSERT [dbo].[Pots] ([PotID], [Label], [Price], [NumberOfPots], [Origin], [Description]) VALUES (1, N'Bộ nồi Hera-Dongil', 1780000.0000, 4, 1, N'Bộ nồi Anod được làm từ nhôm nguyên chất có độ dầy 2.5 mm')
SET IDENTITY_INSERT [dbo].[Pots] OFF
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[ManufacturerID] [smallint] IDENTITY(1,1) NOT NULL,
	[ManufacturerName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Manufacturers] ON
INSERT [dbo].[Manufacturers] ([ManufacturerID], [ManufacturerName]) VALUES (1, N'Philliger')
INSERT [dbo].[Manufacturers] ([ManufacturerID], [ManufacturerName]) VALUES (2, N'Saiko')
INSERT [dbo].[Manufacturers] ([ManufacturerID], [ManufacturerName]) VALUES (3, N'Bluestone')
INSERT [dbo].[Manufacturers] ([ManufacturerID], [ManufacturerName]) VALUES (4, N'Gali')
INSERT [dbo].[Manufacturers] ([ManufacturerID], [ManufacturerName]) VALUES (5, N'Midea')
SET IDENTITY_INSERT [dbo].[Manufacturers] OFF
/****** Object:  Table [dbo].[FullOrders]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FullOrders](
	[OrderID] [int] NOT NULL,
	[CustomerID] [nchar](5) NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [smallint] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10500, N'LAMAI', 15, 15.5000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10500, N'LAMAI', 28, 45.6000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10501, N'BLAUS', 54, 7.4500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10502, N'PERIC', 45, 9.5000, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10502, N'PERIC', 53, 32.8000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10502, N'PERIC', 67, 14.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10503, N'HUNGO', 14, 23.2500, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10503, N'HUNGO', 65, 21.0500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 2, 19.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 21, 10.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 53, 32.8000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 61, 28.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10505, N'MEREP', 62, 49.3000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10506, N'KOENE', 25, 14.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10506, N'KOENE', 70, 15.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10507, N'ANTON', 43, 46.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10507, N'ANTON', 48, 12.7500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10508, N'OTTIK', 13, 6.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10508, N'OTTIK', 39, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10509, N'BLAUS', 28, 45.6000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10510, N'SAVEA', 29, 123.7900, 36)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10510, N'SAVEA', 75, 7.7500, 36)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10511, N'BONAP', 4, 22.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10511, N'BONAP', 7, 30.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10511, N'BONAP', 8, 40.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 24, 4.5000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 46, 12.0000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 47, 9.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 60, 34.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10513, N'WANDK', 21, 10.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10513, N'WANDK', 32, 32.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10513, N'WANDK', 61, 28.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 20, 81.0000, 39)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 28, 45.6000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 56, 38.0000, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 65, 21.0500, 39)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 75, 7.7500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 9, 97.0000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 16, 17.4500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 27, 43.9000, 120)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 33, 2.5000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 60, 34.0000, 84)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10516, N'HUNGO', 18, 62.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10516, N'HUNGO', 41, 9.6500, 80)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10516, N'HUNGO', 42, 14.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10517, N'NORTS', 52, 7.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10517, N'NORTS', 59, 55.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10517, N'NORTS', 70, 15.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10518, N'TORTU', 24, 4.5000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10518, N'TORTU', 38, 263.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10518, N'TORTU', 44, 19.4500, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10519, N'CHOPS', 10, 31.0000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10519, N'CHOPS', 56, 38.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10519, N'CHOPS', 60, 34.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10520, N'SANTG', 24, 4.5000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10520, N'SANTG', 53, 32.8000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10521, N'CACTU', 35, 18.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10521, N'CACTU', 41, 9.6500, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10521, N'CACTU', 68, 12.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 1, 18.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 8, 40.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 30, 25.8900, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 40, 18.4000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 17, 39.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 20, 81.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 37, 26.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 41, 9.6500, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 10, 31.0000, 2)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 30, 25.8900, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 43, 46.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 54, 7.4500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10525, N'BONAP', 36, 19.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10525, N'BONAP', 40, 18.4000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10526, N'WARTH', 1, 18.0000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10526, N'WARTH', 13, 6.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10526, N'WARTH', 56, 38.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10527, N'QUICK', 4, 22.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10527, N'QUICK', 36, 19.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10528, N'GREAL', 11, 21.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10528, N'GREAL', 33, 2.5000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10528, N'GREAL', 72, 34.8000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10529, N'MAISD', 55, 24.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10529, N'MAISD', 68, 12.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10529, N'MAISD', 69, 36.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 17, 39.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 43, 46.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 61, 28.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 76, 18.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10531, N'OCEAN', 59, 55.0000, 2)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10532, N'EASTC', 30, 25.8900, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10532, N'EASTC', 66, 17.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10533, N'FOLKO', 4, 22.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10533, N'FOLKO', 72, 34.8000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10533, N'FOLKO', 73, 15.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10534, N'LEHMS', 30, 25.8900, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10534, N'LEHMS', 40, 18.4000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10534, N'LEHMS', 54, 7.4500, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 11, 21.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 40, 18.4000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 57, 19.5000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 59, 55.0000, 15)
GO
print 'Processed 100 total records'
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 12, 38.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 31, 12.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 33, 2.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 60, 34.0000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 31, 12.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 51, 53.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 58, 13.2500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 72, 34.8000, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 73, 15.0000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10538, N'BSBEV', 70, 15.0000, 7)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10538, N'BSBEV', 72, 34.8000, 1)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 13, 6.0000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 21, 10.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 33, 2.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 49, 20.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 3, 10.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 26, 31.2300, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 38, 263.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 68, 12.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 24, 4.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 38, 263.5000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 65, 21.0500, 36)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 71, 21.5000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10542, N'KOENE', 11, 21.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10542, N'KOENE', 54, 7.4500, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10543, N'LILAS', 12, 38.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10543, N'LILAS', 23, 9.0000, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10544, N'LONEP', 28, 45.6000, 7)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10544, N'LONEP', 67, 14.0000, 7)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10545, N'LAZYK', 11, 21.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10546, N'VICTE', 7, 30.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10546, N'VICTE', 35, 18.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10546, N'VICTE', 62, 49.3000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10547, N'SEVES', 32, 32.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10547, N'SEVES', 36, 19.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10548, N'TOMSP', 34, 14.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10548, N'TOMSP', 41, 9.6500, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10549, N'QUICK', 31, 12.5000, 55)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10549, N'QUICK', 45, 9.5000, 100)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10549, N'QUICK', 51, 53.0000, 48)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 17, 39.0000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 19, 9.2000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 21, 10.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 61, 28.5000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10551, N'FURIB', 16, 17.4500, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10551, N'FURIB', 35, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10551, N'FURIB', 44, 19.4500, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10552, N'HILAA', 69, 36.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10552, N'HILAA', 75, 7.7500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 11, 21.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 16, 17.4500, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 22, 21.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 31, 12.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 35, 18.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 16, 17.4500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 23, 9.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 62, 49.3000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 77, 13.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 14, 23.2500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 19, 9.2000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 24, 4.5000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 51, 53.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 56, 38.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10556, N'SIMOB', 72, 34.8000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10557, N'LEHMS', 64, 33.2500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10557, N'LEHMS', 75, 7.7500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 47, 9.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 51, 53.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 52, 7.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 53, 32.8000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 73, 15.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10559, N'BLONP', 41, 9.6500, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10559, N'BLONP', 55, 24.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10560, N'FRANK', 30, 25.8900, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10560, N'FRANK', 62, 49.3000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10561, N'FOLKO', 44, 19.4500, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10561, N'FOLKO', 51, 53.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10562, N'REGGC', 33, 2.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10562, N'REGGC', 62, 49.3000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10563, N'RICAR', 36, 19.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10563, N'RICAR', 52, 7.0000, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10564, N'RATTC', 17, 39.0000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10564, N'RATTC', 31, 12.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10564, N'RATTC', 55, 24.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10565, N'MEREP', 24, 4.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10565, N'MEREP', 64, 33.2500, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10566, N'BLONP', 11, 21.0000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10566, N'BLONP', 18, 62.5000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10566, N'BLONP', 76, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10567, N'HUNGO', 31, 12.5000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10567, N'HUNGO', 51, 53.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10567, N'HUNGO', 59, 55.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10568, N'GALED', 10, 31.0000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10569, N'RATTC', 31, 12.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10569, N'RATTC', 76, 18.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10570, N'MEREP', 11, 21.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10570, N'MEREP', 56, 38.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10571, N'ERNSH', 14, 23.2500, 11)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10571, N'ERNSH', 42, 14.0000, 28)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 16, 17.4500, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 32, 32.0000, 10)
GO
print 'Processed 200 total records'
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 40, 18.4000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 75, 7.7500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10573, N'ANTON', 17, 39.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10573, N'ANTON', 34, 14.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10573, N'ANTON', 53, 32.8000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 33, 2.5000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10500, N'LAMAI', 15, 15.5000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10500, N'LAMAI', 28, 45.6000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10501, N'BLAUS', 54, 7.4500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10502, N'PERIC', 45, 9.5000, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10502, N'PERIC', 53, 32.8000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10502, N'PERIC', 67, 14.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10503, N'HUNGO', 14, 23.2500, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10503, N'HUNGO', 65, 21.0500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 2, 19.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 21, 10.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 53, 32.8000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10504, N'WHITC', 61, 28.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10505, N'MEREP', 62, 49.3000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10506, N'KOENE', 25, 14.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10506, N'KOENE', 70, 15.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10507, N'ANTON', 43, 46.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10507, N'ANTON', 48, 12.7500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10508, N'OTTIK', 13, 6.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10508, N'OTTIK', 39, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10509, N'BLAUS', 28, 45.6000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10510, N'SAVEA', 29, 123.7900, 36)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10510, N'SAVEA', 75, 7.7500, 36)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10511, N'BONAP', 4, 22.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10511, N'BONAP', 7, 30.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10511, N'BONAP', 8, 40.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 24, 4.5000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 46, 12.0000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 47, 9.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10512, N'FAMIA', 60, 34.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10513, N'WANDK', 21, 10.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10513, N'WANDK', 32, 32.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10513, N'WANDK', 61, 28.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 20, 81.0000, 39)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 28, 45.6000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 56, 38.0000, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 65, 21.0500, 39)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10514, N'ERNSH', 75, 7.7500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 9, 97.0000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 16, 17.4500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 27, 43.9000, 120)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 33, 2.5000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10515, N'QUICK', 60, 34.0000, 84)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10516, N'HUNGO', 18, 62.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10516, N'HUNGO', 41, 9.6500, 80)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10516, N'HUNGO', 42, 14.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10517, N'NORTS', 52, 7.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10517, N'NORTS', 59, 55.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10517, N'NORTS', 70, 15.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10518, N'TORTU', 24, 4.5000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10518, N'TORTU', 38, 263.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10518, N'TORTU', 44, 19.4500, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10519, N'CHOPS', 10, 31.0000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10519, N'CHOPS', 56, 38.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10519, N'CHOPS', 60, 34.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10520, N'SANTG', 24, 4.5000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10520, N'SANTG', 53, 32.8000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10521, N'CACTU', 35, 18.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10521, N'CACTU', 41, 9.6500, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10521, N'CACTU', 68, 12.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 1, 18.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 8, 40.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 30, 25.8900, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10522, N'LEHMS', 40, 18.4000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 17, 39.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 20, 81.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 37, 26.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10523, N'SEVES', 41, 9.6500, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 10, 31.0000, 2)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 30, 25.8900, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 43, 46.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10524, N'BERGS', 54, 7.4500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10525, N'BONAP', 36, 19.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10525, N'BONAP', 40, 18.4000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10526, N'WARTH', 1, 18.0000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10526, N'WARTH', 13, 6.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10526, N'WARTH', 56, 38.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10527, N'QUICK', 4, 22.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10527, N'QUICK', 36, 19.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10528, N'GREAL', 11, 21.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10528, N'GREAL', 33, 2.5000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10528, N'GREAL', 72, 34.8000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10529, N'MAISD', 55, 24.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10529, N'MAISD', 68, 12.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10529, N'MAISD', 69, 36.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 17, 39.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 43, 46.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 61, 28.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10530, N'PICCO', 76, 18.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10531, N'OCEAN', 59, 55.0000, 2)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10532, N'EASTC', 30, 25.8900, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10532, N'EASTC', 66, 17.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10533, N'FOLKO', 4, 22.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10533, N'FOLKO', 72, 34.8000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10533, N'FOLKO', 73, 15.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10534, N'LEHMS', 30, 25.8900, 10)
GO
print 'Processed 300 total records'
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10534, N'LEHMS', 40, 18.4000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10534, N'LEHMS', 54, 7.4500, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 11, 21.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 40, 18.4000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 57, 19.5000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10535, N'ANTON', 59, 55.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 12, 38.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 31, 12.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 33, 2.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10536, N'LEHMS', 60, 34.0000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 31, 12.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 51, 53.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 58, 13.2500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 72, 34.8000, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10537, N'RICSU', 73, 15.0000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10538, N'BSBEV', 70, 15.0000, 7)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10538, N'BSBEV', 72, 34.8000, 1)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 13, 6.0000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 21, 10.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 33, 2.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10539, N'BSBEV', 49, 20.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 3, 10.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 26, 31.2300, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 38, 263.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10540, N'QUICK', 68, 12.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 24, 4.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 38, 263.5000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 65, 21.0500, 36)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10541, N'HANAR', 71, 21.5000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10542, N'KOENE', 11, 21.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10542, N'KOENE', 54, 7.4500, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10543, N'LILAS', 12, 38.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10543, N'LILAS', 23, 9.0000, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10544, N'LONEP', 28, 45.6000, 7)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10544, N'LONEP', 67, 14.0000, 7)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10545, N'LAZYK', 11, 21.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10546, N'VICTE', 7, 30.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10546, N'VICTE', 35, 18.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10546, N'VICTE', 62, 49.3000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10547, N'SEVES', 32, 32.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10547, N'SEVES', 36, 19.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10548, N'TOMSP', 34, 14.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10548, N'TOMSP', 41, 9.6500, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10549, N'QUICK', 31, 12.5000, 55)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10549, N'QUICK', 45, 9.5000, 100)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10549, N'QUICK', 51, 53.0000, 48)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 17, 39.0000, 8)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 19, 9.2000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 21, 10.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10550, N'GODOS', 61, 28.5000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10551, N'FURIB', 16, 17.4500, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10551, N'FURIB', 35, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10551, N'FURIB', 44, 19.4500, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10552, N'HILAA', 69, 36.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10552, N'HILAA', 75, 7.7500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 11, 21.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 16, 17.4500, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 22, 21.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 31, 12.5000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10553, N'WARTH', 35, 18.0000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 16, 17.4500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 23, 9.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 62, 49.3000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10554, N'OTTIK', 77, 13.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 14, 23.2500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 19, 9.2000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 24, 4.5000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 51, 53.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10555, N'SAVEA', 56, 38.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10556, N'SIMOB', 72, 34.8000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10557, N'LEHMS', 64, 33.2500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10557, N'LEHMS', 75, 7.7500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 47, 9.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 51, 53.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 52, 7.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 53, 32.8000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10558, N'AROUT', 73, 15.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10559, N'BLONP', 41, 9.6500, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10559, N'BLONP', 55, 24.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10560, N'FRANK', 30, 25.8900, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10560, N'FRANK', 62, 49.3000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10561, N'FOLKO', 44, 19.4500, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10561, N'FOLKO', 51, 53.0000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10562, N'REGGC', 33, 2.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10562, N'REGGC', 62, 49.3000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10563, N'RICAR', 36, 19.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10563, N'RICAR', 52, 7.0000, 70)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10564, N'RATTC', 17, 39.0000, 16)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10564, N'RATTC', 31, 12.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10564, N'RATTC', 55, 24.0000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10565, N'MEREP', 24, 4.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10565, N'MEREP', 64, 33.2500, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10566, N'BLONP', 11, 21.0000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10566, N'BLONP', 18, 62.5000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10566, N'BLONP', 76, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10567, N'HUNGO', 31, 12.5000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10567, N'HUNGO', 51, 53.0000, 3)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10567, N'HUNGO', 59, 55.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10568, N'GALED', 10, 31.0000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10569, N'RATTC', 31, 12.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10569, N'RATTC', 76, 18.0000, 30)
GO
print 'Processed 400 total records'
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10570, N'MEREP', 11, 21.0000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10570, N'MEREP', 56, 38.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10571, N'ERNSH', 14, 23.2500, 11)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10571, N'ERNSH', 42, 14.0000, 28)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 16, 17.4500, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 32, 32.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 40, 18.4000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10572, N'BERGS', 75, 7.7500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10573, N'ANTON', 17, 39.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10573, N'ANTON', 34, 14.0000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10573, N'ANTON', 53, 32.8000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 33, 2.5000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 40, 18.4000, 2)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 62, 49.3000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 64, 33.2500, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 59, 55.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 63, 43.9000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 72, 34.8000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 76, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10576, N'TORTU', 1, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10576, N'TORTU', 31, 12.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10576, N'TORTU', 44, 19.4500, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10577, N'TRAIH', 39, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10577, N'TRAIH', 75, 7.7500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10577, N'TRAIH', 77, 13.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10578, N'BSBEV', 35, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10578, N'BSBEV', 57, 19.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10579, N'LETSS', 15, 15.5000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10579, N'LETSS', 75, 7.7500, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10580, N'OTTIK', 14, 23.2500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10580, N'OTTIK', 41, 9.6500, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10580, N'OTTIK', 65, 21.0500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10581, N'FAMIA', 75, 7.7500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10582, N'BLAUS', 57, 19.5000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10582, N'BLAUS', 76, 18.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10583, N'WARTH', 29, 123.7900, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10583, N'WARTH', 60, 34.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10583, N'WARTH', 69, 36.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10584, N'BLONP', 31, 12.5000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10585, N'WELLI', 47, 9.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10586, N'REGGC', 52, 7.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10587, N'QUEDE', 26, 31.2300, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10587, N'QUEDE', 35, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10587, N'QUEDE', 77, 13.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10588, N'QUICK', 18, 62.5000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10588, N'QUICK', 42, 14.0000, 100)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10589, N'GREAL', 35, 18.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10590, N'MEREP', 1, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10590, N'MEREP', 77, 13.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10591, N'VAFFE', 3, 10.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10591, N'VAFFE', 7, 30.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10591, N'VAFFE', 54, 7.4500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10592, N'LEHMS', 15, 15.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10592, N'LEHMS', 26, 31.2300, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10593, N'LEHMS', 20, 81.0000, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10593, N'LEHMS', 69, 36.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10593, N'LEHMS', 76, 18.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10594, N'OLDWO', 52, 7.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10594, N'OLDWO', 58, 13.2500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10595, N'ERNSH', 35, 18.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10595, N'ERNSH', 61, 28.5000, 120)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10595, N'ERNSH', 69, 36.0000, 65)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10596, N'WHITC', 56, 38.0000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10596, N'WHITC', 63, 43.9000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10596, N'WHITC', 75, 7.7500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10597, N'PICCO', 24, 4.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10597, N'PICCO', 57, 19.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10597, N'PICCO', 65, 21.0500, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10598, N'RATTC', 27, 43.9000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10598, N'RATTC', 71, 21.5000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10599, N'BSBEV', 62, 49.3000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 40, 18.4000, 2)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 62, 49.3000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10574, N'TRAIH', 64, 33.2500, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 59, 55.0000, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 63, 43.9000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 72, 34.8000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10575, N'MORGK', 76, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10576, N'TORTU', 1, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10576, N'TORTU', 31, 12.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10576, N'TORTU', 44, 19.4500, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10577, N'TRAIH', 39, 18.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10577, N'TRAIH', 75, 7.7500, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10577, N'TRAIH', 77, 13.0000, 18)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10578, N'BSBEV', 35, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10578, N'BSBEV', 57, 19.5000, 6)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10579, N'LETSS', 15, 15.5000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10579, N'LETSS', 75, 7.7500, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10580, N'OTTIK', 14, 23.2500, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10580, N'OTTIK', 41, 9.6500, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10580, N'OTTIK', 65, 21.0500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10581, N'FAMIA', 75, 7.7500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10582, N'BLAUS', 57, 19.5000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10582, N'BLAUS', 76, 18.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10583, N'WARTH', 29, 123.7900, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10583, N'WARTH', 60, 34.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10583, N'WARTH', 69, 36.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10584, N'BLONP', 31, 12.5000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10585, N'WELLI', 47, 9.5000, 15)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10586, N'REGGC', 52, 7.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10587, N'QUEDE', 26, 31.2300, 6)
GO
print 'Processed 500 total records'
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10587, N'QUEDE', 35, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10587, N'QUEDE', 77, 13.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10588, N'QUICK', 18, 62.5000, 40)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10588, N'QUICK', 42, 14.0000, 100)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10589, N'GREAL', 35, 18.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10590, N'MEREP', 1, 18.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10590, N'MEREP', 77, 13.0000, 60)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10591, N'VAFFE', 3, 10.0000, 14)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10591, N'VAFFE', 7, 30.0000, 10)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10591, N'VAFFE', 54, 7.4500, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10592, N'LEHMS', 15, 15.5000, 25)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10592, N'LEHMS', 26, 31.2300, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10593, N'LEHMS', 20, 81.0000, 21)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10593, N'LEHMS', 69, 36.0000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10593, N'LEHMS', 76, 18.0000, 4)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10594, N'OLDWO', 52, 7.0000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10594, N'OLDWO', 58, 13.2500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10595, N'ERNSH', 35, 18.0000, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10595, N'ERNSH', 61, 28.5000, 120)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10595, N'ERNSH', 69, 36.0000, 65)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10596, N'WHITC', 56, 38.0000, 5)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10596, N'WHITC', 63, 43.9000, 24)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10596, N'WHITC', 75, 7.7500, 30)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10597, N'PICCO', 24, 4.5000, 35)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10597, N'PICCO', 57, 19.5000, 20)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10597, N'PICCO', 65, 21.0500, 12)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10598, N'RATTC', 27, 43.9000, 50)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10598, N'RATTC', 71, 21.5000, 9)
INSERT [dbo].[FullOrders] ([OrderID], [CustomerID], [ProductID], [UnitPrice], [Quantity]) VALUES (10599, N'BSBEV', 62, 49.3000, 10)
/****** Object:  Table [dbo].[Countries]    Script Date: 02/15/2011 17:47:49 ******/
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
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (2, N'China')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (3, N'Singapore')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (4, N'Malaysia')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (5, N'Indonesia')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (6, N'Japan')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (7, N'Korea')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (8, N'United State')
INSERT [dbo].[Countries] ([CountryID], [CountryName]) VALUES (9, N'Thailand')
/****** Object:  Table [dbo].[Cookers]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cookers](
	[CookerID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[ManufacturerID] [smallint] NOT NULL,
	[Price] [money] NOT NULL,
	[Accessories] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Cookers] PRIMARY KEY CLUSTERED 
(
	[CookerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cookers] ON
INSERT [dbo].[Cookers] ([CookerID], [Label], [ManufacturerID], [Price], [Accessories], [Color]) VALUES (1, N'Bếp điện từ đa chức năng', 1, 670000.0000, N'Nồi lẩu chuyên dụng', N'Đỏ đen')
SET IDENTITY_INSERT [dbo].[Cookers] OFF
/****** Object:  Table [dbo].[Companies]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyID] [smallint] NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (1, N'FPT Elead')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (2, N'CMS')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (3, N'Toshiba')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (4, N'Sony')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (5, N'Acer')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (6, N'Lenovo')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (7, N'Hewlett Packard')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (8, N'Samsung')
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (9, N'Fujitsu')
/****** Object:  Table [dbo].[AssetTypes]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypes](
	[AssetTypeID] [smallint] NOT NULL,
	[AssetTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AssetTypes] PRIMARY KEY CLUSTERED 
(
	[AssetTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeName]) VALUES (1, N'Desktops')
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeName]) VALUES (2, N'Notebooks')
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeName]) VALUES (3, N'PC Servers')
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeName]) VALUES (4, N'Servers')
INSERT [dbo].[AssetTypes] ([AssetTypeID], [AssetTypeName]) VALUES (5, N'Others')
/****** Object:  Table [dbo].[AssetSources]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetSources](
	[AssetSourceID] [smallint] NOT NULL,
	[AssetSourceName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AssetSources] PRIMARY KEY CLUSTERED 
(
	[AssetSourceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AssetSources] ([AssetSourceID], [AssetSourceName]) VALUES (1, N'From buying')
INSERT [dbo].[AssetSources] ([AssetSourceID], [AssetSourceName]) VALUES (2, N'Are gifts')
INSERT [dbo].[AssetSources] ([AssetSourceID], [AssetSourceName]) VALUES (3, N'Others')
/****** Object:  Table [dbo].[Assets]    Script Date: 02/15/2011 17:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assets](
	[AssetID] [int] NOT NULL,
	[AssetName] [nvarchar](50) NOT NULL,
	[AssetTypeID] [smallint] NOT NULL,
	[AssetCode] [varchar](10) NOT NULL,
	[AssetSourceID] [smallint] NOT NULL,
	[ProductionYear] [smallint] NOT NULL,
	[UsedYear] [smallint] NOT NULL,
	[CountryID] [smallint] NOT NULL,
	[CompanyID] [smallint] NOT NULL,
	[CPU] [nvarchar](50) NOT NULL,
	[HDD] [smallint] NOT NULL,
	[RAM] [smallint] NOT NULL,
	[Monitor] [nvarchar](50) NOT NULL,
	[TotalPrice] [money] NOT NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[AssetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Assets] ([AssetID], [AssetName], [AssetTypeID], [AssetCode], [AssetSourceID], [ProductionYear], [UsedYear], [CountryID], [CompanyID], [CPU], [HDD], [RAM], [Monitor], [TotalPrice]) VALUES (1, N'Computer 1', 1, N'0001', 1, 2007, 2007, 1, 1, N'2 Ghz', 40, 1024, N'CRT 14 inch', 7000000.0000)
INSERT [dbo].[Assets] ([AssetID], [AssetName], [AssetTypeID], [AssetCode], [AssetSourceID], [ProductionYear], [UsedYear], [CountryID], [CompanyID], [CPU], [HDD], [RAM], [Monitor], [TotalPrice]) VALUES (2, N'Computer 2', 2, N'0002', 1, 2008, 2008, 1, 1, N'2 Ghz', 80, 1024, N'LCD 15 inch', 15000000.0000)
INSERT [dbo].[Assets] ([AssetID], [AssetName], [AssetTypeID], [AssetCode], [AssetSourceID], [ProductionYear], [UsedYear], [CountryID], [CompanyID], [CPU], [HDD], [RAM], [Monitor], [TotalPrice]) VALUES (3, N'Computer 3', 1, N'0003', 2, 2007, 2007, 1, 1, N'2 Ghz', 80, 1024, N'CRT 17 inch', 7100000.0000)
