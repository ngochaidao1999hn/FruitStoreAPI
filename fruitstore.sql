USE [master]
GO
/****** Object:  Database [fruitstore]    Script Date: 18/01/2022 10:19:20 ******/
CREATE DATABASE [fruitstore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fruitstore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\fruitstore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fruitstore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\fruitstore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [fruitstore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fruitstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fruitstore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fruitstore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fruitstore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fruitstore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fruitstore] SET ARITHABORT OFF 
GO
ALTER DATABASE [fruitstore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [fruitstore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fruitstore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fruitstore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fruitstore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fruitstore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fruitstore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fruitstore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fruitstore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fruitstore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [fruitstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fruitstore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fruitstore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fruitstore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fruitstore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fruitstore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [fruitstore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fruitstore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [fruitstore] SET  MULTI_USER 
GO
ALTER DATABASE [fruitstore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fruitstore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fruitstore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fruitstore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fruitstore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fruitstore] SET QUERY_STORE = OFF
GO
USE [fruitstore]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cus_id] [int] NULL,
	[create_date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cart_detail]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cart_id] [int] NULL,
	[pro_id] [int] NULL,
	[quantity] [int] NULL,
	[ispaid] [bit] NULL,
	[pric] [float] NULL,
	[order_status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[addr] [nvarchar](max) NULL,
	[phonenumber] [varchar](50) NULL,
	[pwd] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fruit]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fruit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fruit_name] [nvarchar](max) NULL,
	[price] [float] NULL,
	[imp_date] [date] NULL,
	[descrip] [nvarchar](max) NULL,
	[quantity] [int] NULL,
	[isImported] [bit] NULL,
	[img] [nvarchar](max) NULL,
	[id_cate] [int] NULL,
	[id_unit] [int] NULL,
	[id_origin] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[infor]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[infor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[origin]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[origin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[unit]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 18/01/2022 10:19:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](30) NULL,
	[pwd] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD FOREIGN KEY([cus_id])
REFERENCES [dbo].[customer] ([id])
GO
ALTER TABLE [dbo].[cart_detail]  WITH CHECK ADD FOREIGN KEY([cart_id])
REFERENCES [dbo].[cart] ([id])
GO
ALTER TABLE [dbo].[cart_detail]  WITH CHECK ADD FOREIGN KEY([pro_id])
REFERENCES [dbo].[fruit] ([id])
GO
ALTER TABLE [dbo].[fruit]  WITH CHECK ADD FOREIGN KEY([id_cate])
REFERENCES [dbo].[categories] ([id])
GO
ALTER TABLE [dbo].[fruit]  WITH CHECK ADD FOREIGN KEY([id_origin])
REFERENCES [dbo].[origin] ([id])
GO
ALTER TABLE [dbo].[fruit]  WITH CHECK ADD FOREIGN KEY([id_unit])
REFERENCES [dbo].[unit] ([id])
GO
USE [master]
GO
ALTER DATABASE [fruitstore] SET  READ_WRITE 
GO
