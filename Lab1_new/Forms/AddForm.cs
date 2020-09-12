using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class AddForm : Form
    {
        Base flag;
        Form1 mainForm;
        private MySqlConnection connection;
        public Dictionary<int, string> userGroups { get; set; }
        private List<User> users;

        public AddForm(MySqlConnection con, Base f, ref List<User> users)
        {
            InitializeComponent();

            userGroups = new Dictionary<int, string>();
            connection = con;
            flag = f;
            this.users = users;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (flag == Base.BD)
            {

            }
            else
            {
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (flag == Base.BD)
            {
                string sql = "SELECT * FROM groups";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                if (userGroups.Count <= 0 || groupComboBox.Items.Count <= 0)
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            userGroups.Add(reader.GetInt16(0), reader.GetString(1));
                            groupComboBox.Items.Add(reader.GetString(1));

                        }
                    }
                }
            }
            else
            {
                userGroups.Add(1, "Администратор"); userGroups.Add(2, "Пользователь");
                groupComboBox.Items.AddRange(new string[] { "Администратор", "Пользователь" });
            }
        }
    }
}
