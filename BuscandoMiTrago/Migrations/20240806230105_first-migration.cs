using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuscandoMiTrago.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoctelFavorito",
                columns: table => new
                {
                    idDrink = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strDrink = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    strDrinkThumb = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoctelFavorito", x => x.idDrink);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoctelFavorito");
        }
    }
}
