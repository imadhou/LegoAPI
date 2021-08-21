using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegoApi.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raison = table.Column<int>(type: "int", nullable: false),
                    EstPayee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    TypeEmploye = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Application = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Langue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NbFollowers = table.Column<int>(type: "int", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Langage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeConges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 20, 19, 2, 23, 666, DateTimeKind.Local).AddTicks(7629)),
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    CongeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeConges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeConges_Conges_CongeID",
                        column: x => x.CongeID,
                        principalTable: "Conges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeConges_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeConges_CongeID",
                table: "EmployeConges",
                column: "CongeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeConges_EmployeId",
                table: "EmployeConges",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employes_ServiceId",
                table: "Employes",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeConges");

            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
