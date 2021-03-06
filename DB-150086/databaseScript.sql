USE [master]
GO
/****** Object:  Database [150086]    Script Date: 08-Apr-19 1:51:21 PM ******/
CREATE DATABASE [150086]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'150086', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\150086.mdf' , SIZE = 47296KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'150086_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\150086_log.ldf' , SIZE = 16832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [150086] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [150086].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [150086] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [150086] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [150086] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [150086] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [150086] SET ARITHABORT OFF 
GO
ALTER DATABASE [150086] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [150086] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [150086] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [150086] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [150086] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [150086] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [150086] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [150086] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [150086] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [150086] SET  ENABLE_BROKER 
GO
ALTER DATABASE [150086] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [150086] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [150086] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [150086] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [150086] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [150086] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [150086] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [150086] SET RECOVERY FULL 
GO
ALTER DATABASE [150086] SET  MULTI_USER 
GO
ALTER DATABASE [150086] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [150086] SET DB_CHAINING OFF 
GO
ALTER DATABASE [150086] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [150086] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [150086] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'150086', N'ON'
GO
USE [150086]
GO
/****** Object:  Table [dbo].[AgeRange]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgeRange](
	[AgeRangeID] [int] IDENTITY(1,1) NOT NULL,
	[Range] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AgeRangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drzava]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drzava](
	[DrzavaID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DrzavaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Event](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](3000) NOT NULL,
	[KreatorID] [int] NOT NULL,
	[AverageRating] [float] NOT NULL,
	[DatumKreiranja] [datetime] NOT NULL,
	[DatumOdrzavanja] [datetime] NOT NULL,
	[VrijemePocetka] [time](7) NULL,
	[VrijemeZavrsetka] [time](7) NULL,
	[Slika] [varbinary](max) NULL,
	[SlikaThumb] [varbinary](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[EventTipID] [int] NOT NULL,
	[OrganizacijaID] [int] NULL,
	[LokacijaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventAgeRange]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventAgeRange](
	[EventID] [int] NOT NULL,
	[AgeRangeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventID] ASC,
	[AgeRangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventGallery]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventGallery](
	[EventGalleryID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](3000) NOT NULL,
	[DatumKreiranja] [datetime] NOT NULL,
	[EventID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventGalleryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventTip]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTip](
	[EventTipID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventTipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventToVisit]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventToVisit](
	[PosjetilacID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
	[Prisustvovao] [bit] NULL,
	[EventRating] [int] NULL,
	[RatingDate] [datetime] NULL,
	[Comment] [nvarchar](3000) NULL,
	[CommentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PosjetilacID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grad]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grad](
	[GradID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[DrzavaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GradID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Korisnik](
	[KorisnikID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Telefon] [nvarchar](20) NULL,
	[KorisnickoIme] [nvarchar](50) NOT NULL,
	[LozinkaHash] [nvarchar](50) NOT NULL,
	[LozinkaSalt] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[Slika] [varbinary](max) NULL,
	[SlikaThumb] [varbinary](max) NULL,
	[GradID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KorisnikUloga]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KorisnikUloga](
	[KorisnikUlogaID] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[UlogaID] [int] NOT NULL,
	[DatumIzmjene] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[KorisnikUlogaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lokacija]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lokacija](
	[LokacijaID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](3000) NULL,
	[Kapacitet] [int] NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[Slika] [varbinary](max) NULL,
	[SlikaThumb] [varbinary](max) NULL,
	[AverageRating] [float] NULL,
	[GradID] [int] NOT NULL,
	[LokacijaTipID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LokacijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LokacijaTip]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LokacijaTip](
	[LokacijaTipID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[LokacijaTipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organizacija]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organizacija](
	[OrganizacijaID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](3000) NULL,
	[Tip] [nvarchar](50) NULL,
	[SlikaLogo] [varbinary](max) NULL,
	[GradID] [int] NOT NULL,
	[AverageRating] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrganizacijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Posjetilac]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posjetilac](
	[PosjetilacID] [int] NOT NULL,
	[BrojPosjecenihDogadjaja] [int] NULL,
	[Zanimanje] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PosjetilacID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PosjetilacLokacija]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosjetilacLokacija](
	[PosjetilacID] [int] NOT NULL,
	[LokacijaID] [int] NOT NULL,
	[LocationRating] [int] NULL,
	[RatingDate] [datetime] NULL,
	[Comment] [nvarchar](3000) NULL,
	[CommentDate] [datetime] NULL,
	[IsFavorite] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PosjetilacID] ASC,
	[LokacijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PosjetilacOrganizacija]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosjetilacOrganizacija](
	[PosjetilacID] [int] NOT NULL,
	[OrganizacijaID] [int] NOT NULL,
	[LocationRating] [int] NULL,
	[RatingDate] [datetime] NULL,
	[Comment] [nvarchar](3000) NULL,
	[CommentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PosjetilacID] ASC,
	[OrganizacijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slika]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Slika](
	[SlikaID] [int] IDENTITY(1,1) NOT NULL,
	[EventGalleryID] [int] NOT NULL,
	[Slika] [varbinary](max) NOT NULL,
	[SlikaThumb] [varbinary](max) NOT NULL,
	[Opis] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SlikaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Uloga]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uloga](
	[UlogaID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Opis] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[UlogaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([EventTipID])
REFERENCES [dbo].[EventTip] ([EventTipID])
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([KreatorID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([LokacijaID])
REFERENCES [dbo].[Lokacija] ([LokacijaID])
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD FOREIGN KEY([OrganizacijaID])
REFERENCES [dbo].[Organizacija] ([OrganizacijaID])
GO
ALTER TABLE [dbo].[EventAgeRange]  WITH CHECK ADD FOREIGN KEY([AgeRangeID])
REFERENCES [dbo].[AgeRange] ([AgeRangeID])
GO
ALTER TABLE [dbo].[EventAgeRange]  WITH CHECK ADD FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[EventGallery]  WITH CHECK ADD FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[EventToVisit]  WITH CHECK ADD FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([EventID])
GO
ALTER TABLE [dbo].[EventToVisit]  WITH CHECK ADD FOREIGN KEY([PosjetilacID])
REFERENCES [dbo].[Posjetilac] ([PosjetilacID])
GO
ALTER TABLE [dbo].[Grad]  WITH CHECK ADD FOREIGN KEY([DrzavaID])
REFERENCES [dbo].[Drzava] ([DrzavaID])
GO
ALTER TABLE [dbo].[Korisnik]  WITH CHECK ADD FOREIGN KEY([GradID])
REFERENCES [dbo].[Grad] ([GradID])
GO
ALTER TABLE [dbo].[KorisnikUloga]  WITH CHECK ADD FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[KorisnikUloga]  WITH CHECK ADD FOREIGN KEY([UlogaID])
REFERENCES [dbo].[Uloga] ([UlogaID])
GO
ALTER TABLE [dbo].[Lokacija]  WITH CHECK ADD FOREIGN KEY([GradID])
REFERENCES [dbo].[Grad] ([GradID])
GO
ALTER TABLE [dbo].[Lokacija]  WITH CHECK ADD FOREIGN KEY([LokacijaTipID])
REFERENCES [dbo].[LokacijaTip] ([LokacijaTipID])
GO
ALTER TABLE [dbo].[Organizacija]  WITH CHECK ADD FOREIGN KEY([GradID])
REFERENCES [dbo].[Grad] ([GradID])
GO
ALTER TABLE [dbo].[Posjetilac]  WITH CHECK ADD  CONSTRAINT [FK_PosjetilacKorisnik] FOREIGN KEY([PosjetilacID])
REFERENCES [dbo].[Korisnik] ([KorisnikID])
GO
ALTER TABLE [dbo].[Posjetilac] CHECK CONSTRAINT [FK_PosjetilacKorisnik]
GO
ALTER TABLE [dbo].[PosjetilacLokacija]  WITH CHECK ADD FOREIGN KEY([LokacijaID])
REFERENCES [dbo].[Lokacija] ([LokacijaID])
GO
ALTER TABLE [dbo].[PosjetilacLokacija]  WITH CHECK ADD FOREIGN KEY([PosjetilacID])
REFERENCES [dbo].[Posjetilac] ([PosjetilacID])
GO
ALTER TABLE [dbo].[PosjetilacOrganizacija]  WITH CHECK ADD FOREIGN KEY([OrganizacijaID])
REFERENCES [dbo].[Organizacija] ([OrganizacijaID])
GO
ALTER TABLE [dbo].[PosjetilacOrganizacija]  WITH CHECK ADD FOREIGN KEY([PosjetilacID])
REFERENCES [dbo].[Posjetilac] ([PosjetilacID])
GO
ALTER TABLE [dbo].[Slika]  WITH CHECK ADD FOREIGN KEY([EventGalleryID])
REFERENCES [dbo].[EventGallery] ([EventGalleryID])
GO
/****** Object:  StoredProcedure [dbo].[GetSlikaByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetSlikaByID]
(
	@SlikaID int
)
as
select SlikaID, EventGalleryID, Slika, SlikaThumb, Opis
from Slika
where SlikaID = @SlikaID

GO
/****** Object:  StoredProcedure [dbo].[esp_AgeRange_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_AgeRange_SelectAll]
as
select AR.AgeRangeID, AR.Range
from AgeRange AS AR

GO
/****** Object:  StoredProcedure [dbo].[esp_EventAgeRange_GetByEvent]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_EventAgeRange_GetByEvent]
(
	@EventID int
)
as
select AR.AgeRangeID, AR.Range
from EventAgeRange as EAR JOIN AgeRange AS AR ON AR.AgeRangeID = EAR.AgeRangeID
where EAR.EventID = @EventID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventAgeRange_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_EventAgeRange_Insert]
(
	@AgeRangeID int,
	@EventID int
)
as
insert into EventAgeRange(AgeRangeID, EventID) values (@AgeRangeID, @EventID) 
select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[esp_EventGallery_GetByEvent]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_EventGallery_GetByEvent]
(
	@EventID int
)
as
select EG.EventGalleryID, EG.Naziv, EG.Opis, EG.DatumKreiranja
from EventGallery as EG 
where EG.EventID = @EventID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventGallery_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_EventGallery_GetByID] 
(
	@EventGalleryID int
)
as
select TOP 1 EG.EventGalleryID, EG.EventID, EG.Naziv, EG.Opis, EG.DatumKreiranja
from EventGallery AS EG where EventGalleryID = @EventGalleryID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventGallery_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_EventGallery_Insert]
(
	@EventID int,
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@DatumKreiranja datetime
)
as
insert into EventGallery(EventID, Naziv, Opis, DatumKreiranja) values (@EventID, @Naziv, @Opis, @DatumKreiranja)
select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[esp_EventGallery_Update]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_EventGallery_Update]
(
	@EventGalleryID int,
	@Naziv nvarchar(50),
	@Opis nvarchar(3000)
)
as 
update EventGallery
set Naziv = @Naziv, Opis = @Opis
where EventGalleryID = @EventGalleryID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventTip_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_EventTip_SelectAll]
as
select ET.EventTipID, ET.Naziv
from EventTip as ET

GO
/****** Object:  StoredProcedure [dbo].[esp_EventToVisit_GetByPosjetilacID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_EventToVisit_GetByPosjetilacID]
(
	@PosjetilacID int 
)
as
select E.EventID as 'EventID', E.Naziv as 'EventNaziv', E.SlikaThumb as 'SlikaThumb', convert(date, DatumOdrzavanja) as 'DatumOdrzavanja', L.Naziv as 'LokacijaNaziv', E.Status
from EventToVisit as ETV join Event as E on E.EventID = ETV.EventID join Lokacija as L on L.LokacijaID = E.LokacijaID
where ETV.PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventToVisit_GetDetails]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_EventToVisit_GetDetails]
(
	@PosjetilacID int,
	@EventID int
)
as
select top 1 EventID, PosjetilacID, Prisustvovao, EventRating, RatingDate, Comment, CommentDate
from EventToVisit as ETV
where ETV.EventID = @EventID and ETV.PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventToVisit_Remove]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_EventToVisit_Remove]
(
	@EventID int,
	@PosjetilacID int
)
as
delete from EventToVisit
where EventID = @EventID AND PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventToVisit_UpdateAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_EventToVisit_UpdateAll]
(
	@PosjetilacID int,
	@EventID int,
	@Comment nvarchar(3000) null,
	@Rating int null
)
as
update EventToVisit 
set Comment = @Comment, CommentDate = GETDATE(), EventRating = @Rating, RatingDate = GETDATE()
where EventID = @EventID and PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventToVisit_UpdateComment]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_EventToVisit_UpdateComment]
(
	@PosjetilacID int,
	@EventID int,
	@Comment nvarchar(3000)
)
as
update EventToVisit 
set Comment = @Comment, CommentDate = GETDATE()
where EventID = @EventID and PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_EventToVisit_UpdateRating]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_EventToVisit_UpdateRating]
(
	@PosjetilacID int,
	@EventID int,
	@Rating int
)
as
update EventToVisit 
set EventRating = @Rating, RatingDate = GETDATE()
where EventID = @EventID and PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_GetByEventTip]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Event_GetByEventTip]
(
	@EventTipID int
)
as
select E.EventID as 'EventID', E.LokacijaID as 'LokacijaID', E.Naziv as 'EventNaziv', L.Naziv as 'LokacijaNaziv', E.DatumOdrzavanja as 'DatumOdrzavanja', E.SlikaThumb as SlikaThumb
from Event as E join Lokacija as L on E.LokacijaID = L.LokacijaID
where E.EventTipID = @EventTipID

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[esp_Event_GetByID]
(
	@EventID int
)
as 
select TOP 1 E.EventID, E.Naziv, E.Opis, E.DatumKreiranja, E.DatumOdrzavanja, E.VrijemePocetka, E.VrijemeZavrsetka, E.AverageRating, E.EventTipID, E.KreatorID, E.LokacijaID, E.OrganizacijaID, E.Slika, E.SlikaThumb, E.Status
from Event AS E
where EventID = @EventID

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_GetComments]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[esp_Event_GetComments]
(
	@EventID int
)
as
select E.EventID, E.Naziv, K.KorisnickoIme, ETV.EventRating, ETV.Comment, ETV.CommentDate, ETV.RatingDate
from EventToVisit as ETV JOIN Event AS E ON E.EventID = ETV.EventID
join Korisnik as K on K.KorisnikID = ETV.PosjetilacID
where E.EventID = @EventID and ETV.Comment is not null and ETV.Comment not like 'nullcomment'

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_GetDetails]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[esp_Event_GetDetails]
(
	@EventID int
)
as
select top 1 E.EventID, 
		E.Naziv, 
		E.Opis, 
		convert(nvarchar(20), E.DatumKreiranja, 103) as 'DatumKreiranja',
		convert(nvarchar(20), E.DatumOdrzavanja, 103) as 'DatumOdrzavanja',
		K.KorisnickoIme,
		E.AverageRating,
		Cast(E.VrijemePocetka as nvarchar(5)) as 'VrijemePocetka',
		cast(E.VrijemeZavrsetka as nvarchar(5)) AS 'VrijemeZavrsetka',
		E.SlikaThumb,
		E.Status,
		E.OrganizacijaID as 'OrganizacijaID',
		E.LokacijaID as 'LokacijaID',
		ET.Naziv as 'EventTip',
		O.Naziv as 'Organizacija',
		L.Naziv as 'Lokacija'
from Event as E join Korisnik as K
on K.KorisnikID = E.KreatorID
join EventTip as ET on ET.EventTipID = E.EventTipID
join Organizacija as O on O.OrganizacijaID = E.OrganizacijaID 
join Lokacija as L on L.LokacijaID = E.LokacijaID
where E.EventID = @EventID

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_GetEvents]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Event_GetEvents]
(
	@Naziv nvarchar(50)
)
as
select E.EventID, E.Naziv, E.DatumOdrzavanja
from Event as E
where LOWER(E.Naziv) LIKE '%' + LOWER(@Naziv) + '%'

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_GetReport]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Event_GetReport]
(
@EventID int
)
as
select E.EventID, E.Naziv, CONVERT(DATE, E.DatumOdrzavanja) AS 'DatumOdrzavanja', 
E.Status, COUNT(ETV.EventID) as 'MarkedAsToVisit',
Comments = (select count(ETV2.Comment)
from EventToVisit as ETV2 
where ETV2.EventID = E.EventID and ETV2.Comment is not null and ETV2.Comment != 'nullcomment'
)
from Event as E join EventToVisit as ETV on ETV.EventID = E.EventID
where E.EventID = @EventID
group by E.EventID, E.Naziv, [DatumOdrzavanja], E.Status
order by [Comments] desc


GO
/****** Object:  StoredProcedure [dbo].[esp_Event_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Event_Insert]
(
	@KreatorID int,
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@DatumKreiranja datetime,
	@DatumOdrzavanja datetime,
	@VrijemePocetka time,
	@VrijemeZavrsetka time,
	@Slika varbinary(max),
	@SlikaThumb varbinary(max),
	@Status nvarchar(50),
	@EventTipID int,
	@OrganizacijaID int,
	@LokacijaID int
)
as
insert into Event(KreatorID, Naziv, Opis, DatumKreiranja, DatumOdrzavanja, AverageRating, VrijemePocetka, VrijemeZavrsetka, Slika, SlikaThumb, Status, EventTipID, OrganizacijaID, LokacijaID)
values(@KreatorID, @Naziv, @Opis, @DatumKreiranja, @DatumOdrzavanja, 0, @VrijemePocetka, @VrijemeZavrsetka, @Slika, @SlikaThumb, @Status, @EventTipID, @OrganizacijaID, @LokacijaID)
select @@identity

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_OrderByDatum]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Event_OrderByDatum]
as
select E.EventID, E.Naziv, E.DatumOdrzavanja, E.SlikaThumb, L.Naziv as 'LokacijaNaziv'
from Event as E join Lokacija as L on E.LokacijaID = L.LokacijaID
order by E.DatumOdrzavanja desc


GO
/****** Object:  StoredProcedure [dbo].[esp_Event_OrderByLokacija]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Event_OrderByLokacija]
as
select E.EventID, E.Naziv, E.DatumOdrzavanja, E.SlikaThumb, L.Naziv as 'LokacijaNaziv'
from Event as E join Lokacija as L on E.LokacijaID = L.LokacijaID
order by E.Naziv asc

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_ToVisit]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_Event_ToVisit]
(
	@EventID int,
	@PosjetilacID int
)

as

insert into EventToVisit(PosjetilacID, EventID, Prisustvovao)
values(@PosjetilacID, @EventID, 0)

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_Top5ByGradMjesec]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_Event_Top5ByGradMjesec]
(
	@GradID int,
	@Mjesec int
)
as
select E.EventID, E.Naziv, CONVERT(nvarchar(10), E.DatumOdrzavanja, 105) AS 'DatumOdrzavanja', L.Naziv as 'Lokacija', G.Naziv as 'Grad', E.AverageRating
from Event as E
join Lokacija as L on L.LokacijaID = E.LokacijaID
join Grad as G on G.GradID = L.GradID
where MONTH(E.DatumOdrzavanja) = @Mjesec and E.Status LIKE 'Odrzan' and L.GradID = @GradID
order by E.AverageRating desc

GO
/****** Object:  StoredProcedure [dbo].[esp_Event_Update]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Event_Update] 
(
	@EventID int,
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@LokacijaID int,
	@OrganizacijaID int,
	@EventTipID int,
	@VrijemePocetka time,
	@VrijemeZavrsetka time,
	@DatumOdrzavanja datetime,
	@Status nvarchar(50)
)
as
update Event
set Naziv = @Naziv, Opis = @Opis, LokacijaID = @LokacijaID, OrganizacijaID = @OrganizacijaID, EventTipID = @EventTipID, VrijemePocetka = @VrijemePocetka, VrijemeZavrsetka = @VrijemeZavrsetka, DatumOdrzavanja = @DatumOdrzavanja, Status = @Status
where EventID = @EventID


GO
/****** Object:  StoredProcedure [dbo].[esp_Event_UpdateStatus]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Event_UpdateStatus]
(
	@Status nvarchar(50),
	@EventID int
)
as
update Event
set Status = @Status
where EventID = @EventID

GO
/****** Object:  StoredProcedure [dbo].[esp_Events_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Events_Insert]
(
	@Naziv nvarchar(50),
	@Opis nvarchar (3000),
	@KreatorID int,
	@DatumKreiranja datetime,
	@DatumOdrzavanja datetime,
	@VrijemePocetka time,
	@VrijemeZavrsetka time,
	@Slika varbinary(max),
	@SlikaThumb varbinary(max),
	@Status varchar(50),
	@EventTipID int,
	@OrganizacijaID int,
	@LokacijaID int
)
as
insert into Event(Naziv, Opis, KreatorID, DatumKreiranja, DatumOdrzavanja, VrijemePocetka, VrijemeZavrsetka, Slika, SlikaThumb, Status, EventTipID, OrganizacijaID, LokacijaID)
values(@Naziv, @Opis, @KreatorID, @DatumKreiranja, @DatumOdrzavanja, @VrijemePocetka, @VrijemeZavrsetka, @Slika, @SlikaThumb, @Status, @EventTipID, @OrganizacijaID, @LokacijaID)
select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[esp_Events_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_Events_SelectAll]
as
select E.EventID, E.Naziv, E.DatumOdrzavanja, L.Naziv, E.AverageRating
from Event as E join EventTip as ET on ET.EventTipID = E.EventTipID
join Lokacija as L on E.LokacijaID = L.LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_Grad_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Grad_SelectAll]
as
select GradID, Naziv
from Grad

GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_Korisnik_GetByID]
(
@KorisnikID int
)
as
select top 1 K.KorisnikID, K.Ime, K.Prezime, K.Email, K.KorisnickoIme, K.LozinkaSalt, K.LozinkaHash, K.GradID, K.Slika, K.SlikaThumb, K.Status, K.Telefon
from Korisnik as K
where K.KorisnikID = @KorisnikID

GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_GetByKorisnickoIme]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_Korisnik_GetByKorisnickoIme]
(
	@KorisnickoIme nvarchar(50)
)
as
select top 1 K.KorisnikID, K.KorisnickoIme, K.LozinkaHash, K.LozinkaSalt
from Korisnik as K
where K.KorisnickoIme = @KorisnickoIme

GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_GetByUsername]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Korisnik_GetByUsername]
(
@KorisnickoIme nvarchar(50)
)
as
select top 1 K.KorisnikID, K.Ime, K.Prezime, K.Email, K.KorisnickoIme, K.LozinkaSalt, K.LozinkaHash, K.GradID, K.Slika, K.SlikaThumb, K.Status, K.Telefon
from Korisnik as K
where K.KorisnickoIme = @KorisnickoIme

GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[esp_Korisnik_Insert]
(
	@Ime NVARCHAR(50),
	@Prezime NVARCHAR(50),
	@Email NVARCHAR(100),
	@Telefon NVARCHAR(20),
	@KorisnickoIme NVARCHAR(50),
	@LozinkaSalt NVARCHAR(50),
	@LozinkaHash NVARCHAR(50),
	@GradID INT,
	@Slika varbinary(max),
	@SlikaThumb varbinary(max)
)
AS

	INSERT INTO Korisnik(Ime, Prezime, Email, Telefon, KorisnickoIme, LozinkaSalt, LozinkaHash, GradID, Status, Slika, SlikaThumb)
	VALUES (@Ime, @Prezime, @Email, @Telefon, @KorisnickoIme, @LozinkaSalt, @LozinkaHash, @GradID, 1, @Slika, @SlikaThumb)

	SELECT @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Korisnik_SelectAll]
as
select K.KorisnikID, K.Ime, K.Prezime, K.Email, K.Status
from Korisnik as K


GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_SelectByImePrezime]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Korisnik_SelectByImePrezime]
(
	@ImePrezime nvarchar(100)
)
as
	select K.KorisnikID, K.Ime, K.Prezime, K.Email, K.KorisnickoIme, K.Status
	from Korisnik as K
	WHERE LOWER(K.Ime + ' ' + K.Prezime) like LOWER(@ImePrezime) + '%' OR
	        LOWER(K.Prezime + ' ' + K.Ime)  like LOWER(@ImePrezime) + '%'

GO
/****** Object:  StoredProcedure [dbo].[esp_Korisnik_Update]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_Korisnik_Update]
(
 @KorisnikID int,
 @Ime nvarchar(50),
 @Prezime nvarchar(50),
 @Email nvarchar(100),
 @Telefon nvarchar(20),
 @KorisnickoIme nvarchar(50),
 @LozinkaSalt nvarchar(50),
 @LozinkaHash nvarchar(50),
 @Status bit,
 @GradID int
)
as
update Korisnik
set Ime = @Ime, Prezime = @Prezime, Email = @Email, Telefon = @Telefon, KorisnickoIme = @KorisnickoIme, LozinkaSalt = @LozinkaSalt, 
LozinkaHash = @LozinkaHash, Status = @Status, GradID = @GradID
where KorisnikID = @KorisnikID

GO
/****** Object:  StoredProcedure [dbo].[esp_LokacijaTip_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_LokacijaTip_SelectAll]
as
select LT.LokacijaTipID, LT.Naziv
from LokacijaTip as LT

GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Lokacija_GetByID]
(
	@LokacijaID int
)
as
select L.LokacijaID, L.Naziv, L.Opis, L.Kapacitet, L.Adresa, L.Slika, L.SlikaThumb, L.AverageRating, LT.Naziv as 'LokacijaTip', G.Naziv AS 'GradNaziv'
from Lokacija as L join LokacijaTip as LT ON L.LokacijaTipID = LT.LokacijaTipID
join Grad as G on L.GradID = G.GradID
where L.LokacijaID = @LokacijaID


GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_GetComments]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Lokacija_GetComments]
(
	@LokacijaID int
)
as
select PL.LokacijaID as 'LokacijaID', PL.PosjetilacID as 'PosjetilacID',
	   PL.LocationRating AS 'LocationRating', PL.Comment AS 'Comment',
	   L.Naziv AS 'LokacijaNaziv', K.KorisnickoIme as 'KorisnickoIme'
from PosjetilacLokacija AS PL
join Lokacija as L on L.LokacijaID = PL.LokacijaID 
join Korisnik as K on K.KorisnikID = PL.PosjetilacID
WHERE PL.LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_GetFavoriteLokacijas]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Lokacija_GetFavoriteLokacijas]
(
	@PosjetilacID int
)
as
select L.LokacijaID, L.Naziv, LT.Naziv as 'LokacijaTipNaziv', L.SlikaThumb
from Lokacija as L join LokacijaTip as LT ON LT.LokacijaTipID = L.LokacijaTipID join
PosjetilacLokacija as PL on PL.LokacijaID = L.LokacijaID
where PL.PosjetilacID = @PosjetilacID AND PL.IsFavorite = 1

GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_GetLokacijaList]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_Lokacija_GetLokacijaList]
as
select L.LokacijaID, L.Naziv, LT.Naziv as 'LokacijaTipNaziv', L.SlikaThumb
from Lokacija as L join LokacijaTip as LT ON LT.LokacijaTipID = L.LokacijaTipID

GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_GetTop5ByGrad]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Lokacija_GetTop5ByGrad]
(
	@GradID int
)
as
select top 5 L.LokacijaID, L.Naziv, L.Adresa, LT.Naziv as 'Tip', G.Naziv as 'Grad', L.AverageRating --, count(PL.IsFavorite) as 'IsFavorite'
from Lokacija as L
join LokacijaTip as LT ON L.LokacijaTipID = LT.LokacijaTipID
join Grad as G on L.GradID = G.GradID
where L.GradID = @GradID
order by L.AverageRating desc

GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_Input]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Lokacija_Input]
(
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@Kapacitet int,
	@Adresa nvarchar(50),
	@Slika varbinary(max) null,
	@SlikaThumb varbinary(max) null,
	@AverageRating float,
	@GradID int,
	@LokacijaTipID int
)
as
insert into Lokacija(Naziv, Opis, Kapacitet, Adresa, Slika, SlikaThumb,  AverageRating, GradID, LokacijaTipID)
values (@Naziv, @Opis, @Kapacitet, @Adresa, @Slika, @SlikaThumb, @AverageRating, @GradID, @LokacijaTipID)
select @@IDENTITY


GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Lokacija_SelectAll]
(
@Naziv nvarchar(50)
)
as
select L.LokacijaID, L.Naziv, L.AverageRating, L.Adresa, G.Naziv as Grad, LT.Naziv as Tip
from Lokacija as L join Grad as G on G.GradID = L.GradID join LokacijaTip as LT on LT.LokacijaTipID = L.LokacijaTipID
WHERE LOWER(L.Naziv) LIKE '%' + LOWER(@Naziv) + '%'

GO
/****** Object:  StoredProcedure [dbo].[esp_Lokacija_Update]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Lokacija_Update]
(
	@LokacijaID int,
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@Kapacitet int,
	@Adresa nvarchar(50),
	@GradID int,
	@LokacijaTipID int
)
as
update Lokacija
set Naziv = @Naziv, Opis = @Opis, Kapacitet = @Kapacitet, Adresa = @Adresa, GradID = @GradID, LokacijaTipID = @LokacijaTipID
where LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_Organizacija_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_Organizacija_GetByID]
(
	@OrganizacijaID int
)
as
select top 1  O.OrganizacijaID, O.Naziv, O.Opis, O.Tip, O.SlikaLogo, G.Naziv as 'GradNaziv'
from Organizacija as O join Grad as G on G.GradID = O.GradID
where O.OrganizacijaID = @OrganizacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_Organizacija_GetComments]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Organizacija_GetComments]
(
	@OrganizacijaID int
)
as
select PO.OrganizacijaID, PO.PosjetilacID, PO.Comment, PO.LocationRating, PO.CommentDate,
O.Naziv AS 'OrganizacijaNaziv', K.KorisnickoIme AS 'KorisnickoIme'
from PosjetilacOrganizacija as PO
join Organizacija as O on O.OrganizacijaID = PO.OrganizacijaID
JOIN Korisnik as K on PO.PosjetilacID = K.KorisnikID
WHERE PO.OrganizacijaID = @OrganizacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_Organizacija_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_Organizacija_Insert]
(
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@Tip nvarchar(50),
	@GradID int,
	@SlikaLogo varbinary(max)
)
as 
insert into Organizacija(Naziv, Opis, Tip, GradID, AverageRating, SlikaLogo) values (@Naziv, @Opis, @Tip, @GradID, 0, @SlikaLogo)
select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[esp_Organizacija_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_Organizacija_SelectAll]
(
	@Naziv nvarchar(50)
)
as
select O.OrganizacijaID, O.Naziv
from Organizacija as O
WHERE LOWER(O.Naziv) LIKE '%' + LOWER(@Naziv) + '%'

GO
/****** Object:  StoredProcedure [dbo].[esp_Organizacija_Update]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_Organizacija_Update] 
(
	@OrganizacijaID int,
	@Naziv nvarchar(50),
	@Opis nvarchar(3000),
	@Tip nvarchar(50),
	@GradID int
)
as
update Organizacija
set Naziv = @Naziv, Opis = @Opis, Tip = @Tip, GradID = @GradID
where OrganizacijaID = @OrganizacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacLokacija_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_PosjetilacLokacija_GetByID] 
(
	@PosjetilacID int,
	@LokacijaID int
)
as
select top 1 PL.PosjetilacID, PL.LokacijaID, PL.LocationRating, PL.RatingDate, PL.Comment, PL.CommentDate, L.Naziv AS 'LokacijaNaziv', PL.IsFavorite
from PosjetilacLokacija as PL
JOIN Lokacija as L on L.LokacijaID = PL.LokacijaID
WHERE PL.PosjetilacID = @PosjetilacID and PL.LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacLokacija_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_PosjetilacLokacija_Insert]
(
	@PosjetilacID int,
	@LokacijaID int,
	@LocationRating int null,
	@Comment nvarchar(3000) null
)
as
insert into PosjetilacLokacija(PosjetilacID, LokacijaID, LocationRating, RatingDate, Comment, CommentDate)
values (@PosjetilacID, @LokacijaID, @LocationRating, GETDATE(), @Comment, GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacLokacija_UpdateAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_PosjetilacLokacija_UpdateAll]
(
	@PosjetilacID int,
	@LokacijaID int,
	@Comment nvarchar(3000) null,
	@Rating int null
)
as
update PosjetilacLokacija
set Comment = @Comment, CommentDate = GETDATE(), LocationRating = @Rating, RatingDate = GETDATE()
WHERE PosjetilacID = @PosjetilacID and LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacLokacija_UpdateComment]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_PosjetilacLokacija_UpdateComment]
(
	@PosjetilacID int,
	@LokacijaID int,
	@Comment nvarchar(3000)
)
as
update PosjetilacLokacija
set Comment = @Comment, CommentDate = GETDATE()
where PosjetilacID = @PosjetilacID and LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacLokacija_UpdateFavoriteStatus]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_PosjetilacLokacija_UpdateFavoriteStatus]
(
	@PosjetilacID int,
	@LokacijaID int,
	@IsFavorite bit
)
as
update PosjetilacLokacija
set IsFavorite = @IsFavorite
where @PosjetilacID = PosjetilacID and LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacLokacija_UpdateRating]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_PosjetilacLokacija_UpdateRating]
(
	@PosjetilacID int,
	@LokacijaID int,
	@LokacijaRating int
)
as
update PosjetilacLokacija
set LocationRating = @LokacijaRating, RatingDate = GETDATE()
where PosjetilacID = @PosjetilacID and LokacijaID = @LokacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacOrganizacija_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[esp_PosjetilacOrganizacija_GetByID] 
(
	@PosjetilacID int,
	@OrganizacijaID int
)
as
select top 1 PO.PosjetilacID, PO.OrganizacijaID, PO.LocationRating, PO.RatingDate, PO.Comment, 
PO.CommentDate, O.Naziv AS 'OrganizacijaNaziv'
from PosjetilacOrganizacija as PO
JOIN Organizacija as O on O.OrganizacijaID = PO.OrganizacijaID
WHERE PO.PosjetilacID = @PosjetilacID and PO.OrganizacijaID = @OrganizacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacOrganizacija_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_PosjetilacOrganizacija_Insert]
(
	@PosjetilacID int,
	@OrganizacijaID int,
	@LocationRating int null,
	@Comment nvarchar(3000) null
)
as
insert into PosjetilacOrganizacija(PosjetilacID, OrganizacijaID, LocationRating, RatingDate, Comment, CommentDate)
values (@PosjetilacID, @OrganizacijaID, @LocationRating, GETDATE(), @Comment, GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacOrganizacija_UpdateAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[esp_PosjetilacOrganizacija_UpdateAll]
(
	@PosjetilacID int,
	@OrganizacijaID int,
	@Comment nvarchar(3000) null,
	@Rating int null
)
as
update PosjetilacOrganizacija
set Comment = @Comment, CommentDate = GETDATE(), LocationRating = @Rating, RatingDate = GETDATE()
WHERE PosjetilacID = @PosjetilacID and OrganizacijaID = @OrganizacijaID

GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacOrganizacija_UpdateComment]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[esp_PosjetilacOrganizacija_UpdateComment]
(
	@PosjetilacID int,
	@OrganizacijaID int,
	@Comment nvarchar(3000)
)
as
update PosjetilacOrganizacija
set Comment = @Comment, CommentDate = GETDATE()
where PosjetilacID = @PosjetilacID and OrganizacijaID = @OrganizacijaID


GO
/****** Object:  StoredProcedure [dbo].[esp_PosjetilacOrganizacija_UpdateRating]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_PosjetilacOrganizacija_UpdateRating]
(
	@PosjetilacID int,
	@OrganizacijaID int,
	@Rating int
)
as
update PosjetilacOrganizacija
set PosjetilacOrganizacija.LocationRating = @Rating, RatingDate = GETDATE()
where PosjetilacID = @PosjetilacID and OrganizacijaID = @OrganizacijaID


GO
/****** Object:  StoredProcedure [dbo].[esp_Posjetilac_GetByID]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Posjetilac_GetByID]
(
	@PosjetilacID int
)
as
select PosjetilacID, BrojPosjecenihDogadjaja, Zanimanje
from Posjetilac
where PosjetilacID = @PosjetilacID

GO
/****** Object:  StoredProcedure [dbo].[esp_Slika_GetByGallery]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Slika_GetByGallery]
(
	@EventGalleryID int
)
as
select S.SlikaID, S.Slika, S.SlikaThumb, S.Opis
from Slika as S 
where S.EventGalleryID = @EventGalleryID

GO
/****** Object:  StoredProcedure [dbo].[esp_Slika_Insert]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Slika_Insert]
(
	@EventGalleryID int,
	@Slika varbinary(max),
	@SlikaThumb varbinary(max),
	@Opis nvarchar(500)
)
as
insert into Slika(EventGalleryID, Slika, SlikaThumb, Opis)
values (@EventGalleryID, @Slika, @SlikaThumb, @Opis)
select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[esp_Slika_Update]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[esp_Slika_Update]
(
@SlikaID int,
@Opis nvarchar(50)
)
as
update Slika
set Opis = @Opis
where SlikaID = @SlikaID

GO
/****** Object:  StoredProcedure [dbo].[esp_Uloga_SelectAll]    Script Date: 08-Apr-19 1:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[esp_Uloga_SelectAll]
as
select UlogaID, Naziv, Opis
from Uloga

GO
USE [master]
GO
ALTER DATABASE [150086] SET  READ_WRITE 
GO
