USE [master]
GO
/****** Object:  Database [UPMobile]    Script Date: 01/04/2021 09:53:38 ******/
CREATE DATABASE [UPMobile]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UP Mobile', FILENAME = N'C:\Users\feijo\UP Mobile.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UP Mobile_log', FILENAME = N'C:\Users\feijo\UP Mobile_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UPMobile] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UPMobile].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UPMobile] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UPMobile] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UPMobile] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UPMobile] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UPMobile] SET ARITHABORT OFF 
GO
ALTER DATABASE [UPMobile] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UPMobile] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UPMobile] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UPMobile] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UPMobile] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UPMobile] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UPMobile] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UPMobile] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UPMobile] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UPMobile] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UPMobile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UPMobile] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UPMobile] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UPMobile] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UPMobile] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UPMobile] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UPMobile] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UPMobile] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UPMobile] SET  MULTI_USER 
GO
ALTER DATABASE [UPMobile] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UPMobile] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UPMobile] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UPMobile] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UPMobile] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UPMobile] SET QUERY_STORE = OFF
GO
USE [UPMobile]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [UPMobile]
GO
/****** Object:  Table [dbo].[Conteudo_Extra]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conteudo_Extra](
	[Id_Conteudo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Data_Inicio_Comercializacao] [date] NOT NULL,
	[Data_Fim_Comercializacao] [date] NULL,
	[Preco] [decimal](5, 2) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Conteudo_Extra] PRIMARY KEY CLUSTERED 
(
	[Id_Conteudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato](
	[Id_Contrato] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_Operador] [int] NULL,
	[Id_Pacote_Comercial_Promocao] [int] NOT NULL,
	[Data_Inicio_Contrato] [datetime] NOT NULL,
	[Data_Fim_Contrato] [datetime] NULL,
	[Morada_Faturacao] [nvarchar](100) NOT NULL,
	[Data_Fidelizacao] [date] NULL,
	[Preco_Base_Inicio_Contrato] [decimal](5, 2) NOT NULL,
	[Preco_Total] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Contrato] PRIMARY KEY CLUSTERED 
(
	[Id_Contrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato_Conteudo]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato_Conteudo](
	[Id_Contrato_Conteudo] [int] IDENTITY(1,1) NOT NULL,
	[Id_Conteudo] [int] NOT NULL,
	[Id_Contrato] [int] NOT NULL,
	[Data_Inicio_Conteudo] [datetime] NOT NULL,
	[Data_Fim_Conteudo] [datetime] NULL,
 CONSTRAINT [PK_Contrato_Conteudo] PRIMARY KEY CLUSTERED 
(
	[Id_Contrato_Conteudo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[Id_Distrito] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Distrito] PRIMARY KEY CLUSTERED 
(
	[Id_Distrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fatura]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fatura](
	[Id_Fatura] [int] IDENTITY(1,1) NOT NULL,
	[Id_Contrato] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Data_Limite_Pagamento] [date] NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Preco_Total] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Fatura] PRIMARY KEY CLUSTERED 
(
	[Id_Fatura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacote__Comercial]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacote__Comercial](
	[Id_Pacote] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](500) NULL,
	[Data_Inicio_Comercializacao] [date] NOT NULL,
	[Data_Fim_Comercializacao] [date] NULL,
	[Preco_base] [decimal](5, 2) NOT NULL,
	[Periodo_Fidelizacao] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Internet] [nvarchar](50) NULL,
	[Voz] [nvarchar](50) NULL,
	[Tv] [nvarchar](50) NULL,
	[Movel] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pacote__Comercial] PRIMARY KEY CLUSTERED 
(
	[Id_Pacote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacote_Comercial_Promocao]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacote_Comercial_Promocao](
	[Id_Pacote_Comercial_Promocao] [int] IDENTITY(1,1) NOT NULL,
	[Id_Promocao] [int] NOT NULL,
	[Id_Pacote] [int] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Preco_total_pacote] [decimal](5, 2) NOT NULL,
	[Id_Distrito] [int] NOT NULL,
 CONSTRAINT [PK_Pacote_Comercial_Promocao] PRIMARY KEY CLUSTERED 
(
	[Id_Pacote_Comercial_Promocao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocao]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocao](
	[Id_Promocao] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Data_Inicio] [date] NOT NULL,
	[Data_Fim] [date] NULL,
	[Preco] [decimal](5, 2) NOT NULL,
	[Conteudo] [nvarchar](50) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Promocao] PRIMARY KEY CLUSTERED 
(
	[Id_Promocao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reclamacao]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reclamacao](
	[Id_Reclamacao] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_Operador] [int] NULL,
	[Data_Abertura] [datetime] NOT NULL,
	[Assunto] [nvarchar](250) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Id_Estado] [int] NOT NULL,
	[Data_Resolucao] [datetime] NULL,
	[Resolucao] [nvarchar](500) NULL,
 CONSTRAINT [PK_Reclamacao] PRIMARY KEY CLUSTERED 
(
	[Id_Reclamacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id_Role] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizador]    Script Date: 01/04/2021 09:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizador](
	[Id_Utilizador] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Data_Nascimento] [date] NOT NULL,
	[Morada] [nvarchar](100) NOT NULL,
	[Contacto] [nvarchar](9) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[N_Contribuinte] [nvarchar](9) NOT NULL,
	[N_Identificacao] [nvarchar](8) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Local_Trabalho] [nvarchar](100) NULL,
	[Id_Role] [int] NOT NULL,
	[Data_Criacao] [datetime] NOT NULL,
	[Id_Distrito] [int] NOT NULL,
 CONSTRAINT [PK_Utilizador] PRIMARY KEY CLUSTERED 
(
	[Id_Utilizador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Distrito]    Script Date: 01/04/2021 09:53:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Distrito] ON [dbo].[Distrito]
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_Contribuinte]    Script Date: 01/04/2021 09:53:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UN_Contribuinte] ON [dbo].[Utilizador]
(
	[N_Contribuinte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UN_Identificacao]    Script Date: 01/04/2021 09:53:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UN_Identificacao] ON [dbo].[Utilizador]
(
	[N_Identificacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Pacote_Comercial_Promocao] FOREIGN KEY([Id_Pacote_Comercial_Promocao])
REFERENCES [dbo].[Pacote_Comercial_Promocao] ([Id_Pacote_Comercial_Promocao])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Pacote_Comercial_Promocao]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Utilizador] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Utilizador] ([Id_Utilizador])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Utilizador]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Utilizador1] FOREIGN KEY([Id_Operador])
REFERENCES [dbo].[Utilizador] ([Id_Utilizador])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Utilizador1]
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
ALTER TABLE [dbo].[Pacote_Comercial_Promocao]  WITH CHECK ADD  CONSTRAINT [FK_Pacote_Comercial_Promocao_Distrito] FOREIGN KEY([Id_Distrito])
REFERENCES [dbo].[Distrito] ([Id_Distrito])
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao] CHECK CONSTRAINT [FK_Pacote_Comercial_Promocao_Distrito]
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
ALTER TABLE [dbo].[Reclamacao]  WITH CHECK ADD  CONSTRAINT [FK_Reclamacao_Estado] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estado] ([Id_Estado])
GO
ALTER TABLE [dbo].[Reclamacao] CHECK CONSTRAINT [FK_Reclamacao_Estado]
GO
ALTER TABLE [dbo].[Reclamacao]  WITH CHECK ADD  CONSTRAINT [FK_Reclamacao_Utilizador] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Utilizador] ([Id_Utilizador])
GO
ALTER TABLE [dbo].[Reclamacao] CHECK CONSTRAINT [FK_Reclamacao_Utilizador]
GO
ALTER TABLE [dbo].[Reclamacao]  WITH CHECK ADD  CONSTRAINT [FK_Reclamacao_Utilizador1] FOREIGN KEY([Id_Operador])
REFERENCES [dbo].[Utilizador] ([Id_Utilizador])
GO
ALTER TABLE [dbo].[Reclamacao] CHECK CONSTRAINT [FK_Reclamacao_Utilizador1]
GO
ALTER TABLE [dbo].[Utilizador]  WITH CHECK ADD  CONSTRAINT [FK_Utilizador_Distrito] FOREIGN KEY([Id_Distrito])
REFERENCES [dbo].[Distrito] ([Id_Distrito])
GO
ALTER TABLE [dbo].[Utilizador] CHECK CONSTRAINT [FK_Utilizador_Distrito]
GO
ALTER TABLE [dbo].[Utilizador]  WITH CHECK ADD  CONSTRAINT [FK_Utilizador_Role] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Role] ([Id_Role])
GO
ALTER TABLE [dbo].[Utilizador] CHECK CONSTRAINT [FK_Utilizador_Role]
GO
ALTER TABLE [dbo].[Conteudo_Extra]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Conteudo_Extra] CHECK  (([Preco]>(0)))
GO
ALTER TABLE [dbo].[Conteudo_Extra] CHECK CONSTRAINT [CK_Preco_Conteudo_Extra]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Base_Inicio_Contrato] CHECK  (([Preco_Base_Inicio_Contrato]>(0)))
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_Preco_Base_Inicio_Contrato]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_Preco_Total] CHECK  (([Preco_Total]>=(0)))
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_Preco_Total]
GO
ALTER TABLE [dbo].[Fatura]  WITH CHECK ADD  CONSTRAINT [CK_Fatura] CHECK  (([Preco_Total]>=(0)))
GO
ALTER TABLE [dbo].[Fatura] CHECK CONSTRAINT [CK_Fatura]
GO
ALTER TABLE [dbo].[Pacote__Comercial]  WITH CHECK ADD  CONSTRAINT [CK_Periodo_Fidelizacao] CHECK  (([Periodo_Fidelizacao]>=(0) AND [Periodo_Fidelizacao]<=(24)))
GO
ALTER TABLE [dbo].[Pacote__Comercial] CHECK CONSTRAINT [CK_Periodo_Fidelizacao]
GO
ALTER TABLE [dbo].[Pacote__Comercial]  WITH CHECK ADD  CONSTRAINT [CK_Preco_base] CHECK  (([Preco_base]>(0)))
GO
ALTER TABLE [dbo].[Pacote__Comercial] CHECK CONSTRAINT [CK_Preco_base]
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao]  WITH CHECK ADD  CONSTRAINT [Preco_total_pacote] CHECK  (([Preco_total_pacote]>=(0)))
GO
ALTER TABLE [dbo].[Pacote_Comercial_Promocao] CHECK CONSTRAINT [Preco_total_pacote]
GO
ALTER TABLE [dbo].[Promocao]  WITH CHECK ADD  CONSTRAINT [CK_Preco] CHECK  (([Preco]>=(0)))
GO
ALTER TABLE [dbo].[Promocao] CHECK CONSTRAINT [CK_Preco]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Conteudo_Extra', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Conteudo_Extra'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_Base_Inicio_Contrato maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contrato', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Base_Inicio_Contrato'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_Total maior ou igual que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contrato', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_Total'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_total >= 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fatura', @level2type=N'CONSTRAINT',@level2name=N'CK_Fatura'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_base maior que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacote__Comercial', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco_base'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco_total_pacote >= 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pacote_Comercial_Promocao', @level2type=N'CONSTRAINT',@level2name=N'Preco_total_pacote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preco maior ou igual que zero' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Promocao', @level2type=N'CONSTRAINT',@level2name=N'CK_Preco'
GO
USE [master]
GO
ALTER DATABASE [UPMobile] SET  READ_WRITE 
GO
