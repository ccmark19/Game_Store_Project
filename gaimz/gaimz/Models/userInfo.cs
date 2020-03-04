namespace gaimz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userInfo")]
    public partial class userInfo
    {
        [Key]
        public int infoID { get; set; }

        [StringLength(50)]
        public string userId { get; set; }

        [StringLength(50)]
        public string favPlatform { get; set; }

        [StringLength(50)]
        public string favCategory { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string postCode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public bool wantEmail { get; set; }
    }
}
