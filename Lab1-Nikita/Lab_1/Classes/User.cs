using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class User
    {
        //Guid id;
        public string username { get; set; }
        public string password { get; set; }

        public string group { get; set; }
        public bool activity { get; set; }
        public bool constraint { get; set; }

        //конструктор для админа
        public User()
        {
           // id = Guid.NewGuid();
            username = "admin";
            password = "admin";

            group = "Администратор";
            activity = false;           //не заблокирован
            constraint = false;         //не ограничен
        }

        public User(string username, string group)
        {
            //this.id = Guid.NewGuid();
            this.username = username;
            this.password = "";
            this.group = group;
            this.activity = false;
            this.constraint = false;
        }
    }
}
