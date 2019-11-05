using Logic;
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
using ServiceCenter.Master.Devices;
using ServiceCenter.Master.Orders;
namespace ServiceCenter.Master
{
    /// <summary>
    /// Логика взаимодействия для MasterMainWindow.xaml
    /// </summary>
    public partial class MasterMainWindow : Window
    {
        public MasterMainWindow()
        {
            InitializeComponent();
        }

        private void ExitUser_Click(object sender, RoutedEventArgs e)
        {

            UserLogic.ExitUser();
            LoginWindow authorization = new LoginWindow();
            authorization.Show();
            this.Close();

        }

        private void DeviceList_Click(object sender, RoutedEventArgs e)
        {
            DeviceListWindow deviceList = new DeviceListWindow();
            deviceList.Show();
            this.Close();
        }

        private void OrdersList_Click(object sender, RoutedEventArgs e)
        {
            AvailableOrderList availableOrder = new AvailableOrderList();
            availableOrder.Show();
            this.Close();
        }

        private void OrdersCurrentList_Click(object sender, RoutedEventArgs e)
        {
            OrdersListWindow orderList = new OrdersListWindow();
            orderList.Show();
            this.Close();
        }
    }
}
