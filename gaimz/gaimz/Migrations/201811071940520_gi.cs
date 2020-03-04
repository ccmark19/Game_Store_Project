namespace gaimz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblGames",
                c => new
                    {
                        gameId = c.Int(nullable: false, identity: true),
                        gameName = c.String(maxLength: 50, unicode: false),
                        gameDesc = c.String(maxLength: 255, unicode: false),
                        gameGenre = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.gameId);
            
            CreateTable(
                "dbo.tblWishlists",
                c => new
                    {
                        wishlistId = c.Int(nullable: false, identity: true),
                        userId = c.Int(),
                        gameId = c.Int(),
                    })
                .PrimaryKey(t => t.wishlistId);
            
            CreateTable(
                "dbo.userInfo",
                c => new
                    {
                        infoID = c.Int(nullable: false, identity: true),
                        userId = c.String(maxLength: 50, unicode: false),
                        favPlatform = c.String(maxLength: 50, unicode: false),
                        favCategory = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 50, unicode: false),
                        postCode = c.String(maxLength: 50, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        wantEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.infoID);
            
            AlterColumn("dbo.tblReview", "userID", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tblReview", "review", c => c.String(maxLength: 500));
            AlterColumn("dbo.tblReview", "rating", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tblReview", "gameName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblReview", "gameName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.tblReview", "rating", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.tblReview", "review", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.tblReview", "userID", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropTable("dbo.userInfo");
            DropTable("dbo.tblWishlists");
            DropTable("dbo.tblGames");
        }
    }
}
