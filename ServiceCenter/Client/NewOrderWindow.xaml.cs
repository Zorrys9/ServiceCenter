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
using Logic.Enums;
using Logic;
namespace ServiceCenter.Client
{
    /// <summary>
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        DataTable dt = new DataTable();
        public NewOrderWindow()
        {
            InitializeComponent();
            dt = DeviceLogic.GetDeviceList(DeviceEnum.None, "");
            DeviceList.ItemsSource = dt.DefaultView;
            Service.ItemsSource = ServiceLogic.GetService();
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                OrderModel NewOrder = new OrderModel();

                NewOrder.IdDevice = DeviceLogic.GetIdDevice(dt.Rows[DeviceList.SelectedIndex].ItemArray[0].ToString());
                NewOrder.IdClient = SecurityContext.IdUser;
                NewOrder.DateOrder = DateTime.Today;
                NewOrder.ProblemDescription = ProblemDescription.Text;
                NewOrder.SelectedService = (Service.SelectedIndex + 1);
                NewOrder.StageOrder = 1;

                OrderLogic.SaveOrder(NewOrder);
                MessageBox.Show("Заказ успешно оформлен");

                ListOrdersWindow listOrdersWindow = new ListOrdersWindow();
                listOrdersWindow.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Service_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sale.Content = $"Первоначальная стоимость услуги\n(Без учета затрат материалов)\nсоставляет : {ServiceLogic.GetSaleService(Service.SelectedIndex + 1)} рублей";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ListOrdersWindow listOrdersWindow = new ListOrdersWindow();
            listOrdersWindow.Show();
            this.Close();
        }
    }
}
