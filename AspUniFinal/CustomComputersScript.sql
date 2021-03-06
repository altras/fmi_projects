USE [master]
GO
/****** Object:  Database [CustomComputersAsp]    Script Date: 06/24/2012 12:07:53 ******/
CREATE DATABASE [CustomComputersAsp] ON  PRIMARY 
( NAME = N'CustomComputersAsp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CustomComputersAsp.mdf' , SIZE = 3048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CustomComputersAsp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\CustomComputersAsp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CustomComputersAsp] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomComputersAsp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomComputersAsp] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CustomComputersAsp] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CustomComputersAsp] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CustomComputersAsp] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CustomComputersAsp] SET ARITHABORT OFF
GO
ALTER DATABASE [CustomComputersAsp] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CustomComputersAsp] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CustomComputersAsp] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CustomComputersAsp] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CustomComputersAsp] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CustomComputersAsp] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CustomComputersAsp] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CustomComputersAsp] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CustomComputersAsp] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CustomComputersAsp] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CustomComputersAsp] SET  DISABLE_BROKER
GO
ALTER DATABASE [CustomComputersAsp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CustomComputersAsp] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CustomComputersAsp] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CustomComputersAsp] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CustomComputersAsp] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CustomComputersAsp] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CustomComputersAsp] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CustomComputersAsp] SET  READ_WRITE
GO
ALTER DATABASE [CustomComputersAsp] SET RECOVERY SIMPLE
GO
ALTER DATABASE [CustomComputersAsp] SET  MULTI_USER
GO
ALTER DATABASE [CustomComputersAsp] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CustomComputersAsp] SET DB_CHAINING OFF
GO
USE [CustomComputersAsp]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stand] [nvarchar](max) NOT NULL,
	[display] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hdd]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hdd](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[producer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Hdd] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cpu]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cpu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[producer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Cpu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoCard]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoCard](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[producer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VideoCard] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monitor]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monitor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[materialsId] [int] NOT NULL,
	[matrix] [nvarchar](max) NOT NULL,
	[aspectRatio] [nvarchar](max) NOT NULL,
	[led] [nvarchar](max) NOT NULL,
	[producer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Monitor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoxSet]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxSet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cupId] [int] NOT NULL,
	[motherboard] [nvarchar](max) NOT NULL,
	[ram] [nvarchar](max) NOT NULL,
	[videoCardId] [int] NOT NULL,
	[coolingSystem] [nvarchar](max) NOT NULL,
	[powerSupply] [nvarchar](max) NOT NULL,
	[expansionCards] [nvarchar](max) NOT NULL,
	[hddId] [int] NOT NULL,
	[removableDevices] [nvarchar](max) NOT NULL,
	[box] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BoxSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[boxId] [int] NOT NULL,
	[monitorId] [int] NOT NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Software]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Software](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[producer] [nvarchar](max) NOT NULL,
	[type] [nvarchar](max) NOT NULL,
	[configId] [int] NOT NULL,
 CONSTRAINT [PK_Software] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peripherals]    Script Date: 06/24/2012 12:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peripherals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[type] [nvarchar](max) NOT NULL,
	[producer] [nvarchar](max) NOT NULL,
	[configId] [int] NOT NULL,
 CONSTRAINT [PK_Peripherals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Monitor_Materials1]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Materials1] FOREIGN KEY([materialsId])
REFERENCES [dbo].[Materials] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Materials1]
GO
/****** Object:  ForeignKey [FK_BoxSet_Cpu]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[BoxSet]  WITH CHECK ADD  CONSTRAINT [FK_BoxSet_Cpu] FOREIGN KEY([cupId])
REFERENCES [dbo].[Cpu] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoxSet] CHECK CONSTRAINT [FK_BoxSet_Cpu]
GO
/****** Object:  ForeignKey [FK_BoxSet_Hdd]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[BoxSet]  WITH CHECK ADD  CONSTRAINT [FK_BoxSet_Hdd] FOREIGN KEY([hddId])
REFERENCES [dbo].[Hdd] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoxSet] CHECK CONSTRAINT [FK_BoxSet_Hdd]
GO
/****** Object:  ForeignKey [FK_BoxSet_VideoCard]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[BoxSet]  WITH CHECK ADD  CONSTRAINT [FK_BoxSet_VideoCard] FOREIGN KEY([videoCardId])
REFERENCES [dbo].[VideoCard] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoxSet] CHECK CONSTRAINT [FK_BoxSet_VideoCard]
GO
/****** Object:  ForeignKey [FK_Configuration_BoxSet]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[Configuration]  WITH CHECK ADD  CONSTRAINT [FK_Configuration_BoxSet] FOREIGN KEY([boxId])
REFERENCES [dbo].[BoxSet] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Configuration] CHECK CONSTRAINT [FK_Configuration_BoxSet]
GO
/****** Object:  ForeignKey [FK_Configuration_Monitor]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[Configuration]  WITH CHECK ADD  CONSTRAINT [FK_Configuration_Monitor] FOREIGN KEY([monitorId])
REFERENCES [dbo].[Monitor] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Configuration] CHECK CONSTRAINT [FK_Configuration_Monitor]
GO
/****** Object:  ForeignKey [FK_Software_Configuration]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[Software]  WITH CHECK ADD  CONSTRAINT [FK_Software_Configuration] FOREIGN KEY([configId])
REFERENCES [dbo].[Configuration] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Software] CHECK CONSTRAINT [FK_Software_Configuration]
GO
/****** Object:  ForeignKey [FK_Peripherals_Configuration]    Script Date: 06/24/2012 12:07:58 ******/
ALTER TABLE [dbo].[Peripherals]  WITH CHECK ADD  CONSTRAINT [FK_Peripherals_Configuration] FOREIGN KEY([configId])
REFERENCES [dbo].[Configuration] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Peripherals] CHECK CONSTRAINT [FK_Peripherals_Configuration]
GO
