using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TesteAgrotools.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    User = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormField",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    FormFK = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormField_Form_FormFK",
                        column: x => x.FormFK,
                        principalTable: "Form",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserAnswer = table.Column<string>(type: "TEXT", nullable: true),
                    latitude = table.Column<string>(type: "TEXT", nullable: true),
                    longitude = table.Column<string>(type: "TEXT", nullable: true),
                    UserFK = table.Column<int>(type: "INTEGER", nullable: false),
                    FormFieldFK = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answer_FormField_FormFieldFK",
                        column: x => x.FormFieldFK,
                        principalTable: "FormField",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_User_UserFK",
                        column: x => x.UserFK,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_FormFieldFK",
                table: "Answer",
                column: "FormFieldFK");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserFK",
                table: "Answer",
                column: "UserFK");

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FormFK",
                table: "FormField",
                column: "FormFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "FormField");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
