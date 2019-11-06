using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using DataBase.EntityModels;
using System.Text.RegularExpressions;

namespace Logic.LogicModel
{
    public static class UserLogic
    {

        public static int Authorization(UserModel OldUser)
        {
            var CheckUser = DbContext.db.Users.Where(us => us.Login == OldUser.Login && us.Password == OldUser.Password);

            if (CheckUser.Count() > 0)
            {
                SecurityContext.IdUser = CheckUser.FirstOrDefault().Id;
                return CheckUser.FirstOrDefault().Rolle;
            }
            else throw new Exception("Логин или пароль введены неправильно! Проверьте правильность введенных вами данных и повторите попытку...");

        }

        public static void Registration(UserModel NewUser)
        {
                UsersEntityModel newUser = NewUser;
                newUser.Password = Verification(newUser.Password);
                if (DbContext.db.Users.Where(us => us.Login == newUser.Login).Count() == 0)
                {
                    DbContext.db.Users.Add(newUser);
                    DbContext.db.SaveChanges();
                }
                else throw new Exception("Данный логин уже используется, введите другой логин и продолжите регистрацию...");
        }

        static string Verification(string password)
        {
            if(password.Length >= 8)
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
            else throw new Exception("Пароль должен содержать минимум 8 символов!");
        }

        public static UserModel GetInfoUser()
        {

            return (UserModel)DbContext.db.Users.Where(us => us.Id == SecurityContext.IdUser).FirstOrDefault();
            
        }

        public static void ExitUser()
        {
            SecurityContext.IdUser = 0;
        }

        public static (int, int, int) GetInfoOrders() // выборка количества заказов для текущего пользователя для вывода на главной странице пользователя
        {
            var InfoQueue = DbContext.db.Orders.Where(or => or.IdClient == SecurityContext.IdUser && or.StageOrder == 1);   // Все заказы в стадии "В очереди"
            var InfoWorking = DbContext.db.Orders.Where(or => or.IdClient == SecurityContext.IdUser && or.StageOrder == 2); // Все заказы в стадии "В разработке"
            var InfoComplete = DbContext.db.Orders.Where(or => or.IdClient == SecurityContext.IdUser && or.StageOrder == 3);// Все заказы в стадии "Выполнено"
            return (InfoQueue.Count(), InfoWorking.Count(), InfoComplete.Count());
        }
    }
}
