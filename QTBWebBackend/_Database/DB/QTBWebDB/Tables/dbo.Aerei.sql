SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aerei](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[costruttore] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[modello] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[marche] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[peso_vuoto] [int] NULL,
	[minuti_pregressi] [int] NOT NULL CONSTRAINT [DF_Aerei_minuti_pregressi]  DEFAULT ((0)),
 CONSTRAINT [PK_Aerei] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
