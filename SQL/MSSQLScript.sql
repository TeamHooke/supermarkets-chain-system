CREATE DATABASE [Supermarkets]
GO
ALTER DATABASE [Supermarkets] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Supermarkets].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Supermarkets] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Supermarkets] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Supermarkets] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Supermarkets] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Supermarkets] SET ARITHABORT OFF 
GO
ALTER DATABASE [Supermarkets] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Supermarkets] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Supermarkets] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Supermarkets] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Supermarkets] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Supermarkets] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Supermarkets] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Supermarkets] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Supermarkets] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Supermarkets] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Supermarkets] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Supermarkets] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Supermarkets] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Supermarkets] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Supermarkets] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Supermarkets] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Supermarkets] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Supermarkets] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Supermarkets] SET  MULTI_USER 
GO
ALTER DATABASE [Supermarkets] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Supermarkets] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Supermarkets] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Supermarkets] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Supermarkets] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Supermarkets]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 3/14/15 4:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/14/15 4:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1)NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[VendorId] [int] NOT NULL,
	[MeasureId] [int] NOT NULL,
	[Price] [money] NOT NULL
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supermarket_Sales]    Script Date: 3/14/15 4:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supermarket_Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupermarketId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CountOfSales] [int] NOT NULL,
	[Date] [DATE] NOT NULL,
 CONSTRAINT [PK_Supermarket_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupermarketProducts]    Script Date: 3/14/15 4:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupermarketProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SupermarketId] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SupermarketProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supermarkets]    Script Date: 3/14/15 4:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supermarkets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Supermarkets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 3/14/15 4:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_Products]    Script Date: 3/14/15 4:26:25 PM ******/
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [IX_Products] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Measures] FOREIGN KEY([MeasureId])
REFERENCES [dbo].[Measures] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Measures]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Vendors]
GO
ALTER TABLE [dbo].[Supermarket_Sales]  WITH CHECK ADD  CONSTRAINT [FK_Supermarket_Sales_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Supermarket_Sales] CHECK CONSTRAINT [FK_Supermarket_Sales_Products]
GO
ALTER TABLE [dbo].[Supermarket_Sales]  WITH CHECK ADD  CONSTRAINT [FK_Supermarket_Sales_Supermarkets] FOREIGN KEY([SupermarketId])
REFERENCES [dbo].[Supermarkets] ([Id])
GO
ALTER TABLE [dbo].[Supermarket_Sales] CHECK CONSTRAINT [FK_Supermarket_Sales_Supermarkets]
GO
ALTER TABLE [dbo].[SupermarketProducts]  WITH CHECK ADD  CONSTRAINT [FK_SupermarketProducts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[SupermarketProducts] CHECK CONSTRAINT [FK_SupermarketProducts_Products]
GO
ALTER TABLE [dbo].[SupermarketProducts]  WITH CHECK ADD  CONSTRAINT [FK_SupermarketProducts_Supermarkets] FOREIGN KEY([SupermarketId])
REFERENCES [dbo].[Supermarkets] ([Id])
GO

ALTER TABLE [dbo].[SupermarketProducts] CHECK CONSTRAINT [FK_SupermarketProducts_Supermarkets]
GO
CREATE TABLE Expenses
(
 [Id] int PRIMARY KEY IDENTITY,
 [Date] Date,
 [Money] money,
 [VendorId] int,
 CONSTRAINT FK_Expenses_Vendors FOREIGN KEY (VendorId) REFERENCES Vendors(Id)
)
USE [master]
GO
ALTER DATABASE [Supermarkets] SET  READ_WRITE 
GO