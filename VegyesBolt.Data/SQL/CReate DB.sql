CREATE TABLE [dbo].[Megyek] (
    [Id]               FLOAT (53)   NOT NULL,
    [Nev]              VARCHAR (42) NOT NULL,
    [Szekhely]         VARCHAR (50) NULL,
    [TelepulesekSzama] FLOAT (53)   NULL,
    [Nepesseg]         FLOAT (53)   NULL,
    [Terulet]          FLOAT (53)   NULL,
    CONSTRAINT [MEGYEK_PK] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Termekek] (
    [Id]              FLOAT (53)   NOT NULL,
    [TermekNeve]      VARCHAR (30) NULL,
    [Ara]             FLOAT (53)   NULL,
    [AfasAra]         AS           ([Ara]*(1.27)) PERSISTED,
    [LeltarMennyiseg] INT          NULL,
    CONSTRAINT [TERMEKEK_PK] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Vasarlok] (
    [Id]      FLOAT (53)   NOT NULL,
    [Nev]     VARCHAR (30) NOT NULL,
    [Email]   VARCHAR (30) NOT NULL,
    [RegDate] DATETIME     NOT NULL,
    [Megye]   FLOAT (53)   NULL,
    CONSTRAINT [VASARLOK_PK] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [VASARLOK_MEGYEK_ID_FK] FOREIGN KEY ([Megye]) REFERENCES [dbo].[Megyek] ([Id])
);
CREATE TABLE [dbo].[Vasarlasok] (
    [VasarloId]      FLOAT (53) NOT NULL,
    [TermekId]       FLOAT (53) NOT NULL,
    [VasarlasDatuma] DATETIME   NOT NULL,
    [Mennyiseg]      FLOAT (53) NULL,
    CONSTRAINT [VASARLASOK_PK] PRIMARY KEY CLUSTERED ([TermekId] ASC, [VasarloId] ASC, [VasarlasDatuma] ASC),
    CONSTRAINT [VASARLASOK_VASARLOK_ID_FK] FOREIGN KEY ([VasarloId]) REFERENCES [dbo].[Vasarlok] ([Id]),
    CONSTRAINT [VASARLASOK_TERMEKEK_ID_FK] FOREIGN KEY ([TermekId]) REFERENCES [dbo].[Termekek] ([Id])
);



