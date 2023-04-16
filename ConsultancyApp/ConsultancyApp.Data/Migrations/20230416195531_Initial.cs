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
                        principalColumn: "Id");
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
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: false)
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
                        principalColumn: "Id");
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
                    Gender = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    userId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psychologist_AspNetUsers_userId",
                        column: x => x.userId,
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
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", null, "Psikologlar", "Psychologist", "PSYCHOLOGIST" },
                    { "7358a9e4-b73d-430f-baa7-72834d0a6bf8", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "d2aed15b-dea2-4f92-828c-9d083374f158", null, "Kullanıcılar", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[,]
                {
                    { "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21", 0, "d50155ee-70c3-49a0-b114-f753a4281a4c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "baris@gmail.com", true, "Barış", "Durmuş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARIS@GMAIL.COM", "BARISDURMUS", "BARIS", "AQAAAAIAAYagAAAAEOt8cPVw/9MunvXOmPWpZ2SirpSRt7ur1gXgeHevPTW/611ezVB7M5KB81tIvqWeag==", null, false, "577bf186-de7a-446a-aa19-a1a6e07a9cf8", false, 1, "barıs" },
                    { "8da007be-c50b-4973-aa45-224b7358hkn15", 0, "79642e2f-fde5-43e5-b9e6-617d37025bda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "selvi@gmail.com", true, "Selvi", "Kartal", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SELVI@GMAIL.COM", "SELVIKARTAL", "SELVI", "AQAAAAIAAYagAAAAEIZU0qxMKW56YvYHVJQcFj1AEWYb9Cly6VEnr2f6lYbdsp057GZjyWdxs3KgFfBJdw==", null, false, "542ede4d-64b2-4be6-a843-d7a28b6e23b0", false, 1, "selvi" },
                    { "9e8f345d-141f-4ef2-99c7-8a9476llh93", 0, "846f9302-23bc-4d2b-ae65-917c439e9ec7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@gmail.com", true, "Ahmet", "Ovalı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AHMET@GMAIL.COM", "AHMETOVALI", "AHMET", "AQAAAAIAAYagAAAAEOJz4yj8KsKBINPyrZG9gfQajeXWyYTE+4lJSHB/x8OTVD4+GAMB0d+JkAL5tP660w==", null, false, "d0584a80-95e3-4d96-9793-7ab4bfa0c134", false, 1, "ahmet" },
                    { "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f", 0, "c91c64b5-3f50-4e0d-ab09-42d8a354a9ab", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@gmail.com", true, "Mehmet", "Tatlı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEHMET@GMAIL.COM", "MEHMETTATLI", "MEHMET", "AQAAAAIAAYagAAAAEDq/h+RO6crVBWmwCsBFP1vxUYyaSsFVGJQ1tdFzoYnxWUb4lE0cP70S5pojyGcT3w==", null, false, "34aef8ee-3dd2-4ee3-a1f4-3ffb38b3ceef", false, 2, "-mehmet" },
                    { "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62", 0, "0564672d-3f5f-42e8-b82b-bf9271446902", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep@gmail.com", true, "Zeynep", "Öztürk", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZEYNEP@GMAIL.COM", "ZEYNEPOZTURK", "ZEYNEP", "AQAAAAIAAYagAAAAEA1AQsRLYW0gVWzBgZk6MTDnZNb3Nng/pb0PaOoYEM2oJSJMwaC4vTULfcSf9X8Psg==", null, false, "b1ef40ab-f879-473c-9db8-5feadfa3bf09", false, 1, "zeynep" },
                    { "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34", 0, "ee93abc4-967b-4101-94d1-08e412085754", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "merve@gmail.com", true, "Merve", "Kara", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MERVE@GMAIL.COM", "MERVEKARA", "MERVE", "AQAAAAIAAYagAAAAEKhVV11OxxTNGtPJCG3F9ugmKfYGGaNlzO0AhdI9Qx65jiepLfcO+CFmET7DwX6+rA==", null, false, "f8a5af56-2cde-40b4-a0e2-1210a0a9f7d2", false, 1, "merve" },
                    { "b342e19c-42af-4f25-b820-7a07dc9mbf13", 0, "081c2afd-7cd7-464c-92a8-d4b69c9da36c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali@gmail.com", true, "Ali", "Yılmaz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI@GMAIL.COM", "ALIYILMAZ", "ALI", "AQAAAAIAAYagAAAAENfR0m1WCoAI4/942TMCRNLECGd/zKBYBaxmfrI5eHIJORilQFs+i5nwadKKDedztA==", null, false, "1ac0739c-da13-4a34-9ba3-2f6a330729ef", false, 1, "ali" },
                    { "b342e25a-42af-4f25-b820-7a07dc9mbf13", 0, "b082d038-cd90-4503-b3e0-e9c000d9a115", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre@gmail.com", true, "Emre", "Ateş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMRE@GMAIL.COM", "EMREATES", "EMRE", "AQAAAAIAAYagAAAAEK8GQRdlR3ylZ+qRu95/9I+p/ICRZQ+iflDOmMKc8pUhSntyJ5Mez3NJ9wbtqEbSzg==", null, false, "8a883cf6-2331-4849-8ded-af55e6ffe9ab", false, 1, "emre" },
                    { "b35f20c1-836f-49c1-b46f-2399e12pvc85", 0, "d282704c-f638-4412-96df-4c72c99cc51c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem@gmail.com", true, "Cem", "Kar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CEM@GMAIL.COM", "CEMKAR", "CEM", "AQAAAAIAAYagAAAAEJlqOEsBNcC21qI2PWmxg7y3iewK7sDUNNqyfR/NoXvCqtd8MqKFRmQzkfDNnLKH+A==", null, false, "eaf77bf6-7c5c-4612-826e-a7f2068739bf", false, 1, "cem" },
                    { "eabb7e42-6e53-4696-b350-da56Or2c79fa", 0, "485953df-a7db-4c10-8c01-203353d56558", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "canan@gmail.com", true, "Canan", "Umaç", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CANAN@GMAIL.COM", "CANANUMAC", "CANAN", "AQAAAAIAAYagAAAAEO7NZRKOXZk1okCbxx9CHqpJgGNmsaZEIWPaQRLOq8KUVDa7f/1GnHbZT4C1GIe9vQ==", null, false, "457f2c50-f273-44a1-abec-0a3035edf33c", false, 2, "canan" },
                    { "eabb7e42-6e53-4696-b350-da64de2c79fa", 0, "4e996956-4d2b-4b1f-8ee2-854e7478554b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "omer@gmail.com", true, "Ömer", "Akyüz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMER@GMAIL.COM", "OMERAKYUZ", "OMER", "AQAAAAIAAYagAAAAEOxcT6Dd/MRyi+3BcOsPR+/g7QywYuQqdZHMJYVEHLz5QRRxwZxQIYMcdneX0D3/aQ==", null, false, "46788894-2383-4ace-8f11-33666e3039bb", false, 2, "ömer" },
                    { "kema7e42-6e53-4696-b350-ke56Or2c79fa", 0, "b4166bf6-c7b9-435f-bb6f-94c5645272dc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "semanur@gmail.com", true, "Semanur", "Yıldırım", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMANUR@GMAIL.COM", "SEMANURYILDIRIM", "SEMANUR", "AQAAAAIAAYagAAAAEHyG9WtbIw5J/smR4DY6/slE/zEm6g87pEZ7Kbri1dXnRTz/0ptDP2sISkStz9YfGQ==", null, false, "ee73d826-d340-4a07-98ea-bb134de7d7a5", false, 0, "semanur" },
                    { "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34", 0, "630e707b-63b8-44ca-9c94-7480a132e622", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin@gmail.com", true, "Aylin", "Uzar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AYLIN@GMAIL.COM", "AYLINUZAR", "AYLIN", "AQAAAAIAAYagAAAAEFv1MHqPKqj9/E2RWPPJU3AT3ukn7BPuNf+1MyOsn1uE4BpAce8JWkmhAWgPebDqnw==", null, false, "b5062cc3-6e4b-4383-8742-10eeeb6146e9", false, 1, "aylin" },
                    { "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34", 0, "8cdfa40e-4f7a-4046-9192-d6a64cba44dd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aslı@gmail.com", true, "Aslı", "Yaman", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASLI@GMAIL.COM", "ASLIYAMAN", "ASLI", "AQAAAAIAAYagAAAAEDSsP0C4+LYiyVLa5hJwnzbhAnqCJyP0W7UHpaFavZCiLWxwxv9f0EuHQCenLVc6Tw==", null, false, "4a28abf8-aa54-4414-968d-b6362297cc0d", false, 1, "aslı" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7532), true, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7540), "Bireysel Terapi", "bireysel-terapi" },
                    { 2, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7544), true, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7545), "İlişki Terapisi", "iliski-terapisi" },
                    { 3, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7547), true, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7548), "Aile Terapisi", "aile-terapisi" },
                    { 4, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7550), false, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7550), "Çocuk Terapisi", "cocuk-terapisi" },
                    { 5, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7552), true, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7553), "Ergen Terapisi", "ergen-terapisi" },
                    { 6, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7555), true, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7555), "Oyun Terapisi", "oyun-terapisi" },
                    { 7, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7558), false, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7559), "Sanat Danışmanlık", "sanat-danismanlik" },
                    { 8, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7561), true, new DateTime(2023, 4, 16, 22, 55, 30, 955, DateTimeKind.Local).AddTicks(7561), "Cinsel Yönetimi", "cinsel-terapi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { "d2aed15b-dea2-4f92-828c-9d083374f158", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { "d2aed15b-dea2-4f92-828c-9d083374f158", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { "d2aed15b-dea2-4f92-828c-9d083374f158", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { "7358a9e4-b73d-430f-baa7-72834d0a6bf8", "kema7e42-6e53-4696-b350-ke56Or2c79fa" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { "685366d8-8eab-40ec-857d-9de15eb94ea6", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" }
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
                columns: new[] { "Id", "CategoryId", "ForWho", "How", "HowLong", "PositiveEffect", "Purpose", "What" },
                values: new object[,]
                {
                    { 1, 1, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarınısağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Bireysel terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 2, 2, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "Terapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarınısağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Aile terapisi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 3, 3, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Aile terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 4, 4, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "ÇOcuk terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 5, 5, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Ergen terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 6, 6, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Oyun terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 7, 7, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Sanat terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 8, 8, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Cinsel terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "PsychologistId", "Url", "userId" },
                values: new object[,]
                {
                    { 1, "Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4", new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6689), true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6705), "Ahmet", 0, "ahmet-hasta", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { 2, "Güzelbahçe mahallesi Kumsal sokak no:13", new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6715), true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6715), "Ömer", 0, "omer-hasta", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { 3, "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5", new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6728), true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6728), "Mehmet", 0, "mehmet-hasta", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" }
                });

            migrationBuilder.InsertData(
                table: "Psychologist",
                columns: new[] { "Id", "CreatedDate", "Gender", "IsApproved", "ModifiedDate", "Name", "Price", "Url", "userId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6789), "Kadın", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6791), "Selvi", 450m, "Selvi-psikolog", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { 2, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6800), "Kadın", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6801), "Zeynep", 350m, "zeynep-psikolog", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { 3, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6805), "Kadın", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6806), "Merve", 400m, "merve-psikolog", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { 4, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6809), "Kadın", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6810), "Aslı", 450m, "asli-psikolog", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" },
                    { 5, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6813), "Kadın", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6814), "Aylin", 350m, "aylin-psikolog", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { 6, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6819), "Erkek", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6820), "Ali", 500m, "ali-psikolog", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { 7, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6824), "Erkek", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6824), "Cem", 400m, "cem-psikolog", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { 8, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6828), "Erkek", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6828), "Ahmet", 350m, "ahmet-psikolog", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { 9, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6833), "Erkek", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6834), "Emre", 350m, "emre-psikolog", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { 10, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6839), "Erkek", true, new DateTime(2023, 4, 16, 22, 55, 28, 657, DateTimeKind.Local).AddTicks(6839), "Barış", 350m, "barıs-psikolog", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "PsychologistId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2938), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2942), 1, "k-1.jpg" },
                    { 2, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2946), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2946), 2, "k-2.jpg" },
                    { 3, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2948), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2949), 3, "k-3.jpg" },
                    { 4, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2951), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2952), 4, "k-4.jpg" },
                    { 5, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2953), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2954), 5, "k-5.jpg" },
                    { 6, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2955), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2956), 6, "e-1.jpg" },
                    { 7, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2958), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2959), 7, "e-2.jpg" },
                    { 8, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2960), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2961), 8, "e-3.jpg" },
                    { 9, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2963), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2963), 9, "e-4.jpg" },
                    { 10, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2965), true, new DateTime(2023, 4, 16, 22, 55, 30, 957, DateTimeKind.Local).AddTicks(2966), 10, "e-5.jpg" }
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
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDescription_CategoryId",
                table: "CategoryDescription",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_userId",
                table: "Customer",
                column: "userId");

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
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Psychologist_userId",
                table: "Psychologist",
                column: "userId");

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
