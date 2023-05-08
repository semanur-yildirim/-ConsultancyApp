using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsultancyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    userId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Psychologist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psychologist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    What = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    How = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    HowLong = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ForWho = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Purpose = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    PositiveEffect = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDescription_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistCategory",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistCategory", x => new { x.PsychologistId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PsychologistCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistCategory_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistCustomer",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistCustomer", x => new { x.PsychologistId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_PsychologistCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistCustomer_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false),
                    GraduationYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Education = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologistDescription_Psychologist_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", null, "Psikologlar", "Psychologist", "PSYCHOLOGIST" },
                    { "b4995b4c-f6e4-40e0-8b6f-1a41b1545501", null, "Kullanıcılar", "Customer", "CUSTOMER" },
                    { "bbaf0bcf-05d6-4de3-9d3b-2e71669977aa", null, "Yöneticiler", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[,]
                {
                    { "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21", 0, "613d0080-7b72-480d-9126-97ed7c297a36", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "baris@gmail.com", true, "Barış", "Durmuş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARIS@GMAIL.COM", "BARISDURMUS", "BARIS", "AQAAAAIAAYagAAAAEGhT0zD9akPBPUTPEznDyz/Fe3saFL+z02u4GJTKD2qWq4zSO+agpLe4JpghfG00dA==", null, false, "43c6c621-a01a-4a47-9219-5c316eb496b5", false, 1, "barıs" },
                    { "8da007be-c50b-4973-aa45-224b7358hkn15", 0, "3e1e0b93-b73b-4438-8ec8-d37ce7cae150", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "selvi@gmail.com", true, "Selvi", "Kartal", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SELVI@GMAIL.COM", "SELVIKARTAL", "SELVI", "AQAAAAIAAYagAAAAEGiHAcyCGpaq109oIk7Wo6H3UKR0c+AFAEnIH0GfnYqnASarnypmCMhARnWe/gylZA==", null, false, "fa054432-5678-46d0-8aa7-8f629ed4bd0f", false, 1, "selvi" },
                    { "9e8f345d-141f-4ef2-99c7-8a9476llh93", 0, "113849ec-393d-46ae-913d-1bdd9b24491b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@gmail.com", true, "Ahmet", "Ovalı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AHMET@GMAIL.COM", "AHMETOVALI", "AHMET", "AQAAAAIAAYagAAAAEITqlrOCBucFq2jHyhBKlcenNApWyIFrYVSsVD8X+lblkb2qHPL3OTc4SAYzyo9W7Q==", null, false, "df0b1e33-abb6-46aa-9819-c00761260d8b", false, 1, "ahmet" },
                    { "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f", 0, "c98858f3-c3c5-4f79-96d9-e98c84b6ffd0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@gmail.com", true, "Mehmet", "Tatlı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEHMET@GMAIL.COM", "MEHMETTATLI", "MEHMET", "AQAAAAIAAYagAAAAEIHg4wMgrB0Kqk0WUarTAW8DzJY53Lxw0iyMceT/jbwnpWbnQX4qhHXr6yVLK3ksbw==", null, false, "371bfc4d-f36d-40bc-aad8-282d5c83b998", false, 2, "-mehmet" },
                    { "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62", 0, "8e79d782-e6e8-42b4-accd-98c2e6e45051", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep@gmail.com", true, "Zeynep", "Öztürk", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZEYNEP@GMAIL.COM", "ZEYNEPOZTURK", "ZEYNEP", "AQAAAAIAAYagAAAAEJ+9J1NC1bCK6y0DtiE12wMOuyi20TEQnKO4IZM70yhjGZb9sSlAOVhyhvNZTwkbXg==", null, false, "21a790bd-b189-44fb-917f-a50cf3d9e193", false, 1, "zeynep" },
                    { "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34", 0, "1d9ac8b7-ad5b-43c8-b910-b5d6a087b15d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "merve@gmail.com", true, "Merve", "Kara", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MERVE@GMAIL.COM", "MERVEKARA", "MERVE", "AQAAAAIAAYagAAAAEIm6p2b6DOrRLUjgYSvCrasbVDKwsNAVLxhZzyZ741cJ4vl+PHPuZ/syKsvOVyHHCA==", null, false, "7785d825-4fee-41f2-8745-9ac53d23fe9f", false, 1, "merve" },
                    { "b342e19c-42af-4f25-b820-7a07dc9mbf13", 0, "43cbc987-0b81-434c-b5d1-92ebd923d9d2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali@gmail.com", true, "Ali", "Yılmaz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI@GMAIL.COM", "ALIYILMAZ", "ALI", "AQAAAAIAAYagAAAAEEByoPqdCmHFSYdNiSNaxid0CFTBW4g/KWFo53vkiULIY5/9BsNw1/Xh3RvRz8AkGw==", null, false, "6bc7ead8-eca2-4521-8d66-52b547c466de", false, 1, "ali" },
                    { "b342e25a-42af-4f25-b820-7a07dc9mbf13", 0, "ed7fc176-1616-4a4d-b7ae-90fc931ef5ff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre@gmail.com", true, "Emre", "Ateş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMRE@GMAIL.COM", "EMREATES", "EMRE", "AQAAAAIAAYagAAAAEMzn/QG4QVPbqDsw80yDglSBBf1TwcuLHMNwaCl3j3QynrQ3UuxvcQWAVBSCthlcPA==", null, false, "e293c42b-32ed-41c4-b2c4-16969e820f92", false, 1, "emre" },
                    { "b35f20c1-836f-49c1-b46f-2399e12pvc85", 0, "53bce95e-db0d-4ba2-b3f8-4da8a48d985b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem@gmail.com", true, "Cem", "Kar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CEM@GMAIL.COM", "CEMKAR", "CEM", "AQAAAAIAAYagAAAAEGqVRmueVaczccxQucsPX2YustpaDeyc7t+ghHg7Ihe44ISKioS9otUAsW1bg1clww==", null, false, "dd08ac3b-e08a-4c2f-85ef-8545e3e2e3c4", false, 1, "cem" },
                    { "eabb7e42-6e53-4696-b350-da56Or2c79fa", 0, "4a3b3817-94b6-4ba4-9f96-b8f8cac5df02", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "canan@gmail.com", true, "Canan", "Umaç", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CANAN@GMAIL.COM", "CANANUMAC", "CANAN", "AQAAAAIAAYagAAAAELEq0/emOH9Gx9++3Jl2/+Wppo6mN9eBn0JN/xl6GMa1sXiYLJQ+IpNlpPtnVF0tVg==", null, false, "a376849e-cd69-4e8e-b604-ffd88cd58d16", false, 2, "canan" },
                    { "eabb7e42-6e53-4696-b350-da64de2c79fa", 0, "a5072e91-9d92-40b7-85d2-a9322f51f1d9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "omer@gmail.com", true, "Ömer", "Akyüz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMER@GMAIL.COM", "OMERAKYUZ", "OMER", "AQAAAAIAAYagAAAAEPWSV9VfMUf0rMZHLgepn2vqCORiu27oh/pz7vQGlL3TG0xFT4VOaHU8lFFFmMenTw==", null, false, "2499a8eb-80f1-4c6e-9791-cf24cf2dae56", false, 2, "ömer" },
                    { "kema7e42-6e53-4696-b350-ke56Or2c79fa", 0, "27ebcf0d-3c82-4937-9497-17a8bd189b17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "semanur@gmail.com", true, "Semanur", "Yıldırım", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMANUR@GMAIL.COM", "SEMANURYILDIRIM", "SEMANUR", "AQAAAAIAAYagAAAAENsAS3zbPCekHP7lOKrhwZhweyjiPDMzfwW6RwGIdI8+tpoo2ZezEXGystVrOfbjKA==", null, false, "8972da19-a482-401c-8962-373e587f2192", false, 0, "semanur" },
                    { "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34", 0, "be8eed78-835f-42c3-a15d-dab93d30719a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin@gmail.com", true, "Aylin", "Uzar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AYLIN@GMAIL.COM", "AYLINUZAR", "AYLIN", "AQAAAAIAAYagAAAAEFhfjDDvMiXN6WZknXIF1QSNTkaBzW500mFAWjqnUJhLpx/VZdvo/3NNG5ka39Ex7A==", null, false, "ce91bb11-91e5-4408-b9c2-9865e09a28f4", false, 1, "aylin" },
                    { "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34", 0, "6b242741-bd91-4466-beb7-92e7f65f1b63", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aslı@gmail.com", true, "Aslı", "Yaman", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASLI@GMAIL.COM", "ASLIYAMAN", "ASLI", "AQAAAAIAAYagAAAAEHqp+eN0qSEI+GBl1riQ79BhleVapRMNyg96kmlrL5+o0tIzqfp64jh4F5dfERTSpA==", null, false, "7d78bec0-f7bf-4532-ac65-644305333605", false, 1, "aslı" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8626), true, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8632), "Bireysel Terapi", "bireysel-terapi" },
                    { 2, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8635), true, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8636), "İlişki Terapisi", "iliski-terapisi" },
                    { 3, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8638), true, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8638), "Aile Terapisi", "aile-terapisi" },
                    { 4, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8640), false, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8641), "Çocuk Terapisi", "cocuk-terapisi" },
                    { 5, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8642), true, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8643), "Ergen Terapisi", "ergen-terapisi" },
                    { 6, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8644), true, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8645), "Oyun Terapisi", "oyun-terapisi" },
                    { 7, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8646), false, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8647), "Sanat Danışmanlık", "sanat-danismanlik" },
                    { 8, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8648), true, new DateTime(2023, 5, 7, 16, 33, 56, 947, DateTimeKind.Local).AddTicks(8649), "Cinsel Yönetimi", "cinsel-terapi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { "b4995b4c-f6e4-40e0-8b6f-1a41b1545501", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { "b4995b4c-f6e4-40e0-8b6f-1a41b1545501", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { "b4995b4c-f6e4-40e0-8b6f-1a41b1545501", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { "bbaf0bcf-05d6-4de3-9d3b-2e71669977aa", "kema7e42-6e53-4696-b350-ke56Or2c79fa" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { "63e7f56d-a0b2-4485-8f98-f5ac2e3a0bc0", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { 2, "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { 3, "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { 4, "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" },
                    { 5, "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { 6, "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { 7, "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { 8, "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { 9, "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { 10, "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" },
                    { 11, "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { 12, "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { 13, "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" },
                    { 14, "kema7e42-6e53-4696-b350-ke56Or2c79fa" }
                });

            migrationBuilder.InsertData(
                table: "CategoryDescription",
                columns: new[] { "Id", "CategoryId", "ForWho", "How", "HowLong", "PositiveEffect", "Purpose", "Summary", "What" },
                values: new object[,]
                {
                    { 1, 1, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarınısağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Kişinin yaşadığı sorunları bireysel çerçevede ele alarak çözmeyi hedefler.", "Bireysel terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 2, 2, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "Terapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarınısağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Aile yapısı ile aile bireyleri arasındaki iletişim biçimini ele alarak sorunlarını çözmeyi ve ailenin sağlamlığını arttırmayı hedefler.", "Aile terapisi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 3, 3, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Aile yapısı ile aile bireyleri arasındaki iletişim biçimini ele alarak sorunlarını çözmeyi ve ailenin sağlamlığını arttırmayı hedefler.", "Aile terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 4, 4, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Çocukların çevreleriyle yaşadıkları çatışmaları çözümlemeyi ve sorunlara farklı bakış açısıyla bakabilmelerini hedefler.", "Çocuk terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 5, 5, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Gençlerin çevreleriyle yaşadıkları çatışmaları çözümlemeyi ve sorunlara farklı bakış açısıyla bakabilmelerini hedefler.", "Ergen terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 6, 6, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Çocuklara güvenli bir ortam sunarak oyun ve oyuncaklarla beraber kendilerini ifade etme gereksinimlerine odaklanmayı hedefler.", "Oyun terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 7, 7, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Bireylerin halay gücünü kullanarak duygularının dışavurumunu kolaylaştırmayı hedefler.", "Sanat terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 8, 8, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Bireylerin ve çiftlerin yaşadığı cinsel sorunları çözmeyi ve ruhsal dengeyi korumayı hedefler.", "Cinsel terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url", "userId" },
                values: new object[,]
                {
                    { 1, "Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4", new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7665), true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7684), "Canan Umaç", "ahmet-umac", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { 2, "Güzelbahçe mahallesi Kumsal sokak no:13", new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7711), true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7713), "Ömer Akyüz", "omer-akyuz", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { 3, "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5", new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7729), true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7730), "Mehmet Tatlı", "mehmet-tatli", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" }
                });

            migrationBuilder.InsertData(
                table: "Psychologist",
                columns: new[] { "Id", "CreatedDate", "Gender", "IsApproved", "ModifiedDate", "Name", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7912), "Kadın", false, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7916), "Selvi Kartal", 450m, "Selvi-kartal", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { 2, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7944), "Kadın", false, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7945), "Zeynep Öztürk", 350m, "zeynep-ozturk", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { 3, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7950), "Kadın", false, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7951), "Merve Kara", 400m, "merve-kara", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { 4, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7955), "Kadın", false, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7957), "Aslı Yaman", 450m, "asli-yaman", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" },
                    { 5, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7961), "Kadın", false, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7962), "Aylin Uzar", 350m, "aylin-uzar", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { 6, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7969), "Erkek", false, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7970), "Ali Yılmaz", 500m, "ali-yilmaz", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { 7, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7974), "Erkek", true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7975), "Cem Kar", 400m, "cem-kar", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { 8, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7979), "Erkek", true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7980), "Ahmet Ovali", 350m, "ahmet-ovali", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { 9, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7984), "Erkek", true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7985), "Emre Ateş", 350m, "emre-ates", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { 10, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7990), "Erkek", true, new DateTime(2023, 5, 7, 16, 33, 55, 261, DateTimeKind.Local).AddTicks(7991), "Barış Durmuş", 350m, "barıs-durmus", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "PsychologistId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4779), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4785), 1, "k-1.jpg" },
                    { 2, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4788), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4789), 2, "k-2.jpg" },
                    { 3, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4790), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4791), 3, "k-3.jpg" },
                    { 4, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4793), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4793), 4, "k-4.jpg" },
                    { 5, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4794), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4795), 5, "k-5.jpg" },
                    { 6, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4796), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4797), 6, "e-1.jpg" },
                    { 7, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4798), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4799), 7, "e-2.jpg" },
                    { 8, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4800), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4801), 8, "e-3.jpg" },
                    { 9, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4802), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4802), 9, "e-4.jpg" },
                    { 10, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4804), true, new DateTime(2023, 5, 7, 16, 33, 56, 949, DateTimeKind.Local).AddTicks(4804), 10, "e-5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PsychologistCategory",
                columns: new[] { "CategoryId", "PsychologistId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 5, 6 },
                    { 6, 6 },
                    { 5, 7 },
                    { 7, 7 },
                    { 8, 7 },
                    { 6, 8 },
                    { 7, 8 },
                    { 4, 9 },
                    { 5, 9 },
                    { 8, 9 },
                    { 6, 10 }
                });

            migrationBuilder.InsertData(
                table: "PsychologistCustomer",
                columns: new[] { "CustomerId", "PsychologistId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "PsychologistDescription",
                columns: new[] { "Id", "About", "Education", "Experience", "GraduationYear", "PsychologistId" },
                values: new object[,]
                {
                    { 1, "Sosyal Terapist, Bağımlılık Terapisti, Psikodrama Yöneticisi, Organizasyon Geliştirici İzmir Üniversitesi bölümünü tamamlayıp, ardından Almanya’da Sağlık Managment Yüksek Lisans Master egitimini  Magdeburg-Stendal Yüksekokulunda tamamlamıştır. Almanya’da psikososyal alanda 1982 yılından itibaren mesleki calışmasına paralel, 2013 tarihine kadar Sosyalterapi, Bagimlilik terapisti, Psikodrama Grup Yöneticisi, Organizasyon Geliştirici ve Choac  eğitimlerini aldı.", "İzmir Üniversitesi Psikoloji", "Online ve Yüz yüze Terapi", new DateTime(2000, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Bireysel terapi, grup terapisi, cinsel sağlık, madde bağımlılığı, anksiyete ve depresyon konularında uzmanım. Terapi sürecinde öncelikle güvenli bir ilişki kurmayı hedeflerim. İletişim becerileri, bilişsel davranışçı terapi, psikodinamik yaklaşım gibi farklı terapi yöntemleri kullanırım.", "Hacettepe Üniversitesi Psikoloji", "Bireysel ve Grup Terapisi", new DateTime(2005, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "İyi bir dinleyici ve gözlemciyim. Terapi sürecinde öncelikle danışanın sorunlarına odaklanarak, onun düşünce ve duygularını anlamaya çalışırım. Depresyon, anksiyete, panik atak gibi konularda terapi süreci yürütmekteyim.", "Boğaziçi Üniversitesi Psikoloji", "Depresyon ve Anksiyete Terapisi", new DateTime(2007, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "Çocuklar ve ailelerine yönelik terapi süreçlerinde, oyun terapisi, sanat terapisi ve aile danışmanlığı gibi yöntemleri kullanmaktayım. Her çocuğun farklı bir yapısı olduğunu ve ona göre bir terapi planı hazırlanması gerektiğini düşünmekteyim.", "Ankara Üniversitesi Psikoloji", "Çocuk ve Aile Terapisi", new DateTime(2010, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, "Stres ve öfke yönetimi konularında uzmanım. Terapi sürecinde, danışanın stres ve öfke seviyesini düşürmek için birlikte çalışırız. Bunun için bilişsel davranışçı terapi, nefes egzersizleri, meditasyon ve benzeri yöntemler kullanmaktayım.", "İstanbul Üniversitesi Psikoloji", "Stres ve Öfke Yönetimi", new DateTime(2002, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, "Ankara Üniversitesi Psikoloji bölümünden mezun olan psikolog, çift terapisi ve aile terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Çözüm Odaklı Terapi ve Şema Terapi bulunmaktadır.", "Ankara Üniversitesi Psikoloji", "Aile Terapisi, Çift Terapisi", new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, "Boğaziçi Üniversitesi Psikoloji bölümünden mezun olan psikolog, ergen terapisi ve bağımlılık terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Motivasyonel Röportaj ve EMDR bulunmaktadır.", "Boğaziçi Üniversitesi Psikoloji", "Ergen Terapisi, Bağımlılık Terapisi", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, "Hacettepe Üniversitesi Psikoloji bölümünden mezun olan psikolog, stres yönetimi ve depresyon terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Psikanalitik Terapi ve EFT bulunmaktadır.", "Hacettepe Üniversitesi Psikoloji", "Stres Yönetimi, Depresyon Terapisi", new DateTime(2012, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, "İstanbul Üniversitesi Psikoloji bölümünden mezun olan psikolog, bireysel terapi, çift terapisi ve aile terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Şema Terapi ve Gestalt Terapi bulunmaktadır.", "İstanbul Üniversitesi Psikoloji", "Bireysel Terapi, Çift Terapisi, Aile Terapisi", new DateTime(2003, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, "Çocuklarla ve aileleriyle çalışmayı seven bir terapistim. Özellikle, çocuklarda davranış sorunları, kaygı, depresyon ve dikkat eksikliği konularında deneyimim var. Tedavide, bütünsel bir yaklaşım benimsemekteyim ve bu doğrultuda bireysel terapi, aile terapisi ve ebeveyn rehberliği gibi yöntemleri kullanmaktayım.", "Hacettepe Üniversitesi Psikoloji", "Çocuk ve Aile Terapisi", new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PsychologistId",
                table: "CartItems",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDescription_CategoryId",
                table: "CategoryDescription",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_userId",
                table: "Customer",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PsychologistId",
                table: "Images",
                column: "PsychologistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PsychologistId",
                table: "OrderItems",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Psychologist_UserId",
                table: "Psychologist",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistCategory_CategoryId",
                table: "PsychologistCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistCustomer_CustomerId",
                table: "PsychologistCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistDescription_PsychologistId",
                table: "PsychologistDescription",
                column: "PsychologistId",
                unique: true);
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CategoryDescription");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PsychologistCategory");

            migrationBuilder.DropTable(
                name: "PsychologistCustomer");

            migrationBuilder.DropTable(
                name: "PsychologistDescription");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Psychologist");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
