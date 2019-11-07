using Logic;
using Logic.Enums;
using Logic.LogicModel;
using Logic.Models;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
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

                OrderModel NewOrder = new OrderModel()
                {

                IdDevice = DeviceLogic.GetIdDevice(dt.Rows[DeviceList.SelectedIndex].ItemArray[0].ToString()),
                IdClient = SecurityContext.IdUser,
                DateOrder = DateTime.Today,
                ProblemDescription = ProblemDescription.Text,
                SelectedService = (Service.SelectedIndex + 1),
                StageOrder = 1

            };



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
