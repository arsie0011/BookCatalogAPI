using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookCatalog.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                  table: "Category",
                  columns: new[] { "Name" },
                  values: new object[,]
                  {
                        { "Mystery" },
                        { "Romance" },
                        { "Historical Fiction" },
                        { "Science Fiction" },
                        { "Thriller" },
                        { "Horror" },
                        { "Fantasy" },
                        { "Drama" }
              });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    PublishDateUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.InsertData(
                  table: "Book",
                  columns: new[] { "CategoryId", "Title", "Description", "PublishDateUTC" },
                  values: new object[,]
                  {
                                    { 1,"Beauty and the Beast","This is a Mystery Book", DateTime.Now },
                                    { 2,"The Endless Love","This is a Romance Book", DateTime.Now },
                                    { 3,"Wolf Hall","This is a Historical Fiction Book", DateTime.Now },
                                    { 4,"Dune","This is a Science Fiction Book", DateTime.Now },
                                    { 4,"Frankenstein","This is a Science Fiction Book", DateTime.Now },
                                    { 1,"The Lazarus Project","This is a Mystery Book", DateTime.Now },
                                    { 2,"Outlander","This is a Romance Book", DateTime.Now },
                                    { 2,"Happy Place","This is a Romance Book", DateTime.Now }
              });
                    }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
