USE [SarahsBlog]
GO

/****** Object:  Table [dbo].[BlogPosts]    Script Date: 8/3/2015 12:55:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BlogPosts](
	[BlogPostID] [int] IDENTITY(1,1) NOT NULL,
	[PostContents] [nvarchar](max) NOT NULL,
	[UserID] [int] NOT NULL,
	[DateOfPost] [date] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[StatusID] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[BlogPostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPosts_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO

ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPosts_Status]
GO


