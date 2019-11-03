namespace DataBase.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportOrders
    {
        [Key]
        public int IdReport { get; set; }

        public int IdMaster { get; set; }

        public int IdClient { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public double Sale { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
