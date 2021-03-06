USE [jinjie.xu]

-- The commented section below is used to drop all the existing FK, tables, and procedures
-- NOTE: Please rename the FK constraints to match the existing ones.
--ALTER TABLE [dbo].[Match] 
--DROP CONSTRAINT FK__Match__AwayTeamI__7D0E9093;
--GO
--ALTER TABLE [dbo].[Match]
--DROP CONSTRAINT FK__Match__HomeTeamI__7C1A6C5A;
--GO
--ALTER TABLE [dbo].[Player]
--DROP CONSTRAINT FK__Player__TeamId__1F63A897;
--GO
--DROP TABLE [dbo].[Team]
--GO
--DROP TABLE [dbo].[Match]
--GO
--DROP TABLE [dbo].[Player]
--GO
--DROP PROCEDURE Player_GetPlayers;
--GO
--DROP PROCEDURE Player_GetPlayer;
--GO
--DROP PROCEDURE Player_InsertUpdate;
--GO
--DROP PROCEDURE Player_Delete;
--GO
--DROP PROCEDURE Team_GetTeams;  
--GO  
--DROP PROCEDURE Team_InsertUpdate;  
--GO  
--DROP PROCEDURE Team_GetTeam;  
--GO  
--DROP PROCEDURE Team_Delete;  
--GO  
--DROP PROCEDURE Match_GetMatches;  
--GO  
--DROP PROCEDURE Match_GetMatch;  
--GO  
--DROP PROCEDURE Match_InsertUpdate;  
--GO  
--DROP PROCEDURE Match_Delete;  
--GO  

