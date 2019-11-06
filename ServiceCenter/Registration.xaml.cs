﻿using System;
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
namespace ServiceCenter
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserModel NewUser = new UserModel()
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Patronymic = Patronymic.Text,
                    Login = Login.Text,
                    Address = Address.Text,
                    Telephone = Telephone.Text,
                    Rolle = 1
                };

                if (Password.Text == RetryPassword.Text)
                    NewUser.Password = Password.Text;
                else throw new Exception("Пароли не совпадают!");

                UserLogic.Registration(NewUser);
                MessageBox.Show("Регистрация успешно завершена!!!");

                LoginWindow authorization = new LoginWindow();
                authorization.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Telephone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
