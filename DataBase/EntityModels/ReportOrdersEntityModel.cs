namespace DataBase.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportOrders")]
    public class ReportOrdersEntityModel
    {
        [Key]
        public int IdReport { get; set; }

        public int IdOrder { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public double Sale { get; set; }

        public virtual UsersEntityModel Users { get; set; }

        public virtual UsersEntityModel Users1 { get; set; }
    }
}
