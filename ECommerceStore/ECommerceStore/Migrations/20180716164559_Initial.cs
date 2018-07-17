using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceStore.Migrations
{
    public partial class Initial : Migration
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
                    Image = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ProductCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "ProductCategory", "Quantity", "SKU" },
                values: new object[,]
                {
                    { 1, "Designed and engineered in the USA, the R-15PM powered speakers are made with a focus on quality and superior sound. Small enough to sit comfortably on a bookshelf or flanking your turntable or television, the R-15PM's are not only designed from a minimalist perspective, but they also allow you to ditch that bulky external receiver. ", "https://uncrate.com/assets_c/2018/06/klipsch-r15-speaker-55-thumb-960xauto-85810.jpg", "KLIPSCH R-15PM BOOKSHELF SPEAKERS", 499.99m, 1, 50, "speaker01slipsch" },
                    { 2, "The soft vinyl exterior and the fret grille cloth with signature script logo give it a stage equipment look. Marshall's Woburn Speaker sounds concert-worthy, too, with powerful built-in amps, two dome tweeters, and two sizable woofers.", "https://uncrate.com/assets_c/2018/05/marshall-woburn-speaker-13-thumb-960xauto-84761.jpg", "MARSHALL WOBURN SPEAKER", 500.00m, 1, 50, "speaker02marshall" },
                    { 3, "To embrace the vinyl resurgence, you need a pair of speakers designed for the task. Inspired by the warmth of early 70's hi-fi, when vinyl was at its peak, these Wesley & Kemp Full Range Speakers are handmade in Detroit with the analog format in mind. ", "https://uncrate.com/assets_c/2018/06/wasley-kemp-speakers-58-thumb-960xauto-85886.jpg", "WESLEY & KEMP X UNCRATE CS112 SPEAKERS", 1400.00m, 1, 50, "speaker03wesley" },
                    { 4, "Born from an art-school design concept that went viral, the Transparent Speaker from Stockholm-based People People proves great sounding speakers don't have to come in oversized black boxes. ", "https://uncrate.com/assets_c/2017/06/transparent-speaker-1-thumb-960xauto-73340.jpg", "PEOPLE PEOPLE TRANSPARENT SPEAKER", 600m, 1, 50, "speaker04peoplepeople" },
                    { 5, "Now in its fourth generation, Fujifilm's beloved digital rangefinder gets even better with the X100F. Like its film-based predecessors, it's ideal for street photography thanks to a combination of compact size, discreet looks, and a speedy AF system.", "https://uncrate.com/assets_c/2018/06/fujifilm-x100-25-thumb-960xauto-85784.jpg", "FUJIFILM X100F CAMERA", 1200m, 0, 50, "gadget01fujifilm" },
                    { 6, "Something magical happens when a sensor and lens are paired so perfectly that even the best DSLRs can't match it. By marrying Wetzlar's legendary optics with a big, bright sensor in an unbelievably compact body, the Leica Q becomes more than the sum of its parts. ", "https://uncrate.com/assets_c/2018/06/leica-q-25-thumb-960xauto-85787.jpg", "LEICA Q CAMERA ", 4500m, 0, 50, "gadget02leica" },
                    { 7, "Cut from an Ash tree, with the rings and bark left intact, each Barky turntable is beautiful and unique. ", "https://uncrate.com/assets_c/2018/02/audiowood-uncrate-turntable-1-thumb-960xauto-80828.jpg", "AUDIOWOOD X UNCRATE BARKY TURNTABLE ", 2500m, 0, 50, "gadget03audiowood" },
                    { 8, "We're all guilty of mindlessly staring at our smartphones instead of taking the time to view the real world in front of us. The Light Phone, now off of pre-order and available for immediate shipment, acts as a temporary replacement to your existing phone, giving you a break from social media feeds and news notifications, while still keeping a sleek device in your pocket for those old-fashioned 'phone calls'.", "https://uncrate.com/assets_c/2017/06/light-phone-1-thumb-960xauto-72481.jpg", "LIGHT PHONE ", 150m, 0, 50, "gadget04lightphone" },
                    { 9, "Constructed using lightweight and durable aluminum, the Tumi International Carry-On will make an impression no matter where your travels take you. Designed for short, overnight trips and travel within Europe and other international destinations, the suitcase boasts a rippled appearance and is as functional as it is good-looking.", "https://uncrate.com/assets_c/2018/06/tumi-luggage-1-thumb-960xauto-85771.jpg", "TUMI 19 DEGREE INTERNATIONAL CARRY-ON", 1000.00m, 2, 50, "bag01tumi" },
                    { 10, "Seamlessly transition from the office to the gym with the Stuart & Lau Regimen Bag. The outer compartments are dedicated to work, with a tasteful blue nylon twill lining, padded laptop pouch, and various organizer pockets. ", "https://uncrate.com/assets_c/2018/07/stuart-lau-regimen-3-thumb-960xauto-87087.jpg", "STUART & LAU REGIMEN GYM BAG ", 400m, 2, 50, "bag02stuartnlau" },
                    { 11, "Crafted from a waterproof technical weave, this adjustable bag has a versatile roll-top design. A padded compartment holds laptops up to 15\", three external pockets provide quick access to essentials, and bridle leather straps work with polished D - rings rings on the front to give it a smart look and functional purpose.", "https://uncrate.com/assets_c/2018/05/mismo-backpack-2-thumb-960xauto-85173.jpg", "MISMO M/S BACKPACK", 500m, 2, 50, "bag03mismo" },
                    { 12, "When it comes to small-but-important items like your phone, charger, passport, and pens, you don't just want them stored — you want them sorted, as well. This Is Ground's Venture 2 Backpack was designed with this in mind. ", "https://uncrate.com/assets_c/2018/03/thisisground-venture-backpack-5-thumb-960xauto-82491.jpg", "GROUND VENTURE 2 BACKPACK", 950m, 2, 50, "bag04groundventure" },
                    { 13, "Latest series of limited edition collaborations, the Topo Designs x Uncrate Rover Pack uses signature American bison leather as a base for Topo's nearly indestructible Ballistic Cordura fabric construction. ", "https://uncrate.com/assets_c/2016/03/topo-1-thumb-960xauto-61610.jpg", "TOPO DESIGNS X UNCRATE ROVER PACK", 300m, 2, 50, "bag05topo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
