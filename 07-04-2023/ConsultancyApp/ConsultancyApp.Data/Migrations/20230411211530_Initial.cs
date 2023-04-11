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
                name: "CategoryDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                });

            migrationBuilder.CreateTable(
                name: "PsychologistDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GraduationYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Education = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistDescription", x => x.Id);
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CategoryDescriptionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryDescription_CategoryDescriptionId",
                        column: x => x.CategoryDescriptionId,
                        principalTable: "CategoryDescription",
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
                    Gender = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PsychologistDescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Psychologist_PsychologistDescription_PsychologistDescriptionId",
                        column: x => x.PsychologistDescriptionId,
                        principalTable: "PsychologistDescription",
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
                    table.ForeignKey(
                        name: "FK_Customer_Psychologist_PsychologistId",
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
                    Price = table.Column<decimal>(type: "TEXT", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b7b70ec-d6cf-42bc-bfd8-336a35616140", null, "Psikologlar", "Psychologist", "PSYCHOLOGIST" },
                    { "2d75e05d-f650-453c-a1fb-305396ede74f", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "f69957c7-6805-4d84-aa1c-a4f7956eb8e4", null, "Kullanıcılar", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[,]
                {
                    { "022169b4-75b1-4c4c-a27e-0e6660a656b9", 0, "b017a109-5aa1-4497-8c87-f4880b9d8478", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma@gmail.com", true, "Emma", "Deniz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMMA@GMAIL.COM", "EMMADENIZ", "EMMA", "AQAAAAIAAYagAAAAEM4JeWtEsENFuQlWK2cuZkB01Y4TbNsfKCuC1yUV2Z7hnstcSFyn3ZWvkA6sr9d2OQ==", null, false, "d88285b1-fcaa-4113-8551-b1ecadf3d7dd", false, 1, "emma" },
                    { "7d97d1e4-fce7-445e-9752-91816ceb8c2a", 0, "b0869929-523b-4778-9f84-ff0ecdf73b4d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "selin@gmail.com", true, "Selin", "Kara", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SELIN@GMAIL.COM", "SELINKARA", "SELIN", null, null, false, "228f22f4-63f8-4b45-b57a-97625e8a86ae", false, 2, "selin" },
                    { "90699b40-fa10-4920-9b87-03be756306e2", 0, "9b3dc27e-3107-47a1-9c2f-c7817f66e729", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "selvi@gmail.com", true, "Selvi", "Kartal", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SELVI@GMAIL.COM", "SELVIKARTAL", "SELVI", "AQAAAAIAAYagAAAAEAODhRy0JaxsTiKS2J5rrjFE2ivBFcfmB8rW5rUKOHQqgekcwB1J4J4fqVDpHo+Svg==", null, false, "2cdc16a6-c9e5-450b-87f2-ffd369923549", false, 1, "selvi" },
                    { "f053af86-2a08-44b5-bb35-6516478773ba", 0, "fc73c33e-cb07-4b85-951f-945561088aaf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sema@gmail.com", true, "Sema", "Yıldırım", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMA@GMAIL.COM", "SEMAYILDIRIM", "SEMA", "AQAAAAIAAYagAAAAEPFDWCgU7bHG3IS7XFxdFOlhR5ECA5/4Su8t06NHRVaOf6LBufUNXUAc3oxin65LgA==", null, false, "492d920f-ff27-4f23-8103-cf9e21e25fc6", false, 0, "sema" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryDescriptionId", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7448), true, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7519), "Bireysel Terapi", "bireysel-terapi" },
                    { 2, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7523), true, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7524), "İlişki Terapisi", "iliski-terapisi" },
                    { 3, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7525), true, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7526), "Aile Terapisi", "aile-terapisi" },
                    { 4, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7528), false, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7528), "Çocuk Terapisi", "cocuk-terapisi" },
                    { 5, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7530), true, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7530), "Ergen Terapisi", "ergen-terapisi" },
                    { 6, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7532), true, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7532), "Oyun Terapisi", "oyun-terapisi" },
                    { 7, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7534), false, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7534), "Sanat Danışmanlık", "sanat-danismanlik" },
                    { 8, 0, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7536), true, new DateTime(2023, 4, 12, 0, 15, 30, 293, DateTimeKind.Local).AddTicks(7536), "Cinsel Yönetimi", "cinsel-terapi" }
                });

            migrationBuilder.InsertData(
                table: "CategoryDescription",
                columns: new[] { "Id", "ForWho", "How", "HowLong", "PositiveEffect", "Purpose", "What" },
                values: new object[,]
                {
                    { 1, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Bireysel terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 2, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "İlişki terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 3, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Aile terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 4, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "ÇOcuk terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 5, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Ergen terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 6, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Oyun terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 7, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Sanat terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." },
                    { 8, "Depreston, Kaygı,Öfke,Bağımlılık,Aile Sorunları,Düşük benlik kaygısı gibi sorunları yaşayan insanlara yardımcı olabilir.", "Bilişsel davranışçı terapi (CBT) en yaygın ve etkili terapi türlerinden biridir. Bu yaklaşım, insanların düşünceler, duygular ve davranışlar arasındaki bağlantıya bakmasına yardımcı olur. Bu süreçte insanlar olumsuz düşünme kalıplarını pozitif olanlarla değiştirebilirler. Bilişsel Davranışçı Terapi'nin arkasındaki inanç, sağlıklı düşüncelerin genellikle olumlu duyguları ve üretken eylemleri teşvik ettiği yönündedir.", "rapinin süresi ve sıklığı, danışanların ihtiyaçlarına ve hedeflerindeki ilerlemesine bağlı olarak, tek oturum ile birkaç yıla kadar süren bir aralıkta değişkenlik gösterebilir.", "Online terapi, endişe ve depresyondan ilişki sorunlarına ve işle ilgili strese kadar her türlü sorunu tedavi etmek için kullanılabilir. Online terapinin geleneksel yüz yüze terapiden daha fazla olmasa da aynı derecede faydalı olduğu kanıtlanmıştır. Bazı çalışmalar insanların online terapiden daha fazla memnun olduklarını gösteriyor. Dolayısıyla, online terapi, geleneksel tedavinin yalnızca aynı faydalarını sağlamakla kalmaz, aynı zamanda daha fazla kolaylık ve esneklik sunar.", "Genel olarak, psikoterapinin amacı kişilerin mental kaygıları hakkında konuşmak ve danışanların daha üretken, psikolojik olarak daha sağlıklı yaşamlar sürmelerine ve ilerlemelerine yardımcı olmaktır.", "Cinsel terapi, danışanların duygularını, inançlarını veya davranışlarını araştırmak için eğitimli bir terapistle (güvenli, şefkatli ve gizli bir ortamda) birebir çalıştıkları bir süreçtir. Terapinin genel amaçları değişime ilham vermek veya yaşam kalitesini artırmak olabilir. İnsanlar, tek başına yüzleşmeleri zor olan konularda yardım almak için terapi isteyebilir. Bireysel terapi ayrıca terapi, psikoterapi, psikososyal terapi, konuşma terapisi ve danışmanlık olarak da adlandırılabilir. En yaygın terapi şekli olan bireysel terapi, psikanaliz ve bilişsel-davranışçı terapi gibi birçok farklı terapi stilini kapsayabilir." }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "PsychologistId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(745), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(756), 1, "k-1.jpg" },
                    { 2, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(760), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(760), 2, "e-1.jpg" },
                    { 3, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(762), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(762), 3, "k-2.jpg" },
                    { 4, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(764), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(765), 4, "e-2.jpg" },
                    { 5, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(766), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(767), 5, "k-3.jpg" },
                    { 6, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(768), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(769), 6, "e-3.jpg" },
                    { 7, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(770), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(775), 7, "k-4.jpg" },
                    { 8, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(786), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(787), 8, "e-4.jpg" },
                    { 9, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(788), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(789), 9, "k-5.jpg" },
                    { 10, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(790), true, new DateTime(2023, 4, 12, 0, 15, 30, 295, DateTimeKind.Local).AddTicks(791), 10, "e-5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PsychologistDescription",
                columns: new[] { "Id", "About", "BirthDate", "Education", "Experience", "GraduationYear" },
                values: new object[,]
                {
                    { 1, "Sosyal Terapist, Bağımlılık Terapisti, Psikodrama Yöneticisi, Organizasyon Geliştirici İzmir Üniversitesi bölümünü tamamlayıp, ardından Almanya’da Sağlık Managment Yüksek Lisans Master egitimini  Magdeburg-Stendal Yüksekokulunda tamamlamıştır. Almanya’da psikososyal alanda 1982 yılından itibaren mesleki calışmasına paralel, 2013 tarihine kadar Sosyalterapi, Bagimlilik terapisti, Psikodrama Grup Yöneticisi, Organizasyon Geliştirici ve Choac  eğitimlerini aldı.", new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "İzmir Üniversitesi Psikoloji", "Online ve Yüz yüze Terapi", new DateTime(2000, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Bireysel terapi, grup terapisi, cinsel sağlık, madde bağımlılığı, anksiyete ve depresyon konularında uzmanım. Terapi sürecinde öncelikle güvenli bir ilişki kurmayı hedeflerim. İletişim becerileri, bilişsel davranışçı terapi, psikodinamik yaklaşım gibi farklı terapi yöntemleri kullanırım.", new DateTime(1980, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hacettepe Üniversitesi Psikoloji", "Bireysel ve Grup Terapisi", new DateTime(2005, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "İyi bir dinleyici ve gözlemciyim. Terapi sürecinde öncelikle danışanın sorunlarına odaklanarak, onun düşünce ve duygularını anlamaya çalışırım. Depresyon, anksiyete, panik atak gibi konularda terapi süreci yürütmekteyim.", new DateTime(1985, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boğaziçi Üniversitesi Psikoloji", "Depresyon ve Anksiyete Terapisi", new DateTime(2007, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Çocuklar ve ailelerine yönelik terapi süreçlerinde, oyun terapisi, sanat terapisi ve aile danışmanlığı gibi yöntemleri kullanmaktayım. Her çocuğun farklı bir yapısı olduğunu ve ona göre bir terapi planı hazırlanması gerektiğini düşünmekteyim.", new DateTime(1979, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara Üniversitesi Psikoloji", "Çocuk ve Aile Terapisi", new DateTime(2010, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Stres ve öfke yönetimi konularında uzmanım. Terapi sürecinde, danışanın stres ve öfke seviyesini düşürmek için birlikte çalışırız. Bunun için bilişsel davranışçı terapi, nefes egzersizleri, meditasyon ve benzeri yöntemler kullanmaktayım.", new DateTime(1976, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Üniversitesi Psikoloji", "Stres ve Öfke Yönetimi", new DateTime(2002, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Ankara Üniversitesi Psikoloji bölümünden mezun olan psikolog, çift terapisi ve aile terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Çözüm Odaklı Terapi ve Şema Terapi bulunmaktadır.", new DateTime(1985, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ankara Üniversitesi Psikoloji", "Aile Terapisi, Çift Terapisi", new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Boğaziçi Üniversitesi Psikoloji bölümünden mezun olan psikolog, ergen terapisi ve bağımlılık terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Motivasyonel Röportaj ve EMDR bulunmaktadır.", new DateTime(1982, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boğaziçi Üniversitesi Psikoloji", "Ergen Terapisi, Bağımlılık Terapisi", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Hacettepe Üniversitesi Psikoloji bölümünden mezun olan psikolog, stres yönetimi ve depresyon terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Psikanalitik Terapi ve EFT bulunmaktadır.", new DateTime(1989, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hacettepe Üniversitesi Psikoloji", "Stres Yönetimi, Depresyon Terapisi", new DateTime(2012, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "İstanbul Üniversitesi Psikoloji bölümünden mezun olan psikolog, bireysel terapi, çift terapisi ve aile terapisi konularında uzmanlaşmıştır. Terapi yöntemleri arasında Bilişsel-Davranışçı Terapi, Şema Terapi ve Gestalt Terapi bulunmaktadır.", new DateTime(1980, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Üniversitesi Psikoloji", "Bireysel Terapi, Çift Terapisi, Aile Terapisi", new DateTime(2003, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Çocuklarla ve aileleriyle çalışmayı seven bir terapistim. Özellikle, çocuklarda davranış sorunları, kaygı, depresyon ve dikkat eksikliği konularında deneyimim var. Tedavide, bütünsel bir yaklaşım benimsemekteyim ve bu doğrultuda bireysel terapi, aile terapisi ve ebeveyn rehberliği gibi yöntemleri kullanmaktayım.", new DateTime(1985, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hacettepe Üniversitesi Psikoloji", "Çocuk ve Aile Terapisi", new DateTime(2008, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2b7b70ec-d6cf-42bc-bfd8-336a35616140", "022169b4-75b1-4c4c-a27e-0e6660a656b9" },
                    { "f69957c7-6805-4d84-aa1c-a4f7956eb8e4", "7d97d1e4-fce7-445e-9752-91816ceb8c2a" },
                    { "2b7b70ec-d6cf-42bc-bfd8-336a35616140", "90699b40-fa10-4920-9b87-03be756306e2" },
                    { "2d75e05d-f650-453c-a1fb-305396ede74f", "f053af86-2a08-44b5-bb35-6516478773ba" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "90699b40-fa10-4920-9b87-03be756306e2" },
                    { 2, "022169b4-75b1-4c4c-a27e-0e6660a656b9" },
                    { 3, "f053af86-2a08-44b5-bb35-6516478773ba" },
                    { 4, "7d97d1e4-fce7-445e-9752-91816ceb8c2a" }
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
                name: "IX_Categories_CategoryDescriptionId",
                table: "Categories",
                column: "CategoryDescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PsychologistId",
                table: "Customer",
                column: "PsychologistId");

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
                name: "IX_Psychologist_PsychologistDescriptionId",
                table: "Psychologist",
                column: "PsychologistDescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Psychologist_userId",
                table: "Psychologist",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistCategory_CategoryId",
                table: "PsychologistCategory",
                column: "CategoryId");
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
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PsychologistCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Psychologist");

            migrationBuilder.DropTable(
                name: "CategoryDescription");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PsychologistDescription");
        }
    }
}
