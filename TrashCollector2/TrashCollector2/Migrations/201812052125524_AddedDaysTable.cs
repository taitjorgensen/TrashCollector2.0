namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDaysTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickUpDays",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickUpDays");
        }
    }
}
