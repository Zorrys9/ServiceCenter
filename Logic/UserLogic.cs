using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using DataBase.EntityModels;
using System.Text.RegularExpressions;

namespace Logic
{
    public static class UserLogic
    {

        public static int Authorization(UserModel OldUser)
        {
            var CheckUser = DbContext.db.Users.Where(us => us.Login == OldUser.Login && us.Password == OldUser.Password);

            if (CheckUser.Count() > 0)
            {
                return CheckUser.FirstOrDefault().Rolle;
            }
            else throw new Exception("Логин или пароль введены неправильно! Проверьте правильность введенных вами данных и повторите попытку...");

        }

        public static void Registration(UserModel NewUser)
        {
            try
            {

                Users newUser = new Users();
                newUser.FirstName = NewUser.FirstName;
                newUser.LastName = NewUser.LastName;
                newUser.Patronymic = NewUser.Patronymic;
                newUser.Telephone = NewUser.Telephone;
                newUser.Address = NewUser.Address;
                newUser.Login = NewUser.Login;
                newUser.Password = Verification(NewUser.Password);
                newUser.Rolle = 1;

                DbContext.db.Users.Add(newUser);
                DbContext.db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("При регистрации возникла ошибка! " + ex.Message);
            }

        }

        static string Verification(string password)
        {
            var regex = new Regex(@"(.*[a-z])");
            if (regex.IsMatch(password))
            {   
                regex = new Regex(@"(.*[A-Z])");
                if (regex.IsMatch(password))
                {
                    regex = new Regex(@"(.*[!,@,#,$,%,^,&,*,(,),+,_,-,=,?,№,;])");
                    if (regex.IsMatch(password))
                    {
                        return password;
                    }
                    else throw new Exception("Пароль должен содержать спецсимволы : \n !,@,#,$,%,^,&,*,(,),+,_,-,=,?,№,; ");
                }
                else throw new Exception("Пароль должен содержать прописные символы!");
            }
            else throw new Exception("Пароль должен содержать строчные символы!");
        }

    }
}
