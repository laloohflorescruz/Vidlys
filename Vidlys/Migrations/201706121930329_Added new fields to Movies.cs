namespace Vidlys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewfieldstoMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Release", c => c.DateTime());
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "Release");
        }
    }
}
