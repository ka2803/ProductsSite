namespace ProductPrice.Domain.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SizeType = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Material = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomProperties",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductId = c.Guid(),
                        ParentPropetyId = c.Guid(),
                        Name = c.String(maxLength: 100),
                        Value = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomProperties", t => t.ParentPropetyId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => new { t.ProductId, t.Name }, unique: true, name: "UX_CustomProperty_NameProduct")
                .Index(t => t.ParentPropetyId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ProductPriceId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductPrices", t => t.ProductPriceId, cascadeDelete: true)
                .Index(t => t.ProductPriceId);
            
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        StartPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BoxingId = c.Guid(nullable: false),
                        EnvironmentId = c.Guid(nullable: false),
                        ShippingId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boxings", t => t.BoxingId, cascadeDelete: true)
                .ForeignKey("dbo.Environments", t => t.EnvironmentId, cascadeDelete: true)
                .ForeignKey("dbo.Shippings", t => t.ShippingId, cascadeDelete: true)
                .Index(t => t.BoxingId)
                .Index(t => t.EnvironmentId)
                .Index(t => t.ShippingId);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TotalSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalElectricity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmortization = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PathLength = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Email = c.String(maxLength: 25),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UX_Users_Email");
            
            CreateTable(
                "dbo.TaxProductPrices",
                c => new
                    {
                        Tax_Id = c.Guid(nullable: false),
                        ProductPrice_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tax_Id, t.ProductPrice_Id })
                .ForeignKey("dbo.Taxes", t => t.Tax_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductPrices", t => t.ProductPrice_Id, cascadeDelete: true)
                .Index(t => t.Tax_Id)
                .Index(t => t.ProductPrice_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomProperties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductPriceId", "dbo.ProductPrices");
            DropForeignKey("dbo.TaxProductPrices", "ProductPrice_Id", "dbo.ProductPrices");
            DropForeignKey("dbo.TaxProductPrices", "Tax_Id", "dbo.Taxes");
            DropForeignKey("dbo.ProductPrices", "ShippingId", "dbo.Shippings");
            DropForeignKey("dbo.ProductPrices", "EnvironmentId", "dbo.Environments");
            DropForeignKey("dbo.ProductPrices", "BoxingId", "dbo.Boxings");
            DropForeignKey("dbo.CustomProperties", "ParentPropetyId", "dbo.CustomProperties");
            DropIndex("dbo.TaxProductPrices", new[] { "ProductPrice_Id" });
            DropIndex("dbo.TaxProductPrices", new[] { "Tax_Id" });
            DropIndex("dbo.Users", "UX_Users_Email");
            DropIndex("dbo.ProductPrices", new[] { "ShippingId" });
            DropIndex("dbo.ProductPrices", new[] { "EnvironmentId" });
            DropIndex("dbo.ProductPrices", new[] { "BoxingId" });
            DropIndex("dbo.Products", new[] { "ProductPriceId" });
            DropIndex("dbo.CustomProperties", new[] { "ParentPropetyId" });
            DropIndex("dbo.CustomProperties", "UX_CustomProperty_NameProduct");
            DropTable("dbo.TaxProductPrices");
            DropTable("dbo.Users");
            DropTable("dbo.Taxes");
            DropTable("dbo.Shippings");
            DropTable("dbo.Environments");
            DropTable("dbo.ProductPrices");
            DropTable("dbo.Products");
            DropTable("dbo.CustomProperties");
            DropTable("dbo.Boxings");
        }
    }
}
