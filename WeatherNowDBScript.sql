/****** Object:  Database [WeatherNowDB]    Script Date: 13.11.2024 19:59:52 ******/
CREATE DATABASE [WeatherNowDB]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_1', MAXSIZE = 1 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [WeatherNowDB] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [WeatherNowDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WeatherNowDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WeatherNowDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WeatherNowDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WeatherNowDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WeatherNowDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WeatherNowDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WeatherNowDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WeatherNowDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WeatherNowDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WeatherNowDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WeatherNowDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WeatherNowDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WeatherNowDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [WeatherNowDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WeatherNowDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WeatherNowDB] SET  MULTI_USER 
GO
ALTER DATABASE [WeatherNowDB] SET ENCRYPTION ON
GO
ALTER DATABASE [WeatherNowDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [WeatherNowDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[MEASUREMENT]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MEASUREMENT](
	[MeasurementId] [int] IDENTITY(1,1) NOT NULL,
	[MeasurementData] [float] NULL,
	[MeasurementTime] [datetime] NULL,
	[SensorId] [int] NULL,
 CONSTRAINT [PK_MEASUREMENT] PRIMARY KEY CLUSTERED 
(
	[MeasurementId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOCATION]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOCATION](
	[LocationId] [int] NOT NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SENSOR]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SENSOR](
	[SensorId] [int] NOT NULL,
	[SensorType] [varchar](50) NULL,
	[LocationId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SensorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MeasurementLocationView]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MeasurementLocationView] AS
SELECT 
    m.MeasurementId,
    m.MeasurementData,
    m.MeasurementTime,
    m.SensorId,
    l.LocationId
FROM 
    [dbo].[MEASUREMENT] AS m
JOIN 
    [dbo].[SENSOR] AS s ON m.SensorId = s.SensorId
LEFT JOIN 
    [dbo].[LOCATION] AS l ON s.LocationId = l.LocationId;
GO
/****** Object:  View [dbo].[SensorLocationView]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[SensorLocationView] AS
SELECT 
    s.SensorId,
    s.SensorType,
    l.City AS LocationCity
FROM 
    [dbo].[SENSOR] AS s
JOIN 
    [dbo].[LOCATION] AS l ON s.LocationId = l.LocationId;
GO
/****** Object:  View [dbo].[MeasurementSensorView]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MeasurementSensorView] AS
SELECT 
    m.MeasurementId,
    m.SensorId,
    s.SensorType,
    m.MeasurementData,
    m.MeasurementTime
FROM 
    [dbo].[MEASUREMENT] AS m
JOIN 
    [dbo].[SENSOR] AS s ON m.SensorId = s.SensorId;
GO
/****** Object:  Table [dbo].[USERDATA]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERDATA](
	[UserDataId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SensorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserDataId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Firstname] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserSensorView]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[UserSensorView] AS
SELECT 
    u.UserId,
    u.RoleId,
    s.SensorId,
    l.City AS SensorLocationCity
FROM 
    [dbo].[USER] AS u
JOIN 
    [dbo].[USERDATA] AS ud ON u.UserId = ud.UserId
JOIN 
    [dbo].[SENSOR] AS s ON ud.SensorId = s.SensorId
LEFT JOIN 
    [dbo].[LOCATION] AS l ON s.LocationId = l.LocationId;
GO
/****** Object:  Table [dbo].[ACTIVITYLOG]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTIVITYLOG](
	[ActivityId] [int] NOT NULL,
	[ActivityType] [varchar](50) NULL,
	[ActivityTime] [datetime] NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ALERT]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALERT](
	[AlertId] [int] NOT NULL,
	[AlertMessage] [varchar](50) NULL,
	[AlertTime] [datetime] NULL,
	[SensorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AlertId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLE](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LOCATION] ([LocationId], [Longitude], [Latitude], [Country], [City]) VALUES (1, NULL, NULL, N'Norway', N'Skien')
GO
INSERT [dbo].[LOCATION] ([LocationId], [Longitude], [Latitude], [Country], [City]) VALUES (2, NULL, NULL, N'Norway', N'Porsgrunn')
GO
INSERT [dbo].[LOCATION] ([LocationId], [Longitude], [Latitude], [Country], [City]) VALUES (3, NULL, NULL, N'Norway', N'Tønsberg')
GO
INSERT [dbo].[LOCATION] ([LocationId], [Longitude], [Latitude], [Country], [City]) VALUES (4, NULL, NULL, N'Norway', N'Oslo')
GO
SET IDENTITY_INSERT [dbo].[MEASUREMENT] ON 
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (11, 21, CAST(N'2024-11-02T10:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (12, 20.8, CAST(N'2024-11-02T10:30:00.000' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (13, 43.2, CAST(N'2024-11-02T10:15:00.000' AS DateTime), 2)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (15, 22.1, CAST(N'2024-11-03T11:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (16, 21.9, CAST(N'2024-11-03T11:30:00.000' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (17, 22.42, CAST(N'2024-11-08T17:41:32.443' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (18, 22.42, CAST(N'2024-11-08T17:53:00.670' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (19, 2.64, CAST(N'2024-11-08T17:54:25.557' AS DateTime), 2)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (20, 2.64, CAST(N'2024-11-08T17:55:33.120' AS DateTime), 2)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (21, 2.64, CAST(N'2024-11-08T19:36:16.117' AS DateTime), 2)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (25, 22.4, CAST(N'2024-11-08T20:35:16.757' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (26, 22.39, CAST(N'2024-11-08T20:40:19.927' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (27, 22.38, CAST(N'2024-11-08T20:45:23.017' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (28, 22.38, CAST(N'2024-11-08T20:50:26.337' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (29, 22.38, CAST(N'2024-11-08T20:55:29.760' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (30, 22.38, CAST(N'2024-11-08T21:00:32.563' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (31, 22.38, CAST(N'2024-11-08T21:05:35.830' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (32, 22.38, CAST(N'2024-11-08T21:10:38.947' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (33, 21.72, CAST(N'2024-11-08T21:13:13.150' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (34, 22.17, CAST(N'2024-11-08T21:13:23.247' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (35, 22.14, CAST(N'2024-11-08T21:13:33.343' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (36, 22.34, CAST(N'2024-11-08T21:13:43.427' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (37, 22.36, CAST(N'2024-11-08T21:13:53.510' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (38, 22.38, CAST(N'2024-11-08T21:14:03.623' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (39, 22.36, CAST(N'2024-11-08T21:14:13.717' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (40, 22.34, CAST(N'2024-11-08T21:14:23.837' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (41, 22.33, CAST(N'2024-11-08T21:14:33.913' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (42, 22.36, CAST(N'2024-11-08T21:14:43.993' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (43, 22.33, CAST(N'2024-11-08T21:14:54.103' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (44, 22.34, CAST(N'2024-11-08T21:15:04.200' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (45, 22.29, CAST(N'2024-11-08T21:24:37.180' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (46, 22.31, CAST(N'2024-11-08T21:24:57.280' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (47, 22.28, CAST(N'2024-11-08T21:30:10.913' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (48, 22.38, CAST(N'2024-11-08T21:32:20.883' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (49, 22.39, CAST(N'2024-11-08T21:32:41.053' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (50, 22.39, CAST(N'2024-11-08T21:33:01.270' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (51, 22.39, CAST(N'2024-11-08T21:33:21.523' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (52, 13.05, CAST(N'2024-11-08T21:42:01.240' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (53, 30.06, CAST(N'2024-11-08T22:11:04.223' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (54, 32, CAST(N'2024-11-08T22:16:07.767' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (55, 31.57, CAST(N'2024-11-08T22:21:10.547' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (56, 28.74, CAST(N'2024-11-08T22:26:13.737' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (57, 23.61, CAST(N'2024-11-08T22:31:17.500' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (58, 21.97, CAST(N'2024-11-08T22:36:20.300' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (59, 21.6, CAST(N'2024-11-08T22:41:23.713' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (60, 21.19, CAST(N'2024-11-08T22:46:26.857' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (61, 21.04, CAST(N'2024-11-08T22:51:30.500' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (62, 21, CAST(N'2024-11-08T22:56:33.797' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (63, 20.96, CAST(N'2024-11-08T23:01:36.957' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (64, 20.89, CAST(N'2024-11-08T23:06:40.100' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (65, 21, CAST(N'2024-11-08T23:11:43.507' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (66, 21.05, CAST(N'2024-11-08T23:16:46.967' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (67, 21, CAST(N'2024-11-08T23:21:50.037' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (68, 21.18, CAST(N'2024-11-08T23:26:53.593' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (69, 21.18, CAST(N'2024-11-08T23:31:56.660' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (70, 21.33, CAST(N'2024-11-08T23:37:00.220' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (71, 21.19, CAST(N'2024-11-08T23:42:03.277' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (72, 20.96, CAST(N'2024-11-08T23:47:06.867' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (73, 21.02, CAST(N'2024-11-08T23:52:09.913' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (74, 21.01, CAST(N'2024-11-08T23:57:13.480' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (75, 21.02, CAST(N'2024-11-08T23:57:14.373' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (76, 21.01, CAST(N'2024-11-08T23:57:15.397' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (77, 20.99, CAST(N'2024-11-09T00:02:20.700' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (78, 20.88, CAST(N'2024-11-09T00:07:24.277' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (79, 20.91, CAST(N'2024-11-09T00:12:27.253' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (80, 20.98, CAST(N'2024-11-09T00:17:30.773' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (81, 20.92, CAST(N'2024-11-09T00:22:33.827' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (82, 20.98, CAST(N'2024-11-09T00:27:37.360' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (83, 20.98, CAST(N'2024-11-09T00:32:40.557' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (84, 20.97, CAST(N'2024-11-09T00:37:44.133' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (85, 20.94, CAST(N'2024-11-09T00:42:47.350' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (86, 20.88, CAST(N'2024-11-09T00:47:51.083' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (87, 20.85, CAST(N'2024-11-09T00:52:54.287' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (88, 20.85, CAST(N'2024-11-09T00:57:57.497' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (89, 20.88, CAST(N'2024-11-09T01:03:00.930' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (90, 20.8, CAST(N'2024-11-09T01:08:04.047' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (91, 20.72, CAST(N'2024-11-09T01:13:07.647' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (92, 20.75, CAST(N'2024-11-09T01:18:10.773' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (93, 20.79, CAST(N'2024-11-09T01:23:14.343' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (94, 20.77, CAST(N'2024-11-09T01:28:17.657' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (95, 20.77, CAST(N'2024-11-09T01:33:20.847' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (96, 20.7, CAST(N'2024-11-09T01:38:24.133' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (97, 20.6, CAST(N'2024-11-09T01:43:27.733' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (98, 20.49, CAST(N'2024-11-09T01:48:30.853' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (99, 20.15, CAST(N'2024-11-09T01:53:34.440' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (100, 20, CAST(N'2024-11-09T01:58:37.810' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (101, 20.09, CAST(N'2024-11-09T02:03:41.170' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (102, 19.87, CAST(N'2024-11-09T02:08:44.477' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (103, 20.67, CAST(N'2024-11-09T02:13:47.980' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (104, 20.74, CAST(N'2024-11-09T02:18:51.300' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (105, 20.76, CAST(N'2024-11-09T02:23:54.520' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (106, 20.67, CAST(N'2024-11-09T02:28:57.943' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (107, 20.7, CAST(N'2024-11-09T02:34:01.387' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (108, 20.77, CAST(N'2024-11-09T02:39:04.713' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (109, 20.74, CAST(N'2024-11-09T02:44:08.093' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (110, 20.88, CAST(N'2024-11-09T02:49:11.517' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (111, 20.76, CAST(N'2024-11-09T02:54:14.927' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (112, 20.77, CAST(N'2024-11-09T02:59:18.130' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (113, 20.81, CAST(N'2024-11-09T03:04:21.433' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (114, 20.84, CAST(N'2024-11-09T03:09:24.700' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (115, 20.82, CAST(N'2024-11-09T03:14:27.603' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (116, 20.72, CAST(N'2024-11-09T03:19:30.897' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (117, 20.69, CAST(N'2024-11-09T03:24:33.887' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (118, 20.71, CAST(N'2024-11-09T03:29:37.087' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (119, 20.7, CAST(N'2024-11-09T03:34:39.857' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (120, 20.62, CAST(N'2024-11-09T03:39:43.290' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (121, 20.74, CAST(N'2024-11-09T03:44:46.180' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (122, 20.7, CAST(N'2024-11-09T03:49:49.510' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (123, 20.73, CAST(N'2024-11-09T03:54:52.443' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (124, 20.69, CAST(N'2024-11-09T03:59:55.747' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (125, 20.66, CAST(N'2024-11-09T04:04:58.887' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (126, 20.64, CAST(N'2024-11-09T04:10:02.090' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (127, 20.71, CAST(N'2024-11-09T04:15:05.067' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (128, 20.68, CAST(N'2024-11-09T04:20:08.420' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (129, 20.65, CAST(N'2024-11-09T04:25:11.450' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (130, 20.57, CAST(N'2024-11-09T04:30:14.793' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (131, 20.69, CAST(N'2024-11-09T04:35:17.843' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (132, 20.5, CAST(N'2024-11-09T04:40:21.110' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (133, 20.64, CAST(N'2024-11-09T04:45:24.160' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (134, 20.56, CAST(N'2024-11-09T04:50:27.473' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (135, 20.61, CAST(N'2024-11-09T04:55:30.487' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (136, 20.47, CAST(N'2024-11-09T05:00:33.757' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (137, 20.42, CAST(N'2024-11-09T05:05:36.663' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (138, 20.33, CAST(N'2024-11-09T05:10:39.967' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (139, 20.44, CAST(N'2024-11-09T05:15:43.063' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (140, 20.42, CAST(N'2024-11-09T05:20:46.660' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (141, 20.29, CAST(N'2024-11-09T05:25:49.627' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (142, 20.22, CAST(N'2024-11-09T05:30:53.103' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (143, 20.3, CAST(N'2024-11-09T05:35:56.063' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (144, 20.32, CAST(N'2024-11-09T05:40:59.353' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (145, 20.22, CAST(N'2024-11-09T05:46:02.413' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (146, 20.23, CAST(N'2024-11-09T05:51:05.773' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (147, 20.05, CAST(N'2024-11-09T05:56:08.967' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (148, 19.98, CAST(N'2024-11-09T06:01:12.173' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (149, 19.9, CAST(N'2024-11-09T06:06:15.040' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (150, 19.94, CAST(N'2024-11-09T06:11:18.367' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (151, 19.9, CAST(N'2024-11-09T06:16:21.757' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (152, 19.92, CAST(N'2024-11-09T06:21:25.030' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (153, 19.86, CAST(N'2024-11-09T06:26:28.027' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (154, 19.81, CAST(N'2024-11-09T06:31:31.350' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (155, 19.79, CAST(N'2024-11-09T06:36:34.457' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (156, 19.81, CAST(N'2024-11-09T06:41:37.483' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (157, 19.73, CAST(N'2024-11-09T06:46:40.857' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (158, 19.68, CAST(N'2024-11-09T06:51:43.950' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (159, 19.71, CAST(N'2024-11-09T06:56:47.423' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (160, 19.7, CAST(N'2024-11-09T07:01:50.147' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (161, 19.65, CAST(N'2024-11-09T07:06:53.587' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (162, 19.69, CAST(N'2024-11-09T07:11:56.400' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (163, 19.65, CAST(N'2024-11-09T07:16:59.730' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (164, 19.61, CAST(N'2024-11-09T07:22:02.853' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (165, 19.47, CAST(N'2024-11-09T07:27:05.920' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (166, 19.46, CAST(N'2024-11-09T07:32:09.097' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (167, 19.33, CAST(N'2024-11-09T07:37:12.557' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (168, 19.31, CAST(N'2024-11-09T07:42:15.710' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (169, 19.24, CAST(N'2024-11-09T07:47:18.810' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (170, 19.22, CAST(N'2024-11-09T07:52:21.957' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (171, 19.06, CAST(N'2024-11-09T07:57:25.130' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (172, 19.06, CAST(N'2024-11-09T07:57:25.970' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (173, 19.06, CAST(N'2024-11-09T07:57:26.990' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (174, 19.01, CAST(N'2024-11-09T08:02:32.100' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (175, 18.97, CAST(N'2024-11-09T08:07:35.057' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (176, 18.98, CAST(N'2024-11-09T08:12:37.773' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (177, 18.89, CAST(N'2024-11-09T08:17:41.123' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (178, 18.86, CAST(N'2024-11-09T08:22:44.157' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (179, 18.79, CAST(N'2024-11-09T08:27:47.510' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (180, 18.8, CAST(N'2024-11-09T08:32:50.367' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (181, 18.77, CAST(N'2024-11-09T08:37:53.647' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (182, 18.77, CAST(N'2024-11-09T08:42:56.653' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (183, 18.73, CAST(N'2024-11-09T08:47:59.993' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (184, 18.75, CAST(N'2024-11-09T08:53:02.773' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (185, 18.76, CAST(N'2024-11-09T08:58:06.197' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (186, 18.77, CAST(N'2024-11-09T09:03:09.440' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (187, 18.74, CAST(N'2024-11-09T09:08:12.317' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (188, 18.75, CAST(N'2024-11-09T09:13:15.617' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (189, 18.72, CAST(N'2024-11-09T09:18:18.550' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (190, 18.7, CAST(N'2024-11-09T09:23:21.937' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (191, 18.71, CAST(N'2024-11-09T09:28:24.933' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (192, 18.68, CAST(N'2024-11-09T09:33:28.340' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (193, 18.6, CAST(N'2024-11-09T09:38:31.353' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (194, 18.61, CAST(N'2024-11-09T09:43:34.713' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (195, 18.54, CAST(N'2024-11-09T09:48:37.610' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (196, 18.55, CAST(N'2024-11-09T09:53:40.963' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (197, 18.57, CAST(N'2024-11-09T09:58:43.800' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (198, 18.55, CAST(N'2024-11-09T10:03:47.047' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (199, 18.41, CAST(N'2024-11-09T10:08:49.957' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (200, 18.27, CAST(N'2024-11-09T10:13:53.360' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (201, 18.3, CAST(N'2024-11-09T10:18:56.300' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (202, 18.16, CAST(N'2024-11-09T10:23:59.607' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (203, 18.03, CAST(N'2024-11-09T10:29:02.543' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (204, 17.87, CAST(N'2024-11-09T10:34:05.767' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (205, 17.8, CAST(N'2024-11-09T10:39:08.587' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (206, 17.79, CAST(N'2024-11-09T10:44:11.583' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (207, 17.78, CAST(N'2024-11-09T10:49:14.840' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (208, 17.75, CAST(N'2024-11-09T10:54:17.630' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (209, 17.73, CAST(N'2024-11-09T10:59:20.787' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (210, 17.7, CAST(N'2024-11-09T11:04:23.887' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (211, 17.7, CAST(N'2024-11-09T11:09:27.070' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (212, 17.7, CAST(N'2024-11-09T11:14:30.067' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (213, 17.71, CAST(N'2024-11-09T11:19:32.983' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (214, 17.72, CAST(N'2024-11-09T11:24:36.063' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (215, 17.7, CAST(N'2024-11-09T11:29:39.393' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (216, 17.67, CAST(N'2024-11-09T11:34:42.460' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (217, 17.51, CAST(N'2024-11-09T11:39:45.303' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (218, 17.51, CAST(N'2024-11-09T11:44:48.430' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (219, 17.48, CAST(N'2024-11-09T11:49:51.690' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (220, 17.52, CAST(N'2024-11-09T11:54:54.563' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (221, 17.34, CAST(N'2024-11-09T11:59:57.830' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (222, 17.28, CAST(N'2024-11-09T12:05:00.800' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (223, 17.05, CAST(N'2024-11-09T12:10:03.740' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (224, 16.98, CAST(N'2024-11-09T12:15:06.997' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (225, 16.91, CAST(N'2024-11-09T12:20:10.300' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (226, 16.88, CAST(N'2024-11-09T12:25:13.287' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (227, 16.84, CAST(N'2024-11-09T12:30:16.640' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (228, 17.09, CAST(N'2024-11-09T12:35:19.533' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (229, 17.78, CAST(N'2024-11-09T12:40:22.977' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (230, 18.45, CAST(N'2024-11-09T12:45:26.137' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (231, 23.64, CAST(N'2024-11-11T13:33:56.690' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (232, 23.82, CAST(N'2024-11-11T17:28:43.897' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (233, 23.82, CAST(N'2024-11-11T17:28:44.670' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (234, 22.8, CAST(N'2024-11-11T17:28:45.677' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (235, 22.8, CAST(N'2024-11-11T17:28:46.670' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (236, 22.8, CAST(N'2024-11-11T17:28:47.683' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (237, 22.8, CAST(N'2024-11-11T17:28:48.693' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (238, 23.82, CAST(N'2024-11-11T17:28:49.700' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (239, 22.8, CAST(N'2024-11-11T17:28:50.713' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (240, 22.8, CAST(N'2024-11-11T17:28:51.710' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (241, 22.8, CAST(N'2024-11-11T17:28:52.717' AS DateTime), 1)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (242, 22.8, CAST(N'2024-11-11T17:29:49.337' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (243, 22.9, CAST(N'2024-11-11T17:29:59.403' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (244, 22.9, CAST(N'2024-11-11T17:30:09.493' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (245, 22.9, CAST(N'2024-11-11T17:31:25.280' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (246, 22.9, CAST(N'2024-11-11T17:31:35.363' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (247, 23.11, CAST(N'2024-11-11T17:31:45.467' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (248, 22.8, CAST(N'2024-11-11T17:31:55.540' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (249, 23.01, CAST(N'2024-11-11T17:32:05.657' AS DateTime), 5)
GO
INSERT [dbo].[MEASUREMENT] ([MeasurementId], [MeasurementData], [MeasurementTime], [SensorId]) VALUES (250, 23.01, CAST(N'2024-11-11T17:55:05.320' AS DateTime), 5)
GO
SET IDENTITY_INSERT [dbo].[MEASUREMENT] OFF
GO
INSERT [dbo].[ROLE] ([RoleId], [RoleName]) VALUES (0, N'user')
GO
INSERT [dbo].[ROLE] ([RoleId], [RoleName]) VALUES (1, N'admin')
GO
INSERT [dbo].[SENSOR] ([SensorId], [SensorType], [LocationId]) VALUES (1, N'temperature', 2)
GO
INSERT [dbo].[SENSOR] ([SensorId], [SensorType], [LocationId]) VALUES (2, N'humidity', 1)
GO
INSERT [dbo].[SENSOR] ([SensorId], [SensorType], [LocationId]) VALUES (3, N'humidity', 3)
GO
INSERT [dbo].[SENSOR] ([SensorId], [SensorType], [LocationId]) VALUES (5, N'temperature', 4)
GO
INSERT [dbo].[SENSOR] ([SensorId], [SensorType], [LocationId]) VALUES (6, N'windspeed', 3)
GO
SET IDENTITY_INSERT [dbo].[USER] ON 
GO
INSERT [dbo].[USER] ([UserId], [UserName], [Password], [Firstname], [Surname], [RoleId]) VALUES (46, N'admin', N'admin', N'admin', N'admin', 1)
GO
INSERT [dbo].[USER] ([UserId], [UserName], [Password], [Firstname], [Surname], [RoleId]) VALUES (52, N'user', N'user', N'user', N'user', 0)
GO
SET IDENTITY_INSERT [dbo].[USER] OFF
GO
SET IDENTITY_INSERT [dbo].[USERDATA] ON 
GO
INSERT [dbo].[USERDATA] ([UserDataId], [UserId], [SensorId]) VALUES (66, 46, 2)
GO
INSERT [dbo].[USERDATA] ([UserDataId], [UserId], [SensorId]) VALUES (71, 52, 1)
GO
SET IDENTITY_INSERT [dbo].[USERDATA] OFF
GO
ALTER TABLE [dbo].[USER] ADD  CONSTRAINT [DF_User_RoleId]  DEFAULT ((1)) FOR [RoleId]
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ACTIVITYLOG]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[ALERT]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[MEASUREMENT]  WITH CHECK ADD  CONSTRAINT [FK_MEASUREMENT_SENSOR] FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[MEASUREMENT] CHECK CONSTRAINT [FK_MEASUREMENT_SENSOR]
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[SENSOR]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[LOCATION] ([LocationId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLE] ([RoleId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[SENSOR] ([SensorId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
ALTER TABLE [dbo].[USERDATA]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USER] ([UserId])
GO
/****** Object:  StoredProcedure [dbo].[uspAddLocation]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddLocation]
    @LocationId INT,
    @Country VARCHAR(50),
    @City VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om Location allerede finnes basert på LocationId
    IF EXISTS (SELECT 1 FROM [LOCATION] WHERE LocationId = @LocationId)
    BEGIN
        RAISERROR('Location med denne ID-en eksisterer allerede.', 16, 1);
        RETURN;
    END

    -- Sett inn ny Location i LOCATION-tabellen
    INSERT INTO [LOCATION] (LocationId, Country, City)
    VALUES (@LocationId, @Country, @City);

    PRINT 'Ny Location lagt til.';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspAddLocationToSensor]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspAddLocationToSensor]
    @SensorId INT,
    @LocationId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om sensoren finnes
    IF EXISTS (SELECT 1 FROM [dbo].[SENSOR] WHERE SensorId = @SensorId)
    BEGIN
        -- Oppdater LocationId for den angitte SensorId
        UPDATE [dbo].[SENSOR]
        SET LocationId = @LocationId
        WHERE SensorId = @SensorId;
        
        PRINT 'Location oppdatert for Sensor.';
    END
    ELSE
    BEGIN
        -- Hvis SensorId ikke finnes, returner en feilmelding
        RAISERROR('Sensor med ID %d eksisterer ikke.', 16, 1, @SensorId);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspAddNewSensor]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddNewSensor]
    @SensorId INT,
    @SensorType VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om sensoren allerede finnes basert på SensorId
    IF EXISTS (SELECT 1 FROM [SENSOR] WHERE SensorId = @SensorId)
    BEGIN
        RAISERROR('Sensor med denne ID-en eksisterer allerede.', 16, 1);
        RETURN;
    END

    -- Sett inn en ny sensor i SENSOR-tabellen
    INSERT INTO [SENSOR] (SensorId, SensorType)
    VALUES (@SensorId, @SensorType);

    PRINT 'Ny sensor lagt til.';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspAddNewUser]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Opprett lagret prosedyre for å legge til en ny RFID-bruker
CREATE PROCEDURE [dbo].[uspAddNewUser]
    @username NVARCHAR(50),
    @password NVARCHAR(50),
    @firstname NVARCHAR(50),
    @surname NVARCHAR(50),
    @roleid INT
AS
BEGIN
    -- Sjekk om brukernavnet allerede finnes (valgfritt)
    IF EXISTS (SELECT 1 FROM [USER] WHERE Username = @username)
    BEGIN
        RAISERROR('Brukernavn eksisterer allerede.', 16, 1);
        RETURN;
    END

    -- Sett inn en ny bruker i tabellen [USER] (antagelse om tabellstruktur)
    INSERT INTO [USER] (Username, Password, Firstname, Surname, RoleId)
    VALUES (@username, @password, @firstname, @surname, @roleid);

    -- Bekreft antall rader som ble lagt til (valgfritt)
    PRINT 'Ny bruker lagt til i systemet';
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddUserData]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspAddUserData]
    @UserId INT,
    @SensorId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Sett inn UserId og SensorId i USERDATA-tabellen
    INSERT INTO [dbo].[USERDATA] (UserId, SensorId)
    VALUES (@UserId, @SensorId);
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteLocation]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteLocation]
    @LocationId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om Location eksisterer basert på LocationId
    IF NOT EXISTS (SELECT 1 FROM [LOCATION] WHERE LocationId = @LocationId)
    BEGIN
        RAISERROR('Location med denne ID-en eksisterer ikke.', 16, 1);
        RETURN;
    END

    -- Slett Location fra LOCATION-tabellen
    DELETE FROM [LOCATION]
    WHERE LocationId = @LocationId;

    PRINT 'Location slettet.';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteMeasurement]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspDeleteMeasurement]
    @MeasurementId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om Measurement eksisterer basert på MeasurementId
    IF NOT EXISTS (SELECT 1 FROM [MEASUREMENT] WHERE MeasurementId = @MeasurementId)
    BEGIN
        RAISERROR('Måling med denne ID-en eksisterer ikke.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        -- Slett målingen fra MEASUREMENT-tabellen
        DELETE FROM [MEASUREMENT]
        WHERE MeasurementId = @MeasurementId;

        PRINT 'Måling slettet fra databasen.';
    END TRY
    BEGIN CATCH
        -- Håndter eventuelle feil
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteSensor]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteSensor]
    @SensorId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om Sensor eksisterer basert på SensorId
    IF NOT EXISTS (SELECT 1 FROM [SENSOR] WHERE SensorId = @SensorId)
    BEGIN
        RAISERROR('Sensor med denne ID-en eksisterer ikke.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        -- Slett alle målinger knyttet til sensoren
        DELETE FROM [MEASUREMENT]
        WHERE SensorId = @SensorId;

        -- Slett sensoren fra SENSOR-tabellen
        DELETE FROM [SENSOR]
        WHERE SensorId = @SensorId;

        PRINT 'Sensor og tilknyttede målinger slettet fra databasen.';
    END TRY
    BEGIN CATCH
        -- Håndter eventuelle feil
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteUserSensor]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspDeleteUserSensor]
    @UserId INT,
    @SensorId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Slett rad fra USERDATA-tabellen der UserId og SensorId matcher de angitte parametrene
    DELETE FROM [dbo].[USERDATA]
    WHERE UserId = @UserId AND SensorId = @SensorId;

    -- Bekreft at raden ble slettet (valgfritt)
    PRINT 'Sensor slettet fra bruker i USERDATA.';
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetMeasurementsBySensorAndDate]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetMeasurementsBySensorAndDate]
    @SensorId INT,
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM [dbo].[MeasurementLocationView]
    WHERE SensorId = @SensorId 
      AND MeasurementTime BETWEEN @FromDate AND @ToDate;
END
GO
/****** Object:  StoredProcedure [dbo].[uspInsertMeasurement]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspInsertMeasurement]
    @MeasurementData FLOAT,
    @MeasurementTime DATETIME,
    @SensorId INT,
    @LocationId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO MEASUREMENT (MeasurementData, MeasurementTime, SensorId)
    VALUES (@MeasurementData, @MeasurementTime, @SensorId);

END
GO
/****** Object:  StoredProcedure [dbo].[uspRemoveLocationFromSensor]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRemoveLocationFromSensor]
    @SensorId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Sjekk om sensoren finnes
    IF EXISTS (SELECT 1 FROM [dbo].[SENSOR] WHERE SensorId = @SensorId)
    BEGIN
        -- Fjern LocationId for den angitte SensorId ved å sette den til NULL
        UPDATE [dbo].[SENSOR]
        SET LocationId = NULL
        WHERE SensorId = @SensorId;

        PRINT 'Location fjernet for Sensor.';
    END
    ELSE
    BEGIN
        -- Hvis SensorId ikke finnes, returner en feilmelding
        RAISERROR('Sensor med ID %d eksisterer ikke.', 16, 1, @SensorId);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRemoveUser]    Script Date: 13.11.2024 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Opprett ny lagret prosedyre for å slette en bruker basert på userId
CREATE PROCEDURE [dbo].[uspRemoveUser] 
    @userId int
AS
BEGIN
    -- Sjekk om input er gyldig
    IF @userId IS NULL
    BEGIN
        RAISERROR('UserId kan ikke være NULL', 16, 1);
        RETURN;
    END

    -- Slett fra tabellen [USER] der UserId matcher parameteren
    DELETE FROM [USER]
    WHERE UserId = @userId;

    -- Returner antall rader som ble slettet (valgfritt)
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Ingen bruker funnet med UserId = %d', 16, 1, @userId);
    END
    ELSE
    BEGIN
        PRINT 'Bruker med UserId = ' + CAST(@userId AS VARCHAR(10)) + ' ble slettet.';
    END
END
GO
ALTER DATABASE [WeatherNowDB] SET  READ_WRITE 
GO
