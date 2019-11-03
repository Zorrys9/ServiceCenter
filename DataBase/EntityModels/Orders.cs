namespace DataBase.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
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

        public virtual Devices Devices { get; set; }

        public virtual Services Services { get; set; }

        public virtual Stages Stages { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
