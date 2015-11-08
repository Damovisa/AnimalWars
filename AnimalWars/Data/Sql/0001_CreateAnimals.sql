CREATE TABLE [dbo].[Animals](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Category] [varchar](20) NOT NULL,
	[Image] [varchar](max) NULL,
	[Count] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Animals] ADD  CONSTRAINT [DF_Animals_Count]  DEFAULT ((0)) FOR [Count]
GO