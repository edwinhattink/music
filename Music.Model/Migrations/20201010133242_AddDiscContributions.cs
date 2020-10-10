using Microsoft.EntityFrameworkCore.Migrations;

namespace Music.Model.Migrations
{
    public partial class AddDiscContributions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discs_Artists_ArtistId",
                table: "Discs");

            migrationBuilder.DropIndex(
                name: "IX_Discs_ArtistId",
                table: "Discs");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Discs");

            migrationBuilder.CreateTable(
                name: "DiscContributions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscContributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscContributions_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscContributions_Discs_DiscId",
                        column: x => x.DiscId,
                        principalTable: "Discs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscContributions_ArtistId",
                table: "DiscContributions",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscContributions_DiscId",
                table: "DiscContributions",
                column: "DiscId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscContributions");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Discs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discs_ArtistId",
                table: "Discs",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discs_Artists_ArtistId",
                table: "Discs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
