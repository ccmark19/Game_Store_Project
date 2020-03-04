namespace gaimz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblWishlist
    {
        [Key]
        public int wishlistId { get; set; }

        public string userId { get; set; }

        public int? gameId { get; set; }
    }
}
