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
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    GraduationYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", nullable: true),
                    Education = table.Column<string>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
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
                    Address = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "RequestCategory",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCategory", x => new { x.RequestId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_RequestCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestCategory_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
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
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
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
                    PsychologistId = table.Column<int>(type: "INTEGER", nullable: true),
                    RequestId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Images_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
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
                    { "77479a28-1ed0-42b2-a59e-55779dc7aa7f", null, "Kullanıcılar", "Customer", "CUSTOMER" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", null, "Psikologlar", "Psychologist", "PSYCHOLOGIST" },
                    { "bf61468f-2ee1-4b01-a22b-8a83d234e0b2", null, "Yöneticiler", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[,]
                {
                    { "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21", 0, "b822c158-a9ca-4e12-b496-8b38e20a408d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "baris@gmail.com", true, "Barış", "Durmuş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARIS@GMAIL.COM", "BARISDURMUS", "BARIS", "AQAAAAIAAYagAAAAEHi4uWRb+XlJ0USH6TeUVnMYdoyNwqagT0saIIhaYhO3tGG0P8ALzN6UmO+pDo/CQw==", null, false, "f90177d6-f6ae-4b29-9ac8-d09a17b36ab9", false, 1, "barıs" },
                    { "8da007be-c50b-4973-aa45-224b7358hkn15", 0, "46bcad54-1bb6-4285-bea0-4425fece4baa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "selvi@gmail.com", true, "Selvi", "Kartal", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SELVI@GMAIL.COM", "SELVIKARTAL", "SELVI", "AQAAAAIAAYagAAAAEJBZZdno1i72zbbOWw/hp9FGzne5t7z77JSkZdj4DbqtQkXQnUUdXyYhMLN3jI4GQA==", null, false, "d1e6084d-609a-4b89-859a-c56b7f3a58a8", false, 1, "selvi" },
                    { "9e8f345d-141f-4ef2-99c7-8a9476llh93", 0, "ff496659-bae5-4941-8bc2-c09f3f349353", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet@gmail.com", true, "Ahmet", "Ovalı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AHMET@GMAIL.COM", "AHMETOVALI", "AHMET", "AQAAAAIAAYagAAAAEPFjHnJyK4snWqIPorq0vS6hwIUSYxkPbBSQirHs0aw+8Xs6o5Gr1cBHovW7tSy/pw==", null, false, "69ee3ea8-d602-4340-8556-e6b7cf40579f", false, 1, "ahmet" },
                    { "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f", 0, "d205e034-92c5-4f8f-8b30-a142809f2883", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet@gmail.com", true, "Mehmet", "Tatlı", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEHMET@GMAIL.COM", "MEHMETTATLI", "MEHMET", "AQAAAAIAAYagAAAAEBopJr7sa9cc5s6CYAZwg4Kmjw/tsxh1vkAsV2JdmYSUSvKuv2CcMtwZOgluN8lJBQ==", null, false, "f9b8a597-cabf-4d57-92a1-ced2e212ff80", false, 2, "-mehmet" },
                    { "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62", 0, "81737dbf-11e0-4cc4-a0e0-b2929567fed6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "zeynep@gmail.com", true, "Zeynep", "Öztürk", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZEYNEP@GMAIL.COM", "ZEYNEPOZTURK", "ZEYNEP", "AQAAAAIAAYagAAAAEMzG04BXJiHv4G1zcWzJ0DwUFQCTVha0CVUsAG3x/z7SAgnb0jWxxIMkb3UV/NkHvQ==", null, false, "3bb4a366-9d46-4ae0-b65d-25f94d92d15a", false, 1, "zeynep" },
                    { "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34", 0, "b6b47ed6-e3ee-48eb-8323-b512f73dcb4b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "merve@gmail.com", true, "Merve", "Kara", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MERVE@GMAIL.COM", "MERVEKARA", "MERVE", "AQAAAAIAAYagAAAAEKlCvauHstcP/xbR6Xs/vj+WPheIrCX/60d+Zd2EqgAlAah7TxkBqozr/jsUtcMzRg==", null, false, "5098b14a-5f43-4ec0-a6c7-6470efc85faa", false, 1, "merve" },
                    { "b342e19c-42af-4f25-b820-7a07dc9mbf13", 0, "e0b824cd-e96f-4cb2-9ca9-0c7be9b602c7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali@gmail.com", true, "Ali", "Yılmaz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI@GMAIL.COM", "ALIYILMAZ", "ALI", "AQAAAAIAAYagAAAAEGMYZK1Vkke+IGmdDWy/RMRnGS31fzmencoMdCTLvGGG8qxiLpOOKirxvQwSUOnhuQ==", null, false, "5d584e52-edb5-4e41-aa94-5ebfda1220c3", false, 1, "ali" },
                    { "b342e25a-42af-4f25-b820-7a07dc9mbf13", 0, "9d8cd197-7d66-4fb4-bd46-858f481466ae", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre@gmail.com", true, "Emre", "Ateş", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EMRE@GMAIL.COM", "EMREATES", "EMRE", "AQAAAAIAAYagAAAAEAe8ztchFaKQI+8iSrOJl6wbOoGORlQzyF/EhUcHQ259KMGSPfjlLoQY8o1xh+Pr0A==", null, false, "e01c545e-8ba1-451b-87ed-0858b13b84f7", false, 1, "emre" },
                    { "b35f20c1-836f-49c1-b46f-2399e12pvc85", 0, "2881a147-73ae-4574-9610-bae1b6f5d9aa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "cem@gmail.com", true, "Cem", "Kar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CEM@GMAIL.COM", "CEMKAR", "CEM", "AQAAAAIAAYagAAAAEOX03keN2tnugWA2D+BN6xGUvH2jqF8B2A1VFnIyrjBaqxoAP7zLYfln3H1v9jy9OQ==", null, false, "de347360-8087-47c2-8e49-91de6c9481bd", false, 1, "cem" },
                    { "eabb7e42-6e53-4696-b350-da56Or2c79fa", 0, "9ac256b3-298a-4a1e-8e1f-00d155488062", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "canan@gmail.com", true, "Canan", "Umaç", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CANAN@GMAIL.COM", "CANANUMAC", "CANAN", "AQAAAAIAAYagAAAAEHSuNvFUElWDUDlK6acszXg5xWwciv2kqWpDaARfMVxa6b1rzNQ3x0DaK3dEKKGUHA==", null, false, "70b49cdc-56e3-43ae-902c-1e8568ba491b", false, 2, "canan" },
                    { "eabb7e42-6e53-4696-b350-da64de2c79fa", 0, "ca87554f-33c1-4c36-b3b8-8fe622667241", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "omer@gmail.com", true, "Ömer", "Akyüz", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMER@GMAIL.COM", "OMERAKYUZ", "OMER", "AQAAAAIAAYagAAAAEE9lYMpFYtvdl7UyRRaC8aBGHHpDtOuUuOeyv9vWlIEcXnK9yn6d7/DmwP/ujizx/w==", null, false, "18e6f5e4-aa91-4f9a-b3c1-ed639fe03eaf", false, 2, "ömer" },
                    { "kema7e42-6e53-4696-b350-ke56Or2c79fa", 0, "b8271bb6-9cd4-4a05-8ede-2e2bbf43f83c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "semanur@gmail.com", true, "Semanur", "Yıldırım", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEMANUR@GMAIL.COM", "SEMANURYILDIRIM", "SEMANUR", "AQAAAAIAAYagAAAAEM0XgWBYCYG4jkXeyj0taAqhLCzWFrX017YaQ3mRtIHMeANeS1Hiw4XSe4szCrYhgQ==", null, false, "8d67aad9-03e0-4641-a7c3-9ddd711b4dfe", false, 0, "semanur" },
                    { "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34", 0, "9c22e4c4-d944-404d-92ac-d77f1b5a6cd5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin@gmail.com", true, "Aylin", "Uzar", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AYLIN@GMAIL.COM", "AYLINUZAR", "AYLIN", "AQAAAAIAAYagAAAAEGwp0FpCnk7NVdkr1Ylb+Vu/V+rrtIbORQ85EcuSvafOzfuDYs5hItqLu/bgJNAwgA==", null, false, "b6142e58-af61-491b-b595-93ec8eb49e54", false, 1, "aylin" },
                    { "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34", 0, "4a351f52-ac13-406c-ba86-25347a390a12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "aslı@gmail.com", true, "Aslı", "Yaman", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASLI@GMAIL.COM", "ASLIYAMAN", "ASLI", "AQAAAAIAAYagAAAAEAsp2+6MWzAxJZIO1gIS0AL2I10rI/SyidXlzFW2BZPXZ2K/6jLDnvooqW/1SX5ySw==", null, false, "f994f9d6-a434-4dee-b8e5-a63e39a986b6", false, 1, "aslı" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5535), true, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5546), "Bireysel Terapi", "bireysel-terapi" },
                    { 2, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5550), true, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5551), "İlişki Terapisi", "iliski-terapisi" },
                    { 3, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5553), true, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5554), "Aile Terapisi", "aile-terapisi" },
                    { 4, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5556), false, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5557), "Çocuk Terapisi", "cocuk-terapisi" },
                    { 5, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5559), true, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5559), "Ergen Terapisi", "ergen-terapisi" },
                    { 6, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5561), true, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5562), "Oyun Terapisi", "oyun-terapisi" },
                    { 7, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5564), false, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5565), "Sanat Danışmanlık", "sanat-danismanlik" },
                    { 8, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5568), true, new DateTime(2023, 5, 11, 2, 23, 7, 505, DateTimeKind.Local).AddTicks(5568), "Cinsel Yönetimi", "cinsel-terapi" }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "About", "CreatedDate", "DateOfBirth", "Education", "Email", "Experience", "FirstName", "Gender", "GraduationYear", "IsApproved", "LastName", "ModifiedDate", "Name", "Password", "Price", "Url", "UserName" },
                values: new object[] { 1, "Sosyal Terapist, Bağımlılık Terapisti, Psikodrama Yöneticisi, Organizasyon Geliştirici İzmir Üniversitesi bölümünü tamamlayıp, ardından Almanya’da Sağlık Managment Yüksek Lisans Master egitimini  Magdeburg-Stendal Yüksekokulunda tamamlamıştır. Almanya’da psikososyal alanda 1982 yılından itibaren mesleki calışmasına paralel, 2013 tarihine kadar Sosyalterapi, Bagimlilik terapisti, Psikodrama Grup Yöneticisi, Organizasyon Geliştirici ve Choac  eğitimlerini aldı.", new DateTime(2023, 5, 11, 2, 23, 7, 517, DateTimeKind.Local).AddTicks(5276), new DateTime(1978, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul Üniversitesi Psikoloji", "sevil@gmail.com", "Online ve Yüz yüze Terapi", "Sevil", "Kadın", new DateTime(2000, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kara", new DateTime(2023, 5, 11, 2, 23, 7, 517, DateTimeKind.Local).AddTicks(5284), "Seil Kara", "Qwe123.", 450m, "Sevil-Kara", "sevil" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { "77479a28-1ed0-42b2-a59e-55779dc7aa7f", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { "77479a28-1ed0-42b2-a59e-55779dc7aa7f", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { "77479a28-1ed0-42b2-a59e-55779dc7aa7f", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { "bf61468f-2ee1-4b01-a22b-8a83d234e0b2", "kema7e42-6e53-4696-b350-ke56Or2c79fa" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { "78909e5c-73ef-4118-a1eb-05fd78a59d21", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" }
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
                    { 1, "Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4", new DateTime(2023, 5, 11, 2, 23, 5, 325, DateTimeKind.Local).AddTicks(9968), true, new DateTime(2023, 5, 11, 2, 23, 5, 325, DateTimeKind.Local).AddTicks(9982), "Canan Umaç", "ahmet-umac", "eabb7e42-6e53-4696-b350-da56Or2c79fa" },
                    { 2, "Güzelbahçe mahallesi Kumsal sokak no:13", new DateTime(2023, 5, 11, 2, 23, 5, 325, DateTimeKind.Local).AddTicks(9992), true, new DateTime(2023, 5, 11, 2, 23, 5, 325, DateTimeKind.Local).AddTicks(9993), "Ömer Akyüz", "omer-akyuz", "eabb7e42-6e53-4696-b350-da64de2c79fa" },
                    { 3, "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5", new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(3), true, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(4), "Mehmet Tatlı", "mehmet-tatli", "a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "PsychologistId", "RequestId", "Url" },
                values: new object[] { 11, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4065), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4073), null, 1, "r-1.jpg" });

            migrationBuilder.InsertData(
                table: "Psychologist",
                columns: new[] { "Id", "CreatedDate", "Gender", "IsApproved", "ModifiedDate", "Name", "Price", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(76), "Kadın", false, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(78), "Selvi Kartal", 450m, "Selvi-kartal", "8da007be-c50b-4973-aa45-224b7358hkn15" },
                    { 2, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(88), "Kadın", false, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(88), "Zeynep Öztürk", 350m, "zeynep-ozturk", "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                    { 3, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(92), "Kadın", false, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(92), "Merve Kara", 400m, "merve-kara", "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                    { 4, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(96), "Kadın", false, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(97), "Aslı Yaman", 450m, "asli-yaman", "s8e3a9e7-5K05-4487-9945-43d2ff1kgd34" },
                    { 5, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(100), "Kadın", false, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(100), "Aylin Uzar", 350m, "aylin-uzar", "n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34" },
                    { 6, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(105), "Erkek", false, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(106), "Ali Yılmaz", 500m, "ali-yilmaz", "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                    { 7, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(109), "Erkek", true, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(110), "Cem Kar", 400m, "cem-kar", "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                    { 8, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(112), "Erkek", true, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(113), "Ahmet Ovali", 350m, "ahmet-ovali", "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                    { 9, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(116), "Erkek", true, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(117), "Emre Ateş", 350m, "emre-ates", "b342e25a-42af-4f25-b820-7a07dc9mbf13" },
                    { 10, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(121), "Erkek", true, new DateTime(2023, 5, 11, 2, 23, 5, 326, DateTimeKind.Local).AddTicks(122), "Barış Durmuş", 350m, "barıs-durmus", "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" }
                });

            migrationBuilder.InsertData(
                table: "RequestCategory",
                columns: new[] { "CategoryId", "RequestId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "PsychologistId", "RequestId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4077), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4078), 1, null, "k-1.jpg" },
                    { 2, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4080), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4082), 2, null, "k-2.jpg" },
                    { 3, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4084), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4085), 3, null, "k-3.jpg" },
                    { 4, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4087), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4088), 4, null, "k-4.jpg" },
                    { 5, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4089), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4090), 5, null, "k-5.jpg" },
                    { 6, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4093), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4094), 6, null, "e-1.jpg" },
                    { 7, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4096), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4096), 7, null, "e-2.jpg" },
                    { 8, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4099), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4100), 8, null, "e-3.jpg" },
                    { 9, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4101), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4102), 9, null, "e-4.jpg" },
                    { 10, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4104), true, new DateTime(2023, 5, 11, 2, 23, 7, 509, DateTimeKind.Local).AddTicks(4105), 10, null, "e-5.jpg" }
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
                name: "IX_Images_RequestId",
                table: "Images",
                column: "RequestId",
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

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategory_CategoryId",
                table: "RequestCategory",
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
                name: "RequestCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Psychologist");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
