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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic.Models;
using Logic.LogicModel;
using ServiceCenter.Client;
using ServiceCenter.Master;

namespace ServiceCenter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                UserModel OldUser = new UserModel();
                OldUser.Login = Login.Text;
                OldUser.Password = Password.Text;

                switch (UserLogic.Authorization(OldUser))
                {

                    case 1:
                        ClientMainWindow client = new ClientMainWindow();
                        client.Show();
                        this.Close();
                        break;

                    case 2:
                        MasterMainWindow master = new MasterMainWindow();
                        master.Show();
                        this.Close();
                        break;

                }
                

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }



        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
