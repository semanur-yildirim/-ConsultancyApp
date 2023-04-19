using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsultancyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
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
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", null, "Psikologlar", "Psychologist", "PSYCHOLOGIST" },
                    { "454ed758-6d8b-485a-9be2-3c3c5a9065f2", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "f9cd1865-06d2-4e61-b0a5-75db7e7db218", null, "Kullanıcılar", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[,]
                {
                    { "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21", 0, "ed461d7e-cc05-4612-83fe-9a2245487b8c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "baris@gmail.com", true, "Barış", "Durmuş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARIS@GMAIL.COM", "BARISDURMUS", "BARIS", "AQAAAAIAAYagAAAAEIDyDbRu1vLJ3vNOUfS8+q8PF9nv8TbzMmYfH3gxDtRlqzbwq2q1US1PdR2VDJY7Dw==", null, false, "a4efa980-6265-4140-9cef-ec6c5d598125", false, 1, "barıs" },
                    { "8da007be-c50b-4973-aa45-224b7358hkn15", 0, "9a33ce43-7570-4e94-beae-b439d66465e7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "selvi@gmail.com", true, "Selvi", "Kartal", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SELVI@GMAIL.COM", "SELVIKARTAL", "SELVI", "AQAAAAIAAYagAAAAEGqoLN9jLQpohclwnoAfB8CJXIraiiCbye5qeOof9ebNPJgUbP8vsdTFd7M04qV19A==", null, false, "320d335f-d7e9-4eb5-b0c9-dd742a371d8d", false, 1, "selvi" },
                    { "9e8f345d-141f-4ef2-99c7-8a9476llh93", 0, "84236ca8-864e-4a8e-9477-1e4327d6e664", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@gmail.com", true, "Ahmet", "Ovalı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AHMET@GMAIL.COM", "AHMETOVALI", "AHMET", "AQAAAAIAAYagAAAAEChF/ECx5CeI3cd/juszmIR73RzwdJdtO+vdur+HC61FUf72tasWwxgJXIdKLkIfgQ==", null, false, "3335ecea-59d0-4738-b3b6-1e14a452de5a", false, 1, "ahmet" },
                    { "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f", 0, "8e9a3ca9-f3b6-41d6-a54c-e94e3b220722", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@gmail.com", true, "Mehmet", "Tatlı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEHMET@GMAIL.COM", "MEHMETTATLI", "MEHMET", "AQAAAAIAAYagAAAAEICbpWUsbdMS4+sLDLF0OcFb2MNs/PQD+SpECXLGPku56PlEJG+K9p4Er4s85O7uQA==", null, false, "37d3712a-8745-48f2-a37c-57eef4c3f1c2", false, 2, "-mehmet" },
                    { "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62", 0, "7351eda2-c2f1-4624-abce-45cf6ab000fa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep@gmail.com", true, "Zeynep", "Öztürk", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZEYNEP@GMAIL.COM", "ZEYNEPOZTURK", "ZEYNEP", "AQAAAAIAAYagAAAAEHoKp4Al0l0fQBSYNDSyS1lRBHtahRZhd/dJQ4uk4f0+reIPlEVxiejN/OsyOehFLg==", null, false, "209b51f1-9366-4cab-b331-7bcd848db296", false, 1, "zeynep" },
                    { "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34", 0, "5b238b92-b5c7-421f-911e-9b89218d69fc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "merve@gmail.com", true, "Merve", "Kara", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MERVE@GMAIL.COM", "MERVEKARA", "MERVE", "AQAAAAIAAYagAAAAEB+U8YMfm42iqj2hh1gSxEWuTMcHDX6VQJZPCUETS9Z11f62AcOEGJypciE8KrI2+A==", null, false, "fac692c0-4b42-4d83-a5c3-c1dbc5ab3d47", false, 1, "merve" },
                    { "b342e19c-42af-4f25-b820-7a07dc9mbf13", 0, "38dbbaad-4ebc-4dda-b58f-9bf93712d616", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali@gmail.com", true, "Ali", "Yılmaz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI@GMAIL.COM", "ALIYILMAZ", "ALI", "AQAAAAIAAYagAAAAEMak5g4gsA/tliUj20jtbDtfSWLf+n3sjPc+vreLiwsuRkaOy09fnXLVasLLFnKYuw==", null, false, "6536dd82-b064-4a0b-98c2-ab0166843ab1", false, 1, "ali" },
                    { "b342e25a-42af-4f25-b820-7a07dc9mbf13", 0, "ace168c5-6f15-49d9-8b8a-3154f89c0686", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre@gmail.com", true, "Emre", "Ateş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMRE@GMAIL.COM", "EMREATES", "EMRE", "AQAAAAIAAYagAAAAEH1Na7b+g9AUuLzVvauA4ch/d+gn8k53M7ekd0jZGRVEvfKXZdSNJp7PomeyJlpAsQ==", null, false, "029b65cd-0cdd-47c2-aaa1-ce4d4af8b878", false, 1, "emre" },
                    { "b35f20c1-836f-49c1-b46f-2399e12pvc85", 0, "fca0e410-c58a-46d0-bf4e-8e09f85b0f3e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem@gmail.com", true, "Cem", "Kar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CEM@GMAIL.COM", "CEMKAR", "CEM", "AQAAAAIAAYagAAAAEF2Dh8yQCA3D7C5LjWiKFjkmyNkIWmMCPPg/uhhPWJ8QAzyLM4SssH+jNaZDMqMTaQ==", null, false, "7d95c425-1625-46aa-b4d2-be7db1f9c4ab", false, 1, "cem" },
                    { "eabb7e42-6e53-4696-b350-da56Or2c79fa", 0, "ec69c5a5-6cbd-4ef1-b396-c01b7410830d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "canan@gmail.com", true, "Canan", "Umaç", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CANAN@GMAIL.COM", "CANANUMAC", "CANAN", "AQAAAAIAAYagAAAAEKP0X0hFMmNLrBLP5bdekr6XYBg+mfyTSeM/Row0CjQN2VNNxuyNBOj7kiHhds+ocg==", null, false, "97298499-8ff2-4505-973f-1206eff5dfe9", false, 2, "canan" },
                    { "eabb7e42-6e53-4696-b350-da64de2c79fa", 0, "c330ae6d-55c3-478c-acfb-912a05c1dfa0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "omer@gmail.com", true, "Ömer", "Akyüz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMER@GMAIL.COM", "OMERAKYUZ", "OMER", "AQAAAAIAAYagAAAAEBOe2pKbyszMOutQntNShFeIMPj1HrdnhskgBsozt8GcSw43Hl6t0zhzNjx6ye2Bmg==", null, false, "cdf379b2-6b5a-44b9-b3c9-3547e7adc36a", false, 2, "ömer" },
                    { "kema7e42-6e53-4696-b350-ke56Or2c79fa", 0, "4e5ef0e6-8947-42a1-b1be-da2b21e312af", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "semanur@gmail.com", true, "Semanur", "Yıldırım", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMANUR@GMAIL.COM", "SEMANURYILDIRIM", "SEMANUR", "AQAAAAIAAYagAAAAEJAUvGqndgMrbd+G1LHD4tou8Qd7mPYgt3XjGsijPMhYE+ETxgp57qX5IJ+Q8GfkdA==", null, false, "98efa544-98df-4fb3-b807-10eaeed14b27", false, 0, "semanur" },
                    { "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34", 0, "9fe5c8d6-d210-42ad-a2fa-df8e17f4b744", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin@gmail.com", true, "Aylin", "Uzar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AYLIN@GMAIL.COM", "AYLINUZAR", "AYLIN", "AQAAAAIAAYagAAAAEOqz91i2kgDpX0f1s9477A7KrAhoSyKFCAtrp2J7EXGmRTejQSVSt1Nfbc22ItXlDg==", null, false, "82d37dd1-5ac7-4854-abdf-d725d3370e7e", false, 1, "aylin" },
                    { "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34", 0, "817f424c-0a95-49ed-8e35-25a0415f2377", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aslı@gmail.com", true, "Aslı", "Yaman", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASLI@GMAIL.COM", "ASLIYAMAN", "ASLI", "AQAAAAIAAYagAAAAEG4HUAZxlh7rZIJCRFtCuyRnCO5I1PSPc3fMlhKMOmVt4BkV9BltFsS5tToADknLAA==", null, false, "a9193bdb-bd08-4a2a-8954-8115a07a73c4", false, 1, "aslı" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4429), true, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4435), "Bireysel Terapi", "bireysel-terapi" },
                    { 2, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4437), true, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4438), "İlişki Terapisi", "iliski-terapisi" },
                    { 3, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4440), true, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4440), "Aile Terapisi", "aile-terapisi" },
                    { 4, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4442), false, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4442), "Çocuk Terapisi", "cocuk-terapisi" },
                    { 5, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4444), true, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4444), "Ergen Terapisi", "ergen-terapisi" },
                    { 6, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4446), true, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4446), "Oyun Terapisi", "oyun-terapisi" },
                    { 7, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4447), false, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4448), "Sanat Danışmanlık", "sanat-danismanlik" },
                    { 8, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4449), true, new DateTime(2023, 4, 19, 15, 52, 27, 876, DateTimeKind.Local).AddTicks(4450), "Cinsel Yönetimi", "cinsel-terapi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { "f9cd1865-06d2-4e61-b0a5-75db7e7db218", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { "f9cd1865-06d2-4e61-b0a5-75db7e7db218", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { "f9cd1865-06d2-4e61-b0a5-75db7e7db218", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { "454ed758-6d8b-485a-9be2-3c3c5a9065f2", "kema7e42-6e53-4696-b350-ke56Or2c79fa" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { "407d1ed8-c0ad-497a-ae35-621abe2d044e", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" }
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
                columns: new[] { "Id", "Address", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "PsychologistId", "Url", "userId" },
                values: new object[,]
                {
                    { 1, "Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4", new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3861), true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3872), "Ahmet", 0, "ahmet-hasta", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { 2, "Güzelbahçe mahallesi Kumsal sokak no:13", new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3880), true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3881), "Ömer", 0, "omer-hasta", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { 3, "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5", new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3889), true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3890), "Mehmet", 0, "mehmet-hasta", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" }
                });

            migrationBuilder.InsertData(
                table: "Psychologist",
                columns: new[] { "Id", "CreatedDate", "Gender", "IsApproved", "ModifiedDate", "Name", "Price", "Url", "userId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3938), "Kadın", false, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3940), "Selvi", 450m, "Selvi-psikolog", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { 2, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3948), "Kadın", false, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3949), "Zeynep", 350m, "zeynep-psikolog", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { 3, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3952), "Kadın", false, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3953), "Merve", 400m, "merve-psikolog", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { 4, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3956), "Kadın", false, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3957), "Aslı", 450m, "asli-psikolog", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" },
                    { 5, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3959), "Kadın", false, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(3960), "Aylin", 350m, "aylin-psikolog", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { 6, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4008), "Erkek", false, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4009), "Ali", 500m, "ali-psikolog", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { 7, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4012), "Erkek", true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4013), "Cem", 400m, "cem-psikolog", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { 8, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4016), "Erkek", true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4017), "Ahmet", 350m, "ahmet-psikolog", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { 9, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4020), "Erkek", true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4021), "Emre", 350m, "emre-psikolog", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { 10, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4026), "Erkek", true, new DateTime(2023, 4, 19, 15, 52, 25, 726, DateTimeKind.Local).AddTicks(4026), "Barış", 350m, "barıs-psikolog", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "PsychologistId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6842), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6845), 1, "k-1.jpg" },
                    { 2, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6848), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6848), 2, "k-2.jpg" },
                    { 3, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6850), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6851), 3, "k-3.jpg" },
                    { 4, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6852), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6853), 4, "k-4.jpg" },
                    { 5, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6854), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6855), 5, "k-5.jpg" },
                    { 6, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6856), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6857), 6, "e-1.jpg" },
                    { 7, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6859), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6859), 7, "e-2.jpg" },
                    { 8, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6861), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6861), 8, "e-3.jpg" },
                    { 9, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6863), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6863), 9, "e-4.jpg" },
                    { 10, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6865), true, new DateTime(2023, 4, 19, 15, 52, 27, 877, DateTimeKind.Local).AddTicks(6865), 10, "e-5.jpg" }
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
