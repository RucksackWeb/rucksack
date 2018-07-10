using ECommerceStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new { ID = 1, SKU = "naab001Knif", Name = "Assassin's Creed Skull Buckle", Price = 19.54, Description = "Life-size, role-play accessory features a spring-loaded, retractable blade with switchblade-style action", Image = "https://store.ubi.com/on/demandware.static/-/Sites-masterCatalog/default/dw0e43b641/images/large/57fe647529e1238f668b4568-collectible-2.png" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 2, SKU = "naab002beer", Name = "Beer Slushie Machine", Price = 53.14, Description = "Nothing beats ice cold beer! But if that’s not enough for you, then you could go one step higher–and several degrees lower–with the Frozen Beer Slushy Maker. ", Image = "https://cdn.thisiswhyimbroke.com/images/beer-slushie-machine-300x250.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 3, SKU = "naab003shipdispenser", Name = "Ship In A Bottle Whiskey Dispenser", Price = 120.00, Description = "150ml decanter to hold your favorite liquire or mouthwas - whisky, scotch, bourbon, cognac, brandy all your spirits will look fantastic", Image = "https://i.pinimg.com/originals/20/cf/b2/20cfb20ee822bd1a6a9ccf132ba9cd53.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 4, SKU = "naab004groomkit", Name = "Hairline Grooming Tool", Price = 14.95, Description = "A template for shaving or trimming the neckline. The EdgUp guards the back of your hairline so that you can trim with scissors or shave with a trimmer or razor all of the excess hair. You are left with the perfect hairline.", Image = "https://cdn.thisiswhyimbroke.com/images/hair-neckline-grooming-tool.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 5, SKU = "naab005potato", Name = "Custom Message Potato Parcel", Price = 9.99, Description = "Thinking of sending a Birthday, Congrats, Get Well Soon card? This is a quirky and hilarious alternative to the traditional card! Your friends, family, and others will get a kick out of it! ", Image = "https://cdn.thisiswhyimbroke.com/images/potato-parcel2-640x533.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 6, SKU = "naab006cashsuit", Name = "Cash Suit", Price = 59.99, Description = "You may not be made of money, but why can’t your suit be?", Image = "https://cdn.thisiswhyimbroke.com/images/cash-suit-640x533.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 7, SKU = "naab007mountclip", Name = "Tablet Mounting Clip", Price = 34.95, Description = "Great for using a tablet as second (or third) Display for your laptop!", Image = "https://cdn.macrumors.com/article-new/2017/11/mountie1.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 8, SKU = "naab008usbhub", Name = "49 Port USB Hub", Price = 165.00, Description = "Charge every single electronic device in your household simultaneously with the 49 port USB hub.", Image = "https://usb.brando.com/prod_img/zoom/UHUBS041500_3.jpg" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 9, SKU = "naab009forbabies", Name = "HTML For Babies", Price = 346.70, Description = "Ensure Jr. thrives in today’s technology driven society by getting him started at a young age with the HTML for babies", Image = "https://i0.wp.com/www.daddycheckthisout.com/wp-content/uploads/2017/09/html-babies.jpg?fit=400%2C300" });

            modelBuilder.Entity<Product>().HasData(
                new { ID = 10, SKU = "naab010msftkeyboard", Name = "Microsoft Foldable Keyboard", Price = 85.99, Description = "Get more done on your smartphone or tablet with help from the foldable keyboard.", Image = "https://images-na.ssl-images-amazon.com/images/G/01/aplusautomation/vendorimages/032cfa09-5986-4cbc-acd9-f2a2c68aac58.jpg._CB273765552__SL300__.jpg" });

        }

        DbSet<Product> Products { get; set; }
    }
}
