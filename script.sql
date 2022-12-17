USE [DataFashion]
GO
/****** Object:  Database [DataFashion]    Script Date: 4/13/2022 8:32:32 PM ******/
CREATE DATABASE [DataFashion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DataFashion', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.CRRTTZ\MSSQL\DATA\DataFashion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DataFashion_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.CRRTTZ\MSSQL\DATA\DataFashion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DataFashion] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataFashion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataFashion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DataFashion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DataFashion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DataFashion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DataFashion] SET ARITHABORT OFF 
GO
ALTER DATABASE [DataFashion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DataFashion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DataFashion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DataFashion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DataFashion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DataFashion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DataFashion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DataFashion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DataFashion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DataFashion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DataFashion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DataFashion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DataFashion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DataFashion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DataFashion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DataFashion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DataFashion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DataFashion] SET RECOVERY FULL 
GO
ALTER DATABASE [DataFashion] SET  MULTI_USER 
GO
ALTER DATABASE [DataFashion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DataFashion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DataFashion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DataFashion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DataFashion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DataFashion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataFashion', N'ON'
GO
ALTER DATABASE [DataFashion] SET QUERY_STORE = OFF
GO
USE [DataFashion]
GO
/****** Object:  Table [dbo].[brand]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tilte] [nvarchar](255) NULL,
 CONSTRAINT [PK_brand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credentials]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credentials](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [nvarchar](50) NULL,
	[PermissionID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donation]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[description] [nchar](50) NOT NULL,
	[phone] [nchar](50) NOT NULL,
	[organizationName] [nchar](50) NOT NULL,
	[imageUrl] [nchar](50) NOT NULL,
	[startDay] [date] NOT NULL,
	[endDay] [date] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_donation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [nvarchar](50) NOT NULL,
	[user_id] [int] NOT NULL,
	[total_price] [float] NOT NULL,
	[create_at] [datetime] NOT NULL,
	[voucher_id] [int] NULL,
	[status] [int] NULL,
	[note] [nvarchar](200) NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_details]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[order_id] [int] NULL,
	[quantity] [int] NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_order_detalis] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[id] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_code] [nvarchar](50) NOT NULL,
	[product_name] [nvarchar](255) NOT NULL,
	[product_type] [int] NOT NULL,
	[product_color] [int] NOT NULL,
	[product_quantity] [int] NOT NULL,
	[product_brand] [int] NOT NULL,
	[product_image] [nvarchar](max) NOT NULL,
	[product_size] [int] NOT NULL,
	[product_description] [nvarchar](max) NOT NULL,
	[out_price] [float] NOT NULL,
	[status] [int] NOT NULL,
	[product_spec] [nvarchar](max) NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tilte] [nvarchar](255) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[fullname] [nvarchar](255) NOT NULL,
	[phone] [nvarchar](10) NULL,
	[address] [nvarchar](255) NULL,
	[status] [int] NOT NULL,
	[RoleID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_donation]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_donation](
	[user_id] [int] NOT NULL,
	[donation_id] [int] NOT NULL,
	[name] [nchar](50) NULL,
	[money] [float] NULL,
	[createAt] [datetime] NULL,
	[status] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[voucher]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[voucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[voucher_code] [nvarchar](255) NULL,
	[voucher_discount] [float] NULL,
	[voucher_description] [nvarchar](255) NULL,
	[create_at] [date] NULL,
	[delete_at] [date] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_voucher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[warehouse]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[warehouse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[import_code] [nvarchar](255) NOT NULL,
	[user_id] [int] NULL,
	[date_in] [datetime] NULL,
 CONSTRAINT [PK_warehouse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[warehouse_detail]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[warehouse_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[in_price] [float] NULL,
	[quantity] [int] NOT NULL,
	[total_price] [float] NOT NULL,
	[date_in] [date] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_warehouse_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[brand] ON 

INSERT [dbo].[brand] ([id], [tilte]) VALUES (1, N'DELL')
INSERT [dbo].[brand] ([id], [tilte]) VALUES (2, N'HP')
INSERT [dbo].[brand] ([id], [tilte]) VALUES (3, N'Asus')
INSERT [dbo].[brand] ([id], [tilte]) VALUES (4, N'Apple')
SET IDENTITY_INSERT [dbo].[brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([id], [title]) VALUES (1, N'Red')
INSERT [dbo].[Color] ([id], [title]) VALUES (2, N'Black')
INSERT [dbo].[Color] ([id], [title]) VALUES (3, N'White')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (2, N'1', 1, 23790000, CAST(N'2022-04-06T17:44:22.023' AS DateTime), NULL, 6, NULL)
INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (3, N'e@g&P', 1, 23790000, CAST(N'2022-04-06T17:44:33.633' AS DateTime), NULL, 5, N'')
INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (4, N'wU39W', 1, 23790000, CAST(N'2022-04-06T17:47:41.560' AS DateTime), NULL, 2, N'')
INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (5, N'i2n$2', 1, 23790000, CAST(N'2022-04-06T17:51:32.110' AS DateTime), NULL, 2, N'')
INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (6, N'7hD@q', 1, 11895061.5, CAST(N'2022-04-06T17:53:27.893' AS DateTime), 1, 5, N'')
INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (7, N'z8MMz', 1, 11895000, CAST(N'2022-04-06T18:10:01.773' AS DateTime), 1, 2, N'')
INSERT [dbo].[order] ([id], [order_id], [user_id], [total_price], [create_at], [voucher_id], [status], [note]) VALUES (8, N'Msi02', 1, 92929.6875, CAST(N'2022-04-06T18:27:28.570' AS DateTime), 1, 2, N'')
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[order_details] ON 

INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (2, 10, 2, 1, 23790000)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (3, 10, 3, 1, 23790000)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (4, 10, 4, 1, 23790000)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (5, 10, 5, 1, 23790000)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (6, 10, 6, 1, 23790000)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (7, 13, 6, 1, 123)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (8, 10, 7, 1, 23790000)
INSERT [dbo].[order_details] ([id], [product_id], [order_id], [quantity], [price]) VALUES (9, 10, 8, 1, 23790000)
SET IDENTITY_INSERT [dbo].[order_details] OFF
GO
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'CREATE_BRAND', N'tao moi hang')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'CREATE_COLORS', N'Tao mau')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'CREATE_ORDERDETAILS', N'Tao moi Order details')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'CREATE_PRODUCT', N'tao mo')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'CREATE_SIZES', N'tao size')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'CREATE_TYPES', N'tao type')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_BRAND', N'Xoa Hang')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_COLORS', N'Xoa mau')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_ORDERDETAILS', N'Xoa order details')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_PRODUCT', N'xoa')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_SIZES', N'xoa size')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_TYPES', N'xoa type')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DELETE_USERS', N'xoa nguoi dung')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_BRAND', N'Chi tiet hang')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_COLORS', N'Chi tiet mau sac')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_ORDERDETAILS', N'Xem chi tiet ')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_ORDERS', N'Xem chi tiet don hang')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_PRODUCT', N'Chi tiet')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_SIZES', N'chi tiiet size')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'DETAILS_TYPES', N'Chi tiet san pham')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_BRAND', N'sua san pham')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_COLORS', N'sua mau')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_ORDERDETAILS', N'Sua order details')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_ORDERS', N'Sua order')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_PRODUCT', N'sua')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_SIZES', N'sua size')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'EDIT_TYPES', N'sua type')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_BRAND', N'xem hang')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_COLORS', N'Xem Mau Sac')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_ORDERDETAILS', N'Xem Chi tiet don hang')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_ORDERS', N'Xem order')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_PRODUCT', N'Xem san pham')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_SIZES', N'xem size')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_TYPES', N'xem the loai')
INSERT [dbo].[Permission] ([id], [title]) VALUES (N'VIEW_USERS', N'xem nguoi dung')
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([id], [product_code], [product_name], [product_type], [product_color], [product_quantity], [product_brand], [product_image], [product_size], [product_description], [out_price], [status], [product_spec]) VALUES (10, N'hK7C', N'Laptop Asus Zenbook 14X OLED UM5401QA-KN209W', 1, 2, 3, 3, N'14733168-e0ab-4d8f-994e-f5f1cd5ee728_laptop-asus-zenbook-14x-oled-um5401qa-kn209w-2.png 1ec162cd-494b-4bc7-8ea3-9e213cab6a5c_laptop-asus-zenbook-14x-oled-um5401qa-kn209w-3.png ba7a2cf2-0990-4b0e-a8f8-e10c0def00a8_laptop-asus-zenbook-14x-oled-um5401qa-kn209w-4.png ', 1, N'Laptop Asus Zenbook 14X OLED UM5401QA-KN209W mang tới cho bạn chất lượng hình ảnh tuyệt đỉnh nhờ trang bị công nghệ màn hình OLED 2.8K cùng thiết kế nhỏ gọn với bản lề ErgoLift 180° kết hợp cùng bộ vi xử lý AMD Ryzen 5000 Series mạnh mẽ giúp laptop mang đến hiệu suất vượt trội để giúp bạn chinh phục mọi trải nghiệm.', 23790000, 1, N'Nhà sản xuất	Asus@
Model	UM5401QA-KN209W@
Hệ điều hành	Windows 11 Home@
CPU	AMD Ryzen 5 5600H (Up to 4.2GHz) 6 Cores 12 Threads@
Card VGA	AMD Radeon Graphics@
Memory	8GB DDR4 onboard@
Ổ cứng	
512GB SSD M.2 PCIe Gen 3.0@

Bàn phím	Chiclet Keyboard, touch pad cảm ứng đa điểm@
Màn hình	14 inch 2.8K (2880 x 1800) 16:10 OLED 0.2ms, 90Hz, 550nits, DCI-P3 100%@
Lan	None@
WLAN	Intel Wi-Fi 6 802.11ax + Bluetooth 5.0@
Màu sắc	Jade Black@
Cổng kết nối	
1 x USB 3.2 Gen2 Type-A 
2 x USB 3.2 Gen2 Type-C
1 x HDMI 2.0b
1 x Audio jack 3.5mm
1 x MicroSD card reader@
Webcam	720P HD Camera@
Audilo	Harman Kardon speakers@
Hỗ trợ Finger Print Reader	Có@
Pin	63Wh@
Trọng lượng	1.4 kg@
Kích thước	311.2 x 221.1 x 15.9 mm@
Bảo hành	2 năm@')
INSERT [dbo].[product] ([id], [product_code], [product_name], [product_type], [product_color], [product_quantity], [product_brand], [product_image], [product_size], [product_description], [out_price], [status], [product_spec]) VALUES (11, N'&utE', N'iPhone 13 Pro Max 128GB', 2, 2, 5, 4, N'7cb59ca8-4b10-4cf7-a817-4d16ea53d086_iphone-13-pro-max-green-2-650x650.jpeg 08cd7c81-244a-45aa-9f1c-a9738ba923ce_iphone-13-pro-max-green-3-650x650.jpeg 96054e0f-bdc2-4091-b680-2bc356afda29_iphone-13-pro-max-green-650x650.png ', 1, N'iPhone 13 Pro Max xứng đáng là một chiếc iPhone lớn nhất, mạnh mẽ nhất và có thời lượng pin dài nhất từ trước đến nay sẽ cho bạn trải nghiệm tuyệt vời, từ những tác vụ bình thường cho đến các ứng dụng chuyên nghiệp.', 29990000, 1, N'Màn hình:	IPS LCD6.1"Liquid Retina
@Hệ điều hành:	iOS 15
@Camera sau:	2 camera 12 MP
@Camera trước:	12 MP
@Chip:	Apple A13 Bionic
@RAM:	4 GB
@Bộ nhớ trong:	64 GB
@SIM:	1 Nano SIM & 1 eSIMHỗ trợ 4G
@Pin, Sạc:	3110 mAh18 W
@
@@')
INSERT [dbo].[product] ([id], [product_code], [product_name], [product_type], [product_color], [product_quantity], [product_brand], [product_image], [product_size], [product_description], [out_price], [status], [product_spec]) VALUES (12, N'EX$4', N'Cáp sạc Lightning 1 m', 3, 2, 50, 4, N'57077738-f761-49c6-9574-46bf7b44e8af_cap-type-c-lightning-1m-apple-mm0a3-trang-2-1-650x650.jpg 6b33aa73-7c2d-40bc-af97-afaba2b5f025_cap-type-c-lightning-1m-apple-mm0a3-trang-3-1-650x650.jpg b8e54b33-b814-4776-8d30-f48b0a6f6486_cap-type-c-lightning-1m-apple-mm0a3-trang-650x650.png ', 1, N'Cáp sạc Lightning 1 m', 500000, 1, N'Màn hình	IPS LCD6.1"Liquid Retina
@Hệ điều hành	iOS 15
@Camera sau	2 camera 12 MP
@Camera trước	12 MP
@Chip	Apple A13 Bionic
@RAM	4 GB
@Bộ nhớ trong	64 GB
@SIM	1 Nano SIM & 1 eSIMHỗ trợ 4G
@Pin, Sạc	3110 mAh18 W@')
INSERT [dbo].[product] ([id], [product_code], [product_name], [product_type], [product_color], [product_quantity], [product_brand], [product_image], [product_size], [product_description], [out_price], [status], [product_spec]) VALUES (13, N'X49X', N'Máy tính bảng iPad mini 6 WiFi Cellular 64GB', 3, 2, 12, 4, N'ac8137cb-d538-4160-b3cb-39ba450afea0_ipad-mini-6-5g-pink-650x650.png 35445042-c147-45b4-af7e-716edb34c532_ipad-mini-6-pink-2-650x650.jpg 734445ae-d917-48b3-a87a-e1df9af762e6_ipad-mini-6-pink-3-650x650.jpg ', 1, N'iPad mini 6 WiFi Cellular 64GB đánh dấu sự trở lại mạnh mẽ của Apple trên dòng sản phẩm iPad mini, thiết bị mới được người dùng yêu thích bởi thiết kế trẻ trung, hiệu suất đỉnh cao với con chip A15 Bionic và hỗ trợ bút cảm ứng Apple Pencil 2 tiện lợi.', 440000, 1, N'Màn hình	8.3"LED-backlit IPS LCD
@Hệ điều hành	iPadOS 15
@Chip	Apple A15 Bionic
@RAM	4 GB
@Bộ nhớ trong	64 GB
@Kết nối	5GNghe gọi qua FaceTime
@SIM	1 Nano SIM & 1 eSIM
@Camera sau	12 MP
@Camera trước	12 MP
@Pin, Sạc	19.3 Wh20 W
@
@
@@')
INSERT [dbo].[product] ([id], [product_code], [product_name], [product_type], [product_color], [product_quantity], [product_brand], [product_image], [product_size], [product_description], [out_price], [status], [product_spec]) VALUES (15, N'plJn', N'Airpods Pro Hộp sạc không dây', 3, 3, 10, 4, N'238928cc-954a-4a66-a639-9ca7c00398f3_12-650x650.png 96c4578a-4274-482c-bb46-83148587a608_tai-nghe-bluetooth-airpods-pro-apple-mwp22-trang-1-650x650.jpg c31ecc82-22b9-4b9a-afd8-9b8fbdb89141_tai-nghe-bluetooth-airpods-pro-apple-mwp22-trang-2-650x650.jpg ', 1, N'AirPods Pro với thiết kế gọn gàng, đẹp và tinh tế, tai nghe được thiết kế theo dạng In-ear thay vì Earbuds như AirPods 2, cho phép chống ồn tốt hơn, khó rớt khi đeo và đặc biệt là êm tai hơn.', 6790000, 1, N'Thời gian tai nghe	Dùng 5 giờ - Sạc 2 giờ
@Thời gian hộp sạc	Dùng 24 giờ - Sạc 3 giờ
@Cổng sạc	LightningSạc không dây
@Công nghệ âm thanh	Active Noise CancellationAdaptive EQChip Apple H1Custom high-excursion Apple driverHigh Dynamic RangeSpatial AudioTransparency Mode
@Tương thích	AndroidiOS (iPhone)iPadOS (iPad)MacOS
@Tiện ích	Chống nước IPX4Chống ồnCó mic thoạiHỗ trợ sạc không dây Qi
@Hỗ trợ kết nối	Bluetooth 5.0
@Điều khiển bằng	Cảm ứng chạm
@Hãng	Apple@')
SET IDENTITY_INSERT [dbo].[product] OFF
GO
INSERT [dbo].[Role] ([id], [title]) VALUES (N'Admin', NULL)
INSERT [dbo].[Role] ([id], [title]) VALUES (N'Customer', NULL)
INSERT [dbo].[Role] ([id], [title]) VALUES (N'Staff', N'Nhan vien')
GO
SET IDENTITY_INSERT [dbo].[Size] ON 

INSERT [dbo].[Size] ([id], [title]) VALUES (1, N'New')
INSERT [dbo].[Size] ([id], [title]) VALUES (2, N'Used')
SET IDENTITY_INSERT [dbo].[Size] OFF
GO
SET IDENTITY_INSERT [dbo].[type] ON 

INSERT [dbo].[type] ([id], [tilte]) VALUES (1, N'Laptop')
INSERT [dbo].[type] ([id], [tilte]) VALUES (2, N'Phone')
INSERT [dbo].[type] ([id], [tilte]) VALUES (3, N'Accessory')
SET IDENTITY_INSERT [dbo].[type] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [email], [password], [fullname], [phone], [address], [status], [RoleID]) VALUES (1, N'admin@admin', N'admin', N'admin', N'1', N'1', 1, N'Admin')
INSERT [dbo].[user] ([id], [email], [password], [fullname], [phone], [address], [status], [RoleID]) VALUES (2, N'lonhvo@gmail.com', N'l@XDAzGP', N'long', N'0392221200', N'can tho', 1, N'Staff')
INSERT [dbo].[user] ([id], [email], [password], [fullname], [phone], [address], [status], [RoleID]) VALUES (3, N'crrttz@gmail.com', N'CZMk6qxE', N'Nguyen Huu Ly', N'0123456789', N'Can Tho', 1, N'Admin')
INSERT [dbo].[user] ([id], [email], [password], [fullname], [phone], [address], [status], [RoleID]) VALUES (4, N'lynhce140219@fpt.edu.vn', N'76xkZ5Tr', N'Nguyen Huu Ly', N'0123456789', N'Can Tho', 1, N'Staff')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
SET IDENTITY_INSERT [dbo].[voucher] ON 

INSERT [dbo].[voucher] ([id], [voucher_code], [voucher_discount], [voucher_description], [create_at], [delete_at], [quantity]) VALUES (1, N'D1', 50, N'Discount dau thang', CAST(N'2022-04-01' AS Date), NULL, 87)
SET IDENTITY_INSERT [dbo].[voucher] OFF
GO
ALTER TABLE [dbo].[Credentials]  WITH CHECK ADD  CONSTRAINT [FK_Credentials_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([id])
GO
ALTER TABLE [dbo].[Credentials] CHECK CONSTRAINT [FK_Credentials_Permission]
GO
ALTER TABLE [dbo].[Credentials]  WITH CHECK ADD  CONSTRAINT [FK_Credentials_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Credentials] CHECK CONSTRAINT [FK_Credentials_Role]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_voucher] FOREIGN KEY([voucher_id])
REFERENCES [dbo].[voucher] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_voucher]
GO
ALTER TABLE [dbo].[order_details]  WITH CHECK ADD  CONSTRAINT [FK_order_detalis_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[order_details] CHECK CONSTRAINT [FK_order_detalis_order]
GO
ALTER TABLE [dbo].[order_details]  WITH CHECK ADD  CONSTRAINT [FK_order_detalis_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[order_details] CHECK CONSTRAINT [FK_order_detalis_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_brand] FOREIGN KEY([product_brand])
REFERENCES [dbo].[brand] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_brand]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_Color] FOREIGN KEY([product_color])
REFERENCES [dbo].[Color] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_Color]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_Size] FOREIGN KEY([product_size])
REFERENCES [dbo].[Size] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_Size]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_type] FOREIGN KEY([product_type])
REFERENCES [dbo].[type] ([id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_type]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
ALTER TABLE [dbo].[user_donation]  WITH CHECK ADD  CONSTRAINT [FK_user_donation_donation] FOREIGN KEY([donation_id])
REFERENCES [dbo].[donation] ([id])
GO
ALTER TABLE [dbo].[user_donation] CHECK CONSTRAINT [FK_user_donation_donation]
GO
ALTER TABLE [dbo].[warehouse]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[warehouse] CHECK CONSTRAINT [FK_warehouse_user]
GO
ALTER TABLE [dbo].[warehouse_detail]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_detail_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[warehouse_detail] CHECK CONSTRAINT [FK_warehouse_detail_product]
GO
ALTER TABLE [dbo].[warehouse_detail]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_detail_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[warehouse_detail] CHECK CONSTRAINT [FK_warehouse_detail_user]
GO
USE [master]
GO
ALTER DATABASE [DataFashion] SET  READ_WRITE 
GO
