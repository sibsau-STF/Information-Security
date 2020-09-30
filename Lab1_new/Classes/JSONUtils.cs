using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lab_1
{
    class JSONUtils
    {
        static User admin = new User();


        public static List<User> GetAllUsersFromJSON()
        {
            List<User> userList = new List<User>();
            string json = "";
            // чтение данных, десериализация json
            try
            {
                if (File.Exists("users.json"))
                {
                    using (StreamReader fs = new StreamReader("users.json"))
                    {
                        json = fs.ReadToEnd();
                        userList = JsonConvert.DeserializeObject<List<User>>(json);
                    }
                }
                else
                {
                    SetAdmin();
                    userList = GetAllUsersFromJSON();
                }
            }
            catch(Exception ex)
            {
                userList.Add(JsonConvert.DeserializeObject<User>(json));
            }
            return userList;
        }

        public static void SetAdmin()
        {
            FileStream fs = new FileStream("users.json", FileMode.Create);
            using (StreamWriter s = new StreamWriter(fs))
            {
                s.Write(JsonConvert.SerializeObject(admin));
            }
            
            fs.Close();
        }
        public static User GetLastUserFromJSON()
        {
            List<User> userList = new List<User>();
            using (StreamReader fs = new StreamReader("users.json"))
            {
                string json = fs.ReadToEnd();
                userList = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return userList.Last();
        }
    }
}
