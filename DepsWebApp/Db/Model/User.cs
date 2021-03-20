using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DepsWebApp.Db.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Hash_Password { get; set; }

        public User(string login, string hashPassword)
        {
            Login = login;
            Hash_Password = hashPassword;
        }

        public User()
        {
        }
    }
}
