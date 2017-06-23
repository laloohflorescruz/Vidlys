namespace Vidlys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingLicese : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}
