USE [master]
GO
/****** Object:  Database [LeaveManagementDB]    Script Date: 4/10/2025 8:52:45 AM ******/
CREATE DATABASE [LeaveManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeaveManagementDB', FILENAME = N'C:\Users\DELL\LeaveManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LeaveManagementDB_log', FILENAME = N'C:\Users\DELL\LeaveManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LeaveManagementDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeaveManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeaveManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeaveManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LeaveManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeaveManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LeaveManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [LeaveManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeaveManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeaveManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeaveManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LeaveManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LeaveManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LeaveManagementDB] SET QUERY_STORE = OFF
GO
USE [LeaveManagementDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/10/2025 8:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [varchar](10) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[JoinDate] [date] NOT NULL,
	[IsPermanent] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveBalances]    Script Date: 4/10/2025 8:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveBalances](
	[BalanceID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [varchar](10) NULL,
	[Year] [int] NULL,
	[AnnualLeaves] [int] NULL,
	[CasualLeaves] [int] NULL,
	[ShortLeaves] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BalanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveRequests]    Script Date: 4/10/2025 8:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveRequests](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [varchar](10) NULL,
	[LeaveType] [varchar](20) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[TimeSlot] [varchar](20) NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rosters]    Script Date: 4/10/2025 8:52:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rosters](
	[RosterID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [varchar](10) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RosterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[LeaveBalances]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[LeaveRequests]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Rosters]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
USE [master]
GO
ALTER DATABASE [LeaveManagementDB] SET  READ_WRITE 
GO
