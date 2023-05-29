using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_courrier_ANDRIANANTENAINA.Migrations
{
    /// <inheritdoc />
    public partial class MigrationCourrier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courrier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Objet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateArrivee = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expediteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destinataire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urgent_O_N = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courrier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouvementCourrier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateMouvement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom_depositaire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouvementCourrier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courrier");

            migrationBuilder.DropTable(
                name: "MouvementCourrier");
        }
    }
}
