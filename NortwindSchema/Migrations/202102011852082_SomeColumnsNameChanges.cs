namespace NortwindSchema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeColumnsNameChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "orderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "dateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "dateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "orderDate");
        }
    }
}
