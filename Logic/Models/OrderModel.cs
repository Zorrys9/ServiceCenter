using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class OrderModel
    {

        public int IdClient { get; set; }

        public int IdDevice { get; set; }

        public int? IdMaster { get; set; }

        public int StageOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOrder { get; set; }

        [StringLength(200)]
        public string ProblemDescription { get; set; }

        public int SelectedService { get; set; }

    }
}
