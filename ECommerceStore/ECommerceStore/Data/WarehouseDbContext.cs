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
                new {
                    ID = 1,
                    SKU = "speaker01slipsch",
                    Name = "KLIPSCH R-15PM BOOKSHELF SPEAKERS",
                    Price = 499.99m,
                    Description = "Designed and engineered in the USA, the R-15PM powered speakers are made with a focus on quality and superior sound. Small enough to sit comfortably on a bookshelf or flanking your turntable or television, the R-15PM's are not only designed from a minimalist perspective, but they also allow you to ditch that bulky external receiver. ",
                    Image = "https://uncrate.com/assets_c/2018/06/klipsch-r15-speaker-55-thumb-960xauto-85810.jpg",
                    Quantity = 50,
                    ProductCategory = ECommerceStore.Models.Category.Speaker });

            modelBuilder.Entity<Product>().HasData(
                new {
                    ID = 2,
                    SKU = "speaker02marshall",
                    Name = "MARSHALL WOBURN SPEAKER",
                    Price = 500.00m,
                    Description = "The soft vinyl exterior and the fret grille cloth with signature script logo give it a stage equipment look. Marshall's Woburn Speaker sounds concert-worthy, too, with powerful built-in amps, two dome tweeters, and two sizable woofers." ,
                    Image = "https://uncrate.com/assets_c/2018/05/marshall-woburn-speaker-13-thumb-960xauto-84761.jpg",
                    Quantity = 50,
                    ProductCategory = ECommerceStore.Models.Category.Speaker });

            modelBuilder.Entity<Product>().HasData(
                new {
                    ID = 3,
                    SKU = "speaker03wesley",
                    Name = "WESLEY & KEMP X UNCRATE CS112 SPEAKERS",
                    Price = 1400.00m,
                    Description = "To embrace the vinyl resurgence, you need a pair of speakers designed for the task. Inspired by the warmth of early 70's hi-fi, when vinyl was at its peak, these Wesley & Kemp Full Range Speakers are handmade in Detroit with the analog format in mind. ",
                    Image = "https://uncrate.com/assets_c/2018/06/wasley-kemp-speakers-58-thumb-960xauto-85886.jpg",
                    Quantity = 50,
                    ProductCategory = 
                    ECommerceStore.Models.Category.Speaker });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 4,
                     SKU = "speaker04peoplepeople",
                     Name = "PEOPLE PEOPLE TRANSPARENT SPEAKER",
                     Price = 600m,
                     Description = "Born from an art-school design concept that went viral, the Transparent Speaker from Stockholm-based People People proves great sounding speakers don't have to come in oversized black boxes. ",
                     Image = "https://uncrate.com/assets_c/2017/06/transparent-speaker-1-thumb-960xauto-73340.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Speaker });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 5,
                     SKU = "gadget01fujifilm",
                     Name = "FUJIFILM X100F CAMERA",
                     Price = 1200m,
                     Description = "Now in its fourth generation, Fujifilm's beloved digital rangefinder gets even better with the X100F. Like its film-based predecessors, it's ideal for street photography thanks to a combination of compact size, discreet looks, and a speedy AF system.",
                     Image = "https://uncrate.com/assets_c/2018/06/fujifilm-x100-25-thumb-960xauto-85784.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Gadget });

            modelBuilder.Entity<Product>().HasData(
                new
                {
                    ID = 6,
                    SKU = "gadget02leica",
                    Name = "LEICA Q CAMERA ",
                    Price = 4500m,
                    Description = "Something magical happens when a sensor and lens are paired so perfectly that even the best DSLRs can't match it. By marrying Wetzlar's legendary optics with a big, bright sensor in an unbelievably compact body, the Leica Q becomes more than the sum of its parts. ",
                    Image = "https://uncrate.com/assets_c/2018/06/leica-q-25-thumb-960xauto-85787.jpg",
                    Quantity = 50,
                    ProductCategory =
                    ECommerceStore.Models.Category.Gadget });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 7,
                     SKU = "gadget03audiowood",
                     Name = "AUDIOWOOD X UNCRATE BARKY TURNTABLE ",
                     Price = 2500m,
                     Description = "Cut from an Ash tree, with the rings and bark left intact, each Barky turntable is beautiful and unique. ",
                     Image = "https://uncrate.com/assets_c/2018/02/audiowood-uncrate-turntable-1-thumb-960xauto-80828.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Gadget });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 8,
                     SKU = "gadget04lightphone",
                     Name = "LIGHT PHONE ",
                     Price = 150m,
                     Description = "We're all guilty of mindlessly staring at our smartphones instead of taking the time to view the real world in front of us. The Light Phone, now off of pre-order and available for immediate shipment, acts as a temporary replacement to your existing phone, giving you a break from social media feeds and news notifications, while still keeping a sleek device in your pocket for those old-fashioned 'phone calls'.",
                     Image = "https://uncrate.com/assets_c/2017/06/light-phone-1-thumb-960xauto-72481.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Gadget });

            modelBuilder.Entity<Product>().HasData(
                new
                {
                    ID = 9,
                    SKU = "bag01tumi",
                    Name = "TUMI 19 DEGREE INTERNATIONAL CARRY-ON",
                    Price = 1000.00m,
                    Description = "Constructed using lightweight and durable aluminum, the Tumi International Carry-On will make an impression no matter where your travels take you. Designed for short, overnight trips and travel within Europe and other international destinations, the suitcase boasts a rippled appearance and is as functional as it is good-looking.",
                    Image = "https://uncrate.com/assets_c/2018/06/tumi-luggage-1-thumb-960xauto-85771.jpg",
                    Quantity = 50,
                    ProductCategory =
                    ECommerceStore.Models.Category.Bags });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 10,
                     SKU = "bag02stuartnlau",
                     Name = "STUART & LAU REGIMEN GYM BAG ",
                     Price = 400m,
                     Description = "Seamlessly transition from the office to the gym with the Stuart & Lau Regimen Bag. The outer compartments are dedicated to work, with a tasteful blue nylon twill lining, padded laptop pouch, and various organizer pockets. ",
                     Image = "https://uncrate.com/assets_c/2018/07/stuart-lau-regimen-3-thumb-960xauto-87087.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Bags });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 11,
                     SKU = "bag03mismo",
                     Name = "MISMO M/S BACKPACK",
                     Price = 500m,
                     Description = "Crafted from a waterproof technical weave, this adjustable bag has a versatile roll-top design. A padded compartment holds laptops up to 15\", three external pockets provide quick access to essentials, and bridle leather straps work with polished D - rings rings on the front to give it a smart look and functional purpose.",
                     Image = "https://uncrate.com/assets_c/2018/05/mismo-backpack-2-thumb-960xauto-85173.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Bags });

            modelBuilder.Entity<Product>().HasData(
                new
                {
                    ID = 12,
                    SKU = "bag04groundventure",
                    Name = "GROUND VENTURE 2 BACKPACK",
                    Price = 950m,
                    Description = "When it comes to small-but-important items like your phone, charger, passport, and pens, you don't just want them stored — you want them sorted, as well. This Is Ground's Venture 2 Backpack was designed with this in mind. ",
                    Image = "https://uncrate.com/assets_c/2018/03/thisisground-venture-backpack-5-thumb-960xauto-82491.jpg",
                    Quantity = 50,
                    ProductCategory =
                    ECommerceStore.Models.Category.Bags });

            modelBuilder.Entity<Product>().HasData(
                 new
                 {
                     ID = 13,
                     SKU = "bag05topo",
                     Name = "TOPO DESIGNS X UNCRATE ROVER PACK",
                     Price = 300m,
                     Description = "Latest series of limited edition collaborations, the Topo Designs x Uncrate Rover Pack uses signature American bison leather as a base for Topo's nearly indestructible Ballistic Cordura fabric construction. ",
                     Image = "https://uncrate.com/assets_c/2016/03/topo-1-thumb-960xauto-61610.jpg",
                     Quantity = 50,
                     ProductCategory =
                     ECommerceStore.Models.Category.Bags });

        }

        public  DbSet<Product> Products { get; set; }
    }
}
