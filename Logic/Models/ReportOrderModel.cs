using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ReportOrderModel
    {

        public int IdReport { get; set; }

        public int IdOrder { get; set; }


        [StringLength(200)]
        public string Description { get; set; }

        public double Sale { get; set; }

    }
}
