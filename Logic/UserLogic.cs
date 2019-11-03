using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using DataBase.EntityModels;
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

        }


    }
}
