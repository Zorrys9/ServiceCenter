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
using Logic.Models;
using Logic.LogicModel;
using System.Data;

namespace ServiceCenter.Client
{
    /// <summary>
    /// Логика взаимодействия для ListOrdersWindow.xaml
    /// </summary>
    public partial class ListOrdersWindow : Window
    {
        DataTable dt = new DataTable();
        public ListOrdersWindow()
        {

                InitializeComponent();
                dt = OrderLogic.GetOrderList();
                OrderList.ItemsSource = dt.DefaultView;





        }

        private void ExitAccount_Click(object sender, RoutedEventArgs e)
        {

            UserLogic.ExitUser();
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ClientMainWindow client = new ClientMainWindow();
            client.Show();
            this.Close();
        }
    }
}
