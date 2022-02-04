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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipiVoli](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[descrizione] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_TipiVoli] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
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
	[data_nascita] [date] NULL,
	[luogo_nascita] [nvarchar](50) COLLATE Latin1_General_CI_AS NULL,
	[codice_fiscale] [nvarchar](20) COLLATE Latin1_General_CI_AS NULL,
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
CREATE TABLE [dbo].[Voli](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[descrizione] [nvarchar](max) COLLATE Latin1_General_CI_AS NULL,
	[tipo] [bigint] NOT NULL,
	[pilota] [bigint] NOT NULL,
	[passeggero] [bigint] NULL,
	[aereo] [bigint] NOT NULL,
	[ora_inizio]  AS (dateadd(minute, -(([orametro_ore_fine]*(60)+[orametro_minuti_fine])-([orametro_ore_inizio]*(60)+[orametro_minuti_inizio])),[ora_fine])) PERSISTED,
	[ora_locale_decollo] [nvarchar](5) COLLATE Latin1_General_CI_AS NULL,
	[orametro_ore_inizio] [int] NOT NULL,
	[orametro_minuti_inizio] [int] NOT NULL,
	[ora_fine] [datetime] NOT NULL,
	[ora_locale_atterraggio] [nvarchar](5) COLLATE Latin1_General_CI_AS NULL,
	[orametro_ore_fine] [int] NOT NULL,
	[orametro_minuti_fine] [int] NOT NULL,
	[durata]  AS (([orametro_ore_fine]*(60)+[orametro_minuti_fine])-([orametro_ore_inizio]*(60)+[orametro_minuti_inizio])) PERSISTED,
	[carburante_iniziale_sx] [int] NULL,
	[carburante_iniziale_dx] [int] NULL,
	[carburante_aggiunto_sx] [int] NULL,
	[carburante_aggiunto_dx] [int] NULL,
	[olio] [int] NULL,
	[peso_occupanti] [int] NULL,
	[bagaglio] [int] NULL,
	[aeroporto_inizio] [bigint] NOT NULL,
	[aeroporto_fine] [bigint] NOT NULL,
 CONSTRAINT [PK_Voli] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

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
ALTER TABLE [dbo].[Voli]  WITH CHECK ADD  CONSTRAINT [FK_Voli_Aerei] FOREIGN KEY([aereo])
REFERENCES [dbo].[Aerei] ([ID])
GO
ALTER TABLE [dbo].[Voli] CHECK CONSTRAINT [FK_Voli_Aerei]
GO
ALTER TABLE [dbo].[Voli]  WITH CHECK ADD  CONSTRAINT [FK_Voli_Aeroporti] FOREIGN KEY([aeroporto_inizio])
REFERENCES [dbo].[Aeroporti] ([ID])
GO
ALTER TABLE [dbo].[Voli] CHECK CONSTRAINT [FK_Voli_Aeroporti]
GO
ALTER TABLE [dbo].[Voli]  WITH CHECK ADD  CONSTRAINT [FK_Voli_Aeroporti1] FOREIGN KEY([aeroporto_fine])
REFERENCES [dbo].[Aeroporti] ([ID])
GO
ALTER TABLE [dbo].[Voli] CHECK CONSTRAINT [FK_Voli_Aeroporti1]
GO
ALTER TABLE [dbo].[Voli]  WITH CHECK ADD  CONSTRAINT [FK_Voli_Persone] FOREIGN KEY([pilota])
REFERENCES [dbo].[Persone] ([ID])
GO
ALTER TABLE [dbo].[Voli] CHECK CONSTRAINT [FK_Voli_Persone]
GO
ALTER TABLE [dbo].[Voli]  WITH CHECK ADD  CONSTRAINT [FK_Voli_Persone1] FOREIGN KEY([passeggero])
REFERENCES [dbo].[Persone] ([ID])
GO
ALTER TABLE [dbo].[Voli] CHECK CONSTRAINT [FK_Voli_Persone1]
GO
ALTER TABLE [dbo].[Voli]  WITH CHECK ADD  CONSTRAINT [FK_Voli_TipiVoli] FOREIGN KEY([tipo])
REFERENCES [dbo].[TipiVoli] ([ID])
GO
ALTER TABLE [dbo].[Voli] CHECK CONSTRAINT [FK_Voli_TipiVoli]
GO
