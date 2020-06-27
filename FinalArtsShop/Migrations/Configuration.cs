namespace FinalArtsShop.Migrations
{
    using FinalArtsShop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalArtsShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FinalArtsShop.Models.ApplicationDbContext";
        }

        protected override void Seed(FinalArtsShop.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            SeedingCategories(context);
            SeedingProduct(context);
        }

        private void Truncate(FinalArtsShop.Models.ApplicationDbContext context)
        {
            //context.Database.ExecuteSqlCommand("DROP TABLE dbo.MigrationsHistory");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetRoleClaims");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetUserLogins");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetUserRoles");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetRoles");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.AspNetUsers");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");

        }

        public void SeedingCouters(ApplicationDbContext context)
        {
            Counter[] arrCouters = {
                new Counter()
                {
                    CountProduct = 56,
                    Active = ActiveEnum.Active
                }
            };
            context.Counters.AddOrUpdate(arrCouters);
        }

        private void SeedingCategories(ApplicationDbContext context)
        {
            Category[] arrCategories =
            {
                new Category()
                {
                    Id = 1,
                    Parent = 0,
                    CreatedAt = DateTime.Parse("2019-01-16"),
                    Name = "Accessories & Technology",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "01",
                    Active = 1
                },
                new Category()
                {
                    Id = 2,
                    Parent = 1,
                    CreatedAt = DateTime.Parse("2019-01-17"),
                    Name = "Earring",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "02",
                    Active = 1
                },
                new Category()
                {
                    Id = 3,
                    Parent = 1,
                    CreatedAt = DateTime.Parse("2019-01-18"),
                    Name = "Necklace",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "03",
                    Active = 1
                },
                new Category()
                {
                    Id = 4,
                    Parent = 1,
                    CreatedAt = DateTime.Parse("2019-01-19"),
                    Name = "Hair Tie",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "04",
                    Active = 1
                },
                new Category()
                {
                    Id = 5,
                    Parent = 1,
                    CreatedAt = DateTime.Parse("2019-01-20"),
                    Name = "Hair Tongs",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "05",
                    Active = 1
                },new Category()
                {
                    Id = 6,
                    Parent = 1,
                    CreatedAt = DateTime.Parse("2019-01-21"),
                    Name = "Sandals",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "06",
                    Active = 1
                },
                new Category()
                {
                    Id = 7,
                    Parent = 1,
                    CreatedAt = DateTime.Parse("2019-01-22"),
                    Name = "Phone Accessories",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "07",
                    Active = 1
                },

                new Category()
                {
                    Id = 8,
                    Parent = 0,
                    CreatedAt = DateTime.Parse("2019-01-23"),
                    Name = "Souvenir",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "08",
                    Active = 1
                },
                new Category()
                {
                    Id = 9,
                    Parent = 8,
                    CreatedAt = DateTime.Parse("2019-01-24"),
                    Name = "Idol Collection",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "09",
                    Active = 1
                },
                new Category()
                {
                    Id = 10,
                    Parent = 8,
                    CreatedAt = DateTime.Parse("2019-01-25"),
                    Name = "Display",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "10",
                    Active = 1
                },
                new Category()
                {
                    Id = 11,
                    Parent = 8,
                    CreatedAt = DateTime.Parse("2019-01-26"),
                    Name = "Appliances",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "11",
                    Active = 1
                },
                new Category()
                {
                    Id = 12,
                    Parent = 8,
                    CreatedAt = DateTime.Parse("2019-01-27"),
                    Name = "Gift Box",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "12",
                    Active = 1
                },

                new Category()
                {
                    Id = 13,
                    Parent = 0,
                    CreatedAt = DateTime.Parse("2019-01-28"),
                    Name = "Personal Use",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "13",
                    Active = 1
                },
                new Category()
                {
                    Id = 14,
                    Parent = 13,
                    CreatedAt = DateTime.Parse("2019-01-29"),
                    Name = "Balo - Handbag - Wallet",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "14",
                    Active = 1
                },
                new Category()
                {
                    Id = 15,
                    Parent = 13,
                    CreatedAt = DateTime.Parse("2019-02-01"),
                    Name = "Watch",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "15",
                    Active = 1
                },
                new Category()
                {
                    Id = 16,
                    Parent = 13,
                    CreatedAt = DateTime.Parse("2019-02-02"),
                    Name = "Glasses",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "16",
                    Active = 1
                },
                new Category()
                {
                    Id = 17,
                    Parent = 13,
                    CreatedAt = DateTime.Parse("2019-02-03"),
                    Name = "Personal Accessories",
                    Description = "The Memorable Dog is being hunted aggressively by the sisters who were present at our ChipChip house after a long period of weariness. Material: soft feather smooth smooth elasticity, Whats in the movie Secretary Kim? President Lee went with her to play. Because of the love for Kims secretary. Lee did not hesitate to experience new things that he had never done before. With constant adaptation and effort, this brilliant handsome man finally managed to fold a lovely teddy dog ​​for her.Its called Memories",
                    Abbreviation = "17",
                    Active = 1
                },
            };
            context.Categories.AddOrUpdate(arrCategories);
        }

        private void SeedingProduct(ApplicationDbContext context)
        {
            Product[] arrProducts = {
                new Product()
                {
                    Id = "0200001",
                    Name = "Skeleton",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 2,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-13"),
                },
                new Product()
                {
                    Id = "0200002",
                    Name = "Black Winged Earrings",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 2,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-14"),
                },
                new Product()
                {
                    Id = "0200003",
                    Name = "Leaf Earrings",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 2,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-15"),
                },
                new Product()
                {
                    Id = "0200004",
                    Name = "Diamond Hook Earrings",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 2,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "0300005",
                    Name = "3 circles",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 3,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0300006",
                    Name = "Wolf Head",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 3,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0300007",
                    Name = "LINE 2 FISH",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 3,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0300008",
                    Name = "Pendant Lines",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 3,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "0400009",
                    Name = "Small spiky hair",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 4,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0400010",
                    Name = "Spiky hair",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 4,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0400011",
                    Name = "Elastic spandex small",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 4,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0400012",
                    Name = "Tie elastic hair bow",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 4,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "0500013",
                    Name = "2-button clip set",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 5,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0500014",
                    Name = "Set of 3 diamonds",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 5,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0500015",
                    Name = "Heart shaped clip set",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 5,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0500016",
                    Name = "Pearl clip",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 5,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "0600017",
                    Name = "Leopard puka sandals",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 6,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0600018",
                    Name = "Pikachu slippers",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 6,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0600019",
                    Name = "Pony slippers",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 6,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0600020",
                    Name = "Leopard cat sandals",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 6,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "0700021",
                    Name = "Case apeach iphone 6/6s/6 plus",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 7,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0700022",
                    Name = "Case Chimmy iphone 7, 7 plus",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 7,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0700023",
                    Name = "Case iphone 6G pig",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 7,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0700024",
                    Name = "Case Koya iphone 7, 6 plus",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 7,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "0900025",
                    Name = "BT21 2-sided pillow Shooky 40cm",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 9,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0900026",
                    Name = "EXO flexible pens",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 9,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0900027",
                    Name = "Square mirror Angela",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 9,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "0900028",
                    Name = "Keychains brown pig shirt",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 9,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1000029",
                    Name = "Set of wooden pots with heart-shaped grass I LOVE YOU",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 10,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1000030",
                    Name = "Bouquet of heart frames",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 10,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1000031",
                    Name = "Water bridge 2 pink deer",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 10,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1000032",
                    Name = "Water bridge reindeer old man",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 10,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1100033",
                    Name = "Plastic heart cup lid",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 11,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1100034",
                    Name = "Porcelain cup lid",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 11,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1100035",
                    Name = "Porcelain cup with spoon of heart",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 11,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1100036",
                    Name = "Red starbuck glass",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 11,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1200037",
                    Name = "Battery cord",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 12,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1200038",
                    Name = "Happy birthday baby girl",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 12,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1200039",
                    Name = "Happy birthday batman wire",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 12,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1200040",
                    Name = "Happy birthday gold chicken wire",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 12,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1400041",
                    Name = "PU bags",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 14,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1400042",
                    Name = "Squeeze Fuerdanni",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 14,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1400043",
                    Name = "Squeeze short female button",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 14,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1400044",
                    Name = "Pierre's long wallet",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 14,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1500045",
                    Name = "Brown alarm clock 203",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 15,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1600046",
                    Name = "Fake black glasses",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 16,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1600047",
                    Name = "Sunglasses",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 16,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1600048",
                    Name = "Plastic sunglasses",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 16,
                    isNew = 1,
                    isActive = 1,
                    isFeature = 1,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1600049",
                    Name = "Coated Fashion Mirror Female Glasses",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 16,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },

                new Product()
                {
                    Id = "1700050",
                    Name = "Minifan hand fan",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 17,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1700051",
                    Name = "Mirror fan",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 17,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1700052",
                    Name = "Phone support stickers",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 17,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
                new Product()
                {
                    Id = "1700053",
                    Name = "Conical hat against rabbit rabbit fluids",
                    Description = "Color: white Material: stainless steel Size: Description: fashion pendant products made from stainless steel material, very suitable for personality teenagers",
                    UnitPrice = 100000,
                    PromotionPrice = 90000,
                    Thumbnail = "ImageKC3_cx0wwv.jpg,ImageKC2_mrzekc.jpg,PoohKeychain_snaanj.jpg",
                    Image = "ImageKC1_lytmlr.jpg",
                    Unit = 10,
                    SellIndex = 2,
                    CategoryID = 17,
                    isNew = 0,
                    isActive = 1,
                    isFeature = 0,
                    CreatedAt = DateTime.Parse("2020-01-16"),
                },
            };
            context.Products.AddOrUpdate(arrProducts);
        }
    }
}