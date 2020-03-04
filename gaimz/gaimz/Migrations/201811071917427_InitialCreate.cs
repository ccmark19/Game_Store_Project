namespace gaimz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.userInfo");
            DropTable("dbo.tblWishlists");
            DropTable("dbo.tblGames");
        }
    }
}
