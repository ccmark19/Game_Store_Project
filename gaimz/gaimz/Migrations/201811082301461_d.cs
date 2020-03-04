namespace gaimz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEvent",
                c => new
                    {
                        eventID = c.Int(nullable: false, identity: true),
                        eventDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.eventID);
            
            CreateTable(
                "dbo.user_event",
                c => new
                    {
                        user_event_ID = c.Int(nullable: false, identity: true),
                        userId = c.String(maxLength: 10),
                        eventID = c.Int(),
                    })
                .PrimaryKey(t => t.user_event_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.user_event");
            DropTable("dbo.tblEvent");
        }
    }
}
