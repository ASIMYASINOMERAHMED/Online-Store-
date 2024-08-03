USE [master]
GO
/****** Object:  Database [Online_Store]    Script Date: 8/3/2024 12:14:56 PM ******/
CREATE DATABASE [Online_Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'P5 - OnlineShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\P5 - OnlineShop.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'P5 - OnlineShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\P5 - OnlineShop_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Online_Store] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Online_Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Online_Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Online_Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Online_Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Online_Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Online_Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [Online_Store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Online_Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Online_Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Online_Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Online_Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Online_Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Online_Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Online_Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Online_Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Online_Store] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Online_Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Online_Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Online_Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Online_Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Online_Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Online_Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Online_Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Online_Store] SET RECOVERY FULL 
GO
ALTER DATABASE [Online_Store] SET  MULTI_USER 
GO
ALTER DATABASE [Online_Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Online_Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Online_Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Online_Store] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Online_Store] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Online_Store] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Online_Store', N'ON'
GO
ALTER DATABASE [Online_Store] SET QUERY_STORE = ON
GO
ALTER DATABASE [Online_Store] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Online_Store]
GO
/****** Object:  Table [dbo].[ChartData]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartData](
	[ChartDataID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [nvarchar](50) NOT NULL,
	[TotalOrders] [int] NOT NULL,
	[TotalVisitors] [int] NOT NULL,
	[TotalMonthSales] [int] NOT NULL,
 CONSTRAINT [PK_ChartData] PRIMARY KEY CLUSTERED 
(
	[ChartDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompeleteOrders]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompeleteOrders](
	[OrderID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [smallmoney] NOT NULL,
	[Status] [smallint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favourites]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourites](
	[FavouritItemID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[AddedToFavourite] [bit] NOT NULL,
 CONSTRAINT [PK_Favourites] PRIMARY KEY CLUSTERED 
(
	[FavouritItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationCustomer]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationCustomer](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[NewProductID] [int] NULL,
	[NewCategoryID] [int] NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_NotificationCustomer] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationOwner]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationOwner](
	[NoticficationID] [int] IDENTITY(1,1) NOT NULL,
	[NewCustomerID] [int] NULL,
	[NewPaymentID] [int] NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_NotificationOwner] PRIMARY KEY CLUSTERED 
(
	[NoticficationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Size] [nvarchar](10) NULL,
	[Color] [nvarchar](50) NULL,
	[Price] [smallmoney] NOT NULL,
	[TotalItemsPrice] [smallmoney] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [smallmoney] NOT NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK__Orders__C3905BAF37153F67] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[Amount] [smallmoney] NOT NULL,
	[PaymentMethod] [nvarchar](50) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Payments__9B556A583CAD2638] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PendingOrders]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PendingOrders](
	[OrderID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [smallmoney] NOT NULL,
	[Status] [smallint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessingOrders]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessingOrders](
	[OrderID] [int] NOT NULL,
	[CustomerID] [nvarchar](100) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalAmount] [smallmoney] NOT NULL,
	[Status] [smallint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCatalog]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatalog](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[LongDescription] [nvarchar](max) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[QuantityInStock] [int] NOT NULL,
	[ImageURL] [nvarchar](200) NOT NULL,
	[VideoURL] [nvarchar](200) NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[Discount] [int] NULL,
 CONSTRAINT [PK__ProductC__B40CC6EDEB4EC44B] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[CategoryImage] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK__ProductC__19093A2B4AA82D9C] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColor]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColor](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](100) NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageURL] [nvarchar](200) NOT NULL,
	[ImageOrder] [smallint] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSize]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSize](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responses]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responses](
	[ResponseID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Response] [nvarchar](500) NOT NULL,
	[MessageID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Responses] PRIMARY KEY CLUSTERED 
(
	[ResponseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[CustomerID] [int] NULL,
	[ReviewText] [nvarchar](500) NULL,
	[Rating] [decimal](2, 1) NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Reviews__74BC79AE335944D9] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesReport]    Script Date: 8/3/2024 12:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReport](
	[SalesID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [nvarchar](50) NOT NULL,
	[Year] [int] NULL,
	[TotalSales] [int] NOT NULL,
	[TotalRevenue] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_SalesReport] PRIMARY KEY CLUSTERED 
(
	[SalesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[CarrierID] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[CarrierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippings]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippings](
	[ShippingID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[CarrierID] [int] NOT NULL,
	[TrackingNumber] [nvarchar](50) NOT NULL,
	[ShippingStatus] [smallint] NOT NULL,
	[EstimatedDeliveryDate] [datetime] NOT NULL,
	[ActualDeliveryDate] [datetime] NULL,
 CONSTRAINT [PK_Shippings] PRIMARY KEY CLUSTERED 
(
	[ShippingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [nvarchar](200) NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IsOwner] [bit] NULL,
	[ImageURL] [nvarchar](200) NULL,
 CONSTRAINT [PK__Customer__A4AE64B86563B9B8] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeeklySales]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeeklySales](
	[WeeklySalesID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [nvarchar](50) NOT NULL,
	[Week1Sales] [int] NOT NULL,
	[Week2Sales] [int] NOT NULL,
	[Week3Sales] [int] NOT NULL,
	[Week4Sales] [int] NOT NULL,
 CONSTRAINT [PK_WeeklySales] PRIMARY KEY CLUSTERED 
(
	[WeeklySalesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChartData] ON 

INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (1, N'January', 20, 10, 19)
INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (3, N'February', 15, 13, 13)
INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (4, N'March', 32, 22, 29)
INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (5, N'April', 19, 10, 19)
INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (6, N'May', 25, 11, 24)
INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (7, N'June', 8, 1, 8)
INSERT [dbo].[ChartData] ([ChartDataID], [Month], [TotalOrders], [TotalVisitors], [TotalMonthSales]) VALUES (8, N'July', 4, 3, 4)
SET IDENTITY_INSERT [dbo].[ChartData] OFF
GO
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (2008, 1, CAST(N'2024-04-29T00:15:05.607' AS DateTime), 12000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1014, 1, CAST(N'2024-04-25T18:35:30.590' AS DateTime), 52000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (2008, 1, CAST(N'2024-04-29T00:15:05.607' AS DateTime), 12000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (5, 1, CAST(N'2024-04-22T15:22:52.183' AS DateTime), 81000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1018, 1, CAST(N'2024-04-25T20:39:02.580' AS DateTime), 26000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (7, 1, CAST(N'2024-04-22T22:18:14.620' AS DateTime), 4000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1012, 1, CAST(N'2024-04-25T18:29:26.970' AS DateTime), 52000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1008, 1, CAST(N'2024-04-25T15:20:05.763' AS DateTime), 22000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1017, 1, CAST(N'2024-04-25T20:38:25.113' AS DateTime), 20000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1015, 1, CAST(N'2024-04-25T20:35:40.990' AS DateTime), 10000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1010, 1, CAST(N'2024-04-25T15:38:02.490' AS DateTime), 26000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3008, 1, CAST(N'2024-06-12T12:54:08.843' AS DateTime), 4000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4, 1, CAST(N'2024-04-22T15:22:52.183' AS DateTime), 81000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (8, 1, CAST(N'2024-04-25T15:09:12.017' AS DateTime), 39000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (6, 1, CAST(N'2024-04-22T15:27:30.077' AS DateTime), 44000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3, 1, CAST(N'2024-04-22T15:21:40.077' AS DateTime), 81000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (2, 1, CAST(N'2024-04-22T11:57:07.777' AS DateTime), 19000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1, 1, CAST(N'2024-04-22T11:55:44.390' AS DateTime), 19000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3009, 1, CAST(N'2024-06-14T11:27:18.947' AS DateTime), 2500.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3010, 1, CAST(N'2024-06-14T11:28:26.327' AS DateTime), 4000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3015, 1, CAST(N'2024-06-21T17:18:04.100' AS DateTime), 16000.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3012, 1, CAST(N'2024-06-14T11:37:13.420' AS DateTime), 5400.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3011, 1, CAST(N'2024-06-14T11:31:34.467' AS DateTime), 16000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1013, 1, CAST(N'2024-04-25T18:33:11.250' AS DateTime), 52000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1016, 1, CAST(N'2024-04-25T20:36:40.137' AS DateTime), 16000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1009, 1, CAST(N'2024-04-25T15:28:28.510' AS DateTime), 35000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1011, 1, CAST(N'2024-04-25T15:42:30.223' AS DateTime), 12000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4022, 1, CAST(N'2024-07-19T21:14:10.290' AS DateTime), 72.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4024, 1, CAST(N'2024-07-19T23:07:12.947' AS DateTime), 359.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3014, 1, CAST(N'2024-06-21T17:14:01.417' AS DateTime), 16000.0000, 2)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4021, 1, CAST(N'2024-07-19T21:09:40.517' AS DateTime), 19.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4027, 1, CAST(N'2024-07-21T18:35:01.433' AS DateTime), 19.5000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4026, 1, CAST(N'2024-07-21T18:32:39.103' AS DateTime), 39.0000, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4028, 1, CAST(N'2024-07-21T19:30:41.867' AS DateTime), 209.1600, 3)
INSERT [dbo].[CompeleteOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4029, 1, CAST(N'2024-07-21T19:36:23.913' AS DateTime), 629.0000, 3)
GO
SET IDENTITY_INSERT [dbo].[Favourites] ON 

INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (20, 1, 3, 1)
INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (27, 1, 1, 1)
INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (1002, 1, 1004, 1)
INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (2002, 1, 2006, 1)
INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (4002, 1, 3008, 1)
INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (5005, 1, 2, 1)
INSERT [dbo].[Favourites] ([FavouritItemID], [CustomerID], [ProductID], [AddedToFavourite]) VALUES (5007, 1, 3016, 1)
SET IDENTITY_INSERT [dbo].[Favourites] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1, 1, N'Hi, This test Message.', CAST(N'2024-05-05T04:04:22.757' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (2, 1, N'Hi, this is test2.', CAST(N'2024-05-05T04:16:59.833' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1002, 1, N'Hi, this is Test3.', CAST(N'2024-07-19T19:47:03.243' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1003, 1, N'Test4.', CAST(N'2024-07-19T21:07:40.130' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1004, 1, N'Test5.', CAST(N'2024-07-19T23:01:33.620' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1005, 1, N'Test6.', CAST(N'2024-07-21T19:45:53.773' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1006, 1, N'Test7.', CAST(N'2024-07-22T10:44:04.683' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1007, 1, N'hey', CAST(N'2024-07-26T11:08:34.720' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1008, 1, N'hey', CAST(N'2024-07-26T11:10:30.110' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1009, 1, N'hi', CAST(N'2024-07-26T19:25:42.553' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1010, 1, N'hi', CAST(N'2024-07-27T15:19:14.007' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1011, 1, N'hi', CAST(N'2024-07-27T15:25:01.500' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1012, 1, N'hi', CAST(N'2024-07-27T15:54:15.690' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1013, 1, N'hi', CAST(N'2024-07-27T16:00:42.180' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1014, 1, N'hi', CAST(N'2024-07-27T18:17:35.740' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1015, 1, N'hi', CAST(N'2024-07-28T00:57:57.243' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1016, 1, N'hi', CAST(N'2024-07-28T01:07:34.687' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1017, 1, N'hi', CAST(N'2024-07-28T10:47:07.623' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1018, 1, N'hi', CAST(N'2024-07-28T11:10:04.150' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1019, 1, N'hi', CAST(N'2024-07-28T11:12:23.010' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [CustomerID], [Message], [DateTime]) VALUES (1020, 1, N'hi', CAST(N'2024-07-28T11:52:40.930' AS DateTime))
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[NotificationCustomer] ON 

INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (1, 2006, NULL, CAST(N'2024-05-16T12:07:24.237' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2, 2007, NULL, CAST(N'2024-06-07T12:28:00.210' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (1002, 2010, NULL, CAST(N'2024-06-24T12:43:20.297' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2002, 3008, NULL, CAST(N'2024-06-30T23:55:22.617' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2003, 3009, NULL, CAST(N'2024-07-01T00:05:13.337' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2004, 3010, NULL, CAST(N'2024-07-01T19:54:23.810' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2005, 3011, NULL, CAST(N'2024-07-01T20:07:46.060' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2006, 3012, NULL, CAST(N'2024-07-02T00:38:08.503' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2007, 3013, NULL, CAST(N'2024-07-02T00:44:33.383' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2008, NULL, 3002, CAST(N'2024-07-04T00:52:31.500' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (2009, NULL, 3003, CAST(N'2024-07-04T00:53:11.607' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3008, 3014, NULL, CAST(N'2024-07-16T16:05:30.570' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3009, 3015, NULL, CAST(N'2024-07-17T15:42:35.013' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3010, 3016, NULL, CAST(N'2024-07-23T18:24:57.580' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3011, 3017, NULL, CAST(N'2024-07-23T20:08:53.927' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3012, 3018, NULL, CAST(N'2024-07-24T10:22:53.453' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3013, 3019, NULL, CAST(N'2024-07-24T11:05:26.503' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3014, NULL, 4002, CAST(N'2024-07-24T11:21:05.430' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3015, 3020, NULL, CAST(N'2024-07-24T11:32:57.570' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3016, NULL, 4003, CAST(N'2024-07-24T14:45:09.267' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3017, NULL, 4004, CAST(N'2024-07-24T14:47:20.297' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3018, NULL, 4005, CAST(N'2024-07-24T14:48:02.113' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3019, NULL, 4006, CAST(N'2024-07-24T15:12:16.873' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3020, NULL, 4007, CAST(N'2024-07-24T15:12:52.877' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3021, NULL, 4008, CAST(N'2024-07-24T15:14:45.613' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3022, NULL, 4009, CAST(N'2024-07-24T15:28:00.403' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3023, NULL, 4010, CAST(N'2024-07-24T15:35:11.120' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3024, NULL, 4011, CAST(N'2024-07-24T15:44:40.473' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3025, NULL, 4012, CAST(N'2024-07-24T15:58:47.963' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3026, NULL, 4013, CAST(N'2024-07-24T16:01:20.460' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3027, NULL, 4014, CAST(N'2024-07-24T16:04:21.793' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3028, NULL, 4015, CAST(N'2024-07-24T16:06:46.373' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3029, NULL, 4016, CAST(N'2024-07-24T16:10:33.027' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3030, NULL, 4017, CAST(N'2024-07-24T16:22:26.750' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3031, NULL, 4018, CAST(N'2024-07-25T12:34:17.267' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3032, NULL, 4019, CAST(N'2024-07-25T13:11:39.400' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3033, 3021, NULL, CAST(N'2024-07-25T15:04:45.530' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3034, 3022, NULL, CAST(N'2024-07-25T15:11:39.460' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3035, 3023, NULL, CAST(N'2024-07-25T15:25:01.973' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3036, 3024, NULL, CAST(N'2024-07-25T15:37:52.077' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3037, 3025, NULL, CAST(N'2024-07-25T15:44:53.917' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3038, 3026, NULL, CAST(N'2024-07-25T15:55:24.140' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3039, 3027, NULL, CAST(N'2024-07-25T18:21:04.947' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3040, NULL, 4020, CAST(N'2024-07-26T00:56:52.000' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3041, NULL, 4021, CAST(N'2024-07-29T11:11:14.957' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3042, NULL, 4022, CAST(N'2024-07-29T15:44:50.510' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3043, NULL, 4023, CAST(N'2024-07-29T15:46:27.510' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3044, NULL, 4024, CAST(N'2024-07-29T17:46:31.193' AS DateTime))
INSERT [dbo].[NotificationCustomer] ([NotificationID], [NewProductID], [NewCategoryID], [DateTime]) VALUES (3045, 3028, NULL, CAST(N'2024-07-29T18:18:53.247' AS DateTime))
SET IDENTITY_INSERT [dbo].[NotificationCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[NotificationOwner] ON 

INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (1, 1002, NULL, CAST(N'2024-05-26T15:42:11.220' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2, NULL, 3002, CAST(N'2024-06-12T12:54:08.947' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (3, NULL, 3003, CAST(N'2024-06-14T11:27:19.010' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (4, NULL, 3004, CAST(N'2024-06-14T11:28:26.347' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (5, NULL, 3005, CAST(N'2024-06-14T11:31:34.483' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (6, NULL, 3006, CAST(N'2024-06-14T11:37:13.437' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (7, NULL, 3007, CAST(N'2024-06-14T11:39:38.677' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (8, NULL, 3008, CAST(N'2024-06-21T17:14:01.527' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (9, NULL, 3009, CAST(N'2024-06-21T17:18:04.160' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (1002, 2002, NULL, CAST(N'2024-07-02T16:45:30.463' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (1003, 2003, NULL, CAST(N'2024-07-03T12:26:50.980' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (1004, 2004, NULL, CAST(N'2024-07-05T17:46:56.760' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2004, NULL, 4002, CAST(N'2024-07-12T17:41:43.713' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2005, NULL, 4003, CAST(N'2024-07-16T17:25:38.433' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2006, NULL, 4004, CAST(N'2024-07-17T16:35:44.653' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2007, NULL, 4005, CAST(N'2024-07-17T16:41:42.470' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2008, NULL, 4006, CAST(N'2024-07-19T15:49:22.247' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2009, NULL, 4007, CAST(N'2024-07-19T16:03:23.117' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2010, NULL, 4008, CAST(N'2024-07-19T16:04:56.640' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2011, NULL, 4009, CAST(N'2024-07-19T16:12:37.893' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2012, NULL, 4010, CAST(N'2024-07-19T17:42:02.167' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2013, NULL, 4011, CAST(N'2024-07-19T17:52:40.153' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2014, NULL, 4012, CAST(N'2024-07-19T19:46:05.253' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2015, NULL, 4013, CAST(N'2024-07-19T19:46:30.380' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2016, NULL, 4014, CAST(N'2024-07-19T21:09:08.280' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2017, NULL, 4015, CAST(N'2024-07-19T21:09:40.580' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2018, NULL, 4016, CAST(N'2024-07-19T23:05:34.877' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2019, NULL, 4017, CAST(N'2024-07-19T23:07:13.013' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2021, 3012, NULL, CAST(N'2024-07-21T18:04:18.887' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2022, NULL, 4018, CAST(N'2024-07-21T18:32:12.303' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2023, NULL, 4019, CAST(N'2024-07-21T18:32:39.190' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2024, NULL, 4020, CAST(N'2024-07-21T19:31:08.807' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2025, NULL, 4021, CAST(N'2024-07-21T19:37:27.503' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2026, NULL, 4022, CAST(N'2024-07-21T19:40:26.970' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2027, NULL, 4023, CAST(N'2024-07-21T19:41:32.033' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2028, NULL, 4024, CAST(N'2024-07-21T19:42:16.517' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2029, NULL, 4025, CAST(N'2024-07-22T10:56:50.970' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2030, NULL, 4026, CAST(N'2024-07-25T18:32:35.700' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2031, NULL, 4027, CAST(N'2024-07-26T00:29:06.377' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2032, NULL, 4028, CAST(N'2024-07-26T19:45:48.367' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2033, NULL, 4029, CAST(N'2024-07-28T01:02:36.460' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2034, NULL, 4030, CAST(N'2024-07-28T01:11:49.017' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2035, NULL, 4031, CAST(N'2024-07-28T17:25:34.397' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2036, NULL, 4032, CAST(N'2024-07-28T17:46:08.790' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2037, NULL, 4033, CAST(N'2024-07-28T17:48:26.747' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2038, NULL, 4034, CAST(N'2024-07-28T18:00:50.887' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2039, NULL, 4035, CAST(N'2024-07-28T18:01:19.740' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2040, NULL, 4036, CAST(N'2024-07-28T19:11:08.837' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2041, NULL, 4037, CAST(N'2024-07-28T19:30:06.313' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2042, NULL, 4038, CAST(N'2024-07-29T00:11:21.113' AS DateTime))
INSERT [dbo].[NotificationOwner] ([NoticficationID], [NewCustomerID], [NewPaymentID], [DateTime]) VALUES (2043, NULL, 4039, CAST(N'2024-07-29T00:15:31.027' AS DateTime))
SET IDENTITY_INSERT [dbo].[NotificationOwner] OFF
GO
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (6, 3, 1, N'M    ', N'Blue', 20000.0000, 20000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (6, 1005, 3, N'M    ', N'Blue', 3000.0000, 9000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (6, 1006, 3, N'M    ', N'Blue', 5000.0000, 15000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (7, 1, 1, N'M    ', N'Blue', 4000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (8, 3, 1, N'M    ', N'Blue', 20000.0000, 20000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (8, 1005, 3, N'M    ', N'Blue', 3000.0000, 9000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (8, 1006, 2, N'M    ', N'Blue', 5000.0000, 10000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1008, 2, 2, N'M    ', N'Blue', 6000.0000, 12000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1008, 1006, 2, N'M    ', N'Blue', 5000.0000, 10000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1009, 3, 1, N'M    ', N'Blue', 20000.0000, 20000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1009, 1006, 3, N'M    ', N'Blue', 5000.0000, 15000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1010, 3, 1, N'M    ', N'Blue', 20000.0000, 20000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1010, 1004, 3, N'M    ', N'Blue', 2000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1011, 1004, 3, N'M    ', N'Blue', 2000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1011, 1005, 2, N'M    ', N'Blue', 3000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1012, 1, 3, N'M    ', N'Blue', 4000.0000, 12000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1012, 3, 2, N'M    ', N'Blue', 20000.0000, 40000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1013, 2, 2, N'M    ', N'Blue', 6000.0000, 12000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1013, 3, 2, N'M    ', N'Blue', 20000.0000, 40000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1014, 2, 2, N'M    ', N'Blue', 6000.0000, 12000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1014, 3, 2, N'M    ', N'Blue', 20000.0000, 40000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1015, 1004, 2, N'M    ', N'Blue', 2000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1015, 1005, 2, N'M    ', N'Blue', 3000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1016, 1004, 2, N'M    ', N'Blue', 2000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1016, 1005, 2, N'M    ', N'Blue', 3000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1017, 3, 1, N'M    ', N'Blue', 20000.0000, 20000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (1018, 1005, 2, N'M    ', N'Blue', 3000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (2008, 2, 2, N'M', N'Blue', 6000.0000, 12000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3008, 2007, 1, N'14.02in', N'black', 5000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3009, 2006, 1, N'13.3inch', N'Gray', 5000.0000, 2500.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3010, 2006, 1, N'13.3inch', N'Gray', 5000.0000, 2500.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3010, 2007, 1, N'14.02in', N'black', 5000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3011, 3, 1, N'M', N'Blue', 20000.0000, 16000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3011, 2006, 1, N'13.3inch', N'Gray', 5000.0000, 2500.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3011, 2007, 1, N'14.02in', N'black', 5000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3012, 3, 1, N'M', N'Blue', 20000.0000, 16000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3012, 1005, 2, N'M', N'Blue', 3000.0000, 5400.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3012, 2006, 1, N'13.3inch', N'Gray', 5000.0000, 2500.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3012, 2007, 1, N'14.02in', N'black', 5000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3013, 2, 2, N'S', N'Blue', 6000.0000, 12000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3014, 3, 1, N'L', N'Blue', 20000.0000, 16000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3014, 2007, 2, N'14.02in', N'Gold', 5000.0000, 8000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (3015, 3, 1, N'M', N'Blue', 20000.0000, 16000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4008, 3010, 1, N'10-Piece', N'Black', 249.0000, 209.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4008, 3012, 1, N'16.89"Dx15', N'Silver', 179.0000, 179.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4009, 3010, 1, N'10-Piece', N'Black', 249.0000, 209.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4009, 3012, 1, N'16.89"Dx15', N'Silver', 179.0000, 179.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4009, 3013, 1, N'20.1"Dx18.', N'Stainless_Steel', 199.0000, 199.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4010, 3013, 1, N'20.1"Dx18.', N'Stainless_Steel', 199.0000, 199.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4010, 3015, 2, N'31.5"Dx76.', N'Pearl_White', 359.0000, 718.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4011, 3013, 1, N'20.1"Dx18.', N'Stainless_Steel', 199.0000, 199.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4011, 3014, 1, N'256GB', N'Titan', 629.0000, 629.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4011, 3015, 2, N'31.5"Dx76.', N'Pearl_White', 359.0000, 718.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4012, 3015, 1, N'31.5"Dx76.', N'Pearl_White', 359.0000, 359.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4013, 3008, 1, N'Meduim', N'Leaf_Colorful', 19.0000, 19.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4014, 3008, 1, N'Meduim', N'Leaf_Colorful', 19.0000, 19.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4014, 3009, 1, N'Medium', N'Black', 39.0000, 39.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4015, 2007, 1, N'14.02in', N'Silver', 5000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4016, 3014, 1, N'256GB', N'Amber_Yellow', 629.0000, 629.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4017, 2010, 1, N'M', N'White', 39.0000, 20.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4017, 3014, 1, N'256GB', N'Amber_Yellow', 629.0000, 629.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4018, 3013, 1, N'20.1"Dx18.', N'Stainless_Steel', 199.0000, 199.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4019, 3012, 1, N'16.89"Dx15', N'Silver', 179.0000, 179.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4019, 3013, 1, N'20.1"Dx18.', N'Stainless_Steel', 199.0000, 199.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4020, 3015, 1, N'31.5"Dx76.', N'Pearl_White', 359.0000, 359.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4021, 3008, 1, N'Meduim', N'Leaf_Colorful', 19.0000, 19.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4021, 3015, 1, N'31.5"Dx76.', N'Pearl_White', 359.0000, 359.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4023, 3010, 1, N'10-Piece', N'Black', 249.0000, 209.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4024, 3010, 1, N'10-Piece', N'Black', 249.0000, 209.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4024, 3015, 1, N'31.5"Dx76.', N'Pearl_White', 359.0000, 359.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4025, 3008, 1, N'Meduim', N'Leaf_Colorful', 19.0000, 19.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4026, 3008, 1, N'Meduim', N'Leaf_Colorful', 19.0000, 19.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4026, 3009, 1, N'Medium', N'Black', 39.0000, 39.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4028, 3010, 1, N'10-Piece', N'Black', 249.0000, 209.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4029, 3014, 1, N'256GB', N'Marble_Gray', 629.0000, 629.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4030, 3012, 1, N'16.89"Dx15', N'Silver', 179.0000, 179.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4030, 3014, 1, N'256GB', N'Marble_Gray', 629.0000, 629.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4031, 3015, 1, N'31.5"Dx76.', N'Pearl_White', 359.0000, 359.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4032, 2007, 1, N'14.02in', N'Gold', 5000.0000, 4000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4033, 3014, 1, N'256GB', N'Titan', 629.0000, 629.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4034, 3017, 1, N'50_Inches', N'Black', 129.0000, 129.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4034, 3021, 1, N'Small', N'Blue Green Orange Purple Red', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4035, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4035, 3017, 1, N'50 Inches', N'Black', 129.0000, 129.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4036, 3016, 2, N'71"D x 34"', N'Linen Blue', 329.0000, 401.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4037, 3016, 2, N'71"D x 34"', N'Dark Grey', 329.0000, 401.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4038, 3016, 1, N'71"D x 34"', N'Linen Blue', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4039, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4039, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4040, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4040, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4041, 2, 1, N'S', N'Red', 6000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4042, 2, 1, N'S', N'Red', 6000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4043, 2, 1, N'M', N'Red', 6000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4044, 2, 1, N'M', N'Red', 6000.0000, 6000.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4045, 2010, 1, N'L', N'White', 39.0000, 20.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4046, 2010, 1, N'L', N'White', 39.0000, 20.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4046, 2010, 1, N'S', N'Red Pink', 39.0000, 20.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4051, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4047, 2010, 1, N'S', N'Red Pink', 39.0000, 20.0000)
GO
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4047, 3016, 1, N'71"D x 34"', N'Linen Blue', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4047, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4047, 3021, 1, N'Small', N'Orange', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4051, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 2010, 1, N'L', N'White', 39.0000, 20.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4048, 3016, 1, N'71"D x 34"', N'Linen Blue', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4048, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 2010, 1, N'S', N'Red Pink', 39.0000, 20.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4048, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 3016, 1, N'71"D x 34"', N'Linen Blue', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 3021, 1, N'Small', N'Orange', 45.0000, 28.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4050, 3015, 1, N'31.5"D x 7', N'Dark Gray', 359.0000, 359.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4049, 3016, 1, N'71"D x 34"', N'Dark Grey', 329.0000, 201.0000)
INSERT [dbo].[OrderItems] ([OrderID], [ProductID], [Quantity], [Size], [Color], [Price], [TotalItemsPrice]) VALUES (4049, 3021, 1, N'Small', N'Green', 45.0000, 28.0000)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1, 1, CAST(N'2024-04-22T11:55:44.390' AS DateTime), 19000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (2, 1, CAST(N'2024-04-22T11:57:07.777' AS DateTime), 19000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3, 1, CAST(N'2024-04-22T15:21:40.077' AS DateTime), 81000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4, 1, CAST(N'2024-04-22T15:22:52.183' AS DateTime), 81000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (5, 1, CAST(N'2024-04-22T15:22:52.183' AS DateTime), 81000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (6, 1, CAST(N'2024-04-22T15:27:30.077' AS DateTime), 44000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (7, 1, CAST(N'2024-04-22T22:18:14.620' AS DateTime), 4000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (8, 1, CAST(N'2024-04-25T15:09:12.017' AS DateTime), 39000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1008, 1, CAST(N'2024-04-25T15:20:05.763' AS DateTime), 22000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1009, 1, CAST(N'2024-04-25T15:28:28.510' AS DateTime), 35000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1010, 1, CAST(N'2024-04-25T15:38:02.490' AS DateTime), 26000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1011, 1, CAST(N'2024-04-25T15:42:30.223' AS DateTime), 12000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1012, 1, CAST(N'2024-04-25T18:29:26.970' AS DateTime), 52000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1013, 1, CAST(N'2024-04-25T18:33:11.250' AS DateTime), 52000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1014, 1, CAST(N'2024-04-25T18:35:30.590' AS DateTime), 52000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1015, 1, CAST(N'2024-04-25T20:35:40.990' AS DateTime), 10000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1016, 1, CAST(N'2024-04-25T20:36:40.137' AS DateTime), 16000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1017, 1, CAST(N'2024-04-25T20:38:25.113' AS DateTime), 20000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (1018, 1, CAST(N'2024-04-25T20:39:02.580' AS DateTime), 26000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (2008, 1, CAST(N'2024-04-29T00:15:05.607' AS DateTime), 12000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3008, 1, CAST(N'2024-06-12T12:54:08.843' AS DateTime), 4000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3009, 1, CAST(N'2024-06-14T11:27:18.947' AS DateTime), 2500.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3010, 1, CAST(N'2024-06-14T11:28:26.327' AS DateTime), 4000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3011, 1, CAST(N'2024-06-14T11:31:34.467' AS DateTime), 16000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3012, 1, CAST(N'2024-06-14T11:37:13.420' AS DateTime), 5400.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3013, 1, CAST(N'2024-06-14T11:39:38.617' AS DateTime), 12000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3014, 1, CAST(N'2024-06-21T17:14:01.417' AS DateTime), 16000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (3015, 1, CAST(N'2024-06-21T17:18:04.100' AS DateTime), 16000.0000, 3)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4008, 1, CAST(N'2024-07-12T17:41:43.603' AS DateTime), 388.1600, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4009, 1, CAST(N'2024-07-16T17:25:38.360' AS DateTime), 587.1600, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4010, 1, CAST(N'2024-07-17T16:35:44.440' AS DateTime), 917.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4011, 1, CAST(N'2024-07-17T16:41:42.400' AS DateTime), 629.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4012, 1, CAST(N'2024-07-19T15:49:22.037' AS DateTime), 359.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4013, 1, CAST(N'2024-07-19T16:03:22.903' AS DateTime), 19.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4014, 1, CAST(N'2024-07-19T16:04:56.560' AS DateTime), 39.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4015, 1, CAST(N'2024-07-19T16:12:37.797' AS DateTime), 4000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4016, 1, CAST(N'2024-07-19T17:42:01.957' AS DateTime), 629.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4017, 1, CAST(N'2024-07-19T17:52:40.100' AS DateTime), 19.5000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4018, 1, CAST(N'2024-07-19T19:46:05.053' AS DateTime), 199.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4019, 1, CAST(N'2024-07-19T19:46:30.340' AS DateTime), 179.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4020, 1, CAST(N'2024-07-19T21:09:08.117' AS DateTime), 359.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4021, 1, CAST(N'2024-07-19T21:09:40.517' AS DateTime), 19.0000, 3)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4022, 1, CAST(N'2024-07-19T21:14:10.290' AS DateTime), 72.0000, 6)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4023, 1, CAST(N'2024-07-19T23:05:34.687' AS DateTime), 209.1600, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4024, 1, CAST(N'2024-07-19T23:07:12.947' AS DateTime), 359.0000, 6)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4025, 1, CAST(N'2024-07-21T18:32:12.063' AS DateTime), 19.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4026, 1, CAST(N'2024-07-21T18:32:39.103' AS DateTime), 39.0000, 3)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4027, 1, CAST(N'2024-07-21T18:35:01.433' AS DateTime), 19.5000, 3)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4028, 1, CAST(N'2024-07-21T19:30:41.867' AS DateTime), 209.1600, 3)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4029, 1, CAST(N'2024-07-21T19:36:23.913' AS DateTime), 629.0000, 3)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4030, 1, CAST(N'2024-07-21T19:38:01.743' AS DateTime), 179.0000, 6)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4031, 1, CAST(N'2024-07-21T19:41:15.333' AS DateTime), 359.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4032, 1, CAST(N'2024-07-21T19:42:07.863' AS DateTime), 4000.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4033, 1, CAST(N'2024-07-22T10:56:50.753' AS DateTime), 629.0000, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4034, 1, CAST(N'2024-07-25T18:32:35.563' AS DateTime), 157.3500, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4035, 1, CAST(N'2024-07-26T00:29:06.150' AS DateTime), 329.6900, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4036, 1, CAST(N'2024-07-26T19:45:48.093' AS DateTime), 401.3800, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4037, 1, CAST(N'2024-07-28T01:02:36.230' AS DateTime), 401.3800, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4038, 1, CAST(N'2024-07-28T01:11:48.947' AS DateTime), 200.6900, 5)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4039, 1, CAST(N'2024-07-28T17:25:34.167' AS DateTime), 229.0400, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4040, 1, CAST(N'2024-07-28T17:41:57.840' AS DateTime), 229.0400, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4041, 1, CAST(N'2024-07-28T17:45:49.830' AS DateTime), 6000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4042, 1, CAST(N'2024-07-28T17:46:33.303' AS DateTime), 6000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4043, 1, CAST(N'2024-07-28T17:48:14.003' AS DateTime), 6000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4044, 1, CAST(N'2024-07-28T17:48:57.753' AS DateTime), 6000.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4045, 1, CAST(N'2024-07-28T18:00:41.043' AS DateTime), 19.5000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4046, 1, CAST(N'2024-07-28T18:01:19.723' AS DateTime), 19.5000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4047, 1, CAST(N'2024-07-28T19:11:08.680' AS DateTime), 229.0400, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4048, 1, CAST(N'2024-07-28T19:30:06.203' AS DateTime), 229.0400, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4049, 1, CAST(N'2024-07-28T19:30:06.203' AS DateTime), 229.0400, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4050, 1, CAST(N'2024-07-29T00:11:21.027' AS DateTime), 359.0000, 2)
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4051, 1, CAST(N'2024-07-28T19:30:06.203' AS DateTime), 229.0400, 5)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1, 7, 4000.0000, N'Cash On Delivery', CAST(N'2024-04-22T22:18:57.333' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (2, 8, 39000.0000, N'Cash On Delivery', CAST(N'2024-04-25T15:09:12.073' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1002, 1008, 22000.0000, N'Cash On Delivery', CAST(N'2024-04-25T15:20:05.783' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1003, 1009, 35000.0000, N'Cash On Delivery', CAST(N'2024-04-25T15:28:28.533' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1004, 1010, 26000.0000, N'Cash On Delivery', CAST(N'2024-04-25T15:38:02.507' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1005, 1011, 12000.0000, N'Cash On Delivery', CAST(N'2024-04-25T15:42:30.247' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1006, 1012, 52000.0000, N'Cash On Delivery', CAST(N'2024-04-25T18:29:27.037' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1007, 1013, 52000.0000, N'Cash On Delivery', CAST(N'2024-04-25T18:33:11.267' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1008, 1015, 10000.0000, N'Cash On Delivery', CAST(N'2024-04-25T20:35:41.013' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1009, 1016, 16000.0000, N'Cash On Delivery', CAST(N'2024-04-25T20:36:40.147' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1010, 1017, 20000.0000, N'Cash On Delivery', CAST(N'2024-04-25T20:38:25.130' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (1011, 1018, 26000.0000, N'Cash On Delivery', CAST(N'2024-04-25T20:39:02.593' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (2002, 2008, 12000.0000, N'Cash On Delivery', CAST(N'2024-04-29T00:15:05.663' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3002, 3008, 4000.0000, N'Cash On Delivery', CAST(N'2024-06-12T12:54:08.923' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3003, 3009, 2500.0000, N'Cash On Delivery', CAST(N'2024-06-14T11:27:18.997' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3004, 3010, 4000.0000, N'Cash On Delivery', CAST(N'2024-06-14T11:28:26.347' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3005, 3011, 16000.0000, N'Visa Card', CAST(N'2024-06-14T11:31:34.483' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3006, 3012, 5400.0000, N'Cash On Delivery', CAST(N'2024-06-14T11:37:13.433' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3007, 3013, 12000.0000, N'Cash On Delivery', CAST(N'2024-06-14T11:39:38.653' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3008, 3014, 16000.0000, N'Cash On Delivery', CAST(N'2024-06-21T17:14:01.513' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (3009, 3015, 16000.0000, N'Cash On Delivery', CAST(N'2024-06-21T17:18:04.150' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4002, 4008, 388.1600, N'Cash On Delivery', CAST(N'2024-07-12T17:41:43.663' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4003, 4009, 587.1600, N'Cash On Delivery', CAST(N'2024-07-16T17:25:38.410' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4004, 4010, 917.0000, N'Bank Transfer', CAST(N'2024-07-17T16:35:44.617' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4005, 4011, 629.0000, N'Cash On Delivery', CAST(N'2024-07-17T16:41:42.427' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4006, 4012, 359.0000, N'Cash On Delivery', CAST(N'2024-07-19T15:49:22.207' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4007, 4013, 19.0000, N'Cash On Delivery', CAST(N'2024-07-19T16:03:23.073' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4008, 4014, 39.0000, N'Cash On Delivery', CAST(N'2024-07-19T16:04:56.607' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4009, 4015, 4000.0000, N'Cash On Delivery', CAST(N'2024-07-19T16:12:37.867' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4010, 4016, 629.0000, N'Cash On Delivery', CAST(N'2024-07-19T17:42:02.123' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4011, 4017, 19.5000, N'Visa Card', CAST(N'2024-07-19T17:52:40.127' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4012, 4018, 199.0000, N'Cash On Delivery', CAST(N'2024-07-19T19:46:05.213' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4013, 4019, 179.0000, N'Cash On Delivery', CAST(N'2024-07-19T19:46:30.360' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4014, 4020, 359.0000, N'Cash On Delivery', CAST(N'2024-07-19T21:09:08.233' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4015, 4021, 19.0000, N'Cash On Delivery', CAST(N'2024-07-19T21:09:40.533' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4016, 4023, 209.1600, N'Cash On Delivery', CAST(N'2024-07-19T23:05:34.827' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4017, 4024, 359.0000, N'Cash On Delivery', CAST(N'2024-07-19T23:07:12.987' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4018, 4025, 19.0000, N'Cash On Delivery', CAST(N'2024-07-21T18:32:12.250' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4019, 4026, 39.0000, N'Cash On Delivery', CAST(N'2024-07-21T18:32:39.150' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4020, 4028, 209.1600, N'Cash On Delivery', CAST(N'2024-07-21T19:31:08.767' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4021, 4029, 629.0000, N'Cash On Delivery', CAST(N'2024-07-21T19:37:27.473' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4022, 4030, 179.0000, N'Cash On Delivery', CAST(N'2024-07-21T19:40:26.947' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4023, 4031, 359.0000, N'Cash On Delivery', CAST(N'2024-07-21T19:41:32.010' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4024, 4032, 4000.0000, N'Cash On Delivery', CAST(N'2024-07-21T19:42:16.500' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4025, 4033, 629.0000, N'Cash On Delivery', CAST(N'2024-07-22T10:56:50.923' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4026, 4034, 157.3500, N'Cash On Delivery', CAST(N'2024-07-25T18:32:35.667' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4027, 4035, 329.6900, N'Cash On Delivery', CAST(N'2024-07-26T00:29:06.327' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4028, 4036, 401.3800, N'Cash On Delivery', CAST(N'2024-07-26T19:45:48.273' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4029, 4037, 401.3800, N'Cash On Delivery', CAST(N'2024-07-28T01:02:36.360' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4030, 4038, 200.6900, N'Cash On Delivery', CAST(N'2024-07-28T01:11:49.000' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4031, 4039, 229.0400, N'Cash On Delivery', CAST(N'2024-07-28T17:25:34.340' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4032, 4041, 6000.0000, N'Cash On Delivery', CAST(N'2024-07-28T17:46:08.750' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4033, 4043, 6000.0000, N'Cash On Delivery', CAST(N'2024-07-28T17:48:26.703' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4034, 4045, 19.5000, N'Cash On Delivery', CAST(N'2024-07-28T18:00:50.870' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4035, 4046, 19.5000, N'Cash On Delivery', CAST(N'2024-07-28T18:01:19.740' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4036, 4047, 229.0400, N'Cash On Delivery', CAST(N'2024-07-28T19:11:08.803' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4037, 4048, 229.0400, N'Cash On Delivery', CAST(N'2024-07-28T19:30:06.277' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4038, 4050, 359.0000, N'Cash On Delivery', CAST(N'2024-07-29T00:11:21.067' AS DateTime))
INSERT [dbo].[Payments] ([PaymentID], [OrderID], [Amount], [PaymentMethod], [TransactionDate]) VALUES (4039, 4051, 229.0400, N'Cash On Delivery', CAST(N'2024-07-29T00:15:30.997' AS DateTime))
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4034, N'1', CAST(N'2024-07-25T18:32:35.563' AS DateTime), 157.3500, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4008, N'1', CAST(N'2024-07-12T17:41:43.603' AS DateTime), 388.1600, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4010, N'1', CAST(N'2024-07-17T16:35:44.440' AS DateTime), 917.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4011, N'1', CAST(N'2024-07-17T16:41:42.400' AS DateTime), 629.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4015, N'1', CAST(N'2024-07-19T16:12:37.797' AS DateTime), 4000.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4017, N'1', CAST(N'2024-07-19T17:52:40.100' AS DateTime), 19.5000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4023, N'1', CAST(N'2024-07-19T23:05:34.687' AS DateTime), 209.1600, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4037, N'1', CAST(N'2024-07-28T01:02:36.230' AS DateTime), 401.3800, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4040, N'1', CAST(N'2024-07-28T17:41:57.840' AS DateTime), 229.0400, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4045, N'1', CAST(N'2024-07-28T18:00:41.043' AS DateTime), 19.5000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4048, N'1', CAST(N'2024-07-28T19:30:06.203' AS DateTime), 229.0400, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4049, N'1', CAST(N'2024-07-28T19:30:06.203' AS DateTime), 229.0400, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4050, N'1', CAST(N'2024-07-29T00:11:21.027' AS DateTime), 359.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4012, N'1', CAST(N'2024-07-19T15:49:22.037' AS DateTime), 359.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4013, N'1', CAST(N'2024-07-19T16:03:22.903' AS DateTime), 19.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4014, N'1', CAST(N'2024-07-19T16:04:56.560' AS DateTime), 39.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4020, N'1', CAST(N'2024-07-19T21:09:08.117' AS DateTime), 359.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4036, N'1', CAST(N'2024-07-26T19:45:48.093' AS DateTime), 401.3800, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4016, N'1', CAST(N'2024-07-19T17:42:01.957' AS DateTime), 629.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4018, N'1', CAST(N'2024-07-19T19:46:05.053' AS DateTime), 199.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4019, N'1', CAST(N'2024-07-19T19:46:30.340' AS DateTime), 179.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4025, N'1', CAST(N'2024-07-21T18:32:12.063' AS DateTime), 19.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4041, N'1', CAST(N'2024-07-28T17:45:49.830' AS DateTime), 6000.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4042, N'1', CAST(N'2024-07-28T17:46:33.303' AS DateTime), 6000.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4043, N'1', CAST(N'2024-07-28T17:48:14.003' AS DateTime), 6000.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4031, N'1', CAST(N'2024-07-21T19:41:15.333' AS DateTime), 359.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4044, N'1', CAST(N'2024-07-28T17:48:57.753' AS DateTime), 6000.0000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4039, N'1', CAST(N'2024-07-28T17:25:34.167' AS DateTime), 229.0400, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4046, N'1', CAST(N'2024-07-28T18:01:19.723' AS DateTime), 19.5000, 2)
INSERT [dbo].[ProcessingOrders] ([OrderID], [CustomerID], [OrderDate], [TotalAmount], [Status]) VALUES (4047, N'1', CAST(N'2024-07-28T19:11:08.680' AS DateTime), 229.0400, 2)
GO
SET IDENTITY_INSERT [dbo].[ProductCatalog] ON 

INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (1, N'Desk', N'Lurxury Desk', N'Designed specifically for painting and drawing, art desks often have tilting desktops and storage compartments to keep your creative supplies organized.', 4000.0000, 100, N'C:\Users\lap2p\Downloads\Desk.jpg', NULL, 2, 1, 50)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (2, N'Chair', N'Brown Modren Chair 1', N'Designed by Le Corbusier, Pierre Jeanneret, and Charlotte Perriand in 1928.
A timeless piece with straight, fluted legs.
The original LC2 will set you back around $4,000 at Design Within Reach (DWR), but Hampton Modern offers a cute LC2 knockoff for just $5251.', 6000.0000, 195, N'C:\Users\lap2p\Downloads\Chair.png', NULL, 2, 2, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3, N'Couch', N'simple classic decoration', N'A sofa is designed for seating multiple people, typically with a backrest and armrests. It’s often upholstered with fabric or leather. For instance, you might find a family gathered on the sofa, watching a movie together on a lazy Sunday afternoon', 20000.0000, 300, N'C:\Users\lap2p\Downloads\home Decor.jpg', NULL, 1, 5006, 20)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (1004, N'Chair', N'Classic Chair', N'Designed by Charles and Ray Eames in 1956.
The epitome of mid-century modern elegance.
The real deal is available at Design Within Reach for a hefty price of $4,8591.
However, if you’re looking for a more budget-friendly option, check out LexMod’s decent Eames Lounge knockoff, priced around $7501.', 2000.0000, 100, N'C:\Users\lap2p\Downloads\Chair2.png', NULL, 2, 2, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (1005, N'Chair', N'Modren Chair', N'Designed by Jorge Ferrari-Hardoy in 1938.
You’ve probably seen these at cool places like the Hotel San Jose in Austin or the Parker Hotel in Palm Springs.
The authentic butterfly chair from Circa50 costs about $450, but CB2 offers a good replica for $3991.', 3000.0000, 300, N'C:\Users\lap2p\Downloads\Chair3.jpg', NULL, 2, 2, 10)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (1006, N'Modern Chair', N'Modern 360 Degree Swivel Velvet Barrel Accent Chair', N'Modern 360 Degree Swivel Velvet Barrel Accent Chair, Comfy Side Corner Shell Sofa Chair for Small Spaces, Tufted Upholstered Armless Chair for Living Room, Bedroom, Office, Vanity (Beige)', 5000.0000, 100, N'C:\Users\lap2p\Downloads\Chair.jpg', NULL, 2, 2, 10)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (2006, N'ASUS ZenBook', N'Display diagonal: 13.3 inch,Processor model: i7-8550U', N'Display diagonal: 13.3 inch, Processor model: i7-8550U, Internal memory: 16 GB, On-board graphics adapter model: Intel UHD Graphics 620, Total storage capacity: 1024 GB, Weight: 0.99 kg', 5100.0000, 100, N'C:\Users\lap2p\Downloads\Laptop1.jpg', NULL, 2002, 3002, 50)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (2007, N'Dell Inspiron 15 7000', N'Bright 4K touch display.
Decent speed and performance.', N'15.6-inch FHD Truelife Touch Narrow Border WVA Display with Active Pen support', 5000.0000, 100, N'C:\Users\lap2p\Downloads\Dell1.jpg', NULL, 2002, 3002, 20)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (2010, N'Men''s Slim Fit Formal Shirt', N'Men Dress Shirt Regular Fit Soild Casual Business Formal Long Sleeve Button Down Shirts with Pocket', N'Machine Wash Cold Inside Out / No chlorine wash and low iron. Please wash it with similar colors
Soft/Breathable Thin Fabric/Good Choice for Spring ,Summer and the early Autumn/Long Sleeve/Design By Korean
Formal Dress Shirt for Men/Various Colors/Fitted/Please note that body builds vary by person, therefore, detailed size information should be reviewed
Casual/Business/Work/Dating/Party/suitable for a variety of occasions/Perfect Gift for families, friends or boyfriend
Color Disclaimer : Due to ', 39.0000, 41, N'C:\Users\lap2p\Downloads\WhitTShirt.jpg', NULL, 2003, 4002, 50)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3008, N'SheLucki Hawaiian Shirt for Men', N'Unisex Summer Beach Casual Short Sleeve Button Down Shirts, Printed Palmshadow Clothing', N'Mens Hawaiian Shirts Are Made of 95% Polyester, 5% Spandex Fabric. Soft & Coolness Fabric With Quick To Dry Effect, Nice Print.
You May Wear The Shirts In Many Occasions .Including Holiday, Beach Parties, Theme Parties, Fishing, Sailing, Cruise , Days at Office Etc .The Collared Shirt For Men Could Be Easy To Match With Slacks, Hawaiian Shorts, Swim Shorts, Jeans And So On.
Mens Hawaiian & Paisley & Baroque & Funny Cartoon Style Shirts Are Designed for Different Ages. Pineapple,Sunflower,Fruit', 19.0000, 100, N'C:\Users\lap2p\Downloads\Shirt1.jpg', NULL, 2003, 4002, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3009, N'Women''s V-Neck Retro Floral Print Elegant Ruffled Hem Dress', N'Material description: 100% polyester
Description: This is a dress full of summer breath. Its short-', N'Yard description: Check the size information before ordering. Manual tile measurement. There will be an error of 2-3 cm. It is considered normal.
Washing method: do not bleach. Clean with cold water , add a certain amount of detergent, after about 15 minutes, after ordinary washing, just use water.
Suitable places: it is very suitable for dating, parties, holidays, beaches, parties, clubs, offices, schools, outdoor and daily summer wear.', 39.0000, 100, N'C:\Users\lap2p\Downloads\Dress1.jpg', NULL, 2003, 4003, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3010, N'Calphalon 10-Piece Non-Stick Kitchen Cookware Set', N'Black Pots & Pans with Stay-Cool Stainless Steel Handles, Hard-Anodized Aluminum for Even Heating', N'Includes: 8 Fry Pan, 10 Fry Pan, 1-Qt Sauce Pan with Cover, 2-Qt Saucepan with Cover, 3-Qt Sauté Pan with Cover, 6-Qt Stockpot with Cover
Material: Hard-Anodized Aluminum Cookware, Resists Corrosion and Warping
Interior: Durable, 2-Layer Nonstick Interior for Easy Cleanup
Handles: Long Silicone-Stay Cool Handles for Safety
Oven-Safe: Cookware is Oven-Safe Up to 400 Degrees Fahrenheit
Constituents: Contains PTFE, Aluminum, Stainless Steel (Iron, Chromium, Nickel, Manganese, Copper, Phosphoru', 249.0000, 50, N'C:\Users\lap2p\Downloads\CookWare1.jpg', N'C:\Users\lap2p\Downloads\cookware.mp4', 1003, 5002, 16)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3011, N'Hot Plate,Cusimax Double Burner 1800W Cast Iron Heating Plate', N'Electric Stove with Adjustable Temperature Control,Stainless Steel,Suitable for Various Scenarios Up', N'1800W DOUBLE BURNERS & EASY TO CONTROL - Used 2*11 thermostatically controlled heat settings conveniently to cook a variety of foods such as warm sauces, scrambled eggs, grilled cheese, soup, pasta, vegetables and so much more. Also you can use it as extra burner to keep food warm.
ALL TYPES OF COOKWARE - CUSIMAX hot plate is equipped with a powerful 6.1+7.4 inches heating plate, compatible with pots and pans with maximum size of 7.4 inches. CUSIMAX hot plate can be used with any type of cookwa', 80.0000, 80, N'C:\Users\lap2p\Downloads\Stove1.jpg', NULL, 1003, 5004, 10)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3012, N'ECOWELL Air Fryer Toaster Oven Combo', N'15-in-1 Airfryer Toaster Ovens Countertop, 26.4 QT Stainless Steel Air Fryers Convection Oven, for 3', N'【Multi-Functional】ECOWELL Air Fryer Toaster Oven features 15 rich cooking options, Airfry, Bake, Roast, Broil, Toast, Slow cook, etc. Explore and create even more dishes
🔥【Easy to Use】The stainless steel air fryer toaster oven allows easy cooking control with knobs and buttons, an LED display that clearly shows the working status of the unit. A simple cooker for every food lover, even if you''re new to cooking
🔥【Perfect for Family Needs】This toaster oven air fryer combo with a capacity of 26.', 179.0000, 50, N'C:\Users\lap2p\Downloads\Oven1.jpg', NULL, 1003, 5003, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3013, N'Frigidaire EFR451 2 Door Refrigerator/Freezer', N'4.6 cu ft, Platinum Series, Stainless Steel, Double', N'STORAGE: A large Freezer compartment with an ice cube tray. Also, this refrigerator has a double door design perfect for storing drinks and condiments.Freezer Capacity:0.8 cubic_feet.Fresh Food Capacity: 4.3 cubic_feet.Lock Type:Electronic.Frequency : 60 Hz
EXTRA STORAGE: Adjustable / Removable shelves to expand storage and to easy cleaning.
DESIGN: Unique design that stand out out in your kitchen. Great quality Stainless Steel.
THERMOSTAT: Adjustable thermostat control which is easily access', 199.0000, 20, N'C:\Users\lap2p\Downloads\Refrigrator1.jpg', NULL, 1003, 5005, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3014, N'SAMSUNG Galaxy S24 Cell Phone', N'128GB AI Smartphone, Unlocked Android, 50MP Camera, Fastest Processor, Long Battery Life, US Version', N'CIRCLE & SEARCH¹ IN A SNAP: What’s your favorite influencer wearing? Where’d they go on vacation? What’s that word mean? Don’t try to describe it — use Circle to Search1 with Google to get the answer; With S24 Series, circle it on your screen and learn more
REAL EASY, REAL-TIME TRANSLATIONS: Speak foreign languages on the spot with Live Translate²; Unlock the power of convenient communication with near real-time voice translations, right through your Samsung Phone app
NOTE SMARTER, NOT HARDER:', 629.0000, 50, N'C:\Users\lap2p\Downloads\S241.jpg', N'C:\Users\lap2p\Downloads\SamsungS24.mp4', 2002, 3003, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3015, N'mopio Aaron Couch', N'Small Sofa, Futon, Sofa Bed, Sleeper Sofa, Loveseat, Mid Century Modern Futon Couch, Sofa Cama, Couc', N'Dimensions: 76.4 (W) X 31.5 (D) X 29.1 (H) Inches [Sofa] | 76.4 (W) X 36.2 (D) X 22.8 (H) Inches [Bed]
Spill-resistant & Texture-rich Bouclé Fabric: Effortless upkeep with spill-resistance for worry-free use and stylish design details with its elegant color and nubby textured surface
Versatile Functionality: Sit, lounge or sleep with 3 adjustable splitback fold-down backrest settings. Accommodates seating for 3 and easily transforms into a compact futon bed for 1, suitable for living and guest', 359.0000, 19, N'C:\Users\lap2p\Downloads\Couch1.jpg', N'C:\Users\lap2p\Downloads\Couch.mp4', 1, 5006, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3016, N'Sofa Bed', N'4 in 1 Multi-Function Folding Ottoman Breathable Linen Couch Bed with Adjustable Backrest Modern Con', N'* CONVERTIBLE CHAIR TO BED - 4 IN 1 Folding Sofa Bed is easily converted into a leisure ottoman, sofa/chair, bed, and Lounger to satisfy various needs. It''s absolutely a good idea for placement in a small room, dorms, apartments, studios, office.
* MATERIAL -This 4 IN 1 Folding Sofa Bed is wrapped in premium linen fabric for beauty and comfort. High-density sponge makes the sofa very elastic, suitable for rest and sleep. The adjustable sofa back is stable and durable, allowing you to relax at ev', 329.0000, 2, N'C:\Users\lap2p\Downloads\Sofabed1.jpg', N'C:\Users\lap2p\Downloads\Sofabed.mp4', 1, 5007, 39)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3017, N'TV with Alexa Voice Remote', N'INSIGNIA 50-inch Class F30 Series LED 4K UHD Smart Fire TV with Alexa Voice Remote', N'4K Ultra HD (2160p resolution) - Enjoy breathtaking 4K movies and TV shows at 4 times the resolution of Full HD, and upscale your current content to Ultra HD-level picture quality.
Alexa voice control - Speak commands into the voice remote with Alexa to control your Fire TV verbally—ask it to watch live TV, search for titles, play music, switch inputs, control smart home devices and more.
Access thousands of shows with Fire TV - Watch over 1 million streaming movies and TV episodes with access t', 129.0000, 18, N'C:\Users\lap2p\Downloads\Tv1.jpg', NULL, 2002, 5008, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3018, N'Vase w Poetry Card', N'Unique Hand Made Pottery Vase w Poetry Card - Cute Country Farmhouse Style Mini Flower Pot - Gifts f', N'Introducing the perfect gift for mom, expecting moms and those looking for a unique and special find! So what is a mother pot” Well, they are miniature pottery vases -smaller than a bud vase, intended to hold the tiny road-side flowers picked by children. Children don’t always manage to pluck them with the stem intact, so they don’t fit into a traditional bud vase. If you have ever been the recipient of a dandelion bouquet with tiny stems, this wee flower vase is for you! Children always want th', 18.0000, 30, N'C:\Users\lap2p\Downloads\Vase1.jpg', N'C:\Users\lap2p\Downloads\Vase.mp4', 4, 5009, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3019, N'Snowflake Glaze White Ceramic Vase', N'8 Inch Handmade Snowflake Glaze White Ceramic Vase,Asymmetric Wave Patterns White Vase for Modern Ho', N'【Elegant Wave Patterns and Enhanced Stability】Beautifully crafted with an elegant asymmetrical wavy pattern, this ceramic white vase boasts an enhanced stability due to its thickened base. With a weight of 2.1 pounds, it is 20% heavier than vases of similar size, ensuring it sits securely on tables or shelves while providing a substantial feel.
【 Handmade High-Temperature Ceramic】 Made from high-quality ceramic , with kaolin clay pure handcrafted and fired at temperatures exceeding 2000 degrees', 18.0000, 30, N'C:\Users\lap2p\Downloads\Vase11.jpg', N'C:\Users\lap2p\Downloads\Vase2.mp4', 4, 5009, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3020, N'H2OGO! Inflatable Beach Ball', N'Classic Color Panel Design
Constructed from high grade PVC material
Inflation Nozzle allows for ea', N'Brand	Bestway Toys Domestic
Material	Plastic
Color	Multi
Age Range (Description)	3+ years
Item Weight	0.05 Kilograms', 4.0000, 50, N'C:\Users\lap2p\Downloads\Ball1.jpg', NULL, 4002, 5010, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3021, N'Upgraded Flying Orb Ball Toy', N'Hand Controlled Boomerang Hover Ball, Cosmic Globe Flying Spinner with Endless Tricks, Cool Toys Gif', N'【Design Concept of The Flying Orb Ball】Spherical appearance, powerful engine, function based on aviation flight principle, which can realize a variety of flight modes. This girl toys not only brings fun to play but also helps to improve children''s hands-on ability, operating skills, intelligence, and creativity.
【Rich Flying Skills】You can control the flying ball to float, glide and climb in the air, or throw it out and fly back like a boomerang, just like you have magic. Control the angle of th', 45.0000, 37, N'C:\Users\lap2p\Downloads\FlyingBall1.jpg', N'C:\Users\lap2p\Downloads\FlyingBall.mp4', 4002, 5010, 37)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3022, N'Boys T-Shirts', N'Boys T-Shirts Little Big Kids Girls,Game Boys Shirts Short Sleeve T-Shirts,Lightning Graphic Neon T-', N'💨【Breathable Fabric】The neon shirts for boys are made of 100% polyester.With the silky-feeling fabric, the funny shirts for boys and girls make you feel cooler than other shirts in summer. A comfortable rainbow shirt for toddlers and your kids.
💥【Unique Eye-catching Printing Design】Our boys shirts 2024 are made of full body printing design,using the black color as a background and the rainbow smoke graphic, with the popular game characters, suits Hawaiian shirts for boys girls.
🎁【Gift for Kid', 14.0000, 50, N'C:\Users\lap2p\Downloads\ChidTShirt1.jpg', NULL, 2003, 4004, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3023, N'Mother’s Day Fresh Flowers', N'Blue Orchid with Vase For .Gift for Birthday, Anniversary, Get Well, Thank You, Mother’s Day Fresh F', N'BLOOM SELECTIONS : 10 Blue Orchids
FRESH FLOWERS: Revel in the delight of your Bouquet Refreshing to life. Enjoy the freshness, as these handpicked Orchids gracefully.
CRAFT THE PERFECT SURPRISE: To ensure your gift inlcudes your information for the recipient, At checkout, please check off "THIS IS A GIFT" or "ADD A GIFT RECEIPT".
DELIVER AT YOUR CONVENIENCE: Place your orders any day, by 2 PM EST to receive your items the very next day! We deliver Tuesday to Friday. Orders placed on Friday, Sat', 69.0000, 20, N'C:\Users\lap2p\Downloads\Flower1.jpg', NULL, 7, 5012, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3024, N'BGment Blackout Curtains for Bedroom', N'Grommet Thermal Insulated Room Darkening Curtains for Living Room, Set of 2 Panels (42 x 63 Inch, Na', N'Package Includes: Set of 2 pieces navy blue blackout curtains; Each panel measures 42 Inch wide by 63 Inch long. Suggest choose the right size after measuring the windows.
Grommet Construction: Each curtain panel has 6 silver metal grommets on top. Each grommet inner diameter is 1.6 inch, comparable with most rods. Easy to hang, and slide smoothly.
Blackout Functions: Our bedroom curtains can block out sunlight, darker colors work better. Perfect for late sleepers and afternoon naps.
Thermal Ins', 25.0000, 20, N'C:\Users\lap2p\Downloads\Curtains1.jpg', N'C:\Users\lap2p\Downloads\Curtains.mp4', 1002, 5013, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3025, N'PlayStation 5', N'PlayStation 5 Digital Edition – Marvel’s Spider-Man 2 Bundle (Slim)', N'Bundle includes Marvel’s Spider-Man 2 full game digital voucher
Includes DualSense Wireless Controller, 1TB SSD, 2 Horizontal Stand Feet, HDMI Cable, AC power cord, USB cable, printed materials, ASTRO’s PLAYROOM (Pre-installed game)
Slim Design - With PS5, players get powerful gaming technology packed inside a sleek and compact console design.
PS5 Vertical Stand sold separately.', 544.0000, 20, N'C:\Users\lap2p\Downloads\Ps5.jpg', NULL, 2002, 5015, NULL)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3026, N'MATEIN Travel Laptop Backpack', N'MATEIN Travel Laptop Backpack, Business Anti Theft Slim Sturdy Laptops Backpack with USB Charging Po', N'★LOTS OF STORAGE SPACE&POCKETS: One separate laptop compartment hold 15.6 Inch Laptop as well as 15 Inch,14 Inch and 13 Inch Laptop. One spacious packing compartment roomy for daily necessities,tech electronics accessories. Front compartment with many pockets, pen pockets and key fob hook, makes your item organized and easier to find
★COMFY&STURDY: Comfortable soft padded back design with thick but soft multi-panel ventilated padding, gives you maximum back support. Breathable and adjustable sho', 39.0000, 30, N'C:\Users\lap2p\Downloads\BackPack1.jpg', N'C:\Users\lap2p\Downloads\BackPack.mp4', 2003, 5016, 45)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3027, N'Atomic Habits', N'An Easy & Proven Way to Build Good Habits & Break Bad Ones.', N'No matter your goals, Atomic Habits offers a proven framework for improving--every day. James Clear, one of the world''s leading experts on habit formation, reveals practical strategies that will teach you exactly how to form good habits, break bad ones, and master the tiny behaviors that lead to remarkable results.

If you''re having trouble changing your habits, the problem isn''t you. The problem is your system. Bad habits repeat themselves again and again not because you don''t want to change, b', 27.0000, 20, N'C:\Users\lap2p\Downloads\Book1.jpg', NULL, 4019, 5021, 49)
INSERT [dbo].[ProductCatalog] ([ProductID], [ProductName], [Description], [LongDescription], [Price], [QuantityInStock], [ImageURL], [VideoURL], [CategoryID], [SubCategoryID], [Discount]) VALUES (3028, N'Charge Board', N'6Pcs TP5100 Charge Management Power Module 2A Charging Board Voltage Regulator Lithium Battery Charg', N'Double 8.4v / 4.2v lithium rechargeable single. Input voltage: 5-18V DC power supply (actual 5-12V is appropriate); Current: 1A-2A
The TP5100 is a switching step-down dual-cell 8.4V/single-cell 4.2V Li-ion battery charge management module.
The TP5100 has a wide input voltage range of 5V-18V and charges the battery in three stages: trickle pre-charge, constant current, and constant voltage. The trickle pre-charge current and constant current charge current are adjusted by external resistors, and ', 7.0000, 30, N'C:\Users\lap2p\Downloads\Board1.jpg', NULL, 4024, 5023, NULL)
SET IDENTITY_INSERT [dbo].[ProductCatalog] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (1, N'living room furniture', N'C:\Users\lap2p\Downloads\LivingRoom.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (2, N'office & Study furniture', N'C:\Users\lap2p\Downloads\Office-removebg-preview.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (4, N'home decoration', N'C:\Users\lap2p\Downloads\58-581778_home-icon-clip-art-interior-design-logo-png.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (7, N'Gardening store', N'C:\Users\lap2p\Downloads\Gardening.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (1002, N'Curtains & Accessories', N'C:\Users\lap2p\Downloads\Curtain.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (1003, N'kitchen, Cookware & Serveware', N'C:\Users\lap2p\Downloads\Kitcen.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (2002, N'Smart Devices', N'C:\Users\lap2p\Downloads\SmartDevices-removebg-preview.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (2003, N'Clothes', N'C:\Users\lap2p\Downloads\ClothesArt-removebg-preview.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (4002, N'Toys && Games', N'C:\Users\lap2p\Downloads\ToysCategory-removebg-preview (1).png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (4019, N'Books', N'C:\Users\lap2p\Downloads\Books-removebg-preview.png')
INSERT [dbo].[ProductCategory] ([CategoryID], [CategoryName], [CategoryImage]) VALUES (4024, N'Electronics & Automation', N'C:\Users\lap2p\Downloads\Industrial&Automation.jpg')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductColor] ON 

INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (1, N'Red
Blue 
Orange', 1)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (2, N'Red
Blue
Orange', 2)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (3, N'Red
Blue 
Orange', 3)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (10, N'Red Blue Orange', 1004)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (11, N'Red
Blue
Orange', 1005)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (1002, N'Green 
Yellow
White', 1006)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (2002, N'Gold
Gray
Black', 2006)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (6002, N'black
Gold
Silver', 2007)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (6003, N'Red
Blue
Orange', 1005)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (6008, N'Red
Blue 
Orange', 1)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (7002, N'White 
DarkBlue 
SkyBlue 
Red Pink 
Black 
White Green', 2010)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8002, N'Leaf Green 
Leaf Yellow 
Leaf Colorful
Leaf Navy 
Leaf Gray 
Leaf White Green
Leaf Blue', 3008)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8003, N'Black', 3009)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8004, N'Black', 3010)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8005, N'Matte
Silver', 3011)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8006, N'Silver', 3012)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8007, N'Stainless Steel', 3013)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8008, N'Amber Yellow
Cobalt Violet
Marble Gray 
Onyx Black 
Titanium Black 
Titanium Gray 
Titanium Vi', 3014)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8009, N'Cloud Gray 
Dark Gray 
Light Gray 
Midnight Black 
Old Rosa 
Pearl White', 3015)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8010, N'Dark Grey 
Linen Blue 
Linen Red 
White 
Yellow', 3016)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8011, N'Black', 3017)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8012, N'Blue', 3018)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8013, N'White 
Black', 3019)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8014, N'Multi', 3020)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8015, N'Blue 
Green 
Orange 
Purple 
Red', 3021)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8016, N'Green Lightning Neon Shirt Rainbow Smoke Starry Sky', 3022)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8017, N'Blue Orchid
Blue &Purple 
Blue & white 
Purple & White 
White Orchid', 3023)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8018, N'Aqua 
Pink 
Beige 
Black 
Brown 
Camel 
Yellow 
Royal Blue 
Classic Blue', 3024)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8019, N'White', 3025)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8020, N'Black 
Gray 
Green 
Yellow 
BlueWhite', 3026)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8021, N'Black & White
Colorful', 3027)
INSERT [dbo].[ProductColor] ([ColorID], [Color], [ProductID]) VALUES (8022, N'None', 3028)
SET IDENTITY_INSERT [dbo].[ProductColor] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1, N'C:\Users\lap2p\Downloads\Samlpe11.jpg', 1, 1005)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (2, N'C:\Users\lap2p\Downloads\Chair1.jpg', 0, 1006)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (3, N'C:\Users\lap2p\Downloads\Chair2.jpg', 1, 1006)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1002, N'C:\Users\lap2p\Downloads\desk2.jpg', 0, 1)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1003, N'C:\Users\lap2p\Downloads\desk3.jpg', 1, 1)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1004, N'C:\Users\lap2p\Downloads\desk4.jpg', 2, 1)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1006, N'C:\Users\lap2p\Downloads\Sofa1.jpg', 0, 3)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1007, N'C:\Users\lap2p\Downloads\Sofa2.jpg', 1, 3)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1008, N'C:\Users\lap2p\Downloads\Sofa3.jpg', 2, 3)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1009, N'C:\Users\lap2p\Downloads\Sofa4.jpg', 3, 3)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1010, N'C:\Users\lap2p\Downloads\Chair11.jpg', 0, 2)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1011, N'C:\Users\lap2p\Downloads\Chair12.jpg', 1, 2)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1012, N'C:\Users\lap2p\Downloads\Chair13.jpg', 2, 2)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (1013, N'C:\Users\lap2p\Downloads\Chair14.jpg', 3, 2)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (2002, N'C:\Users\lap2p\Downloads\LapTop2.jpg', 0, 2006)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (2003, N'C:\Users\lap2p\Downloads\Laptop3.jpg', 1, 2006)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (2004, N'C:\Users\lap2p\Downloads\LapTop4.jpg', 2, 2006)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (2005, N'C:\Users\lap2p\Downloads\LapTop5.jpg', 3, 2006)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (3002, N'C:\Users\lap2p\Downloads\dell2.jpg', 0, 2007)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (3003, N'C:\Users\lap2p\Downloads\Dell3.jpg', 1, 2007)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (3004, N'C:\Users\lap2p\Downloads\dell4.jpg', 2, 2007)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (3005, N'C:\Users\lap2p\Downloads\Dell5.jpg', 3, 2007)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (4002, N'C:\Users\lap2p\Downloads\WhiteTShirt2.jpg', 0, 2010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (4003, N'C:\Users\lap2p\Downloads\WhiteTShirt3.jpg', 1, 2010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (4004, N'C:\Users\lap2p\Downloads\WhiteTShirt4.jpg', 2, 2010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (4005, N'C:\Users\lap2p\Downloads\WhiteTShirt5.jpg', 3, 2010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (4006, N'C:\Users\lap2p\Downloads\WhiteTShirt6.jpg', 4, 2010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (4007, N'C:\Users\lap2p\Downloads\WhitTShirtInfo.jpg', 5, 2010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5002, N'C:\Users\lap2p\Downloads\Shirt1.jpg', 0, 3008)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5003, N'C:\Users\lap2p\Downloads\Shirt2.jpg', 1, 3008)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5004, N'C:\Users\lap2p\Downloads\Shirt3.jpg', 2, 3008)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5005, N'C:\Users\lap2p\Downloads\Shirt5.jpg', 3, 3008)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5006, N'C:\Users\lap2p\Downloads\Shirt6.jpg', 4, 3008)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5007, N'C:\Users\lap2p\Downloads\Dress1.jpg', 0, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5008, N'C:\Users\lap2p\Downloads\Dress2.jpg', 1, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5009, N'C:\Users\lap2p\Downloads\Dress3.jpg', 2, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5010, N'C:\Users\lap2p\Downloads\Dress4.jpg', 3, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5011, N'C:\Users\lap2p\Downloads\Dress5.jpg', 4, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5012, N'C:\Users\lap2p\Downloads\Dress6.jpg', 5, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5013, N'C:\Users\lap2p\Downloads\Dress7.jpg', 6, 3009)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5014, N'C:\Users\lap2p\Downloads\CookWare2.jpg', 0, 3010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5015, N'C:\Users\lap2p\Downloads\CookWare3.jpg', 1, 3010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5016, N'C:\Users\lap2p\Downloads\CookWare4.jpg', 2, 3010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5017, N'C:\Users\lap2p\Downloads\CookWare5.jpg', 3, 3010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5018, N'C:\Users\lap2p\Downloads\CookWare6.jpg', 4, 3010)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5019, N'C:\Users\lap2p\Downloads\Stove2.jpg', 0, 3011)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5020, N'C:\Users\lap2p\Downloads\Stove3.jpg', 1, 3011)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5021, N'C:\Users\lap2p\Downloads\Stove4.jpg', 2, 3011)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5022, N'C:\Users\lap2p\Downloads\Stove5.jpg', 3, 3011)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5023, N'C:\Users\lap2p\Downloads\Stove6.jpg', 4, 3011)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5024, N'C:\Users\lap2p\Downloads\Oven2.jpg', 0, 3012)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5025, N'C:\Users\lap2p\Downloads\Oven3.jpg', 1, 3012)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5026, N'C:\Users\lap2p\Downloads\Oven4.jpg', 2, 3012)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5027, N'C:\Users\lap2p\Downloads\Oven5.jpg', 3, 3012)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5028, N'C:\Users\lap2p\Downloads\Oven6.jpg', 4, 3012)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5029, N'C:\Users\lap2p\Downloads\Refrigrator1.jpg', 0, 3013)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5030, N'C:\Users\lap2p\Downloads\Refrigrator2.jpg', 1, 3013)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5031, N'C:\Users\lap2p\Downloads\Refrigrator3.jpg', 2, 3013)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5038, N'C:\Users\lap2p\Downloads\S241.jpg', 0, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5039, N'C:\Users\lap2p\Downloads\S242.jpg', 1, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5040, N'C:\Users\lap2p\Downloads\S243.jpg', 2, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5041, N'C:\Users\lap2p\Downloads\S244.jpg', 3, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5042, N'C:\Users\lap2p\Downloads\S245.jpg', 4, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5043, N'C:\Users\lap2p\Downloads\S246.jpg', 5, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5044, N'C:\Users\lap2p\Downloads\S247.jpg', 6, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5045, N'C:\Users\lap2p\Downloads\S248.jpg', 7, 3014)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5046, N'C:\Users\lap2p\Downloads\Couch1.jpg', 0, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5047, N'C:\Users\lap2p\Downloads\Couch2.jpg', 1, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5048, N'C:\Users\lap2p\Downloads\Couch3.jpg', 2, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5049, N'C:\Users\lap2p\Downloads\Couch4.jpg', 3, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5050, N'C:\Users\lap2p\Downloads\Couch5.jpg', 4, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5051, N'C:\Users\lap2p\Downloads\Couch6.jpg', 5, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5052, N'C:\Users\lap2p\Downloads\Couch7.jpg', 6, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5053, N'C:\Users\lap2p\Downloads\Couch8.jpg', 7, 3015)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5054, N'C:\Users\lap2p\Downloads\Sofabed1.jpg', 0, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5055, N'C:\Users\lap2p\Downloads\Sofabed2.jpg', 1, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5056, N'C:\Users\lap2p\Downloads\Sofabed3.jpg', 2, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5057, N'C:\Users\lap2p\Downloads\Sofabed4.jpg', 3, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5058, N'C:\Users\lap2p\Downloads\Sofabed5.jpg', 4, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5059, N'C:\Users\lap2p\Downloads\Sofabed6.jpg', 5, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5060, N'C:\Users\lap2p\Downloads\Sofabed7.jpg', 6, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5061, N'C:\Users\lap2p\Downloads\Sofabed8.jpg', 7, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5062, N'C:\Users\lap2p\Downloads\Sofabed9.jpg', 8, 3016)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5063, N'C:\Users\lap2p\Downloads\Tv1.jpg', 0, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5064, N'C:\Users\lap2p\Downloads\Tv2.jpg', 1, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5065, N'C:\Users\lap2p\Downloads\Tv3.jpg', 2, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5066, N'C:\Users\lap2p\Downloads\Tv4.jpg', 3, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5067, N'C:\Users\lap2p\Downloads\Tv5.jpg', 4, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5068, N'C:\Users\lap2p\Downloads\Tv6.jpg', 5, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5069, N'C:\Users\lap2p\Downloads\Tv7.jpg', 6, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5070, N'C:\Users\lap2p\Downloads\Tv8.jpg', 7, 3017)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5071, N'C:\Users\lap2p\Downloads\Vase1.jpg', 0, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5072, N'C:\Users\lap2p\Downloads\Vase2.jpg', 1, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5073, N'C:\Users\lap2p\Downloads\Vase3.jpg', 2, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5074, N'C:\Users\lap2p\Downloads\Vase4.jpg', 3, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5075, N'C:\Users\lap2p\Downloads\Vase5.jpg', 4, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5076, N'C:\Users\lap2p\Downloads\Vase6.jpg', 5, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5077, N'C:\Users\lap2p\Downloads\Vase7.jpg', 6, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5078, N'C:\Users\lap2p\Downloads\Vase8.jpg', 7, 3018)
GO
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5079, N'C:\Users\lap2p\Downloads\Vase9.jpg', 8, 3018)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5080, N'C:\Users\lap2p\Downloads\Vase11.jpg', 0, 3019)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5081, N'C:\Users\lap2p\Downloads\Vase22.jpg', 1, 3019)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5082, N'C:\Users\lap2p\Downloads\Vase33.jpg', 2, 3019)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5083, N'C:\Users\lap2p\Downloads\Vase44.jpg', 3, 3019)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5084, N'C:\Users\lap2p\Downloads\Vase55.jpg', 4, 3019)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5085, N'C:\Users\lap2p\Downloads\Vase66.jpg', 5, 3019)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5086, N'C:\Users\lap2p\Downloads\Ball1.jpg', 0, 3020)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5087, N'C:\Users\lap2p\Downloads\Ball2.jpg', 1, 3020)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5088, N'C:\Users\lap2p\Downloads\Ball3.jpg', 2, 3020)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5089, N'C:\Users\lap2p\Downloads\FlyingBall1.jpg', 0, 3021)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5090, N'C:\Users\lap2p\Downloads\FlyingBall2.jpg', 1, 3021)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5091, N'C:\Users\lap2p\Downloads\FlyingBall3.jpg', 2, 3021)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5092, N'C:\Users\lap2p\Downloads\FlyingBall4.jpg', 3, 3021)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5093, N'C:\Users\lap2p\Downloads\FlyingBall5.jpg', 4, 3021)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5094, N'C:\Users\lap2p\Downloads\ChidTShirt1.jpg', 0, 3022)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5095, N'C:\Users\lap2p\Downloads\ChidTShirt2.jpg', 1, 3022)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5096, N'C:\Users\lap2p\Downloads\Flower1.jpg', 0, 3023)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5097, N'C:\Users\lap2p\Downloads\Flower2.jpg', 1, 3023)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5098, N'C:\Users\lap2p\Downloads\Flower3.jpg', 2, 3023)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5099, N'C:\Users\lap2p\Downloads\Flower4.jpg', 3, 3023)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5100, N'C:\Users\lap2p\Downloads\Flower5.jpg', 4, 3023)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5101, N'C:\Users\lap2p\Downloads\Curtains1.jpg', 0, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5102, N'C:\Users\lap2p\Downloads\Curtains2.jpg', 1, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5103, N'C:\Users\lap2p\Downloads\Curtains3.jpg', 2, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5104, N'C:\Users\lap2p\Downloads\Curtains4.jpg', 3, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5105, N'C:\Users\lap2p\Downloads\Curtains5.jpg', 4, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5106, N'C:\Users\lap2p\Downloads\Curtains6.jpg', 5, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5107, N'C:\Users\lap2p\Downloads\Curtains7.jpg', 6, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5108, N'C:\Users\lap2p\Downloads\Curtains8.jpg', 7, 3024)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5109, N'C:\Users\lap2p\Downloads\Ps5.jpg', 0, 3025)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5110, N'C:\Users\lap2p\Downloads\Ps52.jpg', 1, 3025)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5111, N'C:\Users\lap2p\Downloads\Ps53.jpg', 2, 3025)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5112, N'C:\Users\lap2p\Downloads\BackPack1.jpg', 0, 3026)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5113, N'C:\Users\lap2p\Downloads\BackPack2.jpg', 1, 3026)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5114, N'C:\Users\lap2p\Downloads\BackPack3.jpg', 2, 3026)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5115, N'C:\Users\lap2p\Downloads\BackPack4.jpg', 3, 3026)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5116, N'C:\Users\lap2p\Downloads\BackPack5.jpg', 4, 3026)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5117, N'C:\Users\lap2p\Downloads\Book1.jpg', 0, 3027)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5118, N'C:\Users\lap2p\Downloads\Board1.jpg', 0, 3028)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5119, N'C:\Users\lap2p\Downloads\Board2.jpg', 1, 3028)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5120, N'C:\Users\lap2p\Downloads\Board3.jpg', 2, 3028)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5121, N'C:\Users\lap2p\Downloads\Board4.jpg', 3, 3028)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5122, N'C:\Users\lap2p\Downloads\Board5.jpg', 4, 3028)
INSERT [dbo].[ProductImages] ([ID], [ImageURL], [ImageOrder], [ProductID]) VALUES (5123, N'C:\Users\lap2p\Downloads\Board6.jpg', 5, 3028)
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSize] ON 

INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (1, N'S 
M 
L', 1)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (2, N'S
M
L', 2)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (3, N'S 
M 
L', 3)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (4, N'S M L', 1004)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (5, N'S
M
L', 1005)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6, N'S
M 
L', 1006)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (7, N'13.3inch', 2006)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (4007, N'14.02in', 2007)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (4008, N'S
M
L', 1005)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (4009, N'S 
M 
L', 1)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (5007, N'S 
M 
L 
XL
XXL', 2010)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6007, N'Small 
Meduim 
Large 
X Large 
XX Large', 3008)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6008, N'Small 
Medium 
Large', 3009)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6009, N'10-Piece', 3010)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6010, N'Tow Heating Elements', 3011)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6011, N'16.89"D x 15.51"W x 15.87"H', 3012)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6012, N'20.1"D x 18.9"W x 43"H', 3013)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6013, N'128GB 
256GB 
512GB', 3014)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6014, N'31.5"D x 76.4"W x 29.1"H', 3015)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6015, N'71"D x 34"W x 16"H', 3016)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6016, N'50 Inches', 3017)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6017, N'Small', 3018)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6018, N'Medium', 3019)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6019, N'Big', 3020)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6020, N'Small', 3021)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6021, N'5-6 Years', 3022)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6022, N'20', 3023)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6023, N'45"L x 38"W 
42"L x 63"W 
52"L x 72"W', 3024)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6024, N'None', 3025)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6025, N'15.6 Inch', 3026)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6026, N'Big
Small', 3027)
INSERT [dbo].[ProductSize] ([SizeID], [Size], [ProductID]) VALUES (6027, N'Input Voltage 18 Volts', 3028)
SET IDENTITY_INSERT [dbo].[ProductSize] OFF
GO
SET IDENTITY_INSERT [dbo].[Responses] ON 

INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (1, 2, N'Asim', N'Hi, this is Owner.', 1, CAST(N'2024-05-05T04:27:22.480' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2, 2, N'Asim', N'Hi Asim', 1, CAST(N'2024-06-06T17:40:01.110' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (1002, 2, N'Asim', N'Hey, How can I help you?', 1, CAST(N'2024-07-05T16:55:48.373' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2002, 2004, N'Tom', N'Test5 response.', 1004, CAST(N'2024-07-19T23:02:33.893' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2003, 2004, N'Tom', N'Test6', 1005, CAST(N'2024-07-21T19:46:35.527' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2004, 2004, N'Tom', N'Test6.', 1005, CAST(N'2024-07-21T23:09:28.183' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2005, 2004, N'Tom', N'Test6', 1005, CAST(N'2024-07-21T23:20:50.883' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2006, 2004, N'Tom', N'Test6.', 1005, CAST(N'2024-07-21T23:27:01.983' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2007, 2004, N'Tom', N'Test6.', 1005, CAST(N'2024-07-22T10:43:19.477' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2008, 2004, N'Tom', N'hey', 1008, CAST(N'2024-07-26T11:11:11.157' AS DateTime), 1)
INSERT [dbo].[Responses] ([ResponseID], [OwnerID], [Name], [Response], [MessageID], [DateTime], [CustomerID]) VALUES (2011, 2004, N'Tom', N'hi', 2, CAST(N'2024-07-29T18:34:12.560' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Responses] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (2, 3, 1, N'Good Quality Furniture.', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-05-09T15:25:13.740' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (1002, 1006, 1, N'Nice Chair', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-05-12T14:45:20.663' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (2002, 2010, 1, N'Nice Shirt', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-06-26T19:28:14.110' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3002, 1, 1, N'', CAST(3.0 AS Decimal(2, 1)), CAST(N'2024-07-02T16:19:48.133' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3003, 3010, 1, N'Nice Cookware Collection', CAST(5.0 AS Decimal(2, 1)), CAST(N'2024-07-10T10:11:21.977' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3004, 3011, 1, N'Nice Stove', CAST(5.0 AS Decimal(2, 1)), CAST(N'2024-07-10T10:15:41.257' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3005, 1005, 1, N'Nice Chair', CAST(5.0 AS Decimal(2, 1)), CAST(N'2024-07-10T10:20:51.667' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3006, 2006, 1, N'Nice Laptop', CAST(5.0 AS Decimal(2, 1)), CAST(N'2024-07-10T10:22:47.520' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3007, 2007, 1, N'High Performance Laptop :)', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-10T12:16:24.793' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3008, 3016, 1, N'jok', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-26T19:03:08.697' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3009, 3016, 1, N'dfdcx', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-26T19:22:50.320' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3010, 3016, 1, N'ccx', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-26T19:34:14.973' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3011, 3016, 1, N'jiio', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-26T19:40:49.287' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3012, 3016, 1, N'nice', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-27T15:30:10.397' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3013, 3016, 1, N'nice', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-28T01:01:19.163' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3014, 3016, 1, N'nice', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-28T01:10:10.983' AS DateTime))
INSERT [dbo].[Reviews] ([ReviewID], [ProductID], [CustomerID], [ReviewText], [Rating], [ReviewDate]) VALUES (3027, 3016, 1, N'cx', CAST(6.0 AS Decimal(2, 1)), CAST(N'2024-07-28T19:27:59.990' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesReport] ON 

INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (2, N'January', 2021, 10, CAST(5000.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (3, N'February', 2021, 15, CAST(5500.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (4, N'March', 2021, 18, CAST(5600.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (5, N'April', 2021, 12, CAST(5800.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (6, N'May', 2021, 11, CAST(5000.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (7, N'June', 2021, 19, CAST(3900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (8, N'July', 2021, 25, CAST(6300.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (9, N'August', 2021, 19, CAST(5600.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (10, N'September', 2021, 29, CAST(6900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (11, N'October', 2021, 26, CAST(6500.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (12, N'November', 2021, 22, CAST(6200.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (13, N'December', 2021, 31, CAST(7100.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (14, N'January', 2022, 19, CAST(5200.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (15, N'February', 2022, 13, CAST(5300.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (16, N'March', 2022, 21, CAST(5900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (17, N'April', 2022, 25, CAST(6000.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (18, N'May', 2022, 30, CAST(6900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (19, N'June', 2022, 33, CAST(7500.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (20, N'July', 2022, 39, CAST(7900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (21, N'August', 2022, 42, CAST(8100.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (22, N'September', 2022, 50, CAST(8800.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (23, N'October', 2022, 49, CAST(8600.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (24, N'November', 2022, 52, CAST(8900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (25, N'December', 2022, 60, CAST(9800.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (26, N'January', 2023, 56, CAST(9200.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (27, N'February', 2023, 62, CAST(10100.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (28, N'March', 2023, 69, CAST(10900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (29, N'April', 2023, 76, CAST(12100.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (30, N'May', 2023, 72, CAST(11200.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (31, N'June', 2023, 78, CAST(12500.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (32, N'July', 2023, 81, CAST(13000.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (33, N'August', 2023, 77, CAST(12300.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (34, N'September', 2023, 85, CAST(13500.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (35, N'October', 2023, 90, CAST(13900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (36, N'November', 2023, 93, CAST(14100.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (37, N'December', 2023, 90, CAST(15000.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (38, N'January', 2024, 93, CAST(16200.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (39, N'February', 2024, 94, CAST(17700.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (40, N'March', 2024, 92, CAST(18200.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (41, N'April', 2024, 97, CAST(20600.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (42, N'May', 2024, 99, CAST(21800.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (43, N'June', 2024, 101, CAST(22900.0000 AS Decimal(19, 4)))
INSERT [dbo].[SalesReport] ([SalesID], [Month], [Year], [TotalSales], [TotalRevenue]) VALUES (44, N'July', 2024, 149, CAST(32978.7900 AS Decimal(19, 4)))
SET IDENTITY_INSERT [dbo].[SalesReport] OFF
GO
SET IDENTITY_INSERT [dbo].[Shippers] ON 

INSERT [dbo].[Shippers] ([CarrierID], [CarrierName], [Phone], [Email], [UserName], [Password]) VALUES (1, N'John', N'0112328932', N'John@gmail.com', N'John123', N'ae37ebcd96927dd446de0cd73c8b880ebeb113a960e777d2e4854899ccd85f8f')
INSERT [dbo].[Shippers] ([CarrierID], [CarrierName], [Phone], [Email], [UserName], [Password]) VALUES (2, N'Mike', N'323781789823', N'Mike@gamil.com', N'Mike123', N'18aa2698ce26db3479297111b7022f2e9c285428533a9c738854e7eaf6a9eed8')
SET IDENTITY_INSERT [dbo].[Shippers] OFF
GO
SET IDENTITY_INSERT [dbo].[Shippings] ON 

INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (1, 2008, 1, N'BR8111797', 5, CAST(N'2024-06-05T00:00:00.000' AS DateTime), CAST(N'2024-06-11T17:35:28.227' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (2, 3008, 1, N'WY4968004', 5, CAST(N'2024-06-14T00:00:00.000' AS DateTime), CAST(N'2024-06-12T12:58:05.333' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (3, 3013, 1, N'JV3248195', 5, CAST(N'2024-07-14T00:00:00.000' AS DateTime), CAST(N'2024-07-11T17:11:46.820' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (4, 4009, 1, N'ZT6725757', 5, CAST(N'2024-07-19T00:00:00.000' AS DateTime), CAST(N'2024-07-16T17:30:59.573' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (5, 4022, 1, N'JQ2143386', 6, CAST(N'2024-07-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (8, 4033, 1, N'XV6871255', 5, CAST(N'2024-07-25T00:00:00.000' AS DateTime), CAST(N'2024-07-22T11:07:11.320' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (9, 4032, 2, N'XJ1492829', 5, CAST(N'2024-07-25T00:00:00.000' AS DateTime), CAST(N'2024-07-22T12:07:01.220' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (11, 4035, 1, N'MJ0636998', 5, CAST(N'2024-07-29T00:00:00.000' AS DateTime), CAST(N'2024-07-26T00:34:46.803' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (12, 4038, 1, N'YJ7969472', 5, CAST(N'2024-07-31T00:00:00.000' AS DateTime), CAST(N'2024-07-28T01:16:20.830' AS DateTime))
INSERT [dbo].[Shippings] ([ShippingID], [OrderID], [CarrierID], [TrackingNumber], [ShippingStatus], [EstimatedDeliveryDate], [ActualDeliveryDate]) VALUES (13, 4051, 1, N'XQ3413526', 5, CAST(N'2024-08-01T00:00:00.000' AS DateTime), CAST(N'2024-07-29T11:06:43.963' AS DateTime))
SET IDENTITY_INSERT [dbo].[Shippings] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategory] ON 

INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (1, N'Tables', 2)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (2, N'Chairs', 2)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (2003, N'Desks', 2)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (3002, N'Laptops', 2002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (3003, N'Smart Phones', 2002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (4002, N'Men Clothes', 2003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (4003, N'Women Clothes', 2003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (4004, N'Children Clothes', 2003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5002, N'Cookware', 1003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5003, N'Ovens', 1003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5004, N'Stoves', 1003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5005, N'Refrigerators', 1003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5006, N'Couch', 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5007, N'Sofa', 1)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5008, N'TV', 2002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5009, N'Home made products', 4)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5010, N'Toys', 4002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5012, N'Flowers', 7)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5013, N'Curtains', 1002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5014, N'Accessories', 1002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5015, N'PlayStation', 2002)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5016, N'BackPack', 2003)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5018, N'Science', 4019)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5019, N'Entertainment', 4019)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5021, N'Self Improvement', 4019)
INSERT [dbo].[SubCategory] ([SubCategoryID], [SubCategoryName], [CategoryID]) VALUES (5023, N'Electric Board', 4024)
SET IDENTITY_INSERT [dbo].[SubCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (1, N'Asim Yasin', N'asim@gmail.com', N'2151626721', N'Egypt-Cairo', N'A123', N'88c263d7ba087c24932fa63d6364db5dd2ba2f9873d03bf4db37c203338a0d4e', 0, N'C:\BankPersons\Face3.jfif')
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (2, N'Asim', N'as@gmail.com', N'382994829', N'Dubai', N'O123', N'4e9036ea221b6acee54c7bf8b9a12f704ce4dad814ea5e998ff2921aaf86bae6', 1, NULL)
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (1002, N'Ali Maher', N'Ali@gmail.com', N'0118328328', N'Egypt-Cairo', N'Ali123', N'b27807a524e3b19040d1076355f4fb3dd752927064ab99742102be81d3b2354c', 0, N'C:\BankPersons\Face4.png')
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (2002, N'Ammar Ali', N'Ammar@gmail.com', N'23982389392', N'Egypt-Alex', N'Ammar1', N'2580ff95ad9569ad4b0d0c84feed17b5b6542909241fc730b32a1b2b428aa5e2', 0, N'C:\BankPersons\Face5.png')
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (2003, N'Aliaa', N'Aliaa@gmail.com', N'3292389109', N'UK-London', N'Aliaa123', N'500e51d40d21a14f57abb6406010d9896746b48b9d2b3031fb497337a751aa36', 0, N'C:\BankPersons\Face6.jpg')
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (2004, N'Tom', N'Tom@gmail.com', N'3921029107012', N'United States', N'Tom123', N'1f94d22bfc4ed5ce1f100ef22e7f187228908dff6e16870275825d3a3ead3756', 1, N'C:\BankPersons\Face5.png')
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (3010, N'Ramy', N'Ramy@gmail.com', N'329723089198', N'Egypt-Cairo', N'Ramy123', N'63033a593a3f731d82ad0e24e6a89d8f81fe9931e489cfe375d218f6f079ff1f', 1, N'')
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (3011, N'Basil', N'Basil@gmail.com', N'329364322893', N'USA-Virgina', N'Basil123', N'a935c2b6223434aad8b1d3f9b58ee36ae2e93c51d923a145d6d5e6d98cf0b14e', 1, NULL)
INSERT [dbo].[Users] ([UserID], [Name], [Email], [Phone], [Address], [Username], [Password], [IsOwner], [ImageURL]) VALUES (3012, N'Ammar', N'Ammar@gmail.com', N'3287362701820', N'Egypt-Cairo', N'Ammar123', N'63bb8c9486c76e0c4f58e03ddf841e5e1d200615576992f3a1d76115a0b2a926', 0, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WeeklySales] ON 

INSERT [dbo].[WeeklySales] ([WeeklySalesID], [Month], [Week1Sales], [Week2Sales], [Week3Sales], [Week4Sales]) VALUES (1, N'July', 8, 6, 10, 14)
INSERT [dbo].[WeeklySales] ([WeeklySalesID], [Month], [Week1Sales], [Week2Sales], [Week3Sales], [Week4Sales]) VALUES (3, N'July', 4, 6, 11, 15)
INSERT [dbo].[WeeklySales] ([WeeklySalesID], [Month], [Week1Sales], [Week2Sales], [Week3Sales], [Week4Sales]) VALUES (4, N'July', 10, 7, 18, 5)
SET IDENTITY_INSERT [dbo].[WeeklySales] OFF
GO
ALTER TABLE [dbo].[Favourites] ADD  CONSTRAINT [DF_Table_1_AddedToFavourit]  DEFAULT ((0)) FOR [AddedToFavourite]
GO
ALTER TABLE [dbo].[ProductImages] ADD  CONSTRAINT [DF_ProductImages_ImageOrder]  DEFAULT ((0)) FOR [ImageOrder]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_ProductCatalog] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductCatalog] ([ProductID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_ProductCatalog]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Order_Payment] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Order_Payment]
GO
ALTER TABLE [dbo].[ProductCatalog]  WITH CHECK ADD  CONSTRAINT [FK_Category_Product] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[ProductCatalog] CHECK CONSTRAINT [FK_Category_Product]
GO
ALTER TABLE [dbo].[ProductColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductColor_ProductCatalog] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductCatalog] ([ProductID])
GO
ALTER TABLE [dbo].[ProductColor] CHECK CONSTRAINT [FK_ProductColor_ProductCatalog]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_ProductCatalog] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductCatalog] ([ProductID])
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_ProductCatalog]
GO
ALTER TABLE [dbo].[ProductSize]  WITH CHECK ADD  CONSTRAINT [FK_ProductSize_ProductCatalog] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductCatalog] ([ProductID])
GO
ALTER TABLE [dbo].[ProductSize] CHECK CONSTRAINT [FK_ProductSize_ProductCatalog]
GO
ALTER TABLE [dbo].[Responses]  WITH CHECK ADD  CONSTRAINT [FK_Responses_Messages1] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Messages] ([MessageID])
GO
ALTER TABLE [dbo].[Responses] CHECK CONSTRAINT [FK_Responses_Messages1]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Review] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Customer_Review]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Product_Review] FOREIGN KEY([ProductID])
REFERENCES [dbo].[ProductCatalog] ([ProductID])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Product_Review]
GO
ALTER TABLE [dbo].[Shippings]  WITH CHECK ADD  CONSTRAINT [FK_Order_Shipping] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Shippings] CHECK CONSTRAINT [FK_Order_Shipping]
GO
ALTER TABLE [dbo].[Shippings]  WITH CHECK ADD  CONSTRAINT [FK_Shippings_Shippers] FOREIGN KEY([CarrierID])
REFERENCES [dbo].[Shippers] ([CarrierID])
GO
ALTER TABLE [dbo].[Shippings] CHECK CONSTRAINT [FK_Shippings_Shippers]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_ProductCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductCategory] ([CategoryID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_ProductCategory]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewCategory]
    @CategoryName nvarchar(100),
	@CategoryImage nvarchar(500),
    @NewCategoryID INT OUTPUT
AS
BEGIN
    INSERT INTO ProductCategory(CategoryName,CategoryImage)
    VALUES   (@CategoryName,@CategoryImage);

    SET @NewCategoryID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewChartData]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewChartData]
 --   @Month nvarchar(50),
	--@TotalOrders int,
	--@TotalVisitors int,
	--@TotalRevenue float,
AS
BEGIN
    INSERT INTO ChartData(Month,TotalOrders,TotalVisitors,TotalMonthSales)
    VALUES  ((SELECT DATENAME(month, GETDATE())),(Select Count(*)from Orders where Month(OrderDate)=Month(SYSDATETIME())),
	(select Count(NewCustomerID)from NotificationOwner where Month(DateTime)= Month(SYSDATETIME())),
	(select Count(*) from Payments where Month(TransactionDate)= Month(SYSDATETIME())));
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewMessage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewMessage]
	@CustomerID int,
	@Message nvarchar(500),
	@DateTime datetime,
	@NewMessageID int output
AS
BEGIN
    INSERT INTO Messages(CustomerID ,Message,DateTime)
    VALUES   (@CustomerID,@Message,@DateTime);
	set @NewMessageID =  SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewOrder]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SP_AddNewOrder]
@CustomerID int,
@OrderDate datetime,
@TotalAmount smallmoney,
@Status smallint,
    @NewOrderID INT OUTPUT
AS
BEGIN
    INSERT INTO Orders(CustomerID,OrderDate,TotalAmount,Status)
    VALUES   (@CustomerID,@OrderDate,@TotalAmount,@Status);

    SET @NewOrderID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewOrderItem]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddNewOrderItem]
@OrderID int,
@ProductID int,
@Quantity int,
@Size nvarchar(10),
@Color nvarchar(50),
@Price decimal,
@TotalItemsPrice decimal
As BEGIN
    INSERT INTO OrderItems(OrderID,ProductID,Quantity,Size,Color,Price,TotalItemsPrice)
    VALUES   (@OrderID,@ProductID,@Quantity,@Size,@Color,@Price,@TotalItemsPrice);

END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewPayment]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_AddNewPayment]
@OrderID int,
@Amount smallmoney,
@PaymentMethod nvarchar(50),
@TransactionDate DateTime,
   @NewPaymentID INT OUTPUT
AS
BEGIN
    INSERT INTO Payments(OrderID,Amount,PaymentMethod,TransactionDate)
    VALUES   (@OrderID,@Amount,@PaymentMethod,@TransactionDate);

    SET @NewPaymentID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewProductCatalog]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewProductCatalog]
@ProductName nvarchar(100),
@Description nvarchar(100),
@LongDescription nvarchar(500),
@Price smallmoney,
@QuantityInStock int,
@CategoryID int,
@SubCategoryID int,
@ImageURL nvarchar(200),
@VideoURL nvarchar(200),
@Discount int,
    @NewProductID INT OUTPUT
AS
BEGIN
    INSERT INTO ProductCatalog(ProductName,Description,LongDescription,Price,QuantityInStock,ImageURL,VideoURL,CategoryID,SubCategoryID,Discount)
    VALUES   (@ProductName,@Description,@LongDescription,@Price,@QuantityInStock,@ImageURL,@VideoURL,@CategoryID,@SubCategoryID,@Discount);

    SET @NewProductID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewProductColor]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewProductColor]
    @Color nvarchar(100),
	@ProductID int,
    @NewColorID INT OUTPUT
AS
BEGIN
    INSERT INTO ProductColor(Color,ProductID)
    VALUES   (@Color,@ProductID);

    SET @NewColorID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewProductImage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewProductImage]
    @ImageUrl nvarchar(200),
	@ImageOrder smallint,
	@ProductID int,
    @NewImageID INT OUTPUT
AS
BEGIN
    INSERT INTO ProductImages(ImageURL,ImageOrder,ProductID)
    VALUES   (@ImageUrl,@ImageOrder,@ProductID);

    SET @NewImageID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewProductSize]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewProductSize]
    @Size nvarchar(100),
	@ProductID int,
    @NewSizeID INT OUTPUT
AS
BEGIN
    INSERT INTO ProductSize(Size,ProductID)
    VALUES   (@Size,@ProductID);

    SET @NewSizeID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewResponse]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewResponse]
	@OwnerID int,
	@Name nvarchar(100),
	@Response nvarchar(500),
	@MessageID int,
	@Datetime datetime,
	@CustomerID int,
    @NewResponseID INT OUTPUT
AS
BEGIN
    INSERT INTO Responses(OwnerID ,Name,Response,MessageID,DateTime,CustomerID)
    VALUES   (@OwnerID,@Name,@Response,@MessageID,@Datetime,@CustomerID);

    SET @NewResponseID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewReview]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewReview]
    @ProductID int,
	@CustomerID int,
	@ReviewText nvarchar(500),
	@Rating decimal(2,1),
	@ReviewDate Datetime,
    @NewReviewID INT OUTPUT
AS
BEGIN
    INSERT INTO Reviews(ProductID,CustomerID,ReviewText,Rating,ReviewDate)
    VALUES   (@ProductID,@CustomerID,@ReviewText,@Rating,@ReviewDate);

    SET @NewReviewID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewShipper]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewShipper]
    @CarrierName nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(20),
	@UserName nvarchar (100),
	@Password nvarchar (100),
    @NewCarrierID INT OUTPUT
AS
BEGIN
    INSERT INTO Shippers(CarrierName ,Email,Phone,UserName,Password)
    VALUES   (@CarrierName,@Email,@Phone,@UserName,@Password);

    SET @NewCarrierID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewShipping]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewShipping]
    @OrderID int,
	@CarrierID int,
	@TrackingNumber nvarchar(100),
	@ShippingStatus smallint,
	@EstimatedDeliveryDate Date,
	@ActualDeliveryDate Date =null,
    @NewShippingID INT OUTPUT
AS
BEGIN
    INSERT INTO Shippings(OrderID ,CarrierID,TrackingNumber,ShippingStatus,EstimatedDeliveryDate,ActualDeliveryDate)
    VALUES   (@OrderID,@CarrierID,@TrackingNumber,@ShippingStatus,@EstimatedDeliveryDate,@ActualDeliveryDate);

    SET @NewShippingID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewSubCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddNewSubCategory]
    @SubCategoryName nvarchar(100),
	@CategoryID int,
    @NewSubCategoryID INT OUTPUT
AS
BEGIN
    INSERT INTO SubCategory(SubCategoryName,CategoryID)
    VALUES   (@SubCategoryName,@CategoryID);

    SET @NewSubCategoryID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewUser]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewUser]
    @Name nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(20),
	@Address nvarchar(200),
	@UserName nvarchar (100),
	@Password nvarchar (100),
	@IsOwner bit,
	@ImageURL nvarchar(200),
    @NewUserID INT OUTPUT
AS
BEGIN
    INSERT INTO Users(Name ,Email,Phone,Address,UserName,Password,IsOwner,ImageURL)
    VALUES   (@Name,@Email,@Phone,@Address,@UserName,@Password,@IsOwner,@ImageURL);

    SET @NewUserID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddNewWeeklySales]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddNewWeeklySales]
 --   @Month nvarchar(50),
	--@TotalOrders int,
	--@TotalVisitors int,
	--@TotalRevenue float,
AS
BEGIN
    INSERT INTO WeeklySales(Month,Week1Sales,Week2Sales,Week3Sales,Week4Sales)
    VALUES  ((SELECT DATENAME(month, GETDATE())),(SELECT 
    COUNT(*) FROM Payments WHERE
    MONTH(TransactionDate) = MONTH(GETDATE()) and DAY(TransactionDate) <=7) ,
	(SELECT 
    COUNT(*) FROM Payments WHERE
    MONTH(TransactionDate) = MONTH(GETDATE()) and DAY(TransactionDate) <=14 ),
	(SELECT 
    COUNT(*) FROM Payments WHERE
    MONTH(TransactionDate) = MONTH(GETDATE()) and DAY(TransactionDate) <=21 ),
	(SELECT 
    COUNT(*) FROM Payments WHERE
    MONTH(TransactionDate) = MONTH(GETDATE()) and DAY(TransactionDate) > 21 ));
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddToFavourit]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddToFavourit]
@ProductID int,
@CustomerID int
AS
BEGIN
   INSERT INTO Favourites (CustomerID, ProductID, AddedToFavourite)
SELECT @CustomerID, @ProductID, 1
WHERE NOT EXISTS (
    SELECT 1 FROM Favourites WHERE ProductID = @ProductID
);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckCategoryExist]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CheckCategoryExist]
    @CategoryName nvarchar(100)
AS
BEGIN
    IF EXISTS(SELECT Found=1 FROM ProductCategory WHERE CategoryName = @CategoryName)
        RETURN 1;  
    ELSE
        RETURN 0;  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckShipperExist]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CheckShipperExist]
    @UserName nvarchar(100)
AS
BEGIN
    IF EXISTS(SELECT Found=1 FROM Shippers WHERE Username = @UserName)
        RETURN 1;  
    ELSE
        RETURN 0;  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckSubCategoryExist]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CheckSubCategoryExist]
    @SubCategoryName nvarchar(100)
AS
BEGIN
    IF EXISTS(SELECT Found=1 FROM SubCategory WHERE SubCategoryName = @SubCategoryName)
        RETURN 1;  
    ELSE
        RETURN 0;  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckUserExist]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CheckUserExist]
    @UserName nvarchar(100)
AS
BEGIN
    IF EXISTS(SELECT Found=1 FROM Users WHERE Username = @UserName)
        RETURN 1;  
    ELSE
        RETURN 0;  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CompleteAllOrders]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_CompleteAllOrders]
AS
BEGIN
	Update ProcessingOrders
	set Status = 2;
  insert into CompeleteOrders(OrderID,CustomerID,OrderDate,TotalAmount,Status)
  select OrderID,CustomerID,OrderDate,TotalAmount,Status from ProcessingOrders;
  truncate table ProcessingOrders;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteCategory]
@CategoryID int
AS
BEGIN
  Delete SubCategory where CategoryID = @CategoryID;
  Delete ProductCategory where CategoryID = @CategoryID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCompleteOrder]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_DeleteCompleteOrder]
@OrderID int
AS
BEGIN
  Delete CompeleteOrders where OrderID = @OrderID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteMessage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteMessage]
@MessageID int
AS
BEGIN
  Delete Messages where MessageID = @MessageID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteOrder]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteOrder]
@OrderID int
AS
BEGIN
  Delete Orders where OrderID = @OrderID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteOrderItem]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteOrderItem]
@ProductID int
AS
BEGIN
  Delete OrderItems where ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePayment]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeletePayment]
@PaymentID int
AS
BEGIN
  Delete Payments where PaymentID = @PaymentID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePendingOrder]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_DeletePendingOrder]
@OrderID int
AS
BEGIN
  Delete PendingOrders where OrderID = @OrderID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteProcessingOrder]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_DeleteProcessingOrder]
@OrderID int
AS
BEGIN
  Delete ProcessingOrders where OrderID = @OrderID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteProductCatalog]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteProductCatalog]
@ProductID int
AS
BEGIN
  Delete ProductCatalog where ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteProductImage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteProductImage]
@ID int
AS
BEGIN
  Delete ProductImages where ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteResponse]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteResponse]
@ResponseID int
AS
BEGIN
  Delete Responses where ResponseID = @ResponseID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteShipper]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteShipper]
@CarrierID int
AS
BEGIN
  Delete Shippers where CarrierID = @CarrierID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteShipping]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteShipping]
@ShippingID int
AS
BEGIN
  Delete Shippings where ShippingID = @ShippingID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteSubCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteSubCategory]
@SubCategoryID int
AS
BEGIN
  Delete SubCategory where SubCategoryID = @SubCategoryID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteUser]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteUser]
@UserID int
AS
BEGIN
  Delete Users where UserID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindCategoryByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindCategoryByID]
	@CategoryID int
AS
BEGIN
    select * from ProductCategory where CategoryID = @CategoryID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindCategoryByName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindCategoryByName]
	@CategoryName nvarchar(100)
AS
BEGIN
    select * from ProductCategory where CategoryName = @CategoryName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindCustomerNotificationByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindCustomerNotificationByID]
@NotificationID int
AS
BEGIN
    select * from NotificationCustomer where NotificationID = @NotificationID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindMessageByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindMessageByID]
	@MessageID int
AS
BEGIN
    select * from Messages where MessageID = @MessageID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindOrderByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindOrderByID]
@OrderID int
AS
BEGIN
    select * from Orders where OrderID = @OrderID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindOrderItemByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_FindOrderItemByID]
@OrderID int,
@ProductID int
AS
BEGIN
    select * from OrderItems where OrderID = @OrderID and ProductID =@ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindOwnerNotificationByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindOwnerNotificationByID]
@NotificationID int
AS
BEGIN
    select * from NotificationOwner where NoticficationID = @NotificationID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindPaymentByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindPaymentByID]
@PaymentID int
AS
BEGIN
    select * from Payments where PaymentID = @PaymentID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindProductCatalogByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindProductCatalogByID]
@ProductID int
AS
BEGIN
    select * from ProductCatalog where ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindProductCatalogByName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindProductCatalogByName]
@ProductName nvarchar(100)
AS
BEGIN
    select * from ProductCatalog where ProductName = @ProductName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindProductColorByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindProductColorByID]
	@ProductID int
AS
BEGIN
    select * from ProductColor where ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindProductImageByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_FindProductImageByID]
	@ID int
AS
BEGIN
    select * from ProductImages where ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindProductSizeByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_FindProductSizeByID]
	@ProductID int
AS
BEGIN
    select * from ProductSize where ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindResponseByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindResponseByID]
	@ResponseID int
AS
BEGIN
    select * from Responses where ResponseID = @ResponseID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindReviewByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindReviewByID]
	@ReviewID int
AS
BEGIN
    select * from Reviews where ReviewID = @ReviewID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindShipperByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindShipperByID]
	@CarrierID int
AS
BEGIN
    select * from Shippers where CarrierID = @CarrierID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindShipperByName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindShipperByName]
	@CarrierName nvarchar(100)
AS
BEGIN
    select * from Shippers where CarrierName = @CarrierName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindShipperByUserName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindShipperByUserName]
	@UserName nvarchar(100)
AS
BEGIN
    select * from Shippers where UserName = @UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindShipperByUserNamePassword]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindShipperByUserNamePassword]
	@UserName nvarchar (100),
	@Password nvarchar (100)
AS
BEGIN
    select * from Shippers where UserName = @UserName and Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindShippingByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindShippingByID]
	@ShippingID int
AS
BEGIN
    select * from Shippings where ShippingID = @ShippingID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindShippingByTrackingNumber]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_FindShippingByTrackingNumber]
	@TrackingNumber nvarchar(100)
AS
BEGIN
    select * from Shippings where TrackingNumber = @TrackingNumber;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindSubCategoryByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindSubCategoryByID]
	@SubCategoryID int
AS
BEGIN
    select * from SubCategory where SubCategoryID = @SubCategoryID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindSubCategoryByName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindSubCategoryByName]
	@SubCategoryName nvarchar(100)
AS
BEGIN
    select * from SubCategory where SubCategoryName = @SubCategoryName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindUserByID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindUserByID]
	@UserID int
AS
BEGIN
    select * from Users where UserID = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindUserByUserName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindUserByUserName]
	@UserName nvarchar(100)
AS
BEGIN
    select * from Users where Username = @UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindUserByUserNamePassword]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindUserByUserNamePassword]
	@UserName nvarchar (100),
	@Password nvarchar (100)
AS
BEGIN
    select * from Users where UserName = @UserName and Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCategories]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCategories]
AS
BEGIN
   select * from ProductCategory
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCompeleteOrders]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCompeleteOrders]
AS
BEGIN
     select OrderID,Name,Email,Phone,Address,OrderDate,TotalAmount,
   Case
   when Status =1 then 'Pending'
   when Status =2 then 'Processing'
   when Status =3 then 'Compelete'
   when Status =4 then 'Shipped'
   when Status =5 then 'Deliverd'
   else 'Canceled'
   end as OrderStatus from CompeleteOrders
   inner join Users on Users.UserID = CompeleteOrders.CustomerID order by OrderDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCustomerNotifications]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCustomerNotifications]
AS
BEGIN
   select * from NotificationCustomer order by NotificationID desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDeliveredShippingsForCarrierID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllDeliveredShippingsForCarrierID]
@CarrierID int
AS
BEGIN
   select * from Shippings where CarrierID = @CarrierID and ShippingStatus = 5;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllFavouritesForCustomerID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_GetAllFavouritesForCustomerID]
@CustomerID int
AS
BEGIN
   select * from Favourites where AddedToFavourite =1 and CustomerID = @CustomerID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMessages]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_GetAllMessages]
AS
BEGIN
   select * from Messages order by DateTime desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMessagesForCustomerID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_GetAllMessagesForCustomerID]
@CustomerID int
AS
BEGIN
   select * from Messages where CustomerID=@CustomerID order by DateTime desc;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllOrderItemsByOrderID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllOrderItemsByOrderID]
@OrderID int
AS
BEGIN
   select OrderID,ProductName,Quantity,ProductCatalog.Price,TotalItemsPrice from OrderItems
   inner join ProductCatalog on ProductCatalog.ProductID = OrderItems.ProductID 
   where OrderID =@OrderID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllOrders]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllOrders]
AS
BEGIN
   select OrderID,Name,Email,Phone,Address,OrderDate,TotalAmount,
   Case
   when Status =1 then 'Pending'
   when Status =2 then 'Processing'
   when Status =3 then 'Compelete'
   when Status =4 then 'Shipped'
   when Status =5 then 'Deliverd'
   else 'Canceled'
   end as OrderStatus from Orders
   inner join Users on Users.UserID =Orders.CustomerID order by OrderDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllOrdersForCustomerID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_GetAllOrdersForCustomerID]
@CustomerID int
AS
BEGIN
   select * from Orders where CustomerID = @CustomerID order by OrderDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllOwnerNotifications]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllOwnerNotifications]
AS
BEGIN
   select * from NotificationOwner order by NoticficationID desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllOwners]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllOwners]
AS
BEGIN
   select UserID,Name,Email,Phone,Address,Username from Users where IsOwner =1;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllPendingOrders]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllPendingOrders]
AS
BEGIN
    select OrderID,Name,Email,Phone,Address,OrderDate,TotalAmount,
   Case
   when Status =1 then 'Pending'
   when Status =2 then 'Processing'
   when Status =3 then 'Compelete'
   when Status =4 then 'Shipped'
   when Status =5 then 'Deliverd'
   else 'Canceled'
   end as OrderStatus from PendingOrders
   inner join Users on Users.UserID = PendingOrders.CustomerID order by OrderDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllProcessingOrders]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllProcessingOrders]
AS
BEGIN
     select OrderID,Name,Email,Phone,Address,OrderDate,TotalAmount,
   Case
   when Status =1 then 'Pending'
   when Status =2 then 'Processing'
   when Status =3 then 'Compelete'
   when Status =4 then 'Shipped'
   when Status =5 then 'Deliverd'
   else 'Canceled'
   end as OrderStatus from ProcessingOrders
   inner join Users on Users.UserID = ProcessingOrders.CustomerID order by OrderDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllProductColors]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllProductColors]
@ProductID int
AS
BEGIN
   select Color from ProductColor where ProductID = @ProductID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllProducts]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_GetAllProducts]
AS
BEGIN
   select * from ProductCatalog order by newID();
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllProductSizes]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllProductSizes]
@ProductID int
AS
BEGIN
   select Size from ProductSize where ProductID = @ProductID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllReviews]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllReviews]
AS
BEGIN
   select * from Reviews order by ReviewDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllReviewsForCustomerID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllReviewsForCustomerID]
@CustomerID int
AS
BEGIN
   select * from Reviews where CustomerID=@CustomerID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllReviewsForProductID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllReviewsForProductID]
@ProductID int
AS
BEGIN
   select * from Reviews where ProductID = @ProductID order by ReviewDate desc;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllShippersData]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllShippersData]
AS
BEGIN
   select CarrierID,CarrierName,Phone,Email,UserName from Shippers;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllShippersName]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllShippersName]
AS
BEGIN
   select CarrierName from Shippers
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllShippings]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_GetAllShippings]
AS
BEGIN
   select * from Shippings;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllShippingsForCarrierID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllShippingsForCarrierID]
@CarrierID int
AS
BEGIN
   select * from Shippings where CarrierID = @CarrierID and ShippingStatus = 1;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllSubCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllSubCategory]
@CategoryID int
AS
BEGIN
   select * from SubCategory where CategoryID = @CategoryID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetChartData]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetChartData]
AS
BEGIN
   select * from ChartData;
   --where Month = (Select DATENAME(month, GETDATE()));
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCurrentYearTotalRevenue]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCurrentYearTotalRevenue]
AS
BEGIN
    select Sum(TotalRevenue) as TotalRevenue from SalesReport where Year = YEAR(GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCurrentYearTotalSales]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCurrentYearTotalSales]
AS
BEGIN
    select Sum(TotalSales) as TotalSales from SalesReport where Year = YEAR(GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCustomersCount]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCustomersCount]
AS
BEGIN
   select Count(*) from Users where IsOwner = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetMostSoldProduct]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_GetMostSoldProduct]
@From Date,
@To Date
AS
BEGIN
  Select Top 3 ProductCatalog.ProductID,ProductName, COUNT(*) AS Frequency from Payments inner join Orders On Payments.OrderID = Orders.OrderID 
  inner join OrderItems On Orders.OrderID = OrderItems.OrderID 
  inner join ProductCatalog On OrderItems.ProductID = ProductCatalog.ProductID Where TransactionDate Between @From AND @To
  GROUP BY ProductName,ProductCatalog.ProductID
ORDER BY Frequency DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductImagesByProductID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductImagesByProductID]
	@ProductID int
AS
BEGIN
    select * from ProductImages where ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductPerPage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductPerPage]
@PageNumber int
AS
BEGIN
	DECLARE @RowsPerPage AS INT;
SET @RowsPerPage = 8;
    select * from ProductCatalog Order by ProductID OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
    FETCH NEXT @RowsPerPage ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductPerPageForCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductPerPageForCategory]
@PageNumber int,
@CategoryID int
AS
BEGIN
	DECLARE @RowsPerPage AS INT;
SET @RowsPerPage = 8;
    select * from ProductCatalog where CategoryID = @CategoryID Order by ProductID OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
    FETCH NEXT @RowsPerPage ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductPerPageForSubCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductPerPageForSubCategory]
@PageNumber int,
@SubCategoryID int
AS
BEGIN
	DECLARE @RowsPerPage AS INT;
SET @RowsPerPage = 8;
    select * from ProductCatalog where SubCategoryID = @SubCategoryID Order by ProductID OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
    FETCH NEXT @RowsPerPage ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductsForCategoryID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductsForCategoryID]
@CategoryID int
AS
BEGIN
   select * from ProductCatalog where CategoryID=@CategoryID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductsForSubCategoryID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductsForSubCategoryID]
@SubCategoryID int
AS
BEGIN
   select * from ProductCatalog where SubCategoryID=@SubCategoryID;
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetResponseForCustomerID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_GetResponseForCustomerID]
	@CustomerID int
AS
BEGIN
    select * from Responses where CustomerID = @CustomerID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSalesReportData]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetSalesReportData]
AS
BEGIN
  SELECT 
      [Month]
      ,[Year]
      ,[TotalSales]
      ,[TotalRevenue]
  FROM [Online_Store].[dbo].[SalesReport];
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalPage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTotalPage]
AS
BEGIN
    select Ceiling(Cast(Count(*) as float)/8) from ProductCatalog;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalPageForCategoryID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTotalPageForCategoryID]
@CategoryID int
AS
BEGIN
    select Ceiling(Cast(Count(*) as float)/8) from ProductCatalog Where CategoryID =@CategoryID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalPageForSubCategoryID]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTotalPageForSubCategoryID]
@SubCategoryID int
AS
BEGIN
    select Ceiling(Cast(Count(*) as float)/8) from ProductCatalog Where SubCategoryID =@SubCategoryID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalRevenue]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetTotalRevenue]
AS
BEGIN
    select Sum(Amount) from Payments;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetWeeklySales]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetWeeklySales]
AS
BEGIN
   select Top 1* from WeeklySales order By WeeklySalesID Desc;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsProductAddedToFavourite]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IsProductAddedToFavourite]
@ProductID int,
@CustomerID int
AS
BEGIN
   select AddedToFavourite from Favourites where CustomerID =@CustomerID and ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ProcessAllOrders]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ProcessAllOrders]
AS
BEGIN
	Update PendingOrders
	set Status = 2;
  insert into ProcessingOrders(OrderID,CustomerID,OrderDate,TotalAmount,Status)
  select OrderID,CustomerID,OrderDate,TotalAmount,Status from PendingOrders;
  truncate table PendingOrders;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveFromFavourit]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RemoveFromFavourit]
@ProductID int,
@CustomerID int
AS
BEGIN
     delete from Favourites where CustomerID = @CustomerID and ProductID = @ProductID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCategory]
@CategoryID int,
@CategoryName nvarchar(100),
@CategoryImage nvarchar(500)
AS
BEGIN
    UPDATE ProductCategory
     SET CategoryName = @CategoryName
	    ,CategoryImage = @CategoryImage
        WHERE CategoryID = @CategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateMesaage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateMesaage]
@MessageID int,
@Message nvarchar(500)
AS
BEGIN
    UPDATE Messages
     SET Message = @Message
        WHERE MessageID = @MessageID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateOrder]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateOrder]
@OrderID int,
@CustomerID int,
@OrderDate datetime,
@TotalAmount smallmoney,
@Status smallint

AS
BEGIN
    UPDATE Orders
     SET CustomerID = @CustomerID
	    ,OrderDate = @OrderDate
		,TotalAmount = @TotalAmount
		,Status = @Status
        WHERE OrderID = @OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateOrderItem]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateOrderItem]
@OrderID int,
@ProductID int,
@Quantity int,
@Size nvarchar(10),
@Color nvarchar(50),
@Price decimal,
@TotalItemsPrice decimal

AS
BEGIN
    UPDATE OrderItems
     SET Quantity = @Quantity
	    ,Size = @Size
		,Color = @Color
		,Price = @Price
		,TotalItemsPrice = @TotalItemsPrice
        WHERE OrderID = @OrderID and ProductID = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateOrderStatus]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateOrderStatus]
@OrderID int,
@Status smallint

AS
BEGIN
    UPDATE Orders
     SET Status = @Status
        WHERE OrderID = @OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePayment]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdatePayment]
@PaymentID int,
@OrderID int,
@Amount smallmoney,
@PaymentMethod nvarchar(50),
@TransactionDate DateTime
AS
BEGIN
    UPDATE Payments
     SET OrderID = @OrderID
	    ,Amount = @Amount
		,PaymentMethod = @PaymentMethod
		,TransactionDate = @TransactionDate
        WHERE PaymentID = @PaymentID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePendingOrderStatus]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdatePendingOrderStatus]
@OrderID int,
@Status smallint

AS
BEGIN
    UPDATE PendingOrders
     SET Status = @Status
        WHERE OrderID = @OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProcessingOrderStatus]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateProcessingOrderStatus]
@OrderID int,
@Status smallint

AS
BEGIN
    UPDATE ProcessingOrders
     SET Status = @Status
        WHERE OrderID = @OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProductCatalog]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateProductCatalog]
@ProductID int,
@ProductName nvarchar(100),
@Description nvarchar(100),
@LongDescription nvarchar(500),
@Price smallmoney,
@QuantityInStock int,
@CategoryID int,
@SubCategoryID int,
@ImageURL nvarchar(200),
@VideoURL nvarchar(200),
@Discount int
AS
BEGIN
    UPDATE ProductCatalog
     SET ProductName = @ProductName
	    ,Description = @Description
		,LongDescription = @LongDescription
		,Price = @Price
		,QuantityInStock = @QuantityInStock
		,ImageURL = @ImageURL
		,VideoURL = @VideoURL
		,CategoryID = @CategoryID
		,SubCategoryID = @SubCategoryID
		,Discount = @Discount
        WHERE ProductID = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProductColor]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateProductColor]
@Color nvarchar(100),
@ProductID int
AS
BEGIN
    UPDATE ProductColor
     SET Color = @Color
        WHERE ProductID = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProductImage]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateProductImage]
    @ID int,
    @ImageUrl nvarchar(200),
	@ImageOrder smallint,
	@ProductID int
AS
BEGIN
    UPDATE ProductImages
     SET ImageURL = @ImageUrl
	    ,ImageOrder = @ImageOrder
		,ProductID = @ProductID
        WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateProductSize]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateProductSize]
@Size nvarchar(100),
@ProductID int
AS
BEGIN
    UPDATE ProductSize
     SET Size = @Size
        WHERE ProductID = @ProductID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateResponse]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateResponse]
@ResponseID int,
@Response nvarchar(500)
AS
BEGIN
    UPDATE Responses
     SET Response = @Response
        WHERE ResponseID = @ResponseID;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateShipper]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateShipper]
    @CarrierID int,
	@CarrierName nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(20),
	@UserName nvarchar (100),
	@Password nvarchar (100)
AS
BEGIN
    UPDATE Shippers
     SET CarrierName = @CarrierName
	    ,Email = @Email
		,Phone = @Phone
		,UserName = @UserName
		,Password = @Password
        WHERE CarrierID = @CarrierID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateShipping]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateShipping]
    @ShippingID int,
    @OrderID int,
	@CarrierID int,
	@TrackingNumber nvarchar(100),
	@ShippingStatus smallint,
	@EstimatedDeliveryDate DateTime,
	@ActualDeliveryDate DateTime =null
AS
BEGIN
    UPDATE Shippings
     SET OrderID = @OrderID
	    ,CarrierID = @CarrierID
		,TrackingNumber = @TrackingNumber
		,ShippingStatus = @ShippingStatus
		,EstimatedDeliveryDate = @EstimatedDeliveryDate
		,ActualDeliveryDate = @ActualDeliveryDate
        WHERE ShippingID = @ShippingID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateSubCategory]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateSubCategory]
@SubCategoryID int,
@SubCategoryName int,
@CategoryID nvarchar(500)
AS
BEGIN
    UPDATE SubCategory
     SET SubCategoryName = @SubCategoryName
	    ,CategoryID = @CategoryID
        WHERE SubCategoryID = @SubCategoryID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateUser]    Script Date: 8/3/2024 12:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateUser]
    @UserID int,
	@Name nvarchar(100),
	@Email nvarchar(100),
	@Phone nvarchar(20),
	@Address nvarchar(200),
	@UserName nvarchar (100),
	@Password nvarchar (100),
	@IsOwner bit,
	@ImageURL nvarchar(200)
AS
BEGIN
    UPDATE Users
     SET Name = @Name
	    ,Email = @Email
		,Phone = @Phone
		,Address = @Address
		,UserName = @UserName
		,Password = @Password
		,IsOwner = @IsOwner
		,ImageURL = @ImageURL
        WHERE UserID = @UserID
END
GO
USE [master]
GO
ALTER DATABASE [Online_Store] SET  READ_WRITE 
GO
