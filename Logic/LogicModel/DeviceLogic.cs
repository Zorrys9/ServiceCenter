using DataBase.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using System.Data;
using Logic.Enums;
using System.Data.Entity;

namespace Logic.LogicModel
{
    public class DeviceLogic
    {

        public static DataTable GetDeviceList(DeviceEnum deviceEnum, string filter)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Название");
            dt.Columns.Add("Модель");
            dt.Columns.Add("Производитель");
            dt.Columns.Add("Описание");
            
            switch (deviceEnum)
            {
                case DeviceEnum.None:
                    var DevicesList = DbContext.db.Devices;

                    foreach (var item in DevicesList)
                    {
                        dt.Rows.Add(item.Name, item.Model, item.Manufacturer, item.DescriptionDevice); 
                    }

                      return dt;
                case DeviceEnum.Name:
                    var DevicesList2 = DbContext.db.Devices.Where(dev => dev.Name == filter);

                    foreach (var item in DevicesList2)
                    {
                        dt.Rows.Add(item.Name, item.Model, item.Manufacturer, item.DescriptionDevice);
                    }

                    break;
                case DeviceEnum.Model:
                    var DevicesList3 = DbContext.db.Devices.Where(dev => dev.Model == filter);

                    foreach (var item in DevicesList3)
                    {
                        dt.Rows.Add(item.Name, item.Model, item.Manufacturer, item.DescriptionDevice);
                    }

                    break;
                case DeviceEnum.Manufacturer:
                    var DevicesList4= DbContext.db.Devices.Where(dev => dev.Manufacturer == filter);

                    foreach (var item in DevicesList4)
                    {
                    }

                    break;
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
