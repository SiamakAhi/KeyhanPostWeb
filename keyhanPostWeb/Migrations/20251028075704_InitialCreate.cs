using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace keyhanPostWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<short>(type: "smallint", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastVisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approve = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SabtNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeliNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1_Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1_Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1_fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2_Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2_Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2_fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2_email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyMembers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMembers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CRMEmailAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRMEmailAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    DegreeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pakeges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    footerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakeges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotionalityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    IdentityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsMoaref = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoGallery",
                columns: table => new
                {
                    photoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    BlogID = table.Column<int>(type: "int", nullable: true),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    IsMainPic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGallery", x => x.photoID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    categoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProductServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsProduct = table.Column<bool>(type: "bit", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceCode = table.Column<int>(type: "int", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepAgencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyCode = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepAgencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepDocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadScore = table.Column<int>(type: "int", nullable: false),
                    DocumentCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepDocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepEntityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityCode = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepEntityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceCode = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepIntroductionMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepIntroductionMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepJobRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestCode = table.Column<int>(type: "int", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepJobRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepPropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyCode = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepPropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepRequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepRequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepVehicleAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailabilityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailabilityCode = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepVehicleAvailabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepVehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    VehicleCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepVehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image3Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image4Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image5Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image6Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image3Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image4Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image5Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image6Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link1Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link2Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link3Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link4Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link5Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_copyright = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_license = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meta_title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SitePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionCode = table.Column<int>(type: "int", nullable: false),
                    SerctionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referrer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    ComID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComSender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approve = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BlogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.ComID);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageTypeId = table.Column<short>(type: "smallint", nullable: false),
                    OriginCityId = table.Column<int>(type: "int", nullable: false),
                    DestinationCityId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ActualWeight = table.Column<double>(type: "float", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SenderNationalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SenderAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReceiverPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReceiverNationalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtext1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtext2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtext3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    AlowShowPrice = table.Column<bool>(type: "bit", nullable: false),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    SpecialProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsAvalable = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtext1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtext2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtext3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    discount = table.Column<long>(type: "bigint", nullable: false),
                    FinalPrice = table.Column<long>(type: "bigint", nullable: false),
                    AlowShowPrice = table.Column<bool>(type: "bit", nullable: false),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    SpecialProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsAvalable = table.Column<bool>(type: "bit", nullable: false),
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductServices_ProductServiceCategories_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionsContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionsContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionsContents_SitePages_SectionID",
                        column: x => x.SectionID,
                        principalTable: "SitePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInPakges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountInPakage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BasicPrice = table.Column<int>(type: "int", nullable: false),
                    AlowShowPrice = table.Column<bool>(type: "bit", nullable: false),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    SpecialProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsAvalable = table.Column<bool>(type: "bit", nullable: false),
                    PakageId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInPakges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInPakges_Pakeges_PakageId",
                        column: x => x.PakageId,
                        principalTable: "Pakeges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInPakges_ProductServices_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductServiceImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsMainImage = table.Column<bool>(type: "bit", nullable: false),
                    AllowToShow = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductServiceImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductServiceImages_ProductServices_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_Projects_ProductServices_ProductServiceId",
                        column: x => x.ProductServiceId,
                        principalTable: "ProductServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RepApplicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityTypeId = table.Column<int>(type: "int", nullable: true),
                    EducationId = table.Column<int>(type: "int", nullable: true),
                    AgencyTypeId = table.Column<int>(type: "int", nullable: true),
                    RequestStatusId = table.Column<int>(type: "int", nullable: true),
                    JobRequestId = table.Column<int>(type: "int", nullable: true),
                    ExperienceId = table.Column<int>(type: "int", nullable: true),
                    VehicleAvailabilityId = table.Column<int>(type: "int", nullable: true),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: true),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    BranchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroductionId = table.Column<int>(type: "int", nullable: true),
                    JobSeekerRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluationNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    currentStep = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepApplicants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_EducationDegrees_EducationId",
                        column: x => x.EducationId,
                        principalTable: "EducationDegrees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepAgencyTypes_AgencyTypeId",
                        column: x => x.AgencyTypeId,
                        principalTable: "RepAgencyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepEntityTypes_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "RepEntityTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepExperiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "RepExperiences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepIntroductionMethods_IntroductionId",
                        column: x => x.IntroductionId,
                        principalTable: "RepIntroductionMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepJobRequests_JobRequestId",
                        column: x => x.JobRequestId,
                        principalTable: "RepJobRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepPropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "RepPropertyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepRequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RepRequestStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepVehicleAvailabilities_VehicleAvailabilityId",
                        column: x => x.VehicleAvailabilityId,
                        principalTable: "RepVehicleAvailabilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepApplicants_RepVehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "RepVehicleTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SectionsListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    altImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link1_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link1_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link2_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link2_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link3_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link3_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionContentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionsListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionsListItems_SectionsContents_SectionContentID",
                        column: x => x.SectionContentID,
                        principalTable: "SectionsContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsMainImage = table.Column<bool>(type: "bit", nullable: false),
                    AllowToShow = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImages_Projects_projectId",
                        column: x => x.projectId,
                        principalTable: "Projects",
                        principalColumn: "projectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepUploadedDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepUploadedDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepUploadedDocuments_RepApplicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "RepApplicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepUploadedDocuments_RepDocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "RepDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CRMEmailAddresses",
                columns: new[] { "Id", "EmailAddress", "Name" },
                values: new object[,]
                {
                    { 1, "crm@keyhanpost.ir", "پیگیری مرسولات" },
                    { 2, "marketing@keyhanpost.ir", "استعلام هزینه پست داخلی" },
                    { 3, "marketing@keyhanpost.ir", "استعلام هزینه پست خارجی" },
                    { 4, "ceo@keyhanpost.ir", "انتقاد و پیشنهاد" },
                    { 5, "crm@keyhanpost.ir", "امور شعب و نمایندگی" },
                    { 6, "info@keyhanpost.ir", "سایر" }
                });

            migrationBuilder.InsertData(
                table: "EducationDegrees",
                columns: new[] { "Id", "DegreeCode", "DegreeTitle", "Score" },
                values: new object[,]
                {
                    { 1, 5001, "سیکل", 5 },
                    { 2, 5002, "دیپلم", 10 },
                    { 3, 5003, "فوق دیپلم", 15 },
                    { 4, 5004, "لیسانس", 20 },
                    { 5, 5005, "فوق لیسانس", 25 },
                    { 6, 5006, "دکتری", 30 }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "ProvinceCode", "ProvinceName" },
                values: new object[,]
                {
                    { 1, 10, "آذربایجان شرقی" },
                    { 2, 11, "آذربایجان غربی" },
                    { 3, 12, "اردبیل" },
                    { 4, 13, "اصفهان" },
                    { 5, 14, "البرز" },
                    { 6, 15, "ایلام" },
                    { 7, 16, "بوشهر" },
                    { 8, 17, "تهران" },
                    { 9, 18, "چهارمحال و بختیاری" },
                    { 10, 19, "خراسان جنوبی" },
                    { 11, 20, "خراسان رضوی" },
                    { 12, 21, "خراسان شمالی" },
                    { 13, 22, "خوزستان" },
                    { 14, 23, "زنجان" },
                    { 15, 24, "سمنان" },
                    { 16, 25, "سیستان و بلوچستان" },
                    { 17, 26, "فارس" },
                    { 18, 27, "قزوین" },
                    { 19, 28, "قم" },
                    { 20, 29, "کردستان" },
                    { 21, 30, "کرمان" },
                    { 22, 31, "کرمانشاه" },
                    { 23, 32, "کهگیلویه و بویراحمد" },
                    { 24, 33, "گلستان" },
                    { 25, 34, "گیلان" },
                    { 26, 35, "لرستان" },
                    { 27, 36, "مازندران" },
                    { 28, 37, "مرکزی" },
                    { 29, 38, "هرمزگان" },
                    { 30, 39, "همدان" },
                    { 31, 40, "یزد" }
                });

            migrationBuilder.InsertData(
                table: "RepAgencyTypes",
                columns: new[] { "Id", "AgencyCode", "AgencyTitle", "Score" },
                values: new object[,]
                {
                    { 1, 5000, "ثابت", 30 },
                    { 2, 5001, "سیار", 20 },
                    { 3, 5002, "ثابت و سیار", 50 }
                });

            migrationBuilder.InsertData(
                table: "RepDocumentTypes",
                columns: new[] { "Id", "DocumentCode", "DocumentTitle", "UploadScore" },
                values: new object[,]
                {
                    { 1, 6000, "کارت ملی", 5 },
                    { 2, 6001, "شناسنامه", 5 },
                    { 3, 6002, "عکس", 5 },
                    { 4, 6003, "گواهینامه", 5 },
                    { 5, 6004, "پایان خدمت", 5 },
                    { 6, 6005, "بیمه نامه", 5 },
                    { 7, 6006, "مدرک تحصیلی", 5 },
                    { 8, 6007, "گواهی امضاء", 5 },
                    { 9, 6008, "گواهی سوء پیشینه", 5 },
                    { 10, 6009, "گواهی عدم اعتیاد", 5 },
                    { 11, 6010, "تعهدنامه عدم دریافت کالای قاچاق", 5 },
                    { 12, 6011, "کپی سند یا اجاره نامه محل سکونت به همراه کدپستی", 5 },
                    { 13, 6012, "کپی سند یا اجاره نامه محل مورد نظر جهت نمایندگی به همراه کدپستی", 5 },
                    { 14, 6013, "فرم پیش ثبت نام سامانه ثنا", 5 }
                });

            migrationBuilder.InsertData(
                table: "RepEntityTypes",
                columns: new[] { "Id", "EntityCode", "EntityTitle", "Score" },
                values: new object[,]
                {
                    { 1, 3001, "حقیقی", 50 },
                    { 2, 3002, "حقوقی", 20 }
                });

            migrationBuilder.InsertData(
                table: "RepExperiences",
                columns: new[] { "Id", "ExperienceCode", "ExperienceTitle", "Score" },
                values: new object[,]
                {
                    { 1, 4000, "سابقه فعالیت دارم", 50 },
                    { 2, 4001, "سابقه فعالیت ندارم", 0 }
                });

            migrationBuilder.InsertData(
                table: "RepIntroductionMethods",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[,]
                {
                    { 1, 3001, "وب سایت شرکت کیهان پست" },
                    { 2, 3002, "آگهی دیوار" },
                    { 3, 3003, "وب سایت جابینجا" },
                    { 4, 3004, "وب سایت جابویژن" },
                    { 5, 3005, "وب سایت ایران تلنت" },
                    { 6, 3006, "فضای مجازی" },
                    { 7, 3007, "روزنامه" },
                    { 8, 3008, "صداوسیما" },
                    { 9, 3009, "دوستان و آشنایان" },
                    { 10, 3010, "سایر" }
                });

            migrationBuilder.InsertData(
                table: "RepJobRequests",
                columns: new[] { "Id", "JobTitle", "RequestCode", "RowNumber" },
                values: new object[,]
                {
                    { 1, "درخواست ایجاد نمایندگی", 2001, 1 },
                    { 2, "درخواست ایجاد شعبه", 2002, 2 },
                    { 3, "درخواست به عنوان همکار پیک موتوری", 2003, 3 },
                    { 4, "درخواست به عنوان وانت بار به صورت سیار و ثابت", 2004, 4 },
                    { 5, "درخواست به عنوان همکاری با کامیون", 2005, 5 },
                    { 6, "درخواست همکاری در واحد تجزیه مبادلات", 2006, 6 },
                    { 7, "درخواست همکاری نیروی بسته بند و ثبت سامانه", 2006, 7 }
                });

            migrationBuilder.InsertData(
                table: "RepPropertyTypes",
                columns: new[] { "Id", "PropertyCode", "PropertyTitle", "Score" },
                values: new object[,]
                {
                    { 1, 3001, "استجاری", 10 },
                    { 2, 3002, "مالک", 50 }
                });

            migrationBuilder.InsertData(
                table: "RepRequestStatuses",
                columns: new[] { "Id", "StatusCode", "StatusTitle" },
                values: new object[,]
                {
                    { 10, 1001, "در صف بررسی" },
                    { 11, 1002, "درحال بررسی و امکانسنجی" },
                    { 12, 1003, "رد درخواست" },
                    { 13, 1004, "موافقت اولیه درخواست" },
                    { 14, 1005, "نقص مدارک نیاز به بارگذاری مجدد دارد." },
                    { 20, 2001, "در حال تکمیل درخواست" }
                });

            migrationBuilder.InsertData(
                table: "RepVehicleAvailabilities",
                columns: new[] { "Id", "AvailabilityCode", "AvailabilityTitle", "Score" },
                values: new object[,]
                {
                    { 1, 9000, "دارم", 50 },
                    { 2, 9001, "ندارم", 0 }
                });

            migrationBuilder.InsertData(
                table: "RepVehicleTypes",
                columns: new[] { "Id", "Score", "VehicleCode", "VehicleTitle" },
                values: new object[,]
                {
                    { 1, 5, 7000, "سواری" },
                    { 2, 10, 7001, "موتور سیکلت" },
                    { 3, 20, 7002, "وانت" },
                    { 4, 20, 7003, "نیسان" },
                    { 5, 30, 7004, "کامیون" },
                    { 6, 50, 7005, "تریلی" }
                });

            migrationBuilder.InsertData(
                table: "SitePages",
                columns: new[] { "Id", "SectionCode", "SectionUrl", "SerctionName" },
                values: new object[,]
                {
                    { 1, 1, "Home/Index", "صحفه اول - معرفی" },
                    { 2, 2, "Home/Index", "صحفه اول - اهداف" },
                    { 3, 3, "Home/Index", "صحفه اول - آمارها" },
                    { 4, 4, "Home/Index", "صحفه اول - فرآیندهای کسب و کار" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "تبریز", 1 },
                    { 2, "مراغه", 1 },
                    { 3, "مرند", 1 },
                    { 4, "میانه", 1 },
                    { 5, "اهر", 1 },
                    { 6, "سراب", 1 },
                    { 7, "شبستر", 1 },
                    { 8, "بستان‌آباد", 1 },
                    { 9, "ارومیه", 2 },
                    { 10, "خوی", 2 },
                    { 11, "میاندوآب", 2 },
                    { 12, "مهاباد", 2 },
                    { 13, "سلماس", 2 },
                    { 14, "بوکان", 2 },
                    { 15, "پیرانشهر", 2 },
                    { 16, "سردشت", 2 },
                    { 17, "اردبیل", 3 },
                    { 18, "پارس‌آباد", 3 },
                    { 19, "مشگین‌شهر", 3 },
                    { 20, "خلخال", 3 },
                    { 21, "بیله‌سوار", 3 },
                    { 22, "نمین", 3 },
                    { 23, "گرمی", 3 },
                    { 24, "نیر", 3 },
                    { 25, "اصفهان", 4 },
                    { 26, "کاشان", 4 },
                    { 27, "خمینی‌شهر", 4 },
                    { 28, "نجف‌آباد", 4 },
                    { 29, "فلاورجان", 4 },
                    { 30, "شاهین‌شهر", 4 },
                    { 31, "شهرضا", 4 },
                    { 32, "نایین", 4 },
                    { 33, "کرج", 5 },
                    { 34, "نظرآباد", 5 },
                    { 35, "ساوجبلاغ", 5 },
                    { 36, "فردیس", 5 },
                    { 37, "اشتهارد", 5 },
                    { 38, "چهارباغ", 5 },
                    { 39, "طالقان", 5 },
                    { 40, "گرمدره", 5 },
                    { 41, "ایلام", 6 },
                    { 42, "ایوان", 6 },
                    { 43, "دره‌شهر", 6 },
                    { 44, "دهلران", 6 },
                    { 45, "مهران", 6 },
                    { 46, "سرابله", 6 },
                    { 47, "آبدانان", 6 },
                    { 48, "بدره", 6 },
                    { 49, "بوشهر", 7 },
                    { 50, "دشتستان", 7 },
                    { 51, "دشتی", 7 },
                    { 52, "تنگستان", 7 },
                    { 53, "گناوه", 7 },
                    { 54, "کنگان", 7 },
                    { 55, "جم", 7 },
                    { 56, "دیر", 7 },
                    { 57, "تهران", 8 },
                    { 58, "شهریار", 8 },
                    { 59, "ملارد", 8 },
                    { 60, "ری", 8 },
                    { 61, "قدس", 8 },
                    { 62, "اسلام‌شهر", 8 },
                    { 63, "بهارستان", 8 },
                    { 64, "پاکدشت", 8 },
                    { 65, "شهرکرد", 9 },
                    { 66, "فارسان", 9 },
                    { 67, "بروجن", 9 },
                    { 68, "لردگان", 9 },
                    { 69, "سامان", 9 },
                    { 70, "اردل", 9 },
                    { 71, "کیار", 9 },
                    { 72, "بن", 9 },
                    { 73, "بیرجند", 10 },
                    { 74, "قائن", 10 },
                    { 75, "فردوس", 10 },
                    { 76, "نهبندان", 10 },
                    { 77, "طبس", 10 },
                    { 78, "سربیشه", 10 },
                    { 79, "درمیان", 10 },
                    { 80, "خوسف", 10 },
                    { 81, "مشهد", 11 },
                    { 82, "نیشابور", 11 },
                    { 83, "سبزوار", 11 },
                    { 84, "تربت‌حیدریه", 11 },
                    { 85, "قوچان", 11 },
                    { 86, "کاشمر", 11 },
                    { 87, "تربت‌جام", 11 },
                    { 88, "چناران", 11 },
                    { 89, "اهواز", 13 },
                    { 90, "آبادان", 13 },
                    { 91, "خرمشهر", 13 },
                    { 92, "دزفول", 13 },
                    { 93, "شوشتر", 13 },
                    { 94, "بندر ماهشهر", 13 },
                    { 95, "بهبهان", 13 },
                    { 96, "اندیمشک", 13 },
                    { 97, "زنجان", 14 },
                    { 98, "ابهر", 14 },
                    { 99, "خدابنده", 14 },
                    { 100, "خرمدره", 14 },
                    { 101, "سلطانیه", 14 },
                    { 102, "ماه‌نشان", 14 },
                    { 103, "طارم", 14 },
                    { 104, "ایجرود", 14 },
                    { 105, "سمنان", 15 },
                    { 106, "شاهرود", 15 },
                    { 107, "دامغان", 15 },
                    { 108, "گرمسار", 15 },
                    { 109, "مهدیشهر", 15 },
                    { 110, "میامی", 15 },
                    { 111, "سرخه", 15 },
                    { 112, "آرادان", 15 },
                    { 113, "زاهدان", 16 },
                    { 114, "چابهار", 16 },
                    { 115, "ایرانشهر", 16 },
                    { 116, "سراوان", 16 },
                    { 117, "خاش", 16 },
                    { 118, "زابل", 16 },
                    { 119, "نیک‌شهر", 16 },
                    { 120, "کنارک", 16 },
                    { 121, "شیراز", 17 },
                    { 122, "مرودشت", 17 },
                    { 123, "کازرون", 17 },
                    { 124, "جهرم", 17 },
                    { 125, "لارستان", 17 },
                    { 126, "فسا", 17 },
                    { 127, "داراب", 17 },
                    { 128, "نورآباد", 17 },
                    { 129, "قزوین", 18 },
                    { 130, "الوند", 18 },
                    { 131, "آبیک", 18 },
                    { 132, "تاکستان", 18 },
                    { 133, "بوئین‌زهرا", 18 },
                    { 134, "اقبالیه", 18 },
                    { 135, "آوج", 18 },
                    { 136, "محمدیه", 18 },
                    { 137, "قم", 19 },
                    { 138, "جعفریه", 19 },
                    { 139, "دستجرد", 19 },
                    { 140, "قنوات", 19 },
                    { 141, "کهک", 19 },
                    { 142, "سلفچگان", 19 },
                    { 143, "خلجستان", 19 },
                    { 144, "شهرک قدس", 19 },
                    { 145, "سنندج", 20 },
                    { 146, "سقز", 20 },
                    { 147, "بانه", 20 },
                    { 148, "مریوان", 20 },
                    { 149, "بیجار", 20 },
                    { 150, "دیواندره", 20 },
                    { 151, "قروه", 20 },
                    { 152, "کامیاران", 20 },
                    { 153, "کرمان", 21 },
                    { 154, "رفسنجان", 21 },
                    { 155, "سیرجان", 21 },
                    { 156, "جیرفت", 21 },
                    { 157, "بم", 21 },
                    { 158, "زرند", 21 },
                    { 159, "کهنوج", 21 },
                    { 160, "بافت", 21 },
                    { 161, "کرمانشاه", 22 },
                    { 162, "اسلام‌آباد غرب", 22 },
                    { 163, "قصر شیرین", 22 },
                    { 164, "سنقر", 22 },
                    { 165, "کنگاور", 22 },
                    { 166, "سرپل ذهاب", 22 },
                    { 167, "هرسین", 22 },
                    { 168, "پاوه", 22 },
                    { 169, "یاسوج", 23 },
                    { 170, "دهدشت", 23 },
                    { 171, "دوگنبدان", 23 },
                    { 172, "سی‌سخت", 23 },
                    { 173, "لیکک", 23 },
                    { 174, "لنده", 23 },
                    { 175, "چرام", 23 },
                    { 176, "باشت", 23 },
                    { 177, "گرگان", 24 },
                    { 178, "گنبد کاووس", 24 },
                    { 179, "علی‌آباد کتول", 24 },
                    { 180, "آق‌قلا", 24 },
                    { 181, "بندر ترکمن", 24 },
                    { 182, "مینودشت", 24 },
                    { 183, "آزادشهر", 24 },
                    { 184, "کلاله", 24 },
                    { 185, "رشت", 25 },
                    { 186, "انزلی", 25 },
                    { 187, "لاهیجان", 25 },
                    { 188, "لنگرود", 25 },
                    { 189, "آستارا", 25 },
                    { 190, "رودسر", 25 },
                    { 191, "صومعه‌سرا", 25 },
                    { 192, "تالش", 25 },
                    { 193, "خرم‌آباد", 26 },
                    { 194, "بروجرد", 26 },
                    { 195, "دورود", 26 },
                    { 196, "کوهدشت", 26 },
                    { 197, "الیگودرز", 26 },
                    { 198, "نورآباد", 26 },
                    { 199, "پلدختر", 26 },
                    { 200, "ازنا", 26 },
                    { 201, "ساری", 27 },
                    { 202, "بابل", 27 },
                    { 203, "آمل", 27 },
                    { 204, "قائم‌شهر", 27 },
                    { 205, "بهشهر", 27 },
                    { 206, "نور", 27 },
                    { 207, "نوشهر", 27 },
                    { 208, "چالوس", 27 },
                    { 209, "اراک", 28 },
                    { 210, "ساوه", 28 },
                    { 211, "خمین", 28 },
                    { 212, "محلات", 28 },
                    { 213, "دلیجان", 28 },
                    { 214, "شازند", 28 },
                    { 215, "تفرش", 28 },
                    { 216, "آشتیان", 28 },
                    { 217, "بندرعباس", 29 },
                    { 218, "قشم", 29 },
                    { 219, "کیش", 29 },
                    { 220, "بندر لنگه", 29 },
                    { 221, "میناب", 29 },
                    { 222, "رودان", 29 },
                    { 223, "جاسک", 29 },
                    { 224, "حاجی‌آباد", 29 },
                    { 225, "همدان", 30 },
                    { 226, "ملایر", 30 },
                    { 227, "نهاوند", 30 },
                    { 228, "اسدآباد", 30 },
                    { 229, "تویسرکان", 30 },
                    { 230, "کبودرآهنگ", 30 },
                    { 231, "رزن", 30 },
                    { 232, "فامنین", 30 },
                    { 233, "یزد", 31 },
                    { 234, "میبد", 31 },
                    { 235, "اردکان", 31 },
                    { 236, "بافق", 31 },
                    { 237, "مهریز", 31 },
                    { 238, "ابرکوه", 31 },
                    { 239, "تفت", 31 },
                    { 240, "خاتم", 31 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogID",
                table: "BlogComments",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInPakges_PakageId",
                table: "ProductInPakges",
                column: "PakageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInPakges_ProductId",
                table: "ProductInPakges",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductServiceImages_ProductID",
                table: "ProductServiceImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductServices_ProductCategoryID",
                table: "ProductServices",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_projectId",
                table: "ProjectImages",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProductServiceId",
                table: "Projects",
                column: "ProductServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_AgencyTypeId",
                table: "RepApplicants",
                column: "AgencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_CityId",
                table: "RepApplicants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_EducationId",
                table: "RepApplicants",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_EntityTypeId",
                table: "RepApplicants",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_ExperienceId",
                table: "RepApplicants",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_IntroductionId",
                table: "RepApplicants",
                column: "IntroductionId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_JobRequestId",
                table: "RepApplicants",
                column: "JobRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_PropertyTypeId",
                table: "RepApplicants",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_RequestStatusId",
                table: "RepApplicants",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_VehicleAvailabilityId",
                table: "RepApplicants",
                column: "VehicleAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RepApplicants_VehicleTypeId",
                table: "RepApplicants",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepUploadedDocuments_ApplicantId",
                table: "RepUploadedDocuments",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_RepUploadedDocuments_DocumentTypeId",
                table: "RepUploadedDocuments",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionsContents_SectionID",
                table: "SectionsContents",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionsListItems_SectionContentID",
                table: "SectionsListItems",
                column: "SectionContentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "CompanyMembers");

            migrationBuilder.DropTable(
                name: "CRMEmailAddresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PhotoGallery");

            migrationBuilder.DropTable(
                name: "ProductInPakges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductServiceImages");

            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropTable(
                name: "RepUploadedDocuments");

            migrationBuilder.DropTable(
                name: "SectionsListItems");

            migrationBuilder.DropTable(
                name: "ServicePages");

            migrationBuilder.DropTable(
                name: "VisitorLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Pakeges");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "RepApplicants");

            migrationBuilder.DropTable(
                name: "RepDocumentTypes");

            migrationBuilder.DropTable(
                name: "SectionsContents");

            migrationBuilder.DropTable(
                name: "ProductServices");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EducationDegrees");

            migrationBuilder.DropTable(
                name: "RepAgencyTypes");

            migrationBuilder.DropTable(
                name: "RepEntityTypes");

            migrationBuilder.DropTable(
                name: "RepExperiences");

            migrationBuilder.DropTable(
                name: "RepIntroductionMethods");

            migrationBuilder.DropTable(
                name: "RepJobRequests");

            migrationBuilder.DropTable(
                name: "RepPropertyTypes");

            migrationBuilder.DropTable(
                name: "RepRequestStatuses");

            migrationBuilder.DropTable(
                name: "RepVehicleAvailabilities");

            migrationBuilder.DropTable(
                name: "RepVehicleTypes");

            migrationBuilder.DropTable(
                name: "SitePages");

            migrationBuilder.DropTable(
                name: "ProductServiceCategories");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
