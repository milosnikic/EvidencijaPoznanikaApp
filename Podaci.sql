USE [EvidencijaPoznanika]
GO
SET IDENTITY_INSERT [dbo].[Osoba] ON 

INSERT [dbo].[Osoba] ([Id], [Maticni_broj], [Ime], [Prezime], [Visina], [Tezina], [Boja_ociju], [Telefon], [Email], [Rodjendan], [Adresa], [Prebivaliste]) VALUES (107, N'0512981717776', N'Uros', N'Stepanovic', 305, NULL, NULL, N'064.547.4844', N'uros.st@gmail.com', CAST(N'1992-11-01T00:00:00.000' AS DateTime), NULL, N'Smederevo')
INSERT [dbo].[Osoba] ([Id], [Maticni_broj], [Ime], [Prezime], [Visina], [Tezina], [Boja_ociju], [Telefon], [Email], [Rodjendan], [Adresa], [Prebivaliste]) VALUES (117, N'3112996710142', N'Milos', N'Nikic', NULL, 80, NULL, N'064.547.4844', N'milos.nikic@gmail.com', CAST(N'2005-11-01T00:00:00.000' AS DateTime), N'', N'Beograd')
INSERT [dbo].[Osoba] ([Id], [Maticni_broj], [Ime], [Prezime], [Visina], [Tezina], [Boja_ociju], [Telefon], [Email], [Rodjendan], [Adresa], [Prebivaliste]) VALUES (124, N'0103993710095', N'Milan', N'Plazinic', NULL, NULL, NULL, NULL, N'milan_plazinic@yahoo.com', CAST(N'1999-12-11T00:00:00.000' AS DateTime), NULL, N'Sombor')
SET IDENTITY_INSERT [dbo].[Osoba] OFF
