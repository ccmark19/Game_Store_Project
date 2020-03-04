namespace gaimz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_event
    {
        [Key]
        public int user_event_ID { get; set; }

        [StringLength(10)]
        public string userId { get; set; }

        public int? eventID { get; set; }
    }
}
