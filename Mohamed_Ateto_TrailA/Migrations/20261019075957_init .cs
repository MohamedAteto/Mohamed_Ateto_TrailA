using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mohamed_Ateto_TrailA.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAte = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CanditateProfiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanditateProfiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_CanditateProfiles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Companys_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CanditaeProfileID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_CanditateProfiles_CanditaeProfileID",
                        column: x => x.CanditaeProfileID,
                        principalTable: "CanditateProfiles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "CreateAte", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmedhassan@gmail.com", "Ahmed Hassan", "123456", "Candidate" },
                    { 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "saramohamed@gmail.com", "Sara Mohamed", "123456", "Employer" },
                    { 3, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "omeradmin@gmail.com", "Omer Ali", "123456", "Admin" },
                    { 4, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "gilbertomohamed@gmail.com", "gilberto mohamed", "123456", "Candidate" },
                    { 5, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "hosame@gmail.com", "Hosame ahmed", "123456", "Employer" }
                });

            migrationBuilder.InsertData(
                table: "CanditateProfiles",
                columns: new[] { "id", "Phone", "ResumeURL", "Skill", "UserID", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, "01012345678", "emample.ocm/resume1", "ASP.NET Core", 1, 1 },
                    { 2, "01055556677", "emample.ocm/resume2", "Jave", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "Description", "Location", "Name", "UserId", "WebSite" },
                values: new object[,]
                {
                    { 1, "Software company", "Cairo", "Tach Solutions", 2, "https:// techsolutions.example.com" },
                    { 2, "IT consulting", "Giza", "Future System", 5, "https:// it.example2.com" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CompanyID", "Deadline", "Description", "EmployeeType", "Location", "PostedDate", "Salary", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "using ASP.NET Core", "FullTime", "Cairo", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Open", "Back End" },
                    { 2, 2, new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop Web Interface", "Contract", "Giza", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m, "Open", "Front End" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "ApplicationDate", "CanditaeProfileID", "CoverLetter", "JobID", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, " Intersted in backecnd development", 1, "Pending" },
                    { 2, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, " Intersted in Front End development", 2, "UnderReview" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CanditaeProfileID_JobID",
                table: "Applications",
                columns: new[] { "CanditaeProfileID", "JobID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobID",
                table: "Applications",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_CanditateProfiles_UserID",
                table: "CanditateProfiles",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companys_UserId",
                table: "Companys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyID",
                table: "Jobs",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "CanditateProfiles");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
