using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.EntityModels;

namespace Logic.Models
{
    public class ReportOrderModel
    {

        public int IdReport { get; set; }

        public int IdOrder { get; set; }


        [StringLength(200)]
        public string Description { get; set; }

        public double Sale { get; set; }

        public static implicit operator ReportOrdersEntityModel(ReportOrderModel report)
        {
            return new ReportOrdersEntityModel
            {
                IdOrder = report.IdOrder,
                Description = report.Description,
                Sale = report.Sale
            };
        }

    }
}
