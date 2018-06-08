namespace ProductPrice.Domain.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocalization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Category = c.String(),
                        Key = c.String(maxLength: 100),
                        Value = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true);
            
            CreateTable(
                "dbo.ImageUrls",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Category = c.String(),
                        Key = c.String(maxLength: 100),
                        Value = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true);
            
            CreateTable(
                "dbo.LocalizedStrings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 100),
                        IsoLanguageName = c.String(maxLength: 100),
                        Category = c.String(),
                        Value = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true)
                .Index(t => t.IsoLanguageName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LocalizedStrings", new[] { "IsoLanguageName" });
            DropIndex("dbo.LocalizedStrings", new[] { "Key" });
            DropIndex("dbo.ImageUrls", new[] { "Key" });
            DropIndex("dbo.Colors", new[] { "Key" });
            DropTable("dbo.LocalizedStrings");
            DropTable("dbo.ImageUrls");
            DropTable("dbo.Colors");
        }
    }
}
