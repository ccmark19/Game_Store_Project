namespace gaimz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblReview",
                c => new
                    {
                        reviewID = c.Int(nullable: false, identity: true),
                        gameID = c.Int(nullable: false),
                        userID = c.String(nullable: false, maxLength: 50, unicode: false),
                        review = c.String(maxLength: 500, unicode: false),
                        rating = c.Decimal(precision: 18, scale: 0),
                        gameName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.reviewID);
            
            DropTable("dbo.tblGames");
            DropTable("dbo.tblWishlists");
            DropTable("dbo.userInfo");
        }
        
        public override void Down()
        {
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
                "dbo.tblGames",
                c => new
                    {
                        gameId = c.Int(nullable: false, identity: true),
                        gameName = c.String(maxLength: 50, unicode: false),
                        gameDesc = c.String(maxLength: 255, unicode: false),
                        gameGenre = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.gameId);
            
            DropTable("dbo.tblReview");
        }
    }
}
