namespace gaimz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblGame
    {
        [Key]
        public int gameId { get; set; }

        [StringLength(50)]
        public string gameName { get; set; }

        [StringLength(255)]
        public string gameDesc { get; set; }

        [StringLength(50)]
        public string gameGenre { get; set; }
    }
}
