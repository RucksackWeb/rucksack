using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceStore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Life-size, role-play accessory features a spring-loaded, retractable blade with switchblade-style action", "https://store.ubi.com/on/demandware.static/-/Sites-masterCatalog/default/dw0e43b641/images/large/57fe647529e1238f668b4568-collectible-2.png", "Assassin's Creed Skull Buckle", 19.54m, "naab001Knif" },
                    { 2, "Nothing beats ice cold beer! But if that’s not enough for you, then you could go one step higher–and several degrees lower–with the Frozen Beer Slushy Maker. ", "https://cdn.thisiswhyimbroke.com/images/beer-slushie-machine-300x250.jpg", "Beer Slushie Machine", 53.14m, "naab002beer" },
                    { 3, "150ml decanter to hold your favorite liquire or mouthwas - whisky, scotch, bourbon, cognac, brandy all your spirits will look fantastic", "https://i.pinimg.com/originals/20/cf/b2/20cfb20ee822bd1a6a9ccf132ba9cd53.jpg", "Ship In A Bottle Whiskey Dispenser", 120.00m, "naab003shipdispenser" },
                    { 4, "A template for shaving or trimming the neckline. The EdgUp guards the back of your hairline so that you can trim with scissors or shave with a trimmer or razor all of the excess hair. You are left with the perfect hairline.", "https://cdn.thisiswhyimbroke.com/images/hair-neckline-grooming-tool.jpg", "Hairline Grooming Tool", 14.95m, "naab004groomkit" },
                    { 5, "Thinking of sending a Birthday, Congrats, Get Well Soon card? This is a quirky and hilarious alternative to the traditional card! Your friends, family, and others will get a kick out of it! ", "https://cdn.thisiswhyimbroke.com/images/potato-parcel2-640x533.jpg", "Custom Message Potato Parcel", 9.99m, "naab005potato" },
                    { 6, "You may not be made of money, but why can’t your suit be?", "https://cdn.thisiswhyimbroke.com/images/cash-suit-640x533.jpg", "Cash Suit", 59.99m, "naab006cashsuit" },
                    { 7, "Great for using a tablet as second (or third) Display for your laptop!", "https://cdn.macrumors.com/article-new/2017/11/mountie1.jpg", "Tablet Mounting Clip", 34.95m, "naab007mountclip" },
                    { 8, "Charge every single electronic device in your household simultaneously with the 49 port USB hub.", "https://usb.brando.com/prod_img/zoom/UHUBS041500_3.jpg", "49 Port USB Hub", 165.00m, "naab008usbhub" },
                    { 9, "Ensure Jr. thrives in today’s technology driven society by getting him started at a young age with the HTML for babies", "https://i0.wp.com/www.daddycheckthisout.com/wp-content/uploads/2017/09/html-babies.jpg?fit=400%2C300", "HTML For Babies", 346.70m, "naab009forbabies" },
                    { 10, "Get more done on your smartphone or tablet with help from the foldable keyboard.", "https://images-na.ssl-images-amazon.com/images/G/01/aplusautomation/vendorimages/032cfa09-5986-4cbc-acd9-f2a2c68aac58.jpg._CB273765552__SL300__.jpg", "Microsoft Foldable Keyboard", 85.99m, "naab010msftkeyboard" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
