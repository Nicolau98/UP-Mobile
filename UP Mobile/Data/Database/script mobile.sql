USE [master]
GO
/****** Object:  Database [UP Mobile]    Script Date: 11/02/2021 09:57:18 ******/
CREATE DATABASE [UP Mobile]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UP Mobile', FILENAME = N'C:\Users\xxx\UP Mobile.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UP Mobile_log', FILENAME = N'C:\Users\xxx\UP Mobile_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UP Mobile] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UP Mobile].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UP Mobile] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UP Mobile] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UP Mobile] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UP Mobile] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UP Mobile] SET ARITHABORT OFF 
GO
ALTER DATABASE [UP Mobile] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UP Mobile] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UP Mobile] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UP Mobile] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UP Mobile] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UP Mobile] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UP Mobile] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UP Mobile] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UP Mobile] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UP Mobile] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UP Mobile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UP Mobile] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UP Mobile] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UP Mobile] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UP Mobile] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UP Mobile] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UP Mobile] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UP Mobile] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UP Mobile] SET  MULTI_USER 
GO
ALTER DATABASE [UP Mobile] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UP Mobile] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UP Mobile] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UP Mobile] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UP Mobile] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UP Mobile] SET QUERY_STORE = OFF
GO
USE [UP Mobile]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [UP Mobile]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[Id_Administrador] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Data_Nascimento] [date] NOT NULL,
	[Morada] [nvarchar](50) NOT NULL,
	[Contacto] [int] NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[Local_Trabalho] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[Id_Administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Data_Nascimento] [date] NOT NULL,
	[Morada] [nvarchar](50) NOT NULL,
	[Contacto] [int] NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[N_Contribuinte] [int] NOT NULL,
	[N_Identificacao] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conteudo_Extra]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conteudo_Extra](
	[Id_Conteudo] [int] NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Data_Inicio_Comercializacao] [date] NOT NULL,
	[Data_Fim_Comercializacao] [date] NULL,
	[Preco] [int] NULL,
 CONSTRAINT [PK_Conteudo_Extra] PRIMARY KEY CLUSTERED 
