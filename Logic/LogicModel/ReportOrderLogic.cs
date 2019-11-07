using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic.LogicModel
{
    public class ReportOrderLogic
    {

        public static void SaveReport(ReportOrderModel report)
        {

                DbContext.db.ReportOrders.Add(report);
                DbContext.db.Orders.Where(or => or.IdOrder == SecurityContext.IdOrder).FirstOrDefault().StageOrder = 3;
                DbContext.db.Orders.Create();
                DbContext.db.SaveChanges();
        }

    }
}
