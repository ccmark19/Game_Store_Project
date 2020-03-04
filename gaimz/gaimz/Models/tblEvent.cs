namespace gaimz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblEvent")]
    public partial class tblEvent
    {
        [Key]
        public int eventID { get; set; }

        [StringLength(50)]
        public string eventDesc { get; set; }
    }
}
