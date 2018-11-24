
/****** Object:  Table [dbo].[Candy]    Script Date: 10/25/2018 4:52:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK__Candy__3214EC076AD2FBA5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Costumes]    Script Date: 10/25/2018 4:52:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Costumes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Costume] [varchar](50) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK__Costumes__3214EC07186C04D8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treaters]    Script Date: 10/25/2018 4:52:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treaters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FavoriteCandyID] [int] NOT NULL,
	[CostumeID] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Treaters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Candy] ON 
GO
INSERT [dbo].[Candy] ([Id], [ProductName], [Timestamp]) VALUES (1, N'Butterfinger', CAST(N'2018-10-25T16:35:23.943' AS DateTime))
GO
INSERT [dbo].[Candy] ([Id], [ProductName], [Timestamp]) VALUES (2, N'Snickers', CAST(N'2018-10-25T16:35:23.943' AS DateTime))
GO
INSERT [dbo].[Candy] ([Id], [ProductName], [Timestamp]) VALUES (3, N'Twix', CAST(N'2018-10-25T16:35:23.943' AS DateTime))
GO
INSERT [dbo].[Candy] ([Id], [ProductName], [Timestamp]) VALUES (4, N'Now and Later', CAST(N'2018-10-25T16:35:23.943' AS DateTime))
GO
INSERT [dbo].[Candy] ([Id], [ProductName], [Timestamp]) VALUES (5, N'Popcorn Ball', CAST(N'2018-10-25T16:35:23.943' AS DateTime))
GO
INSERT [dbo].[Candy] ([Id], [ProductName], [Timestamp]) VALUES (6, N'Fruitcake', CAST(N'2018-10-25T16:35:23.943' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Candy] OFF
GO
SET IDENTITY_INSERT [dbo].[Costumes] ON 
GO
INSERT [dbo].[Costumes] ([Id], [Costume], [Timestamp]) VALUES (1, N'Ghost', CAST(N'2018-10-25T16:39:09.597' AS DateTime))
GO
INSERT [dbo].[Costumes] ([Id], [Costume], [Timestamp]) VALUES (2, N'Skeleton', CAST(N'2018-10-25T16:39:09.597' AS DateTime))
GO
INSERT [dbo].[Costumes] ([Id], [Costume], [Timestamp]) VALUES (3, N'Zombie', CAST(N'2018-10-25T16:39:09.597' AS DateTime))
GO
INSERT [dbo].[Costumes] ([Id], [Costume], [Timestamp]) VALUES (4, N'Chupacabra', CAST(N'2018-10-25T16:39:09.597' AS DateTime))
GO
INSERT [dbo].[Costumes] ([Id], [Costume], [Timestamp]) VALUES (5, N'Richard Dean Anderson', CAST(N'2018-10-25T16:39:09.597' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Costumes] OFF
GO
ALTER TABLE [dbo].[Candy] ADD  CONSTRAINT [DF_Candy_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Costumes] ADD  CONSTRAINT [DF_Costumes_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Treaters] ADD  CONSTRAINT [DF_Treaters_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO

CREATE PROCEDURE Candy_GetList
AS
SELECT * FROM Candy;
GO

CREATE PROCEDURE Candy_Insert
(
	@ProductName varchar(50)
)
AS
INSERT INTO Candy(ProductName) 
VALUES (@ProductName);
GO

CREATE PROCEDURE Candy_Delete
(
	@Id int
)
AS
DELETE FROM Candy
WHERE Id=@Id;
GO

CREATE PROCEDURE Costumes_GetList
AS
SELECT * FROM Costumes;
GO

CREATE PROCEDURE Costumes_Insert
(
	@Costume varchar(50)
)
AS
INSERT INTO Costumes(Costume)
VALUES (@Costume)
GO

CREATE PROCEDURE Costumes_Delete
(
	@Id int
)
AS
DELETE FROM Costumes
WHERE Id=@Id;
GO

CREATE PROCEDURE Treaters_GetList
AS
SELECT * FROM Treaters;
GO

CREATE PROCEDURE Treaters_Insert
(
	@Name varchar(50),
	@FavoriteCandyID INT,
	@CostumeID INT
)
AS
INSERT INTO Treaters
(
    Name,
    FavoriteCandyID,
    CostumeID
)
VALUES
(   @Name,
    @FavoriteCandyID,
    @CostumeID
)
GO

DROP TABLE Treaters
GO

CREATE TABLE [dbo].[Treaters](
[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[Name] [varchar](50) NOT NULL,
[FavoriteCandyID] [int] NOT NULL REFERENCES Candy(Id),
[CostumeID] [int] NOT NULL REFERENCES Costumes(Id),
[Timestamp] [datetime] NOT NULL DEFAULT(GETDATE())
)

CREATE LOGIN Ghost WITH PASSWORD='abc123', CHECK_POLICY=OFF;
GO
USE Halloween;
GO
CREATE USER Ghost;
GO