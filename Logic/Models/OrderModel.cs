using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.EntityModels;
namespace Logic.Models
{
    public class OrderModel
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }

        public int IdDevice { get; set; }

        public int? IdMaster { get; set; }

        public int StageOrder { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOrder { get; set; }

        [StringLength(200)]
        public string ProblemDescription { get; set; }

        public int SelectedService { get; set; }


        public static implicit operator OrdersEntityModel(OrderModel order)
        {
            return new OrdersEntityModel
            {
                DateOrder = order.DateOrder,
                IdClient = order.IdClient,
                IdDevice = order.IdDevice,
                IdMaster = order.IdMaster,
                StageOrder = order.StageOrder,
                ProblemDescription = order.ProblemDescription,
                SelectedService = order.SelectedService
            };
        }

    }
}
