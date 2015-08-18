USE [SarahsBlog]
GO

/****** Object:  Table [dbo].[Comments]    Script Date: 8/3/2015 12:56:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[CommentContent] [nvarchar](max) NOT NULL,
	[BlogPostID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_BlogPosts] FOREIGN KEY([BlogPostID])
REFERENCES [dbo].[BlogPosts] ([BlogPostID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_BlogPosts]
GO


