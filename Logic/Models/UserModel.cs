using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.EntityModels;
namespace Logic.Models
{
    public class UserModel
    {

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [StringLength(12)]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int Rolle { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public static implicit operator UsersEntityModel(UserModel user)
        {
            return new UsersEntityModel()
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Address = user.Address,
                Telephone = user.Telephone,
                Login = user.Login,
                Password = user.Password,
                Rolle = user.Rolle

            };
        }

        public static explicit operator UserModel(UsersEntityModel user)
        {
            return new UserModel()
            { 

                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                Address = user.Address,
                Telephone = user.Telephone,
                Login = user.Login,
                Password = user.Password,
                Rolle = user.Rolle

            };
        }
    }
}
