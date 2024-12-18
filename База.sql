USE [Build unit in workshop 5]
GO
/****** Object:  Table [dbo].[Build]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Build](
	[idBuild] [int] IDENTITY(1,1) NOT NULL,
	[BuildName] [nvarchar](max) NOT NULL,
	[BlueprintCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Build] PRIMARY KEY CLUSTERED 
(
	[idBuild] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConstructionDocuments]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConstructionDocuments](
	[numberInOrder] [int] IDENTITY(1,1) NOT NULL,
	[blueprintCode] [nvarchar](50) NOT NULL,
	[blueprintImage] [int] NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_ConstructionDocuments] PRIMARY KEY CLUSTERED 
(
	[blueprintCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details](
	[idDetail] [int] IDENTITY(1,1) NOT NULL,
	[nameOfDetail] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED 
(
	[idDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImagePath]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagePath](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ImagePath] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShiftAndDailyTask]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftAndDailyTask](
	[workNumber] [int] IDENTITY(1,1) NOT NULL,
	[idTask] [int] NOT NULL,
	[typeOfWork] [int] NOT NULL,
	[idBuild] [int] NOT NULL,
	[Employeer] [int] NOT NULL,
	[dateOfTheTask] [date] NULL,
	[dateOfComplete] [date] NULL,
 CONSTRAINT [PK_ShiftAndDailyTask] PRIMARY KEY CLUSTERED 
(
	[idTask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[idStaff] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[idStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[idTask] [int] IDENTITY(1,1) NOT NULL,
	[nameOfTask] [nvarchar](max) NOT NULL,
	[idDetail] [int] NOT NULL,
	[numberOfDetails] [nvarchar](50) NOT NULL,
	[numberOfHours] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[idTask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfWork]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfWork](
	[idtypeOfWork] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeOfWork] PRIMARY KEY CLUSTERED 
(
	[idtypeOfWork] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05.06.2023 22:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[idRole] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Build]  WITH CHECK ADD  CONSTRAINT [FK_Build_ConstructionDocuments] FOREIGN KEY([BlueprintCode])
REFERENCES [dbo].[ConstructionDocuments] ([blueprintCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Build] CHECK CONSTRAINT [FK_Build_ConstructionDocuments]
GO
ALTER TABLE [dbo].[ConstructionDocuments]  WITH CHECK ADD  CONSTRAINT [FK_ConstructionDocuments_ImagePath] FOREIGN KEY([blueprintImage])
REFERENCES [dbo].[ImagePath] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConstructionDocuments] CHECK CONSTRAINT [FK_ConstructionDocuments_ImagePath]
GO
ALTER TABLE [dbo].[ShiftAndDailyTask]  WITH CHECK ADD  CONSTRAINT [FK_ShiftAndDailyTask_Staff] FOREIGN KEY([Employeer])
REFERENCES [dbo].[Staff] ([idStaff])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShiftAndDailyTask] CHECK CONSTRAINT [FK_ShiftAndDailyTask_Staff]
GO
ALTER TABLE [dbo].[ShiftAndDailyTask]  WITH CHECK ADD  CONSTRAINT [FK_ShiftAndDailyTask_Tasks] FOREIGN KEY([idTask])
REFERENCES [dbo].[Tasks] ([idTask])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShiftAndDailyTask] CHECK CONSTRAINT [FK_ShiftAndDailyTask_Tasks]
GO
ALTER TABLE [dbo].[ShiftAndDailyTask]  WITH CHECK ADD  CONSTRAINT [FK_ShiftAndDailyTask_TypeOfWork] FOREIGN KEY([typeOfWork])
REFERENCES [dbo].[TypeOfWork] ([idtypeOfWork])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShiftAndDailyTask] CHECK CONSTRAINT [FK_ShiftAndDailyTask_TypeOfWork]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Details] FOREIGN KEY([idDetail])
REFERENCES [dbo].[Details] ([idDetail])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Details]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([idRole])
REFERENCES [dbo].[Role] ([idRole])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
