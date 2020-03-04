namespace gaimz.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Game : DbContext
    {
        public Game()
            : base("name=Game1")
        {
        }

        public virtual DbSet<tblGame> tblGames { get; set; }
        public virtual DbSet<tblWishlist> tblWishlists { get; set; }
        public virtual DbSet<userInfo> userInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblGame>()
                .Property(e => e.gameName)
                .IsUnicode(false);

            modelBuilder.Entity<tblGame>()
                .Property(e => e.gameDesc)
                .IsUnicode(false);

            modelBuilder.Entity<tblGame>()
                .Property(e => e.gameGenre)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.userId)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.favPlatform)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.favCategory)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.postCode)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<userInfo>()
                .Property(e => e.Country)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<gaimz.Models.tblReview> tblReviews { get; set; }
        public System.Data.Entity.DbSet<gaimz.Models.user_event> user_event { get; set; }
        public System.Data.Entity.DbSet<gaimz.Models.tblEvent> tblEvents { get; set; }
    }
}
