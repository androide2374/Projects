USE [master]
GO
	/****** Object:  Database [VecFleet]    Script Date: 9/26/2022 11:47:33 PM ******/
	CREATE DATABASE [VecFleet] ALTER DATABASE [VecFleet]
SET
	COMPATIBILITY_LEVEL = 150
GO
	IF (
		1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')
	) begin EXEC [VecFleet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
	ALTER DATABASE [VecFleet]
SET
	ANSI_NULL_DEFAULT OFF
GO
	ALTER DATABASE [VecFleet]
SET
	ANSI_NULLS OFF
GO
	ALTER DATABASE [VecFleet]
SET
	ANSI_PADDING OFF
GO
	ALTER DATABASE [VecFleet]
SET
	ANSI_WARNINGS OFF
GO
	ALTER DATABASE [VecFleet]
SET
	ARITHABORT OFF
GO
	ALTER DATABASE [VecFleet]
SET
	AUTO_CLOSE OFF
GO
	ALTER DATABASE [VecFleet]
SET
	AUTO_SHRINK OFF
GO
	ALTER DATABASE [VecFleet]
SET
	AUTO_UPDATE_STATISTICS ON
GO
	ALTER DATABASE [VecFleet]
SET
	CURSOR_CLOSE_ON_COMMIT OFF
GO
	ALTER DATABASE [VecFleet]
SET
	CURSOR_DEFAULT GLOBAL
GO
	ALTER DATABASE [VecFleet]
SET
	CONCAT_NULL_YIELDS_NULL OFF
GO
	ALTER DATABASE [VecFleet]
SET
	NUMERIC_ROUNDABORT OFF
GO
	ALTER DATABASE [VecFleet]
SET
	QUOTED_IDENTIFIER OFF
GO
	ALTER DATABASE [VecFleet]
SET
	RECURSIVE_TRIGGERS OFF
GO
	ALTER DATABASE [VecFleet]
SET
	DISABLE_BROKER
GO
	ALTER DATABASE [VecFleet]
SET
	AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
	ALTER DATABASE [VecFleet]
SET
	DATE_CORRELATION_OPTIMIZATION OFF
GO
	ALTER DATABASE [VecFleet]
SET
	TRUSTWORTHY OFF
GO
	ALTER DATABASE [VecFleet]
SET
	ALLOW_SNAPSHOT_ISOLATION OFF
GO
	ALTER DATABASE [VecFleet]
SET
	PARAMETERIZATION SIMPLE
GO
	ALTER DATABASE [VecFleet]
SET
	READ_COMMITTED_SNAPSHOT OFF
GO
	ALTER DATABASE [VecFleet]
SET
	HONOR_BROKER_PRIORITY OFF
GO
	ALTER DATABASE [VecFleet]
SET
	RECOVERY FULL
GO
	ALTER DATABASE [VecFleet]
SET
	MULTI_USER
GO
	ALTER DATABASE [VecFleet]
SET
	PAGE_VERIFY CHECKSUM
GO
	ALTER DATABASE [VecFleet]
SET
	DB_CHAINING OFF
GO
	ALTER DATABASE [VecFleet]
SET
	FILESTREAM(NON_TRANSACTED_ACCESS = OFF)
GO
	ALTER DATABASE [VecFleet]
SET
	TARGET_RECOVERY_TIME = 60 SECONDS
GO
	ALTER DATABASE [VecFleet]
SET
	DELAYED_DURABILITY = DISABLED
GO
	ALTER DATABASE [VecFleet]
SET
	ACCELERATED_DATABASE_RECOVERY = OFF
GO
	EXEC sys.sp_db_vardecimal_storage_format N'VecFleet',
	N 'ON'
GO
	ALTER DATABASE [VecFleet]
SET
	QUERY_STORE = OFF
GO
	USE [VecFleet]
GO
	/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 9/26/2022 11:47:34 PM ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE TABLE [dbo].[TipoVehiculo](
		[id] [int] IDENTITY(1, 1) NOT NULL,
		[descripcion] [varchar](50) NOT NULL,
		[estado] [bit] NOT NULL,
		CONSTRAINT [PK_TipoVehiculo] PRIMARY KEY CLUSTERED ([id] ASC) WITH (
			PAD_INDEX = OFF,
			STATISTICS_NORECOMPUTE = OFF,
			IGNORE_DUP_KEY = OFF,
			ALLOW_ROW_LOCKS = ON,
			ALLOW_PAGE_LOCKS = ON,
			OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
		) ON [PRIMARY]
	) ON [PRIMARY]
GO
	/****** Object:  Table [dbo].[Vehiculos]    Script Date: 9/26/2022 11:47:34 PM ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE TABLE [dbo].[Vehiculos](
		[id] [int] IDENTITY(1, 1) NOT NULL,
		[marca] [varchar](50) NOT NULL,
		[cantidadRuedas] [int] NOT NULL,
		[modelo] [varchar](50) NOT NULL,
		[patente] [varchar](50) NOT NULL,
		[chasis] [varchar](50) NOT NULL,
		[kmsRecorrido] [bigint] NOT NULL,
		[kmsProximoMantenimiento] [bigint] NOT NULL,
		[anio] [int] NOT NULL,
		[fechaRegistro] [datetime] NOT NULL,
		[idTipoVehiculo] [int] NOT NULL,
		CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED ([id] ASC) WITH (
			PAD_INDEX = OFF,
			STATISTICS_NORECOMPUTE = OFF,
			IGNORE_DUP_KEY = OFF,
			ALLOW_ROW_LOCKS = ON,
			ALLOW_PAGE_LOCKS = ON,
			OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
		) ON [PRIMARY]
	) ON [PRIMARY]
GO
SET
	IDENTITY_INSERT [dbo].[TipoVehiculo] ON
INSERT
	[dbo].[TipoVehiculo] ([id], [descripcion], [estado])
VALUES
	(1, N'Auto', 1)
INSERT
	[dbo].[TipoVehiculo] ([id], [descripcion], [estado])
VALUES
	(2, N'Moto', 1)
INSERT
	[dbo].[TipoVehiculo] ([id], [descripcion], [estado])
VALUES
	(3, N'Camioneta', 1)
INSERT
	[dbo].[TipoVehiculo] ([id], [descripcion], [estado])
VALUES
	(4, N'Utilitario', 1)
SET
	IDENTITY_INSERT [dbo].[TipoVehiculo] OFF
GO
SET
	IDENTITY_INSERT [dbo].[Vehiculos] ON
INSERT
	[dbo].[Vehiculos] (
		[id],
		[marca],
		[cantidadRuedas],
		[modelo],
		[patente],
		[chasis],
		[kmsRecorrido],
		[kmsProximoMantenimiento],
		[anio],
		[fechaRegistro],
		[idTipoVehiculo]
	)
VALUES
	(
		5,
		N'123123',
		4,
		N'123',
		N'12312',
		N'1ads',
		123,
		123,
		123,
		CAST(N'2022-09-26T23:34:14.930' AS DateTime),
		1
	)
INSERT
	[dbo].[Vehiculos] (
		[id],
		[marca],
		[cantidadRuedas],
		[modelo],
		[patente],
		[chasis],
		[kmsRecorrido],
		[kmsProximoMantenimiento],
		[anio],
		[fechaRegistro],
		[idTipoVehiculo]
	)
VALUES
	(
		6,
		N'123123',
		4,
		N'123',
		N'12312',
		N'1ads',
		123,
		123,
		123,
		CAST(N'2022-09-26T23:34:29.767' AS DateTime),
		1
	)
INSERT
	[dbo].[Vehiculos] (
		[id],
		[marca],
		[cantidadRuedas],
		[modelo],
		[patente],
		[chasis],
		[kmsRecorrido],
		[kmsProximoMantenimiento],
		[anio],
		[fechaRegistro],
		[idTipoVehiculo]
	)
VALUES
	(
		7,
		N'123123',
		4,
		N'123',
		N'12312',
		N'1ads',
		123,
		123,
		123,
		CAST(N'2022-09-26T23:34:43.507' AS DateTime),
		1
	)
INSERT
	[dbo].[Vehiculos] (
		[id],
		[marca],
		[cantidadRuedas],
		[modelo],
		[patente],
		[chasis],
		[kmsRecorrido],
		[kmsProximoMantenimiento],
		[anio],
		[fechaRegistro],
		[idTipoVehiculo]
	)
VALUES
	(
		8,
		N'123123',
		4,
		N'123',
		N'12312',
		N'1ads',
		123,
		123,
		123,
		CAST(N'2022-09-26T23:34:52.020' AS DateTime),
		1
	)
INSERT
	[dbo].[Vehiculos] (
		[id],
		[marca],
		[cantidadRuedas],
		[modelo],
		[patente],
		[chasis],
		[kmsRecorrido],
		[kmsProximoMantenimiento],
		[anio],
		[fechaRegistro],
		[idTipoVehiculo]
	)
VALUES
	(
		9,
		N'123123',
		4,
		N'123',
		N'12312',
		N'1ads',
		123,
		123,
		123,
		CAST(N'2022-09-26T23:35:09.413' AS DateTime),
		1
	)
SET
	IDENTITY_INSERT [dbo].[Vehiculos] OFF
GO
ALTER TABLE
	[dbo].[Vehiculos] WITH CHECK
ADD
	CONSTRAINT [FK_Vehiculos_TipoVehiculo] FOREIGN KEY([idTipoVehiculo]) REFERENCES [dbo].[TipoVehiculo] ([id])
GO
ALTER TABLE
	[dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_TipoVehiculo]
GO
	USE [master]
GO
	ALTER DATABASE [VecFleet]
SET
	READ_WRITE
GO