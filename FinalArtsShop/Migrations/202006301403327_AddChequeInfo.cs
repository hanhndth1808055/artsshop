namespace FinalArtsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChequeInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChequeInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.String(maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Payer = c.String(),
                        ChequeCode = c.String(),
                        Amount = c.Double(nullable: false),
                        AmountByWord = c.String(),
                        BankName = c.String(),
                        Receiver = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTime(precision: 0),
                        UpdatedAt = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.Orders", "isReturnable", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChequeInfoes", "OrderId", "dbo.Orders");
            DropIndex("dbo.ChequeInfoes", new[] { "OrderId" });
            DropColumn("dbo.Orders", "isReturnable");
            DropTable("dbo.ChequeInfoes");
        }
    }
}
