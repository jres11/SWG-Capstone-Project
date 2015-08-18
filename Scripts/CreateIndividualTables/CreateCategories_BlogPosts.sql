USE [SarahsBlog]
GO

/****** Object:  Table [dbo].[Categories_BlogPosts]    Script Date: 8/3/2015 12:56:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories_BlogPosts](
	[BlogPostID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Categories_BlogPosts] PRIMARY KEY CLUSTERED 
(
	[BlogPostID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Categories_BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_Categories_BlogPosts_BlogPosts] FOREIGN KEY([BlogPostID])
REFERENCES [dbo].[BlogPosts] ([BlogPostID])
GO

ALTER TABLE [dbo].[Categories_BlogPosts] CHECK CONSTRAINT [FK_Categories_BlogPosts_BlogPosts]
GO

ALTER TABLE [dbo].[Categories_BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_Categories_BlogPosts_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO

ALTER TABLE [dbo].[Categories_BlogPosts] CHECK CONSTRAINT [FK_Categories_BlogPosts_Categories]
GO


