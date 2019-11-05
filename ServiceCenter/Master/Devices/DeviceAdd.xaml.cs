using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic.LogicModel;
using Logic.Models;


namespace ServiceCenter.Master.Devices
{
    /// <summary>
    /// Логика взаимодействия для Device.xaml
    /// </summary>
    public partial class DeviceAdd : Window
    {
        public DeviceAdd()
        {
            InitializeComponent();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DeviceModel NewDevice = new DeviceModel
                {

                    Name = NameDevice.Text,
                    Model = ModelDevice.Text,
                    Manufacturer = ManufacturerDevice.Text,
                    DescriptionDevice = DescriptionDevice.Text

                };
                DeviceLogic.RegistrationDevice(NewDevice);
                MessageBox.Show("Устройство успешно добавлено!");

                DeviceListWindow deviceList = new DeviceListWindow();
                deviceList.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
