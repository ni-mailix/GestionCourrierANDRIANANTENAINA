using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_courrier_ANDRIANANTENAINA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courriers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Objet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateArrivee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expediteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinataire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Urgent_O_N = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouvementsCourriers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourrierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateMouvement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom_depositaire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouvementsCourriers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courriers");

            migrationBuilder.DropTable(
                name: "MouvementsCourriers");
        }
    }
}
