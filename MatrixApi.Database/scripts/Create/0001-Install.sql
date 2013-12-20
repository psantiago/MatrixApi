PRINT N'Initializing Database...';

PRINT N'Creating [Users]...';
GO
CREATE TABLE [dbo].[User] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
 
	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	) 
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

PRINT N'Creating [Project]...';
GO
CREATE TABLE [dbo].[Project] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Priority] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Deadline] [datetime] NULL,
	
	CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	) 
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

PRINT N'Creating [Ticket]...';
GO
CREATE TABLE [dbo].[Ticket] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Priority] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Deadline] [datetime] NULL,
	[UserId] [int] Null,

	CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	) 
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

PRINT N'Creating [Comment]...';
GO
CREATE TABLE [dbo].[Comment] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](max) NULL,
	[UserId] [int] Null,
	[TicketId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,

	CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	) 
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO