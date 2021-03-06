USE [master]
GO
/****** Object:  Database [JOB_ASSIGNMENT_DB]    Script Date: 05/01/2015 16:11:13 ******/
CREATE DATABASE [JOB_ASSIGNMENT_DB] ON  PRIMARY 
( NAME = N'JOB_ASSIGNMENT_DB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\JOB_ASSIGNMENT_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JOB_ASSIGNMENT_DB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\JOB_ASSIGNMENT_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JOB_ASSIGNMENT_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET  DISABLE_BROKER
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET  READ_WRITE
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET  MULTI_USER
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [JOB_ASSIGNMENT_DB] SET DB_CHAINING OFF
GO
USE [JOB_ASSIGNMENT_DB]
GO
/****** Object:  Table [dbo].[P007_P008_Tracking]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P007_P008_Tracking](
	[MSNV] [nchar](10) NULL,
	[Name] [nchar](30) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Shift] [nchar](10) NOT NULL,
	[Time] [smalldatetime] NOT NULL,
	[LineID] [nchar](10) NOT NULL,
	[LineName] [nchar](30) NOT NULL,
	[WSID] [nchar](10) NOT NULL,
	[WSName] [nchar](30) NOT NULL,
	[Tracking] [nchar](10) NOT NULL,
	[Note] [nchar](200) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P_005_006_007_P008_SapLichPlan]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_005_006_007_P008_SapLichPlan](
	[MSNV] [nchar](10) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[Shift] [nchar](10) NOT NULL,
	[LineID] [nchar](10) NOT NULL,
	[LineName] [nchar](30) NOT NULL,
	[WSID] [nchar](10) NOT NULL,
	[WSName] [nchar](30) NOT NULL,
	[Note] [nchar](200) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P_004_KeHoachSanXuatTheoGroup]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_004_KeHoachSanXuatTheoGroup](
	[GroupID] [nchar](10) NOT NULL,
	[GroupName] [nchar](30) NOT NULL,
	[WW] [nchar](10) NOT NULL,
	[TongSoGioTangCa] [float] NOT NULL,
	[SoGioTangCaBinhQuanTungNguoi] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P_003_KeHoachSanXuatTheoTram]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_003_KeHoachSanXuatTheoTram](
	[Date] [smalldatetime] NOT NULL,
	[PartNumber] [nvarchar](20) NULL,
	[LineID] [nvarchar](20) NOT NULL,
	[LineName] [nvarchar](50) NOT NULL,
	[WST_ID] [nvarchar](20) NOT NULL,
	[WST_Name] [nvarchar](50) NULL,
	[Shift_Name] [nvarchar](50) NOT NULL,
	[Shift_Percent] [int] NULL,
	[Capacity] [int] NULL,
	[Qty] [int] NULL,
	[NumOfPerson_Per_Day] [int] NULL,
	[NumOfShift] [float] NULL,
 CONSTRAINT [PK_P_003_KeHoachSanXuatTheoTram] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[LineID] ASC,
	[WST_ID] ASC,
	[Shift_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P_002_PlanForProductionByDate]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_002_PlanForProductionByDate](
	[Date] [smalldatetime] NOT NULL,
	[PartNumber] [nvarchar](50) NOT NULL,
	[LineID] [nvarchar](20) NOT NULL,
	[LineName] [nvarchar](50) NOT NULL,
	[GroupID] [nvarchar](20) NOT NULL,
	[TotalShiftPerLine] [numeric](5, 2) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[NumOfShift] [numeric](5, 2) NOT NULL,
	[NumOfPerson_Per_Day] [int] NOT NULL,
 CONSTRAINT [PK_P_002_PlanForProductionByDate] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[PartNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[P_001_InputFromPlanner]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[P_001_InputFromPlanner](
	[PartNumber] [nchar](20) NOT NULL,
	[LineID] [nchar](20) NOT NULL,
	[LineName] [nchar](50) NOT NULL,
	[GroupID] [nchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Demand] [int] NOT NULL,
	[SoCa] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MDB_005_LineWorkStationMapping]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MDB_005_LineWorkStationMapping](
	[LineID] [nvarchar](20) NOT NULL,
	[WstID] [nvarchar](20) NOT NULL,
	[WstName] [nvarchar](100) NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK_MDB_004_LineWorkStationMapping] PRIMARY KEY CLUSTERED 
(
	[LineID] ASC,
	[WstID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MDB_004_LineSkillRequest]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MDB_004_LineSkillRequest](
	[WorkStationID] [nchar](20) NOT NULL,
	[WorkStationName] [nchar](50) NOT NULL,
	[LineID] [nchar](20) NOT NULL,
	[LineName] [nchar](50) NOT NULL,
	[SkillID] [nchar](20) NOT NULL,
	[SkillName] [nchar](50) NOT NULL,
 CONSTRAINT [PK_MDB_004_LineSkillRequest_1] PRIMARY KEY CLUSTERED 
(
	[WorkStationID] ASC,
	[WorkStationName] ASC,
	[LineID] ASC,
	[LineName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MDB_003_Line_Desciption]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MDB_003_Line_Desciption](
	[PartNumber] [nvarchar](20) NOT NULL,
	[PartName] [nvarchar](50) NULL,
	[LineID] [nvarchar](20) NOT NULL,
	[LineName] [nvarchar](50) NULL,
	[GroupID] [nvarchar](20) NULL,
	[Description] [nvarchar](200) NULL,
	[Note] [nvarchar](200) NULL,
	[MinResource] [int] NOT NULL,
	[MaxResource] [int] NOT NULL,
	[MaxCapacity] [int] NOT NULL,
 CONSTRAINT [PK_MDB_003_Line_Desciption] PRIMARY KEY CLUSTERED 
(
	[PartNumber] ASC,
	[LineID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MDB_002_Empl_Skill]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MDB_002_Empl_Skill](
	[MSNV] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Skill_ID] [nvarchar](20) NOT NULL,
	[Skill_Name] [nvarchar](50) NULL,
	[Priority] [nvarchar](20) NULL,
 CONSTRAINT [PK_Line_Skill_Request] PRIMARY KEY CLUSTERED 
(
	[MSNV] ASC,
	[Skill_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MDB_001_Skill_List_Tbl]    Script Date: 05/02/2015 09:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MDB_001_Skill_List_Tbl](
	[Skill_ID] [nvarchar](20) NOT NULL,
	[Skill_Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK_Skill_List_Tbl] PRIMARY KEY CLUSTERED 
(
	[Skill_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
