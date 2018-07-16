using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceStore.Migrations.WarehouseDb
{
    public partial class initialtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Designed and engineered in the USA, the R-15PM powered speakers are made with a focus on quality and superior sound. Small enough to sit comfortably on a bookshelf or flanking your turntable or television, the R-15PM's are not only designed from a minimalist perspective, but they also allow you to ditch that bulky external receiver. ", "https://uncrate.com/assets_c/2018/06/klipsch-r15-speaker-55-thumb-960xauto-85810.jpg", "KLIPSCH R-15PM BOOKSHELF SPEAKERS", 499.99m, 1, "speaker01slipsch" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "The soft vinyl exterior and the fret grille cloth with signature script logo give it a stage equipment look. Marshall's Woburn Speaker sounds concert-worthy, too, with powerful built-in amps, two dome tweeters, and two sizable woofers.", "https://uncrate.com/assets_c/2018/05/marshall-woburn-speaker-13-thumb-960xauto-84761.jpg", "MARSHALL WOBURN SPEAKER", 500.00m, 1, "speaker02marshall" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "To embrace the vinyl resurgence, you need a pair of speakers designed for the task. Inspired by the warmth of early 70's hi-fi, when vinyl was at its peak, these Wesley & Kemp Full Range Speakers are handmade in Detroit with the analog format in mind. ", "https://uncrate.com/assets_c/2018/06/wasley-kemp-speakers-58-thumb-960xauto-85886.jpg", "WESLEY & KEMP X UNCRATE CS112 SPEAKERS", 1400.00m, 1, "speaker03wesley" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Born from an art-school design concept that went viral, the Transparent Speaker from Stockholm-based People People proves great sounding speakers don't have to come in oversized black boxes. ", "https://uncrate.com/assets_c/2017/06/transparent-speaker-1-thumb-960xauto-73340.jpg", "PEOPLE PEOPLE TRANSPARENT SPEAKER", 600m, 1, "speaker04peoplepeople" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Now in its fourth generation, Fujifilm's beloved digital rangefinder gets even better with the X100F. Like its film-based predecessors, it's ideal for street photography thanks to a combination of compact size, discreet looks, and a speedy AF system.", "https://uncrate.com/assets_c/2018/06/fujifilm-x100-25-thumb-960xauto-85784.jpg", "FUJIFILM X100F CAMERA", 1200m, 0, "gadget01fujifilm" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Something magical happens when a sensor and lens are paired so perfectly that even the best DSLRs can't match it. By marrying Wetzlar's legendary optics with a big, bright sensor in an unbelievably compact body, the Leica Q becomes more than the sum of its parts. ", "https://uncrate.com/assets_c/2018/06/leica-q-25-thumb-960xauto-85787.jpg", "LEICA Q CAMERA ", 4500m, 0, "gadget02leica" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "Cut from an Ash tree, with the rings and bark left intact, each Barky turntable is beautiful and unique. ", "https://uncrate.com/assets_c/2018/02/audiowood-uncrate-turntable-1-thumb-960xauto-80828.jpg", "AUDIOWOOD X UNCRATE BARKY TURNTABLE ", 2500m, "gadget03audiowood" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "We're all guilty of mindlessly staring at our smartphones instead of taking the time to view the real world in front of us. The Light Phone, now off of pre-order and available for immediate shipment, acts as a temporary replacement to your existing phone, giving you a break from social media feeds and news notifications, while still keeping a sleek device in your pocket for those old-fashioned 'phone calls'.", "https://uncrate.com/assets_c/2017/06/light-phone-1-thumb-960xauto-72481.jpg", "LIGHT PHONE ", 150m, "gadget04lightphone" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Constructed using lightweight and durable aluminum, the Tumi International Carry-On will make an impression no matter where your travels take you. Designed for short, overnight trips and travel within Europe and other international destinations, the suitcase boasts a rippled appearance and is as functional as it is good-looking.", "https://uncrate.com/assets_c/2018/06/tumi-luggage-1-thumb-960xauto-85771.jpg", "TUMI 19 DEGREE INTERNATIONAL CARRY-ON", 1000.00m, 2, "bag01tumi" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Seamlessly transition from the office to the gym with the Stuart & Lau Regimen Bag. The outer compartments are dedicated to work, with a tasteful blue nylon twill lining, padded laptop pouch, and various organizer pockets. ", "https://uncrate.com/assets_c/2018/07/stuart-lau-regimen-3-thumb-960xauto-87087.jpg", "STUART & LAU REGIMEN GYM BAG ", 400m, 2, "bag02stuartnlau" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "ProductCategory", "Quantity", "SKU" },
                values: new object[,]
                {
                    { 11, "Crafted from a waterproof technical weave, this adjustable bag has a versatile roll-top design. A padded compartment holds laptops up to 15\", three external pockets provide quick access to essentials, and bridle leather straps work with polished D - rings rings on the front to give it a smart look and functional purpose.", "https://uncrate.com/assets_c/2018/05/mismo-backpack-2-thumb-960xauto-85173.jpg", "MISMO M/S BACKPACK", 500m, 2, 50, "bag03mismo" },
                    { 12, "When it comes to small-but-important items like your phone, charger, passport, and pens, you don't just want them stored — you want them sorted, as well. This Is Ground's Venture 2 Backpack was designed with this in mind. ", "https://uncrate.com/assets_c/2018/03/thisisground-venture-backpack-5-thumb-960xauto-82491.jpg", "GROUND VENTURE 2 BACKPACK", 950m, 2, 50, "bag04groundventure" },
                    { 13, "Latest series of limited edition collaborations, the Topo Designs x Uncrate Rover Pack uses signature American bison leather as a base for Topo's nearly indestructible Ballistic Cordura fabric construction. ", "https://uncrate.com/assets_c/2016/03/topo-1-thumb-960xauto-61610.jpg", "TOPO DESIGNS X UNCRATE ROVER PACK", 300m, 2, 50, "bag05topo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Life-size, role-play accessory features a spring-loaded, retractable blade with switchblade-style action", "https://store.ubi.com/on/demandware.static/-/Sites-masterCatalog/default/dw0e43b641/images/large/57fe647529e1238f668b4568-collectible-2.png", "Assassin's Creed Skull Buckle", 19.54m, 3, "naab001Knif" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Nothing beats ice cold beer! But if that’s not enough for you, then you could go one step higher–and several degrees lower–with the Frozen Beer Slushy Maker. ", "https://cdn.thisiswhyimbroke.com/images/beer-slushie-machine-300x250.jpg", "Beer Slushie Machine", 53.14m, 0, "naab002beer" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "150ml decanter to hold your favorite liquire or mouthwas - whisky, scotch, bourbon, cognac, brandy all your spirits will look fantastic", "https://i.pinimg.com/originals/20/cf/b2/20cfb20ee822bd1a6a9ccf132ba9cd53.jpg", "Ship In A Bottle Whiskey Dispenser", 120.00m, 3, "naab003shipdispenser" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "A template for shaving or trimming the neckline. The EdgUp guards the back of your hairline so that you can trim with scissors or shave with a trimmer or razor all of the excess hair. You are left with the perfect hairline.", "https://cdn.thisiswhyimbroke.com/images/hair-neckline-grooming-tool.jpg", "Hairline Grooming Tool", 14.95m, 3, "naab004groomkit" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Thinking of sending a Birthday, Congrats, Get Well Soon card? This is a quirky and hilarious alternative to the traditional card! Your friends, family, and others will get a kick out of it! ", "https://cdn.thisiswhyimbroke.com/images/potato-parcel2-640x533.jpg", "Custom Message Potato Parcel", 9.99m, 3, "naab005potato" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "You may not be made of money, but why can’t your suit be?", "https://cdn.thisiswhyimbroke.com/images/cash-suit-640x533.jpg", "Cash Suit", 59.99m, 1, "naab006cashsuit" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "Great for using a tablet as second (or third) Display for your laptop!", "https://cdn.macrumors.com/article-new/2017/11/mountie1.jpg", "Tablet Mounting Clip", 34.95m, "naab007mountclip" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "Description", "Image", "Name", "Price", "SKU" },
                values: new object[] { "Charge every single electronic device in your household simultaneously with the 49 port USB hub.", "https://usb.brando.com/prod_img/zoom/UHUBS041500_3.jpg", "49 Port USB Hub", 165.00m, "naab008usbhub" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Ensure Jr. thrives in today’s technology driven society by getting him started at a young age with the HTML for babies", "https://i0.wp.com/www.daddycheckthisout.com/wp-content/uploads/2017/09/html-babies.jpg?fit=400%2C300", "HTML For Babies", 346.70m, 3, "naab009forbabies" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "Description", "Image", "Name", "Price", "ProductCategory", "SKU" },
                values: new object[] { "Get more done on your smartphone or tablet with help from the foldable keyboard.", "https://images-na.ssl-images-amazon.com/images/G/01/aplusautomation/vendorimages/032cfa09-5986-4cbc-acd9-f2a2c68aac58.jpg._CB273765552__SL300__.jpg", "Microsoft Foldable Keyboard", 85.99m, 0, "naab010msftkeyboard" });
        }
    }
}
