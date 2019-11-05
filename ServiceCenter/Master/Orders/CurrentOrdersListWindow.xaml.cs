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
namespace ServiceCenter.Master.Orders
{
    /// <summary>
    /// Логика взаимодействия для OrdersListWindow.xaml
    /// </summary>
    public partial class OrdersListWindow : Window
    {
        DataTable dt = new DataTable();
        public OrdersListWindow()
        {
            InitializeComponent();
            dt = OrderLogic.GetCurrentOrderListToMaster();
            OrderList.ItemsSource = dt.DefaultView;
        }

        private void ExitAccount_Click(object sender, RoutedEventArgs e)
        {

            UserLogic.ExitUser();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            MasterMainWindow master = new MasterMainWindow();
            master.Show();
            this.Close();

        }

        private void OrderList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (OrderList.SelectedCells.Count > 0)
                {
                    MessageBoxResult message = MessageBox.Show("Вы уверены, что хотите завершить этот заказ?", "Подтверждение заказа", MessageBoxButton.YesNo);
                    if(message == MessageBoxResult.Yes)
                    {
                        SecurityContext.IdOrder = Convert.ToInt32(dt.Rows[OrderList.SelectedIndex].ItemArray[0]);
                        MessageBox.Show("Для завершения заказа необходимо заполнить отчет о проделанной работе");
                        OrderReportWindow orderReport = new OrderReportWindow();
                        orderReport.Show();
                        this.Close();
     
                    }
                    

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

    }
}
