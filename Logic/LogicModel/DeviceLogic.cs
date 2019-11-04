using DataBase.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using System.Data;

namespace Logic.LogicModel
{
    public class DeviceLogic
    {

        public static DataTable GetDeviceList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Название");
            dt.Columns.Add("Модель");
            dt.Columns.Add("Производитель");
            dt.Columns.Add("Описание");

            var DevicesList = DbContext.db.Devices;
            foreach(var item in DevicesList)
            {
                dt.Rows.Add(item.Name, item.Model, item.Manufacturer, item.DescriptionDevice); // можно было бы через DbContext.db.Devices.ToList  DataGrid заполнить, но для того, что я хочу нужен DataTable, по другому не понял как сделать(
            }

            return dt;
        }

        public static void RegistrationDevice(DeviceModel NewDevice)
        {
            if (DbContext.db.Devices.Where(dev => dev.Name == NewDevice.Name).Count() == 0)
            {

                DbContext.db.Devices.Add(NewDevice);
                DbContext.db.SaveChanges();

            }
            else throw new Exception("Данное устройство уже существует!");

        }

        public static DeviceModel GetViewDevice()
        {

            return (DeviceModel)DbContext.db.Devices.Where(dev => dev.Name == SecurityContext.NameDevice).FirstOrDefault();
                
        }

        public static void DeleteDevice()
        {
            var DeleteDevice = DbContext.db.Devices.Single(dev => dev.Name == SecurityContext.NameDevice);
            DbContext.db.Devices.Remove(DeleteDevice);
            DbContext.db.SaveChanges();
            SecurityContext.NameDevice = "";
        }

        public static void ChangeDevice(DeviceModel device)
        {
            if (DbContext.db.Devices.Where(dev => dev.Name == device.Name).Count() == 0)
            {
                var ChangeDevice = DbContext.db.Devices.Where(dev => dev.Name == SecurityContext.NameDevice);
                ChangeDevice.FirstOrDefault().Name = device.Name;
                DbContext.db.Devices.Create();
                DbContext.db.SaveChanges();
                SecurityContext.NameDevice = "";
            }
            else throw new Exception("Данное устройство уже существует!");
        }


    }
}
