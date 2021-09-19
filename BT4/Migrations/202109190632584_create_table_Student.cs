namespace BT4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acount",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.Acount");
        }
    }
}
