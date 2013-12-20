USE [MatrixApi]
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Id], [Body], [UserId], [TicketId], [CreatedAt]) VALUES (1, N'You the man, Tank!', 2, 1, CAST(0x0000A29A01027410 AS DateTime))
INSERT [dbo].[Comment] ([Id], [Body], [UserId], [TicketId], [CreatedAt]) VALUES (3, N'Yes, enter the Matrix. We''ll be waiting.', 4, 1, CAST(0x0000A29A0102BA60 AS DateTime))
INSERT [dbo].[Comment] ([Id], [Body], [UserId], [TicketId], [CreatedAt]) VALUES (4, N'What? Spoons?', 1, 3, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[Comment] ([Id], [Body], [UserId], [TicketId], [CreatedAt]) VALUES (5, N'Do not question the Oracle, she is always right.', 3, 3, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[Comment] ([Id], [Body], [UserId], [TicketId], [CreatedAt]) VALUES (6, N'This is a very poor idea', 4, 5, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[Comment] ([Id], [Body], [UserId], [TicketId], [CreatedAt]) VALUES (8, N'Seriously, knock if off guys. Not funny.', 4, 5, CAST(0x0000A29A00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Title], [Description], [Priority], [Status], [Deadline]) VALUES (1, N'Get Neo''s Phrophecy', N'Find the oracle, don''t get killt, is Neo the one?', N'2', N'0', CAST(0x0000A29A010FE960 AS DateTime))
INSERT [dbo].[Project] ([Id], [Title], [Description], [Priority], [Status], [Deadline]) VALUES (2, N'Get Agent Smith', N'F**k that guy up', N'1', N'0', CAST(0x0000A29F0083D600 AS DateTime))
INSERT [dbo].[Project] ([Id], [Title], [Description], [Priority], [Status], [Deadline]) VALUES (3, N'Save Morpheus', N'We can''t do it without him.', N'2', N'1', CAST(0x0000A13900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (1, 1, N'Get into the Matrix', N'Tank''s thing', N'1', N'1', CAST(0x0000A29A0107AC00 AS DateTime), 5)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (2, 1, N'Find a car & drive the the Oracle''s apartment', N'nuff said', N'1', N'1', CAST(0x0000A29A0107AC00 AS DateTime), 2)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (3, 1, N'Learn about spoons', N'those are some weird kids', N'1', N'1', CAST(0x0000A29A0107AC00 AS DateTime), 1)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (4, 2, N'Find the secret of the Matrix', N'???', N'1', N'1', CAST(0x0000A29F0083D600 AS DateTime), 1)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (5, 2, N'Explode Agent Smith', N'boom.', N'1', N'1', CAST(0x0000A29F0083D600 AS DateTime), 4)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (6, 3, N'Have a major fire fight', N'seriously shoot all the things', N'1', N'1', CAST(0x0000A13900000000 AS DateTime), 2)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (7, 3, N'Fly a helecopter', NULL, N'1', N'1', CAST(0x0000A13900000000 AS DateTime), 2)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (8, 3, N'Shoot a lot moar of the things', NULL, N'1', N'1', CAST(0x0000A13900000000 AS DateTime), 1)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (9, 3, N'Make a dramatic mid-air rescue, twice', N'', N'1', N'1', CAST(0x0000A13900000000 AS DateTime), 1)
INSERT [dbo].[Ticket] ([Id], [ProjectId], [Title], [Description], [Priority], [Status], [Deadline], [UserId]) VALUES (10, 3, N'Phone home', NULL, N'1', N'1', CAST(0x0000A13900000000 AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Password], [Email]) VALUES (1, N'Neo', N'Neo', N'neo@theMatrix.net')
INSERT [dbo].[User] ([Id], [Name], [Password], [Email]) VALUES (2, N'Trinity', N'Neo', N'trinity@theMatrix.net')
INSERT [dbo].[User] ([Id], [Name], [Password], [Email]) VALUES (3, N'Morpheus', N'Neo', N'morpeus@theMatrix.net')
INSERT [dbo].[User] ([Id], [Name], [Password], [Email]) VALUES (4, N'Agent Smith', N'Neo', N'mrSmith@theMatrix.net')
INSERT [dbo].[User] ([Id], [Name], [Password], [Email]) VALUES (5, N'Tank', N'Neo', N'tank@theMatrix.net')
SET IDENTITY_INSERT [dbo].[User] OFF