/****** Object:  Table [dbo].[Team]    Script Date: 12/1/2018 11:42:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[ID] [int] NOT NULL IDENTITY(1,1),
	[TeamName] [varchar](50) NOT NULL,
	[Badge] [varchar](MAX) NULL,
	[Wins] [int] NOT NULL,
	[Draws] [int] NOT NULL,
	[Loses] [int] NOT NULL,
	[GoalsFor] [int] NOT NULL,
	[GoalsAgainst] [int] NOT NULL,
	[Group] [char] NOT NULL,
	[Timestamp] [datetime] NOT NULL DEFAULT(GETDATE())
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Match]    Script Date: 12/1/2018 11:49:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[ID] [int] NOT NULL IDENTITY(1,1),
	[HomeTeamId] [int] NOT NULL REFERENCES Team(ID),
	[HomeGoals] [int] NOT NULL,
	[AwayTeamId] [int] NOT NULL REFERENCES Team(ID),
	[AwayGoals] [int] NOT NULL,
	[MatchDate] [varchar](50) NOT NULL,
	[MatchTime] [varchar](50) NULL,
	[MatchDayNumber] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL DEFAULT(GETDATE())
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 12/3/2018 2:57:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Position] [varchar](50) NOT NULL,
	[Nationality] [varchar](50) NOT NULL,
	[JerseyNumber] [int] NOT NULL,
	[GoalScored] [int] NOT NULL,
	[TeamId] [int] NOT NULL REFERENCES Team(ID),
	[Timestamp] [datetime] NOT NULL DEFAULT(GETDATE()),
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE Player_GetPlayers
AS
BEGIN
	SELECT * 
	FROM Player;
END
GO

CREATE PROCEDURE Player_GetPlayer
(
	@ID int = NULL
)
AS
BEGIN
	SELECT *
	FROM Player
	WHERE ID=@ID
END
GO

CREATE PROCEDURE Player_InsertUpdate
(
	@ID int = NULL,
	@Name varchar(50),
	@Position varchar(50),
	@Nationality varchar(50),
	@JerseyNumber int,
	@GoalScored int,
	@TeamId int
)
AS
BEGIN
IF @ID IS NULL
	BEGIN
		INSERT INTO Player
		(
			[Name],
			Position,
			Nationality,
			JerseyNumber,
			GoalScored,
			TeamId
		)
		VALUES
		(
			@Name,
			@Position,
			@Nationality,
			@JerseyNumber,
			@GoalScored,
			@TeamId
		)
	END
ELSE
	BEGIN
		UPDATE Player 
		SET 
		[Name]=@Name,
		Position=@Position,
		Nationality=@Nationality,
		JerseyNumber=@JerseyNumber,
		GoalScored=@GoalScored,
		TeamId=@TeamId
		WHERE ID=@ID;
	END
END
GO

CREATE PROCEDURE Player_Delete
(
	@ID int
)
AS
BEGIN
	DELETE FROM Player
	WHERE ID=@ID;
END
GO

CREATE PROCEDURE Team_GetTeams
AS
BEGIN
	SELECT * 
	FROM [Team];
END
GO

CREATE PROCEDURE Team_GetTeam
(
	@ID int = NULL
)
AS
BEGIN
	SELECT *
	FROM Team
	WHERE ID=@ID
END
GO

CREATE PROCEDURE Team_InsertUpdate
(
	@ID int = NULL,
	@TeamName varchar(50),
	@Badge varchar(MAX) = NULL,
	@Wins int,
	@Draws int, 
	@Loses int,
	@GoalsFor int,
	@GoalsAgainst int,
	@Group char
)
AS
BEGIN
IF @ID IS NULL
	BEGIN
		INSERT INTO Team
		(
			TeamName,
			Badge,
			Wins,
			Draws,
			Loses,
			GoalsFor,
			GoalsAgainst,
			[Group]
		)
		VALUES
		(
			@TeamName,
			@Badge,
			@Wins,
			@Draws,
			@Loses,
			@GoalsFor,
			@GoalsAgainst,
			@Group
		)
	END
ELSE
	BEGIN
		UPDATE Team 
		SET 
		TeamName=@TeamName, 
		Badge=@Badge,
		Wins=@Wins,
		Draws=@Draws,
		Loses=@Loses,
		GoalsFor=@GoalsFor,
		GoalsAgainst=@GoalsAgainst,
		[Group]=@Group
		WHERE ID=@ID;
	END
END
GO

CREATE PROCEDURE Team_Delete
(
	@ID int
)
AS
BEGIN
	DELETE FROM Team
	WHERE ID=@ID;
END
GO

CREATE PROCEDURE Match_GetMatches
AS
BEGIN
	SELECT * 
	FROM [Match];
END
GO

CREATE PROCEDURE Match_GetMatch
(
	@ID int = NULL
)
AS
BEGIN
	SELECT *
	FROM [Match]
	WHERE ID=@ID
END
GO

CREATE PROCEDURE Match_InsertUpdate
(
	@ID int = NULL,
	@HomeTeamId int,
	@HomeGoals int, 
	@AwayTeamId int,
	@AwayGoals int,
	@MatchDate varchar(50),
	@MatchTime varchar(50) = NULL,
	@MatchDayNumber int
)
AS
BEGIN
IF @ID IS NULL
	BEGIN
		INSERT INTO [Match]
		(
			HomeTeamId,
			HomeGoals,
			AwayTeamId,
			AwayGoals,
			MatchDate,
			MatchTime,
			MatchDayNumber
		)
		VALUES
		(
			@HomeTeamId,
			@HomeGoals,
			@AwayTeamId,
			@AwayGoals,
			@MatchDate,
			@MatchTime,
			@MatchDayNumber
		)
	END
ELSE
	BEGIN
		UPDATE [Match] 
		SET 
		HomeTeamId=@HomeTeamId, 
		HomeGoals=@HomeGoals,
		AwayTeamId=@AwayTeamId,
		AwayGoals=@AwayGoals,
		MatchDate=@MatchDate,
		MatchTime=@MatchTime,
		MatchDayNumber=@MatchDayNumber
		WHERE ID=@ID;
	END
END
GO

CREATE PROCEDURE Match_Delete
(
	@ID int
)
AS
BEGIN
	DELETE FROM [Match]
	WHERE ID=@ID;
END
GO