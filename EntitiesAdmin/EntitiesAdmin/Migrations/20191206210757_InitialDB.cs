using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntitiesAdmin.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusFields",
                columns: table => new
                {
                    StatusFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFields", x => x.StatusFieldId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Countries_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RosterId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_JobPositions_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestCategories",
                columns: table => new
                {
                    RequestCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCategories", x => x.RequestCategoryId);
                    table.ForeignKey(
                        name: "FK_RequestCategories_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(maxLength: 50, nullable: false),
                    TypeRequestId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    StatusRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Rosters",
                columns: table => new
                {
                    RosterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rosters", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_Rosters_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteId);
                    table.ForeignKey(
                        name: "FK_Site_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusEmployees",
                columns: table => new
                {
                    StatusEmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEmployees", x => x.StatusEmployeeId);
                    table.ForeignKey(
                        name: "FK_StatusEmployees_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstSurname = table.Column<string>(maxLength: 50, nullable: false),
                    SecondSurname = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    LowDate = table.Column<DateTime>(nullable: false),
                    JobPositionId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    StatusEmployeeId = table.Column<int>(nullable: true),
                    SkillId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_StatusEmployees_StatusEmployeeId",
                        column: x => x.StatusEmployeeId,
                        principalTable: "StatusEmployees",
                        principalColumn: "StatusEmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusRequest",
                columns: table => new
                {
                    StatusRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusRequest", x => x.StatusRequestId);
                    table.ForeignKey(
                        name: "FK_StatusRequest_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatusRequest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeRequests",
                columns: table => new
                {
                    TypeRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: true),
                    RequestCategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StatusFieldId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    EditionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRequests", x => x.TypeRequestId);
                    table.ForeignKey(
                        name: "FK_TypeRequests_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeRequests_RequestCategories_RequestCategoryId",
                        column: x => x.RequestCategoryId,
                        principalTable: "RequestCategories",
                        principalColumn: "RequestCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeRequests_StatusFields_StatusFieldId",
                        column: x => x.StatusFieldId,
                        principalTable: "StatusFields",
                        principalColumn: "StatusFieldId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_AspNetUsers_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId");

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
                name: "UName",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_StatusFieldId",
                table: "Countries",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UserId",
                table: "Countries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_RosterId",
                table: "Departments",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_StatusFieldId",
                table: "Departments",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UserId",
                table: "Departments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "URosterIdName",
                table: "Departments",
                columns: new[] { "RosterId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UEmployeeCodeEmployees",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPositionId",
                table: "Employees",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SiteId",
                table: "Employees",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SkillId",
                table: "Employees",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusEmployeeId",
                table: "Employees",
                column: "StatusEmployeeId");

            migrationBuilder.CreateIndex(
                name: "UNameJobpositions",
                table: "JobPositions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_StatusFieldId",
                table: "JobPositions",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_UserId",
                table: "JobPositions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UNameRequestCategories",
                table: "RequestCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategories_StatusFieldId",
                table: "RequestCategories",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCategories_UserId",
                table: "RequestCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StatusRequestId",
                table: "Requests",
                column: "StatusRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TypeRequestId",
                table: "Requests",
                column: "TypeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UNameRoster",
                table: "Rosters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_StatusFieldId",
                table: "Rosters",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Rosters_UserId",
                table: "Rosters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CountryId",
                table: "Site",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_StatusFieldId",
                table: "Site",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_UserId",
                table: "Site",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UName_CountryID_Site",
                table: "Site",
                columns: new[] { "CountryId", "Name" },
                unique: true,
                filter: "[CountryId] IS NOT NULL AND [Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DepartmentID_Name",
                table: "Skills",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StatusFieldId",
                table: "Skills",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId",
                table: "Skills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UNameSkill_Department",
                table: "Skills",
                columns: new[] { "DepartmentId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNameStatusEmployee",
                table: "StatusEmployees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusEmployees_StatusFieldId",
                table: "StatusEmployees",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEmployees_UserId",
                table: "StatusEmployees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UNameStatusField",
                table: "StatusFields",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNameStatusRequest",
                table: "StatusRequest",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusRequest_StatusFieldId",
                table: "StatusRequest",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusRequest_UserId",
                table: "StatusRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeRequests_DepartmentId",
                table: "TypeRequests",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeRequests_RequestCategoryId",
                table: "TypeRequests",
                column: "RequestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeRequests_StatusFieldId",
                table: "TypeRequests",
                column: "StatusFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeRequests_UserId",
                table: "TypeRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UNameDepartmantTypeRequest",
                table: "TypeRequests",
                columns: new[] { "DepartmentId", "Name" },
                unique: true,
                filter: "[DepartmentId] IS NOT NULL AND [Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AspNetUsers_UserId",
                table: "Countries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_UserId",
                table: "Departments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Rosters_RosterId",
                table: "Departments",
                column: "RosterId",
                principalTable: "Rosters",
                principalColumn: "RosterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPositions_AspNetUsers_UserId",
                table: "JobPositions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestCategories_AspNetUsers_UserId",
                table: "RequestCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StatusRequest_StatusRequestId",
                table: "Requests",
                column: "StatusRequestId",
                principalTable: "StatusRequest",
                principalColumn: "StatusRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_TypeRequests_TypeRequestId",
                table: "Requests",
                column: "TypeRequestId",
                principalTable: "TypeRequests",
                principalColumn: "TypeRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rosters_AspNetUsers_UserId",
                table: "Rosters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_AspNetUsers_UserId",
                table: "Site",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AspNetUsers_UserId",
                table: "Skills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusEmployees_AspNetUsers_UserId",
                table: "StatusEmployees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_UserId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_UserId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPositions_AspNetUsers_UserId",
                table: "JobPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Rosters_AspNetUsers_UserId",
                table: "Rosters");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_AspNetUsers_UserId",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AspNetUsers_UserId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusEmployees_AspNetUsers_UserId",
                table: "StatusEmployees");

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
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "StatusRequest");

            migrationBuilder.DropTable(
                name: "TypeRequests");

            migrationBuilder.DropTable(
                name: "RequestCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "StatusEmployees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Rosters");

            migrationBuilder.DropTable(
                name: "StatusFields");
        }
    }
}
