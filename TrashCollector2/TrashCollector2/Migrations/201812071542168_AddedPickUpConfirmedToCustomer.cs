namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPickUpConfirmedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "hasBeenPickedUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "hasBeenPickedUp");
        }
    }
}
