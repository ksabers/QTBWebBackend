SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipiAeroporti](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[descrizione] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_TipiAeroporti] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruoli](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[descrizione] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Ruoli] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aeroporti](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[denominazione] [nvarchar](max) COLLATE Latin1_General_CI_AS NULL,
	[tipo_aeroporto] [bigint] NOT NULL,
	[identificativo] [nvarchar](4) COLLATE Latin1_General_CI_AS NULL,
	[coordinate] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[ICAO] [nvarchar](4) COLLATE Latin1_General_CI_AS NULL,
	[IATA] [nvarchar](3) COLLATE Latin1_General_CI_AS NULL,
	[QNH] [int] NULL,
	[QFU] [nvarchar](10) COLLATE Latin1_General_CI_AS NULL,
	[lunghezza] [int] NULL,
	[asfalto] [bit] NOT NULL CONSTRAINT [DF_Aeroporti_asfalto]  DEFAULT ((0)),
	[radio] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[indirizzo] [nvarchar](100) COLLATE Latin1_General_CI_AS NULL,
	[telefono] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[email] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[web] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[note] [nvarchar](max) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Aeroporti] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Aeroporti] UNIQUE NONCLUSTERED 
(
	[identificativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persone](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[cognome] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[indirizzo] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[citta] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[cap] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[telefono] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[pilota] [bit] NOT NULL CONSTRAINT [DF_Persone_Pilota]  DEFAULT ((0)),
	[minuti_pregressi] [int] NULL,
	[aeroporto_base] [bigint] NULL,
	[tessera] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Persone] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[password] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[persona] [bigint] NOT NULL,
	[ruolo] [bigint] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Aeroporti_1] ON [dbo].[Aeroporti]
(
	[nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [IX_Persone] ON [dbo].[Persone]
(
	[cognome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aeroporti]  WITH CHECK ADD  CONSTRAINT [FK_Aeroporti_TipiAeroporti] FOREIGN KEY([tipo_aeroporto])
REFERENCES [dbo].[TipiAeroporti] ([ID])
GO
ALTER TABLE [dbo].[Aeroporti] CHECK CONSTRAINT [FK_Aeroporti_TipiAeroporti]
GO
ALTER TABLE [dbo].[Persone]  WITH CHECK ADD  CONSTRAINT [FK_Persone_Aeroporti] FOREIGN KEY([aeroporto_base])
REFERENCES [dbo].[Aeroporti] ([ID])
GO
ALTER TABLE [dbo].[Persone] CHECK CONSTRAINT [FK_Persone_Aeroporti]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Persone] FOREIGN KEY([persona])
REFERENCES [dbo].[Persone] ([ID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Persone]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Ruoli] FOREIGN KEY([ruolo])
REFERENCES [dbo].[Ruoli] ([ID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Ruoli]
GO
