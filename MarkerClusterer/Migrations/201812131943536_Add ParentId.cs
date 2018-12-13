namespace MarkerClusterer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ParentId");
        }
    }
}
