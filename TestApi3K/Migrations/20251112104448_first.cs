using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi3K.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    id_Achievement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.id_Achievement);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level1score = table.Column<int>(type: "int", nullable: false),
                    level2score = table.Column<int>(type: "int", nullable: false),
                    level3score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_User);
                });

            migrationBuilder.CreateTable(
                name: "UsersRecord",
                columns: table => new
                {
                    id_Record = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_User = table.Column<int>(type: "int", nullable: false),
                    id_Achievement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRecord", x => x.id_Record);
                    table.ForeignKey(
                        name: "FK_UsersRecord_Achievements_id_Achievement",
                        column: x => x.id_Achievement,
                        principalTable: "Achievements",
                        principalColumn: "id_Achievement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRecord_Users_id_User",
                        column: x => x.id_User,
                        principalTable: "Users",
                        principalColumn: "id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRecord_id_Achievement",
                table: "UsersRecord",
                column: "id_Achievement");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRecord_id_User",
                table: "UsersRecord",
                column: "id_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRecord");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
