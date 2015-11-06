namespace Nettbutikk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.OldCategories",
            //    c => new
            //        {
            //            OldCategoryId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Changed = c.DateTime(nullable: false),
            //            AdminId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.OldCategoryId)
            //    .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
            //    .Index(t => t.AdminId);
            
            //CreateTable(
            //    "dbo.OldProducts",
            //    c => new
            //        {
            //            OldProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Price = c.Double(nullable: false),
            //            Stock = c.Int(nullable: false),
            //            Description = c.String(),
            //            ImageUrl = c.String(),
            //            CategoryId = c.Int(nullable: false),
            //            Changed = c.DateTime(nullable: false),
            //            AdminId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.OldProductId)
            //    .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
            //    .Index(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            //    DropForeignKey("dbo.OldProducts", "AdminId", "dbo.Admins");
            //    DropForeignKey("dbo.OldCategories", "AdminId", "dbo.Admins");
            //    DropIndex("dbo.OldProducts", new[] { "AdminId" });
            //    DropIndex("dbo.OldCategories", new[] { "AdminId" });
            //    DropTable("dbo.OldProducts");
            //    DropTable("dbo.OldCategories");
        }
    }
}
