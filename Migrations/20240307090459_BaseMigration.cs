using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GroupActivity.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Sci-fi", 2009, "Avatar" },
                    { 2, "Action", 2019, "Avengers: Endgame" },
                    { 3, "Sci-fi", 2022, "Avatar: The Way of Water" },
                    { 4, "Romance", 1997, "Titanic" },
                    { 5, "Sci-fi", 2015, "Star Wars: The Force Awakens" },
                    { 6, "Action", 2018, "Avengers: Infinity War" },
                    { 7, "Action", 2021, "Spider-Man: No Way Home" },
                    { 8, "Action", 2015, "Jurassic World" },
                    { 9, "Animation", 1994, "The Lion King" },
                    { 10, "Action", 2012, "The Avengers" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "QuoteText" },
                values: new object[,]
                {
                    { 1, "Mahatma Gandhi", "You must be the change you wish to see in the world." },
                    { 2, "Mother Teresa", "Spread love everywhere you go. Let no one ever come to you without leaving happier." },
                    { 3, "Franklin D. Roosevelt", "The only thing we have to fear is fear itself." },
                    { 4, "Martin Luther King Jr.", "Darkness cannot drive out darkness: only light can do that. Hate cannot drive out hate: only love can do that." },
                    { 5, "Eleanor Roosevelt", "Do one thing every day that scares you." },
                    { 6, "Benjamin Franklin", "Well done is better than well said." },
                    { 7, "Helen Keller", "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart." },
                    { 8, "Aristotle", "It is during our darkest moments that we must focus to see the light." },
                    { 9, "Ralph Waldo Emerson", "Do not go where the path may lead, go instead where there is no path and leave a trail." },
                    { 10, "Oscar Wilde", "Be yourself; everyone else is already taken." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
