namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedPickUpDaysModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PickUpDays", "dayOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PickUpDays", "dayOfWeek");
        }
    }
}
