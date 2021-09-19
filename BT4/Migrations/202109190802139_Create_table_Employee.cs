namespace BT4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_Employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Company", c => c.String());
            AddColumn("dbo.People", "Address", c => c.String());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.People", "Address");
            DropColumn("dbo.People", "Company");
        }
    }
}
