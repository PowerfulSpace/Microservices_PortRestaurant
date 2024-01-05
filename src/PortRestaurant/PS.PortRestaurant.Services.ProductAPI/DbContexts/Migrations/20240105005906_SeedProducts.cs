using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PS.PortRestaurant.Services.ProductAPI.DbContexts.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11513685-6851-4d54-9aed-4713c84bcc3f"), "Entree" },
                    { new Guid("84f69823-bc64-4ef6-a5ae-be49d3e966f9"), "Dessert" },
                    { new Guid("baee70ca-5651-4713-82ac-f4442d317afa"), "Appetizer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("98a4ada3-d15b-4f20-bafc-564e1a80052f"), new Guid("baee70ca-5651-4713-82ac-f4442d317afa"), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://e1.edimdoma.ru/data/posts/0002/2542/22542-ed4_wide.jpg?1631192811", "Samosa", 15m },
                    { new Guid("d7dec9e0-145b-4fb2-8328-0ac08361523f"), new Guid("11513685-6851-4d54-9aed-4713c84bcc3f"), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR_RMcFUJhD35yfT4Ps2HR16l8fBY85dqcDcg&usqp=CAU", "Pav Bhaji", 15m },
                    { new Guid("ee0d48e2-0d7c-490c-b987-0dacb05d1e8a"), new Guid("baee70ca-5651-4713-82ac-f4442d317afa"), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://img-global.cpcdn.com/recipes/251da7cdca421f817701a5467edd095a73e9f43f6fe624825fc8fcd17bc9304f/680x482cq70/ghoriachiie-bliuda-na-novyi-ghod-%D0%BE%D1%81%D0%BD%D0%BE%D0%B2%D0%BD%D0%BE%D0%B5-%D1%84%D0%BE%D1%82%D0%BE-%D1%80%D0%B5%D1%86%D0%B5%D0%BF%D1%82%D0%B0.jpg", "Paneer Tikka", 13.99m },
                    { new Guid("f11d764b-1ecb-49c0-9ea1-a8abe88a383d"), new Guid("84f69823-bc64-4ef6-a5ae-be49d3e966f9"), "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://s1.webspoon.ru/receipts/2021/1/41606/orig_41606_0_xxl.jpg", "Sweet Pie", 10.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98a4ada3-d15b-4f20-bafc-564e1a80052f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7dec9e0-145b-4fb2-8328-0ac08361523f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ee0d48e2-0d7c-490c-b987-0dacb05d1e8a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f11d764b-1ecb-49c0-9ea1-a8abe88a383d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11513685-6851-4d54-9aed-4713c84bcc3f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("84f69823-bc64-4ef6-a5ae-be49d3e966f9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("baee70ca-5651-4713-82ac-f4442d317afa"));
        }
    }
}
