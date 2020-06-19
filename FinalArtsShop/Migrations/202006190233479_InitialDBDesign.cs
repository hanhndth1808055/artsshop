namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBDesign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parent = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Abbreviation = c.String(),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        Name = c.String(),
                        Rate = c.Int(nullable: false),
                        Message = c.String(),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(),
                        Name = c.String(),
                        ShippingFee = c.Double(nullable: false),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdType = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Double(nullable: false),
                        PromotionPrice = c.Double(nullable: false),
                        Thumbnail = c.String(),
                        Image = c.String(),
                        Unit = c.Int(nullable: false),
                        New = c.Int(nullable: false),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Feature = c.Int(nullable: false),
                        SellIndex = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountProduct = c.Int(),
                        CountInvoice = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Factor = c.Double(nullable: false),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Message = c.String(),
                        Link = c.String(),
                        Seen = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Payment = c.Int(nullable: false),
                        DeliveryTypeId = c.Int(),
                        Status = c.Int(nullable: false),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        CityId = c.Int(),
                        DistrictId = c.Int(),
                        Address = c.String(),
                        CustomerName = c.String(),
                        CustomerPhoneNumber = c.String(),
                        CustomerEmail = c.String(),
                        Note = c.String(),
                        Otp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.DeliveryTypes", t => t.DeliveryTypeId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .Index(t => t.UserId)
                .Index(t => t.DeliveryTypeId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Priority = c.Int(nullable: false),
                        Image = c.String(),
                        Active = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CityId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DistrictId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            CreateIndex("dbo.AspNetUsers", "CityId");
            CreateIndex("dbo.AspNetUsers", "DistrictId");
            AddForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Orders", "DeliveryTypeId", "dbo.DeliveryTypes");
            DropForeignKey("dbo.Orders", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUsers", "CityId", "dbo.Cities");
            DropIndex("dbo.Orders", new[] { "DistrictId" });
            DropIndex("dbo.Orders", new[] { "CityId" });
            DropIndex("dbo.Orders", new[] { "DeliveryTypeId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.AspNetUsers", new[] { "DistrictId" });
            DropIndex("dbo.AspNetUsers", new[] { "CityId" });
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "DistrictId");
            DropColumn("dbo.AspNetUsers", "CityId");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Description");
            DropTable("dbo.Slides");
            DropTable("dbo.Posts");
            DropTable("dbo.Orders");
            DropTable("dbo.Notifications");
            DropTable("dbo.Followers");
            DropTable("dbo.DeliveryTypes");
            DropTable("dbo.Counters");
            DropTable("dbo.Products");
            DropTable("dbo.Districts");
            DropTable("dbo.Comments");
            DropTable("dbo.Cities");
            DropTable("dbo.Categories");
        }
    }
}
