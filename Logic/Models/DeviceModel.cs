using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.EntityModels;

namespace Logic.Models
{
    public class DeviceModel
    {

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        public string DescriptionDevice { get; set; }

        public static explicit operator DeviceModel(DevicesEntityModel device)
        {

            return new DeviceModel
            {

                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                DescriptionDevice = device.DescriptionDevice

            };

        }

        public static implicit operator DevicesEntityModel(DeviceModel device)
        {

            return new DevicesEntityModel
            {

                Name = device.Name,
                Model = device.Model,
                Manufacturer = device.Manufacturer,
                DescriptionDevice = device.DescriptionDevice

            };

        }



    }
}
