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

namespace ServiceCenter.Client
{
    /// <summary>
    /// Логика взаимодействия для ClientMainWindow.xaml
    /// </summary>
    public partial class ClientMainWindow : Window
    {
        public ClientMainWindow()
        {
            InitializeComponent();
            var InfoOrders = UserLogic.GetInfoOrders();
            QueueInfo.Content = $"В очереди : {InfoOrders.Item1}";
            WorkingInfo.Content = $"В разработке : {InfoOrders.Item2}";
            CompleteInfo.Content = $"Завершено : {InfoOrders.Item3}";

        }

        private void ExitUser_Click(object sender, RoutedEventArgs e)
        {

            UserLogic.ExitUser();
            LoginWindow authorization = new LoginWindow();
            authorization.Show();
            this.Close();


        }

        private void OrderList_Click(object sender, RoutedEventArgs e)
        {

            ListOrdersWindow listOrdersWindow = new ListOrdersWindow();
            listOrdersWindow.Show();
            this.Close();

        }
    }
}
