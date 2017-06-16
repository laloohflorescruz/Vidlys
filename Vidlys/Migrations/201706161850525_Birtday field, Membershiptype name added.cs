namespace Vidlys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirtdayfieldMembershiptypenameadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
