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


INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (1, N'Bács-Kiskun', N'Kecskemét', 119, 511419, 8443)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (2, N'Baranya', N'Pécs', 301, 368135, 4430)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (3, N'Békés', N'Békéscsaba', 75, 347058, 5630)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (4, N'Borsod-Abaúj-Zemplén', N'Miskolc', 358, 660549, 7247)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (5, N'Csongrád', N'Szeged', 60, 404459, 4262)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (6, N'Fejér', N'Székesfehérvár', 108, 418486, 4358)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (7, N'Gyor-Moson-Sopron', N'Gyor', 183, 455217, 4208)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (8, N'Hajdú-Bihar', N'Debrecen', 82, 534974, 6209)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (9, N'Heves', N'Eger', 121, 299219, 3637)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (10, N'Jász-Nagykun-Szolnok', N'Szolnok', 78, 376334, 5581)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (11, N'Komárom-Esztergom', N'Tatabánya', 76, 297914, 2264)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (12, N'Nógrád', N'Salgótarján', 131, 193946, 2544)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (13, N'Pest', N'Budapest', 187, 1234541, 6390)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (14, N'Somogy', N'Kaposvár', 246, 309115, 6065)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (15, N'Szabolcs-Szatmár-Bereg', N'Nyíregyháza', 229, 563075, 5933)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (16, N'Tolna', N'Szekszárd', 109, 223618, 3703)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (17, N'Vas', N'Szombathely', 216, 253689, 3336)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (18, N'Veszprém', N'Veszprém', 217, 344302, 4463)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (19, N'Zala', N'Zalaegerszeg', 258, 275027, 3784)
INSERT INTO [dbo].[Megyek] ([Id], [Nev], [Szekhely], [TelepulesekSzama], [Nepesseg], [Terulet]) VALUES (20, N'Budapest (fováros)', NULL, 23, 1759407, 525)

INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (1, N'Elem', 1200, 72)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (2, N'Bicikli', 20000, 36)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (3, N'Ceruza', 200, 35)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (4, N'Pohár', 500, 64)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (5, N'Könyv', 2000, 5)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (6, N'Egér', 4000, 6)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (7, N'Lámpa', 3500, 48)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (8, N'TV', 19000, 38)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (9, N'Ágy', 35000, 80)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (10, N'Bicikli', 20000, 14)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (11, N'Ceruza', 200, 14)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (12, N'Pohár', 500, 80)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (13, N'Könyv', 2000, 40)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (14, N'Egér', 4000, 39)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (15, N'Lámpa', 3500, 33)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (16, N'TV', 19000, 55)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (17, N'Ágy', 35000, 48)
INSERT INTO [dbo].[Termekek] ([Id], [TermekNeve], [Ara], [LeltarMennyiseg]) VALUES (18, N'Ablak', 14000, 73)

INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (1, N'Kis Béla', N'kis.bela@gmail.com', N'2015-06-15 00:00:00', 13)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (2, N'Nagy Benedek', N'nagy.be@gmail.com', N'2015-08-10 00:00:00', 9)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (3, N'Arany Alma', N'aranyalma@outlook.com', N'2015-08-12 00:00:00', 15)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (4, N'Nagy Alfréd', N'Nagya@outlook.com', N'2015-08-30 00:00:00', 9)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (5, N'Kovács Béla', N'kov.bel@gmail.com', N'2015-09-05 00:00:00', 13)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (6, N'Thimár Alisz', N'Tia@outlook.com', N'2015-09-10 00:00:00', 17)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (7, N'Major Anna', N'ma@outlook.com', N'2015-09-25 00:00:00', 9)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (8, N'József Benedek', N'jobe@gmail.com', N'2015-11-05 00:00:00', 14)
INSERT INTO [dbo].[Vasarlok] ([Id], [Nev], [Email], [RegDate], [Megye]) VALUES (9, N'Major Sándor', N'major.sanyi@outlook.com', N'2015-07-30 00:00:00', 9)

INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (1, 1, N'2015-08-19 00:00:00', 3)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (6, 2, N'2015-06-08 00:00:00', 4)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (3, 4, N'2015-07-23 00:00:00', 9)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (5, 4, N'2015-09-17 00:00:00', 4)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (6, 4, N'2015-07-01 00:00:00', 10)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (6, 4, N'2015-09-21 00:00:00', 4)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (7, 4, N'2015-04-28 00:00:00', 1)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (3, 5, N'2015-07-13 00:00:00', 2)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (4, 5, N'2015-07-07 00:00:00', 7)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (5, 5, N'2015-06-02 00:00:00', 1)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (5, 5, N'2015-08-07 00:00:00', 3)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (4, 6, N'2015-04-29 00:00:00', 8)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (3, 7, N'2015-08-25 00:00:00', 5)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (4, 7, N'2015-04-15 00:00:00', 6)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (6, 7, N'2015-04-01 00:00:00', 5)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (4, 8, N'2015-06-11 00:00:00', 4)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (4, 9, N'2015-07-06 00:00:00', 6)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (5, 9, N'2015-08-28 00:00:00', 3)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (6, 10, N'2015-07-14 00:00:00', 3)
INSERT INTO [dbo].[Vasarlasok] ([VasarloId], [TermekId], [VasarlasDatuma], [Mennyiseg]) VALUES (7, 10, N'2015-05-08 00:00:00', 3)