(
	[Id_Conteudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato](
	[Id_Contrato] [int] NOT NULL,
	[Data_Inicio] [datetime] NOT NULL,
	[Data_Fim] [datetime] NULL,
	[Morada_Faturacao] [nvarchar](50) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Data_Fidelizacao] [date] NULL,
	[Id_Operador] [int] NULL,
	[Nome_Cliente] [nvarchar](50) NOT NULL,
	[Nome_Operador] [nvarchar](50) NULL,
	[Preco_Base_Inicio_Contrato] [int] NOT NULL,
	[Id_Pacote_Comercial_Promocao] [int] NOT NULL,
	[Preco_Total] [int] NOT NULL,
	[Conteudo_Extra_Total] [int] NULL,
 CONSTRAINT [PK_Contrato] PRIMARY KEY CLUSTERED 
(
	[Id_Contrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato_Conteudo]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato_Conteudo](
	[Id_Contrato_Conteudo] [int] NOT NULL,
	[Id_Conteudo] [int] NOT NULL,
	[Id_Contrato] [int] NOT NULL,
	[Data_Inicio_Conteudo] [date] NOT NULL,
	[Data_Fim_Conteudo] [date] NULL,
 CONSTRAINT [PK_Contrato_Conteudo] PRIMARY KEY CLUSTERED 
(
	[Id_Contrato_Conteudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fatura]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fatura](
	[Id_Fatura] [int] NOT NULL,
	[Id_Contrato] [int] NOT NULL,
	[Data] [date] NOT NULL,
	[Data_Limite_Pagamento] [date] NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Preco_Total] [int] NOT NULL,
 CONSTRAINT [PK_Fatura] PRIMARY KEY CLUSTERED 
(
	[Id_Fatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operador]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operador](
	[Id_Operador] [int] NOT NULL,
	[Nome] [nvarchar](10) NOT NULL,
	[Data_Nascimento] [date] NOT NULL,
	[Morada] [nvarchar](50) NOT NULL,
	[Contacto] [int] NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[Local_Trabalho] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Operador] PRIMARY KEY CLUSTERED 
(
	[Id_Operador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacote__Comercial]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacote__Comercial](
	[Id_Pacote] [int] NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Data_Inicio_Comercializacao] [datetime] NOT NULL,
	[Data_Fim_Comercializacao] [datetime] NULL,
	[Preco_base] [int] NOT NULL,
	[Periodo_Fidelizacao] [int] NULL,
 CONSTRAINT [PK_Pacote__Comercial] PRIMARY KEY CLUSTERED 
(
	[Id_Pacote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacote_Comercial_Promocao]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacote_Comercial_Promocao](
	[Id_Pacote_Comercial_Promocao] [int] NOT NULL,
	[Id_Promocao] [int] NOT NULL,
	[Id_Pacote] [int] NOT NULL,
 CONSTRAINT [PK_Pacote_Comercial_Promocao] PRIMARY KEY CLUSTERED 
(
	[Id_Pacote_Comercial_Promocao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocao]    Script Date: 11/02/2021 09:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocao](
	[Id_Promocao] [int] NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Data_Inicio_Comercializacao] [date] NOT NULL,
	[Data_Fim_Comercializacao] [date] NULL,
	[Preco] [int] NOT NULL,
	[Conteudo] [nchar](10) NULL,
 CONSTRAINT [PK_Promocao] PRIMARY KEY CLUSTERED 
(
	[Id_Promocao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [UN_N_Contribuinte]    Script Date: 11/02/2021 09:57:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UN_N_Contribuinte] ON [dbo].[Cliente]
(
	[N_Contribuinte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UN_N_Identificacao]    Script Date: 11/02/2021 09:57:18 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UN_N_Identificacao] ON [dbo].[Cliente]
(
	[N_Identificacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Cliente] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Cliente]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Operador] FOREIGN KEY([Id_Operador])
REFERENCES [dbo].[Operador] ([Id_Operador])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Operador]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Pacote_Comercial_Promocao1] FOREIGN KEY([Id_Pacote_Comercial_Promocao])
REFERENCES [dbo].[Pacote_Comercial_Promocao] ([Id_Pacote_Comercial_Promocao])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Pacote_Comercial_Promocao1]
GO
ALTER TABLE [dbo].[Contrato_Conteudo]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Conteudo_Conteudo_Extra] FOREIGN KEY([Id_Conteudo])
REFERENCES [dbo].[Conteudo_Extra] ([Id_Conteudo])
GO
ALTER TABLE [dbo].[Contrato_Conteudo] CHECK CONSTRAINT [FK_Contrato_Conteudo_Conteudo_Extra]
GO
ALTER TABLE [dbo].[Contrato_Conteudo]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Conteudo_Contrato] FOREIGN KEY([Id_Contrato])
REFERENCES [dbo].[Contrato] ([Id_Contrato])
GO
ALTER TABLE [dbo].[Contrato_Conteudo] CHECK CONSTRAINT [FK_Contrato_Conteudo_Contrato]
GO
ALTER TABLE [dbo].[Fatura]  WITH CHECK ADD  CONSTRAINT [FK_Fatura_Contrato] FOREIGN KEY([Id_Contrato])
REFERENCES [dbo].[Contrato] ([Id_Contrato])
GO
ALTER TABLE [dbo].[Fatura] CHECK CONSTRAINT [FK_Fatura_Contrato]
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao]  WITH CHECK ADD  CONSTRAINT [FK_Pacote_Comercial_Promocao_Pacote__Comercial] FOREIGN KEY([Id_Pacote])
REFERENCES [dbo].[Pacote__Comercial] ([Id_Pacote])
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao] CHECK CONSTRAINT [FK_Pacote_Comercial_Promocao_Pacote__Comercial]
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao]  WITH CHECK ADD  CONSTRAINT [FK_Pacote_Comercial_Promocao_Promocao] FOREIGN KEY([Id_Promocao])
REFERENCES [dbo].[Promocao] ([Id_Promocao])
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao] CHECK CONSTRAINT [FK_Pacote_Comercial_Promocao_Promocao]
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [CK_Contacto_Administrador] CHECK  (([Contacto]>(0)))
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [CK_Contacto_Administrador]
GO
ALTER TABLE [dbo].[Conteudo_Extra]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Conteudo_Extra] CHECK  (([Preco]>(0)))
GO
ALTER TABLE [dbo].[Conteudo_Extra] CHECK CONSTRAINT [CK_Preco_Conteudo_Extra]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Base_Inicio_Contrato] CHECK  (([Preco_Base_Inicio_Contrato]>(0)))
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_Preco_Base_Inicio_Contrato]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Total] CHECK  (([Preco_Total]>(0)))
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_Preco_Total]
GO
ALTER TABLE [dbo].[Fatura]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Total_Fatura] CHECK  (([Preco_Total]>(0)))
GO
ALTER TABLE [dbo].[Fatura] CHECK CONSTRAINT [CK_Preco_Total_Fatura]
GO
ALTER TABLE [dbo].[Operador]  WITH CHECK ADD  CONSTRAINT [CK_Contacto_Operador] CHECK  (([Contacto]>(0)))
GO
ALTER TABLE [dbo].[Operador] CHECK CONSTRAINT [CK_Contacto_Operador]
GO
ALTER TABLE [dbo].[Pacote__Comercial]  WITH CHECK ADD  CONSTRAINT [CK_Periodo_Fidelizacao] CHECK  (([Periodo_Fidelizacao]>(0) AND [Periodo_Fidelizacao]<(24)))
GO
ALTER TABLE [dbo].[Pacote__Comercial] CHECK CONSTRAINT [CK_Periodo_Fidelizacao]
GO
ALTER TABLE [dbo].[Pacote__Comercial]  WITH CHECK ADD  CONSTRAINT [CK_Preco_base] CHECK  (([Preco_base]>(0)))
GO
ALTER TABLE [dbo].[Pacote__Comercial] CHECK CONSTRAINT [CK_Preco_base]
GO
ALTER TABLE [dbo].[Promocao]  WITH CHECK ADD  CONSTRAINT [CK_Preco] CHECK  (([Preco]>=(0)))
GO
ALTER TABLE [dbo].[Promocao] CHECK CONSTRAINT [CK_Preco]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contacto maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Administrador', @level2type=N'CONSTRAINT',@level2name=N'CK_Contacto_Administrador'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conteudo_Extra', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Conteudo_Extra'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_Base_Inicio_Contrato maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contrato', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Base_Inicio_Contrato'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_Total maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contrato', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Total'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_Total maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fatura', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Total_Fatura'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contacto maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Operador', @level2type=N'CONSTRAINT',@level2name=N'CK_Contacto_Operador'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_base maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacote__Comercial', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_base'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco maior ou igual que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Promocao', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco'
GO
USE [master]
GO
ALTER DATABASE [UP Mobile] SET  READ_WRITE 
GO
