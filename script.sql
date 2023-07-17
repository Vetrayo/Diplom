CREATE DATABASE [DiplomSuntsov]

USE [DiplomSuntsov]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Patronymic] [nvarchar](64) NULL,
	[Phone] [nvarchar](16) NOT NULL,
	[Photo] [image] NULL,
	[IdControlQuestion] [int] NOT NULL,
	[AnswerOnQuestion] [nvarchar](64) NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlQuestion]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlQuestion](
	[IdControlQuestion] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ControlQuestion] PRIMARY KEY CLUSTERED 
(
	[IdControlQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Patronymic] [nvarchar](64) NULL,
	[Phone] [nvarchar](16) NOT NULL,
	[Salary] [int] NOT NULL,
	[Premium] [int] NULL,
	[Photo] [image] NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [int] NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](64) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usluga]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usluga](
	[IdUsluga] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IdUsluga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zakaz]    Script Date: 16.06.2023 10:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zakaz](
	[IdZakaz] [int] IDENTITY(1,1) NOT NULL,
	[IdUsluga] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[DescriprionByClient] [nvarchar](max) NULL,
	[AcceptedByWhom] [nvarchar](150) NULL,
	[IdClient] [int] NOT NULL,
 CONSTRAINT [PK_Zakaz] PRIMARY KEY CLUSTERED 
(
	[IdZakaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 
GO
INSERT [dbo].[Client] ([IdClient], [Surname], [Name], [Patronymic], [Phone], [Photo], [IdControlQuestion], [AnswerOnQuestion], [IdUser]) VALUES (1, N'Иванов', N'Иван', N'Иванович', N'+7 999 999 99 99', NULL, 1, N'Шаурма', 3)
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
INSERT [dbo].[ControlQuestion] ([IdControlQuestion], [Name]) VALUES (1, N'Ваше любимое блюдо?')
GO
INSERT [dbo].[ControlQuestion] ([IdControlQuestion], [Name]) VALUES (2, N'Кличка вашего первого питомца?')
GO
INSERT [dbo].[ControlQuestion] ([IdControlQuestion], [Name]) VALUES (3, N'На какой улице вы родились?')
GO
INSERT [dbo].[ControlQuestion] ([IdControlQuestion], [Name]) VALUES (4, N'Название вашей первой школы')
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([IdEmployee], [Surname], [Name], [Patronymic], [Phone], [Salary], [Premium], [Photo], [IdUser]) VALUES (1, N'Сидоров', N'Семен', N'Иванович', N'+7 999 999 99 92', 60000, 0, NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (1, N'Администратор')
GO
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (2, N'Сотрудник')
GO
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (3, N'Пользователь')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (1, N'В ожидании')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (2, N'На расcмотрении')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (3, N'Отказано')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (4, N'Принято')
GO
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (5, N'Подтвержденно')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (1, N'admin', N'admin', 1)
GO
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (2, N'work', N'work', 2)
GO
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdRole]) VALUES (3, N'user', N'user', 3)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Usluga] ON 
GO
INSERT [dbo].[Usluga] ([IdUsluga], [Name], [Description]) VALUES (1, N'Предоставление информации по документам учреждений системы образования', N'нету')
GO
INSERT [dbo].[Usluga] ([IdUsluga], [Name], [Description]) VALUES (2, N'Предоставление информации по системам жилищно-коммунального хозяйства', N'нету')
GO
INSERT [dbo].[Usluga] ([IdUsluga], [Name], [Description]) VALUES (3, N'Предоставлении информации по документам медицинских учреждений (организаций)', N'нету')
GO
INSERT [dbo].[Usluga] ([IdUsluga], [Name], [Description]) VALUES (4, N'Изготовление копий архивных документов, в том числе на электронных носителях', N'нету')
GO
INSERT [dbo].[Usluga] ([IdUsluga], [Name], [Description]) VALUES (5, N'Тематический запрос', N'нету')
GO
SET IDENTITY_INSERT [dbo].[Usluga] OFF
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_ControlQuestion] FOREIGN KEY([IdControlQuestion])
REFERENCES [dbo].[ControlQuestion] ([IdControlQuestion])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_ControlQuestion]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_Client]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_Product] FOREIGN KEY([IdUsluga])
REFERENCES [dbo].[Usluga] ([IdUsluga])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_Product]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_Status]
GO
USE [master]
GO
ALTER DATABASE [DiplomSuntsov] SET  READ_WRITE 
GO
