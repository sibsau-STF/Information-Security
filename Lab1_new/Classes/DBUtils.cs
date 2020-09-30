using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    class DBUtils
    {
        private static MySqlConnection connection;
        //параметры подключения
        private static string host = "localhost";
        private static int port = 3306;
        private static string database = "infolab";
        private static string username = "root";
        private static string password = "root";

        //метод получения объекта подключения к бд
        public static MySqlConnection GetDBConnection()
        {
            string connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";CharSet=utf8";

            connection = new MySqlConnection(connString);

            return connection;
        }
        //метод получения объекта подключения к бд
        public static MySqlConnection GetDBConnection(string user,string pass)
        {
            string connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + user + ";password=" + pass + ";CharSet=utf8";

            connection = new MySqlConnection(connString);

            return connection;
        }

        public static MySqlDataReader GetAllUsersFromDB(MySqlConnection con, string user, string pass)
        {

            string sql = " SELECT * FROM USERS WHERE USERNAME!=@USERNAME AND PASSWORD!=@PASSWORD";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Parameters.Add("@USERNAME", MySqlDbType.VarChar).Value = user;
            cmd.Parameters.Add("@PASSWORD", MySqlDbType.VarChar).Value = pass;

            return cmd.ExecuteReader();
        }
        public static MySqlDataReader GetLastUserFromDB(MySqlConnection con)
        {

            string sql = " SELECT * FROM users ORDER BY iduser DESC LIMIT 1";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;

            return cmd.ExecuteReader();
        }
    }
}
