namespace DataBase.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Orders")]
    public class OrdersEntityModel
    {
        [Key]
        public int IdOrder { get; set; }

        public int IdClient { get; set; }

        public int IdDevice { get; set; }

        public int? IdMaster { get; set; }

        public int StageOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOrder { get; set; }

        [Required]
        [StringLength(200)]
        public string ProblemDescription { get; set; }

        public int SelectedService { get; set; }

        public virtual DevicesEntityModel Devices { get; set; }

        public virtual ServicesEntityModel Services { get; set; }

        public virtual StagesEntityModel Stages { get; set; }

        public virtual UsersEntityModel Users { get; set; }

        public virtual UsersEntityModel Users1 { get; set; }
    }
}
