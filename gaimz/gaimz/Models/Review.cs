namespace gaimz.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Review : DbContext
    {
        public Review()
            : base("name=Review")
        {
        }

        public virtual DbSet<tblReview> tblReviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblReview>()
                .Property(e => e.userID)
                .IsUnicode(false);

            modelBuilder.Entity<tblReview>()
                .Property(e => e.review)
                .IsUnicode(false);

            modelBuilder.Entity<tblReview>()
                .Property(e => e.rating)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblReview>()
                .Property(e => e.gameName)
                .IsUnicode(false);
        }
    }
}
