namespace BT4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_colum_account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "RoleID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
        }
    }
}
