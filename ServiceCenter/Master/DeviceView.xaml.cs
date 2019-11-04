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


namespace ServiceCenter.Master
{
    /// <summary>
    /// Логика взаимодействия для Device.xaml
    /// </summary>
    public partial class DeviceView : Window
    {
        public DeviceView()
        {
            InitializeComponent();

            try
            {
                DeviceModel device = DeviceLogic.GetViewDevice();

                NameDevice.Text = device.Name;
                ModelDevice.Text = device.Model;
                ManufacturerDevice.Text = device.Manufacturer;
                DescriptionDevice.Text = device.DescriptionDevice;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DeleteDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MessageBoxResult messageResult = MessageBox.Show("Вы уверены, что хотите удалить это устройство?", "Удаление устройства", MessageBoxButton.YesNo);
                if (messageResult == MessageBoxResult.Yes)
                {

                    DeviceLogic.DeleteDevice();
                    MessageBox.Show("Устройство успешно удалено!");
                    DeviceListWindow deviceList = new DeviceListWindow();
                    deviceList.Show();
                    this.Close();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void ChangeDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DeviceModel ChangeDevice = new DeviceModel
                {

                    Name = NameDevice.Text,
                    Model = ModelDevice.Text,
                    Manufacturer = ManufacturerDevice.Text,
                    DescriptionDevice = DescriptionDevice.Text

                };
                DeviceLogic.ChangeDevice(ChangeDevice);
                MessageBox.Show("Информация об устройсте успешно изменена");
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
