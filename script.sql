USE [PHTech]
GO

/****** Object:  Table [dbo].[Brands] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	CONSTRAINT [PK_brand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Colors] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Credentials] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credentials]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [nvarchar](50) NULL,
	[PermissionID] [nvarchar](50) NULL,
	CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Orders] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders]
(
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

/****** Object:  Table [dbo].[OrderDetails] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails]
(
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

/****** Object:  Table [dbo].[Permissions] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions]
(
	[id] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NULL,
	CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Products] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products]
(
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

/****** Object:  Table [dbo].[Roles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles]
(
	[id] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NULL,
	CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sizes] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Types] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Users] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
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

/****** Object:  Table [dbo].[Vouchers] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers]
(
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

/****** Object:  Table [dbo].[Warehouse] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse]
(
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

/****** Object:  Table [dbo].[WarehouseDetails]    Script Date: 4/13/2022 8:32:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseDetails]
(
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

SET IDENTITY_INSERT [dbo].[Brands] ON
INSERT [dbo].[Brands] ([id], [title]) VALUES (1, N'DELL')
INSERT [dbo].[Brands] ([id], [title]) VALUES (2, N'HP')
INSERT [dbo].[Brands] ([id], [title]) VALUES (3, N'Asus')
INSERT [dbo].[Brands] ([id], [title]) VALUES (4, N'Apple')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO

SET IDENTITY_INSERT [dbo].[Colors] ON
INSERT [dbo].[Colors] ([id], [title]) VALUES (1, N'Red')
INSERT [dbo].[Colors] ([id], [title]) VALUES (2, N'Black')
INSERT [dbo].[Colors] ([id], [title]) VALUES (3, N'White')
INSERT [dbo].[Colors] ([id], [title]) VALUES (4, N'Gold')
INSERT [dbo].[Colors] ([id], [title]) VALUES (5, N'Rose')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO

INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'CREATE_BRAND', N'Add new brand')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'CREATE_COLORS', N'Add new color')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'CREATE_ORDERDETAILS', N'Add new Order details')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'CREATE_PRODUCT', N'Add new product')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'CREATE_SIZES', N'Add new size')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'CREATE_TYPES', N'Add new type')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_BRAND', N'Remove brand')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_COLORS', N'Remove color')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_ORDERDETAILS', N'Remove order details')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_PRODUCT', N'Remove product')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_SIZES', N'Remove size')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_TYPES', N'Remove type')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DELETE_USERS', N'Remove user')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_BRAND', N'View brand')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_COLORS', N'View color')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_ORDERDETAILS', N'View order details')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_ORDERS', N'View order')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_PRODUCT', N'View product')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_SIZES', N'View size')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'DETAILS_TYPES', N'View type')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_BRAND', N'Edit brand')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_COLORS', N'Edit color')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_ORDERDETAILS', N'Edit order details')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_ORDERS', N'Edit order')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_PRODUCT', N'Edit product')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_SIZES', N'Edit size')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'EDIT_TYPES', N'Edit type')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_BRAND', N'View list of brands')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_COLORS', N'View list of colors')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_ORDERDETAILS', N'View order details')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_ORDERS', N'View list of orders')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_PRODUCT', N'View list of products')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_SIZES', N'View list of sizes')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_TYPES', N'View list of types')
INSERT [dbo].[Permissions] ([id], [title]) VALUES (N'VIEW_USERS', N'View list of users')
GO

INSERT [dbo].[Roles] VALUES (N'Admin', N'Admin')
INSERT [dbo].[Roles] VALUES (N'Customer', N'Customer')
INSERT [dbo].[Roles] VALUES (N'Staff', N'Staff')
GO

SET IDENTITY_INSERT [dbo].[Sizes] ON
INSERT [dbo].[Sizes] ([id], [title]) VALUES (1, N'New')
INSERT [dbo].[Sizes] ([id], [title]) VALUES (2, N'Used')
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO

SET IDENTITY_INSERT [dbo].[Types] ON
INSERT [dbo].[Types] ([id], [title]) VALUES (1, N'Laptop')
INSERT [dbo].[Types] ([id], [title]) VALUES (2, N'Phone')
INSERT [dbo].[Types] ([id], [title]) VALUES (3, N'Accessory')
SET IDENTITY_INSERT [dbo].[Types] OFF
GO

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([id], [email], [password], [fullname], [phone], [address], [status], [RoleID]) VALUES (1, N'admin@admin', N'admin', N'Administrator', N'1', N'1', 1, N'Admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

SET IDENTITY_INSERT [dbo].[Vouchers] ON
INSERT [dbo].[Vouchers]([id], [voucher_code], [voucher_discount], [voucher_description], [create_at], [delete_at], [quantity])
VALUES (1, N'D50', 50, N'Sale Off 50%', CAST(N'2023-03-01' AS Date), NULL, 87)
SET IDENTITY_INSERT [dbo].[Vouchers] OFF
GO

ALTER TABLE [dbo].[Credentials]  WITH CHECK ADD  CONSTRAINT [FK_Credentials_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permissions] ([id])
GO

ALTER TABLE [dbo].[Credentials] CHECK CONSTRAINT [FK_Credentials_Permission]
GO

ALTER TABLE [dbo].[Credentials]  WITH CHECK ADD  CONSTRAINT [FK_Credentials_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([id])
GO

ALTER TABLE [dbo].[Credentials] CHECK CONSTRAINT [FK_Credentials_Role]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_order_user]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_order_voucher] FOREIGN KEY([voucher_id])
REFERENCES [dbo].[Vouchers] ([id])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_order_voucher]
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_order_detalis_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO

ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_order_detalis_order]
GO

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_order_detalis_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
GO

ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_order_detalis_product]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_product_brand] FOREIGN KEY([product_brand])
REFERENCES [dbo].[Brands] ([id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_product_brand]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_product_Color] FOREIGN KEY([product_color])
REFERENCES [dbo].[Colors] ([id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_product_Color]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_product_Size] FOREIGN KEY([product_size])
REFERENCES [dbo].[Sizes] ([id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_product_Size]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_product_type] FOREIGN KEY([product_type])
REFERENCES [dbo].[Types] ([id])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_product_type]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([id])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_user_role]
GO

ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_warehouse_user]
GO

ALTER TABLE [dbo].[WarehouseDetails]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_detail_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
GO

ALTER TABLE [dbo].[WarehouseDetails] CHECK CONSTRAINT [FK_warehouse_detail_product]
GO

ALTER TABLE [dbo].[WarehouseDetails]  WITH CHECK ADD  CONSTRAINT [FK_warehouse_detail_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[WarehouseDetails] CHECK CONSTRAINT [FK_warehouse_detail_user]
GO

CREATE TABLE [dbo].[UserActivations]
(
	[user_id] [int] NOT NULL,
	[code] [nchar](50) NOT NULL,
	[expired_at] [datetime] NOT NULL,
	[status] [int] NOT NULL,
	CONSTRAINT [PK_user_activation] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserActivations]  WITH CHECK ADD CONSTRAINT [FK_user_activation_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Orders]  
	ADD [payment_method] [nvarchar](50) NOT NULL DEFAULT 'COD',
			[payment_status] [int] NOT NULL DEFAULT 0,
			[payment_detail] [nvarchar](255) NULL
GO

CREATE TABLE [dbo].[Wishlist]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[create_at] [datetime] NOT NULL,
	CONSTRAINT [PK_wishlist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD CONSTRAINT [FK_wishlist_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO

ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_wishlist_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
GO

USE [master]
GO
ALTER DATABASE [PHTech] SET  READ_WRITE 
GO
