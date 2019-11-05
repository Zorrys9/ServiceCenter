using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.LogicModel
{
    public class ServiceLogic
    {

        public static List<string> GetService()
        {
            List<string> services = new List<string>();
            var ServiceList = DbContext.db.Services;
            foreach(var item in ServiceList)
            {
                services.Add(item.Name);
            }
            return services;
        }

        public static double? GetSaleService(int id)
        {
            return DbContext.db.Services.Where(s => s.IdService == id).FirstOrDefault().Sale;
        }
    }
}
