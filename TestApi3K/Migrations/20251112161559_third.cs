using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi3K.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRecord_Achievements_id_Achievement",
                table: "UsersRecord");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_UsersRecord_id_Achievement",
                table: "UsersRecord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    id_Achievement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.id_Achievement);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRecord_id_Achievement",
                table: "UsersRecord",
                column: "id_Achievement");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecord_Achievements_id_Achievement",
                table: "UsersRecord",
                column: "id_Achievement",
                principalTable: "Achievements",
                principalColumn: "id_Achievement",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
