using Logic.Models;
using System.Data;
using System.Linq;
using Logic.ViewModel;

namespace Logic.LogicModel
{
    public class OrderLogic
    {
        // Выборка из кууучи таблиц, чтобы показать всю информацию о заказах текущего пользователя(клиента)
        public static DataTable GetOrderListToClient()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("№");
            //dt.Columns.Add("Клиент");
            //dt.Columns.Add("Мастер");
            dt.Columns.Add("Устройство");
            dt.Columns.Add("Стадия");
            dt.Columns.Add("Дата заказа");
            dt.Columns.Add("Описание проблемы");
            dt.Columns.Add("Услуга");

            var OrderInfo = from order in DbContext.db.Orders
                            join client in DbContext.db.Users on order.IdClient equals client.Id
                            where client.Rolle == 1 && client.Id == SecurityContext.IdUser
                            //join master in DbContext.db.Users on order.IdMaster equals master.Id
                            join device in DbContext.db.Devices on order.IdDevice equals device.IdDevice
                            join stage in DbContext.db.Stages on order.StageOrder equals stage.IdStage
                            join service in DbContext.db.Services on order.SelectedService equals service.IdService
                            select new
                            {
                                Id = order.IdOrder,
                                //  Client = client.FirstName + "." + client.LastName.Substring(0, 1) + "." + client.Patronymic.Substring(0,1),
                                //  Master = master.FirstName + "." + master.LastName.Substring(0, 1) + "." + master.Patronymic.Substring(0,1),
                                Device = device.Name,
                                Stage = stage.Name,
                                Date = order.DateOrder,
                                Description = order.ProblemDescription,
                                Service = service.Name

                            };

            foreach (var item in OrderInfo)
            {
                dt.Rows.Add(item.Id, item.Device, item.Stage, item.Date, item.Description, item.Service);
            }

            return dt;
        }
        // Выбирает все заказы текущего мастера
        public static DataTable GetCurrentOrderListToMaster()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("№");
            dt.Columns.Add("Клиент");
            //  dt.Columns.Add("Мастер");
            dt.Columns.Add("Устройство");
            dt.Columns.Add("Стадия");
            dt.Columns.Add("Дата заказа");
            dt.Columns.Add("Описание проблемы");
            dt.Columns.Add("Услуга");

            var OrderInfo = from order in DbContext.db.Orders
                            join client in DbContext.db.Users on order.IdClient equals client.Id
                            where client.Rolle == 1 && order.IdMaster == SecurityContext.IdUser
                            // join master in DbContext.db.Users on order.IdMaster equals master.Id 
                            join device in DbContext.db.Devices on order.IdDevice equals device.IdDevice
                            join stage in DbContext.db.Stages on order.StageOrder equals stage.IdStage
                            join service in DbContext.db.Services on order.SelectedService equals service.IdService
                            select new
                            {
                                Id = order.IdOrder,
                                Client = client.FirstName + "." + client.LastName.Substring(0, 1) + "." + client.Patronymic.Substring(0, 1),
                                // Master = master.FirstName + "." + master.LastName.Substring(0, 1) + "." + master.Patronymic.Substring(0,1),
                                Device = device.Name,
                                Stage = stage.Name,
                                Date = order.DateOrder,
                                Description = order.ProblemDescription,
                                Service = service.Name

                            };

            foreach (var item in OrderInfo)
            {
                dt.Rows.Add(item.Id, item.Client, item.Device, item.Stage, item.Date, item.Description, item.Service);
            }

            return dt;
        }
        // Выбирает все доступные заказы, одинаковые для любого работника
        public static DataTable GetAvailableOrderListToMaster()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("№");
            dt.Columns.Add("Клиент");
            //  dt.Columns.Add("Мастер");
            dt.Columns.Add("Устройство");
            dt.Columns.Add("Стадия");
            dt.Columns.Add("Дата заказа");
            dt.Columns.Add("Описание проблемы");
            dt.Columns.Add("Услуга");

            var OrderInfo = from order in DbContext.db.Orders
                            join client in DbContext.db.Users on order.IdClient equals client.Id
                            where client.Rolle == 1 && order.IdMaster == null
                            // join master in DbContext.db.Users on order.IdMaster equals master.Id 
                            join device in DbContext.db.Devices on order.IdDevice equals device.IdDevice
                            join stage in DbContext.db.Stages on order.StageOrder equals stage.IdStage
                            join service in DbContext.db.Services on order.SelectedService equals service.IdService
                            select new
                            {
                                Id = order.IdOrder,
                                Client = client.FirstName + "." + client.LastName.Substring(0, 1) + "." + client.Patronymic.Substring(0, 1),
                                // Master = master.FirstName + "." + master.LastName.Substring(0, 1) + "." + master.Patronymic.Substring(0,1),
                                Device = device.Name,
                                Stage = stage.Name,
                                Date = order.DateOrder,
                                Description = order.ProblemDescription,
                                Service = service.Name

                            };

            foreach (var item in OrderInfo)
            {
                dt.Rows.Add(item.Id, item.Client, item.Device, item.Stage, item.Date, item.Description, item.Service);
            }

            return dt;
        }
        public static OrderViewModel GetViewOrder()
        {

            var OrderInfo = from order in DbContext.db.Orders where order.IdOrder == SecurityContext.IdOrder
                            join device in DbContext.db.Devices on order.IdDevice equals device.IdDevice
                            join stage in DbContext.db.Stages on order.StageOrder equals stage.IdStage
                            join service in DbContext.db.Services on order.SelectedService equals service.IdService
                            select new
                            {
                                Id = order.IdOrder,
                                Device = device.Name,
                                Stage = stage.Name,
                                Date = order.DateOrder,
                                Description = order.ProblemDescription,
                                Service = service.Name

                            };


            return new OrderViewModel
            {

                Description = OrderInfo.FirstOrDefault().Description,
                StageName = OrderInfo.FirstOrDefault().Stage,
                ServiceName = OrderInfo.FirstOrDefault().Service,
                DeviceName = OrderInfo.FirstOrDefault().Device
                
            };
        }

        public static void SaveOrder(OrderModel newOrder)
        {

            DbContext.db.Orders.Add(newOrder);
            DbContext.db.SaveChanges();
        }

        public static void SelectOrder(OrderModel order)
        {

            var CurrentOrder = DbContext.db.Orders.Where(or => or.IdOrder == order.IdOrder).FirstOrDefault();
            CurrentOrder.IdMaster = SecurityContext.IdUser;
            CurrentOrder.StageOrder = 2;
            DbContext.db.Orders.Create();
            DbContext.db.SaveChanges();

        }

    }
}
