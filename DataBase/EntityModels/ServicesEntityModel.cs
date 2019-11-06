namespace DataBase.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Services")]
    public class ServicesEntityModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServicesEntityModel()
        {
            Orders = new HashSet<OrdersEntityModel>();
        }

        [Key]
        public int IdService { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double? Sale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersEntityModel> Orders { get; set; }
    }
}
