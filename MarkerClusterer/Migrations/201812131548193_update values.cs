namespace MarkerClusterer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevalues : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Items", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Items", "Latitude", c => c.Single(nullable: false));
        }
    }
}
