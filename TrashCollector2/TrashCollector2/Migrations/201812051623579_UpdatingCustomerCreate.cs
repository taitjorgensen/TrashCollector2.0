namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingCustomerCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BalanceDue", c => c.Double());
            AlterColumn("dbo.Customers", "ExtraPickUp", c => c.DateTime());
            AlterColumn("dbo.Customers", "StartSuspendService", c => c.DateTime());
            AlterColumn("dbo.Customers", "EndSuspendService", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndSuspendService", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "StartSuspendService", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ExtraPickUp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "BalanceDue", c => c.Double(nullable: false));
        }
    }
}
