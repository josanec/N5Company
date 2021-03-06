USE [master]
GO
/****** Object:  Database [N5Company]    Script Date: 26/12/2021 23:08:40 ******/
CREATE DATABASE [N5Company]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'N5Company', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\N5Company.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'N5Company_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\N5Company_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [N5Company] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [N5Company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [N5Company] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [N5Company] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [N5Company] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [N5Company] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [N5Company] SET ARITHABORT OFF 
GO
ALTER DATABASE [N5Company] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [N5Company] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [N5Company] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [N5Company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [N5Company] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [N5Company] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [N5Company] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [N5Company] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [N5Company] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [N5Company] SET  ENABLE_BROKER 
GO
ALTER DATABASE [N5Company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [N5Company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [N5Company] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [N5Company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [N5Company] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [N5Company] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [N5Company] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [N5Company] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [N5Company] SET  MULTI_USER 
GO
ALTER DATABASE [N5Company] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [N5Company] SET DB_CHAINING OFF 
GO
ALTER DATABASE [N5Company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [N5Company] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [N5Company] SET DELAYED_DURABILITY = DISABLED 
GO
USE [N5Company]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 26/12/2021 23:08:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeForename] [nvarchar](50) NOT NULL,
	[EmployeeSurname] [nvarchar](50) NOT NULL,
	[PermissionType] [int] NOT NULL,
	[PermissionDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PermissionTypes]    Script Date: 26/12/2021 23:08:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PermissionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_PermissionTypes] FOREIGN KEY([PermissionType])
REFERENCES [dbo].[PermissionTypes] ([Id])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionTypes]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee Forename' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'EmployeeForename'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee Surname' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'EmployeeSurname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'PermissionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission granted on Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permissions', @level2type=N'COLUMN',@level2name=N'PermissionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionTypes', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionTypes', @level2type=N'COLUMN',@level2name=N'Description'
GO
USE [master]
GO
ALTER DATABASE [N5Company] SET  READ_WRITE 
GO
