namespace gaimz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblReview")]
    public partial class tblReview
    {
        [Key]
        public int reviewID { get; set; }

        public int gameID { get; set; }

        [Required]
        [StringLength(50)]
        public string userID { get; set; }

        [StringLength(500)]
        public string review { get; set; }

        public decimal? rating { get; set; }

        [StringLength(50)]
        public string gameName { get; set; }
    }
}
