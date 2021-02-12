USE [master]
GO
/****** Object:  Database [Telerik]    Script Date: 2/12/2021 1:48:58 PM ******/
CREATE DATABASE [Telerik]
Go
USE Telerik
GO

CREATE TABLE [dbo].[Products](
	[ProductId] [int] NOT NULL,
	[Price] [varchar](50) NULL,
	[InStock] [int] NULL,
	[Category] [varchar](50) NULL,
	[Rating] [int] NULL,
	[Country] [varchar](50) NULL,
	[Units] [int] NULL,
	[ProductName] [varchar](100) NULL,
	[ParentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Products] ([ProductId], [Price], [InStock], [Category], [Rating], [Country], [Units], [ProductName], [ParentId]) VALUES (1, N'25', 1, N'Beverages', 3, N'India', 50, N'soda', NULL)
INSERT [dbo].[Products] ([ProductId], [Price], [InStock], [Category], [Rating], [Country], [Units], [ProductName], [ParentId]) VALUES (2, N'28', 60, N'Dairy ', 5, N'India', 2, N'Milk', NULL)
INSERT [dbo].[Products] ([ProductId], [Price], [InStock], [Category], [Rating], [Country], [Units], [ProductName], [ParentId]) VALUES (3, N'153', 25, N'Cleaners ', 3, N'India', 6, N'Detergent', NULL)
INSERT [dbo].[Products] ([ProductId], [Price], [InStock], [Category], [Rating], [Country], [Units], [ProductName], [ParentId]) VALUES (4, N'260', 50, N'Cleaners', 4, N'India', 50, N'Fena', 3)
INSERT [dbo].[Products] ([ProductId], [Price], [InStock], [Category], [Rating], [Country], [Units], [ProductName], [ParentId]) VALUES (5, N'506', 60, N'Cleaners', 5, N'India', 50, N'Surf Excel', 3)
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[Products] ([ProductId])
GO
/****** Object:  StoredProcedure [dbo].[SelectAllProducts]    Script Date: 2/12/2021 1:48:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllProducts]
AS
SELECT * FROM Products
GO;
GO
USE [master]
GO
ALTER DATABASE [Telerik] SET  READ_WRITE 
GO
