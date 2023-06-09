USE [Decks]
GO
ALTER TABLE [dbo].[Progress] DROP CONSTRAINT [FK_Progress_User]
GO
ALTER TABLE [dbo].[Deck] DROP CONSTRAINT [FK_Deck_User]
GO
ALTER TABLE [dbo].[Deck] DROP CONSTRAINT [FK_Deck_Tag]
GO
ALTER TABLE [dbo].[Card] DROP CONSTRAINT [FK_Card_Deck]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/26/2023 3:07:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 5/26/2023 3:07:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tag]') AND type in (N'U'))
DROP TABLE [dbo].[Tag]
GO
/****** Object:  Table [dbo].[Progress]    Script Date: 5/26/2023 3:07:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Progress]') AND type in (N'U'))
DROP TABLE [dbo].[Progress]
GO
/****** Object:  Table [dbo].[Deck]    Script Date: 5/26/2023 3:07:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deck]') AND type in (N'U'))
DROP TABLE [dbo].[Deck]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 5/26/2023 3:07:11 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Card]') AND type in (N'U'))
DROP TABLE [dbo].[Card]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 5/26/2023 3:07:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[CardId] [bigint] IDENTITY(1,1) NOT NULL,
	[Front] [nvarchar](50) NULL,
	[Back] [nvarchar](50) NULL,
	[DeckId] [bigint] NULL,
	[Times_Studied] [bigint] NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deck]    Script Date: 5/26/2023 3:07:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deck](
	[DeckId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[UserID] [bigint] NULL,
	[TagId] [bigint] NULL,
 CONSTRAINT [PK_Deck] PRIMARY KEY CLUSTERED 
(
	[DeckId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Progress]    Script Date: 5/26/2023 3:07:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Progress](
	[ProgressId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[DeckId] [bigint] NULL,
	[Cards_Studied] [bigint] NULL,
	[Cards_Mastered] [bigint] NULL,
 CONSTRAINT [PK_Progress] PRIMARY KEY CLUSTERED 
(
	[ProgressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 5/26/2023 3:07:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/26/2023 3:07:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Card] ON 

INSERT [dbo].[Card] ([CardId], [Front], [Back], [DeckId], [Times_Studied]) VALUES (1, N'Liam', N'Welk', 7, 0)
INSERT [dbo].[Card] ([CardId], [Front], [Back], [DeckId], [Times_Studied]) VALUES (2, N'Liam', N'Welking', 7, 1)
INSERT [dbo].[Card] ([CardId], [Front], [Back], [DeckId], [Times_Studied]) VALUES (3, N'Text', N'Text2', 1, 0)
INSERT [dbo].[Card] ([CardId], [Front], [Back], [DeckId], [Times_Studied]) VALUES (4, N'Me cas', N'Sf', 8, 0)
SET IDENTITY_INSERT [dbo].[Card] OFF
GO
SET IDENTITY_INSERT [dbo].[Deck] ON 

INSERT [dbo].[Deck] ([DeckId], [Name], [Description], [UserID], [TagId]) VALUES (1, N'test2', N'test2', 1, 2)
INSERT [dbo].[Deck] ([DeckId], [Name], [Description], [UserID], [TagId]) VALUES (6, N'NewDeck', N'This is a new deck', 1, 1)
INSERT [dbo].[Deck] ([DeckId], [Name], [Description], [UserID], [TagId]) VALUES (7, N'Liamdeck', N'This is Liam’s deck', 1, 1)
INSERT [dbo].[Deck] ([DeckId], [Name], [Description], [UserID], [TagId]) VALUES (8, N'Rfbrg', N'Srg', 1, 1)
SET IDENTITY_INSERT [dbo].[Deck] OFF
GO
SET IDENTITY_INSERT [dbo].[Progress] ON 

INSERT [dbo].[Progress] ([ProgressId], [UserId], [DeckId], [Cards_Studied], [Cards_Mastered]) VALUES (1, 1, 7, 1, 1)
SET IDENTITY_INSERT [dbo].[Progress] OFF
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([TagId], [Name]) VALUES (1, N'Language')
INSERT [dbo].[Tag] ([TagId], [Name]) VALUES (2, N'Math')
INSERT [dbo].[Tag] ([TagId], [Name]) VALUES (3, N'NewTag')
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [Password]) VALUES (1, N'name', N'onetwo')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_Deck] FOREIGN KEY([DeckId])
REFERENCES [dbo].[Deck] ([DeckId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_Deck]
GO
ALTER TABLE [dbo].[Deck]  WITH CHECK ADD  CONSTRAINT [FK_Deck_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([TagId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deck] CHECK CONSTRAINT [FK_Deck_Tag]
GO
ALTER TABLE [dbo].[Deck]  WITH CHECK ADD  CONSTRAINT [FK_Deck_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Deck] CHECK CONSTRAINT [FK_Deck_User]
GO
ALTER TABLE [dbo].[Progress]  WITH CHECK ADD  CONSTRAINT [FK_Progress_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Progress] CHECK CONSTRAINT [FK_Progress_User]
GO
