using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class manufacturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @$"
                insert into
                    [Manufacturer]
                    ([Name])
                values
                    ('Honda'),
                    ('Yamaha'),
                    ('Suzuki'),
                    ('Triumph'),
                    ('Harley-Davidson'),
                    ('Kawasaki')
            ";

            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var query = $"truncate table [Manufacturer]";

            migrationBuilder.Sql(query);
        }
    }
}
