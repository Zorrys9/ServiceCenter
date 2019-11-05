using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.LogicModel
{
    public class OrderLogic
    {

        public static DataTable GetOrderList()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Клиент");
            dt.Columns.Add("Мастер");
            dt.Columns.Add("Устройство");
            dt.Columns.Add("Стадия");
            dt.Columns.Add("Дата заказа");
            dt.Columns.Add("Описание проблемы");
            dt.Columns.Add("Услуга");

            var OrderInfo = from order in DbContext.db.Orders
                            join client in DbContext.db.Users on order.IdClient equals client.Id where client.Rolle == 1 && client.Id == SecurityContext.IdUser
                            join master in DbContext.db.Users on order.IdMaster equals master.Id where master.Rolle == 2 
                            join device in DbContext.db.Devices on order.IdDevice equals device.IdDevice
                            join stage in DbContext.db.Stages on order.StageOrder equals stage.IdStage
                            join service in DbContext.db.Services on order.SelectedService equals service.IdService
                            select new
                            {
                                Client = client.FirstName + "." + client.LastName.Substring(0, 1) + "." + client.Patronymic.Substring(0,1),
                                Master = master.FirstName + "." + master.LastName.Substring(0, 1) + "." + master.Patronymic.Substring(0,1),
                                Device = device.Name,
                                Stage = stage.Name,
                                Date = order.DateOrder,
                                Description = order.ProblemDescription,
                                Service = service.Name

                            };

            foreach(var item in OrderInfo)
            {
                dt.Rows.Add(item.Client, item.Master, item.Device, item.Stage, item.Date, item.Description, item.Service);
            }

            return dt;
        }

    }
}
