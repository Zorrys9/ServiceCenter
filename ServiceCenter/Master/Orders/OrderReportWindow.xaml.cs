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
using Logic;
using ServiceCenter.Master.Orders;
namespace ServiceCenter.Master.Orders
{
    /// <summary>
    /// Логика взаимодействия для OrderReportWindow.xaml
    /// </summary>
    public partial class OrderReportWindow : Window
    {
        public OrderReportWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            OrdersListWindow OrderList = new OrdersListWindow();
            OrderList.Show();
            this.Close();
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ReportOrderModel NewReport = new ReportOrderModel();

                NewReport.IdOrder = SecurityContext.IdOrder;
                NewReport.Description = Description.Text;
                NewReport.Sale = int.Parse(Sale.Text);

                ReportOrderLogic.SaveReport(NewReport);
                MessageBox.Show("Отчет о заказе успешно сохранен. Заказ успешно выполнен!");

                OrdersListWindow order = new OrdersListWindow();
                order.Show();
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
