namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCustomersandEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PickUpDay = c.String(),
                        BalanceDue = c.Double(nullable: false),
                        ExtraPickUp = c.DateTime(nullable: false),
                        StartSuspendService = c.DateTime(nullable: false),
                        EndSuspendService = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
