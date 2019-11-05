using System;
using System.Collections.Generic;
using System.Data;
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
using Logic;
using Logic.Enums;
namespace ServiceCenter.Master.Devices
{
    /// <summary>
    /// Логика взаимодействия для DeviceListWindow.xaml
    /// </summary>
    public partial class DeviceListWindow : Window
    {
        DataTable dt = new DataTable();
        public DeviceListWindow()
        {
            try
            {

                InitializeComponent();
                dt = DeviceLogic.GetDeviceList(DeviceEnum.None, "");
                DeviceList.ItemsSource = dt.DefaultView;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            MasterMainWindow master = new MasterMainWindow();
            master.Show();
            this.Close();

        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            DeviceAdd device = new DeviceAdd();
            device.Show();
            this.Close();
        }

        private void DeviceList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                if (DeviceList.SelectedCells.Count() != 0)
                {

                    SecurityContext.NameDevice = dt.Rows[DeviceList.SelectedIndex].ItemArray[0].ToString();

                    DeviceView device = new DeviceView();
                    device.Show();
                    this.Close();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void FilterName_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void FilterName_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                dt.Clear();
                DeviceEnum deviceEnum = DeviceEnum.None;
                switch (FilterItem.Text)
                {
                    case "Названию":
                        deviceEnum = DeviceEnum.Name;
                        break;
                    case "Модели":
                        deviceEnum = DeviceEnum.Model;
                        break;
                    case "Производителю":
                        deviceEnum = DeviceEnum.Manufacturer;
                        break;
                }

                string FilterText = FilterName.Text;
                if (FilterText == "")
                    deviceEnum = DeviceEnum.None;

                dt = DeviceLogic.GetDeviceList(deviceEnum, FilterText);
                DeviceList.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ExitAccount_Click(object sender, RoutedEventArgs e)
        {
            UserLogic.ExitUser();
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
