# PenaltyCalculate

Instructions to run the application :-

1. Download the project.
2. Open PenaltyCalculate.API.sln with Visual Studio 2017.
3. Either restore the DB backup file or Execute the below script in SQL Server.
	
		/****** Object:  Database [PenaltyCalculate]    Script Date: 6/15/2020  ******/
		CREATE DATABASE [PenaltyCalculate]
		GO
		USE [PenaltyCalculate]
		GO
		/****** Object:  Table [dbo].[tblCountryMasterDetails]    Script Date: 6/15/2020  ******/
		SET ANSI_NULLS ON
		GO
		SET QUOTED_IDENTIFIER ON
		GO
		CREATE TABLE [dbo].[tblCountryMasterDetails](
			[ID] [int] IDENTITY(1,1) NOT NULL,
			[CountryID] [varchar](10) NOT NULL,
			[Country] [varchar](100) NULL,
			[Currency] [nvarchar](5) NOT NULL,
			[PenaltyFee] [decimal](18, 2) NOT NULL,
			[PenaltyCalculateDays] [int] NOT NULL,
			[Weekends] [varchar](100) NULL
		) ON [PRIMARY]
		GO
		/****** Object:  Table [dbo].[tblholiday]    Script Date: 6/15/2020  ******/
		SET ANSI_NULLS ON
		GO
		SET QUOTED_IDENTIFIER ON
		GO
		CREATE TABLE [dbo].[tblholiday](
			[ID] [int] IDENTITY(1,1) NOT NULL,
			[CountryID] [varchar](50) NULL,
			[CountryName] [varchar](50) NULL,
			[NationalHoliday] [datetime] NULL
		) ON [PRIMARY]
		GO
		SET IDENTITY_INSERT [dbo].[tblCountryMasterDetails] ON 
		GO
		INSERT [dbo].[tblCountryMasterDetails] ([ID], [CountryID], [Country], [Currency], [PenaltyFee], [PenaltyCalculateDays], [Weekends]) VALUES (1, N'DB', N'Dubai', N'AED', CAST(18.35 AS Decimal(18, 2)), 10, N'Friday,Saturday')
		GO
		INSERT [dbo].[tblCountryMasterDetails] ([ID], [CountryID], [Country], [Currency], [PenaltyFee], [PenaltyCalculateDays], [Weekends]) VALUES (2, N'US', N'United State', N'$', CAST(5.00 AS Decimal(18, 2)), 10, N'Saturday,Sunday')
		GO
		INSERT [dbo].[tblCountryMasterDetails] ([ID], [CountryID], [Country], [Currency], [PenaltyFee], [PenaltyCalculateDays], [Weekends]) VALUES (3, N'IN', N'India', N'INR', CAST(2.00 AS Decimal(18, 2)), 10, N'Saturday')
		GO
		SET IDENTITY_INSERT [dbo].[tblCountryMasterDetails] OFF
		GO
		SET IDENTITY_INSERT [dbo].[tblholiday] ON 
		GO
		INSERT [dbo].[tblholiday] ([ID], [CountryID], [CountryName], [NationalHoliday]) VALUES (1, N'DB', N'Dubai', CAST(N'2020-06-12T00:00:00.000' AS DateTime))
		GO
		INSERT [dbo].[tblholiday] ([ID], [CountryID], [CountryName], [NationalHoliday]) VALUES (2, N'DB', N'Dubai', CAST(N'2020-06-18T00:00:00.000' AS DateTime))
		GO
		INSERT [dbo].[tblholiday] ([ID], [CountryID], [CountryName], [NationalHoliday]) VALUES (3, N'US', N'United State', CAST(N'2020-06-07T00:00:00.000' AS DateTime))
		GO
		INSERT [dbo].[tblholiday] ([ID], [CountryID], [CountryName], [NationalHoliday]) VALUES (4, N'US', N'United State', CAST(N'2020-06-10T00:00:00.000' AS DateTime))
		GO
		SET IDENTITY_INSERT [dbo].[tblholiday] OFF
		GO	
	
4. Please change the connection string(Data Source,Initial Catalog,UserId,Password) in web.config file of PenaltyCalculate.API project.

<connectionStrings>	
    <add name="PenaltyCalculateEntities" connectionString="metadata=res://*/PenaltyCalculate.csdl|res://*/PenaltyCalculate.ssdl|res://*/PenaltyCalculate.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=XXXXXXXXX;initial catalog=XXXXXXXX;persist security info=True;user id=XXXXX;password=XXXXXXX;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />		
</connectionStrings>

5. Compile the project and run the application.

