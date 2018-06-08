using System;
using ProductPrice.Domain.Database.SqlScripts;

namespace ProductPrice.Domain.Database.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ScriptsInit : DbMigration
    {
        public override void Up()
        {
            Sql(Scripts.dbo_ProductId);
            Sql(Scripts.dbo_ProductTaxes);
            Sql(Scripts.dbo_PriceByProductId);
            Sql(Scripts.dbo_PriceForRange);
        }
        
        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
