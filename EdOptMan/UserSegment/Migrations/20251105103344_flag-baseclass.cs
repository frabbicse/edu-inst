using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSegment.Migrations
{
    /// <inheritdoc />
    public partial class flagbaseclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClassEntryModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "ClassEntryModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClassEntryModels");

            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "ClassEntryModels");
        }
    }
}
