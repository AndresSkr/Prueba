USE [PruebaTecnica]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/07/2020 6:22:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 11/07/2020 6:22:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NIT] [int] NOT NULL,
	[nombre] [nvarchar](max) NULL,
	[correo] [nvarchar](max) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[paises]    Script Date: 11/07/2020 6:22:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paises](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombrePais] [nvarchar](max) NULL,
 CONSTRAINT [PK_paises] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicios]    Script Date: 11/07/2020 6:22:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombreServicio] [nvarchar](max) NULL,
	[valorxHora] [decimal](18, 2) NOT NULL,
	[fk_ClienteId] [int] NULL,
 CONSTRAINT [PK_servicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicios_pais]    Script Date: 11/07/2020 6:22:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicios_pais](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fk_IdPaisId] [int] NULL,
	[fK_IdServicioId] [int] NULL,
 CONSTRAINT [PK_servicios_pais] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (1, 1, N'Une', N'une@une.co')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (2, 2, N'Claro', N'claro@claro.co')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (3, 3, N'Toyota', N'toyota@toyota.us')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (4, 4, N'Ferreteria don Juan', N'FerreJuan@gmail.com')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (5, 5, N'Epm', N'epm@soporte.co')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (6, 6, N'Huawei', N'huawei@huawei.us')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (7, 7, N'apple', N'apple@soporte.co')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (8, 8, N'Logitech', N'logi@Logitech.com')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (9, 9, N'Cargarros', N'carrosCargar@gmail.com')
INSERT [dbo].[clientes] ([Id], [NIT], [nombre], [correo]) VALUES (10, 10, N'Casas sili', N'Sili@gmail.com')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[paises] ON 

INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (1, N'Colombia')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (2, N'Peru')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (3, N'Chile')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (4, N'Usa')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (5, N'Canada')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (6, N'Argentina')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (7, N'Mexico')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (8, N'Bolivia')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (9, N'España')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (10, N'Italia')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (11, N'Francia')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (12, N'Paraguay')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (13, N'Uruguay')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (14, N'Venezuela')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (15, N'Ecuador')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (16, N'Suiza')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (17, N'Suecia')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (18, N'China')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (19, N'Japon')
INSERT [dbo].[paises] ([Id], [nombrePais]) VALUES (20, N'Israel')
SET IDENTITY_INSERT [dbo].[paises] OFF
GO
SET IDENTITY_INSERT [dbo].[servicios] ON 

INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (1, N'Soporte', CAST(500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (2, N'Internet', CAST(200.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (3, N'Tv + Internet 30GB', CAST(2000.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (4, N'Agua + luz', CAST(500.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (5, N'Soporte Celulares', CAST(500.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (6, N'Mantenimiento de la casa', CAST(20000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (7, N'Grua para carros', CAST(10000.00 AS Decimal(18, 2)), 9)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (8, N'Arreglos de ferreteria', CAST(20000.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (9, N'Enchapar baños', CAST(50000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[servicios] ([Id], [nombreServicio], [valorxHora], [fk_ClienteId]) VALUES (10, N'Telefono', CAST(100.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[servicios] OFF
GO
SET IDENTITY_INSERT [dbo].[servicios_pais] ON 

INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (1, 3, 1)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (2, 5, 2)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (3, 3, 4)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (4, 7, 5)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (5, 3, 3)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (6, 10, 4)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (7, 2, 5)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (8, 5, 3)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (9, 1, 9)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (10, 3, 8)
INSERT [dbo].[servicios_pais] ([Id], [fk_IdPaisId], [fK_IdServicioId]) VALUES (11, 1, 1)
SET IDENTITY_INSERT [dbo].[servicios_pais] OFF
GO
ALTER TABLE [dbo].[servicios]  WITH CHECK ADD  CONSTRAINT [FK_servicios_clientes_fk_ClienteId] FOREIGN KEY([fk_ClienteId])
REFERENCES [dbo].[clientes] ([Id])
GO
ALTER TABLE [dbo].[servicios] CHECK CONSTRAINT [FK_servicios_clientes_fk_ClienteId]
GO
ALTER TABLE [dbo].[servicios_pais]  WITH CHECK ADD  CONSTRAINT [FK_servicios_pais_paises_fk_IdPaisId] FOREIGN KEY([fk_IdPaisId])
REFERENCES [dbo].[paises] ([Id])
GO
ALTER TABLE [dbo].[servicios_pais] CHECK CONSTRAINT [FK_servicios_pais_paises_fk_IdPaisId]
GO
ALTER TABLE [dbo].[servicios_pais]  WITH CHECK ADD  CONSTRAINT [FK_servicios_pais_servicios_fK_IdServicioId] FOREIGN KEY([fK_IdServicioId])
REFERENCES [dbo].[servicios] ([Id])
GO
ALTER TABLE [dbo].[servicios_pais] CHECK CONSTRAINT [FK_servicios_pais_servicios_fK_IdServicioId]
GO