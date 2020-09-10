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
    public enum Base
    {
        BD = 1,
        JSON = 2
    }

    public partial class Form1 : Form
    {
        Base flag = Base.JSON;
        public List<User> users = new List<User>();

        private MySqlConnection connection = new MySqlConnection();

        private string username;
        private string password;
        private string group;

        string constraints = @"0123456789/*-+=";

        public Form1()
        {
            InitializeComponent();

            connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            username = "";
            password = "";
            users = new List<User>();
        }

        private void LoadUsers()
        {
            if (flag == Base.BD)
            {
                using (MySqlDataReader reader = DBUtils.GetAllUsersFromDB(connection, username, password))
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        bool isLock = reader.GetInt16(4) == 1 ? true : false;
                        bool isConstraint = reader.GetInt16(5) == 1 ? true : false;
                        userDataGridView.Rows.Add(reader.GetInt16(0), reader.GetString(1), reader.GetString(2));
                        userDataGridView[3, i].Value = isLock;
                        userDataGridView[4, i].Value = isConstraint;
                        i++;
                    }

                }
            }
            else
            {
                users = JSONUtils.GetAllUsersFromJSON();
                int i = 0;
                foreach (var u in users)
                {
                    userDataGridView.Rows.Add(i, u.username, u.password);
                    userDataGridView[3, i].Value = u.constraint;
                    userDataGridView[4, i].Value = u.activity;
                    i++;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (flag == Base.BD)
            {
                AuthForm authForm = new AuthForm(this);
                bool isCorrect = false;
                while (!isCorrect)
                {
                    if (authForm.ShowDialog() == DialogResult.OK)
                    {

                        isCorrect = true;
                        username = authForm.Username;
                        password = authForm.Password;

                        string sql = "SELECT * FROM USERS WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD";
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.CommandText = sql;
                        cmd.Connection = connection;
                        cmd.Parameters.Add("@USERNAME", MySqlDbType.VarChar).Value = username;
                        cmd.Parameters.Add("@PASSWORD", MySqlDbType.VarChar).Value = password;
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                group = reader.GetString(3);
                                if (reader.GetInt16(5) == 1)
                                {
                                    MessageBox.Show("Отказано в доступе!", "Ошибка", MessageBoxButtons.OK);
                                    isCorrect = false;
                                    reader.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверно указаны имя или пароль!", "Ошибка", MessageBoxButtons.OK);
                                isCorrect = false;
                                reader.Close();
                            }
                        }
                        if (isCorrect) break;
                    }
                    else break;
                }
                if(isCorrect) LoadUsers();
            }
            else if (flag == Base.JSON)
            {
                AuthForm authForm = new AuthForm(this);
                bool isCorrect = false;
                int falseCount = 0;

                while (!isCorrect)
                {
                    if (falseCount >= 3)
                    {
                        authForm.Close();
                        this.Close();
                        break;
                    }
                    if (authForm.ShowDialog() == DialogResult.OK)
                    {

                        isCorrect = true;
                        username = authForm.Username;
                        password = authForm.Password;
                        List<User> users = JSONUtils.GetAllUsersFromJSON();
                        User user = users.FirstOrDefault(x => x.username == username && x.password == password);

                        if (user != null)
                        {
                            group = user.group;

                            if (user.activity == true)
                            {
                                MessageBox.Show("Отказано в доступе!", "Ошибка", MessageBoxButtons.OK);
                                isCorrect = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверно указаны имя или пароль!", "Ошибка", MessageBoxButtons.OK);
                            isCorrect = false;
                            falseCount++;
                        }
                        if (isCorrect) break;
                    }
                    else
                    {
                        Close();
                        break;
                        
                    }
                }
                if (isCorrect)
                {
                    LoadUsers();
                    if (password == "")
                    {
                        UpdatePassForm updateForm = new UpdatePassForm(users.Find(x => x.username == username));
                        while (true)
                        {
                            if (updateForm.ShowDialog() == DialogResult.OK)
                            {

                                //введенный пароль правильныый
                                if (updateForm.oldPassTextBox.Text == updateForm.user.password)
                                {
                                    if (updateForm.newPassTextBox.Text == updateForm.confirmPassTextBox.Text)
                                    {
                                        if (updateForm.user.constraint == true)
                                        {
                                            string constraints = "0123456789+-*/ ";
                                            foreach (char c in updateForm.newPassTextBox.Text)
                                            {
                                                //если символ входит в ограниечение, то ошибка
                                                if (constraints.ToCharArray().ToList().IndexOf(c) != -1)
                                                {
                                                    MessageBox.Show("Пароль содержит недопустимые символы!");
                                                }
                                                else
                                                {
                                                    updateForm.user.password = updateForm.newPassTextBox.Text;
                                                    users.Find(x => x.username == updateForm.user.username).password = updateForm.user.password;
                                                    using (StreamWriter s = new StreamWriter("users.json"))
                                                    {
                                                        s.Write(JsonConvert.SerializeObject(users));
                                                    }

                                                    userDataGridView.SelectedRows[0].Cells[2].Value = users.Find(x => x.username == updateForm.user.username).password;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            updateForm.user.password = updateForm.newPassTextBox.Text;
                                            users.Find(x => x.username == updateForm.user.username).password = updateForm.user.password;
                                            using (StreamWriter s = new StreamWriter("users.json"))
                                            {
                                                s.Write(JsonConvert.SerializeObject(users));
                                            }

                                            userDataGridView.SelectedRows[0].Cells[2].Value = users.Find(x => x.username == updateForm.user.username).password;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пароли не совпадают!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Введен неверный пароль!");
                                }

                            }
                        }
                    }
                    else
                    {
                        if(username != "admin")
                        {
                            addUserStripButton.Visible = false;
                            userDataGridView.Visible = false;
                            LockStripButton.Visible = false;
                            constStripButton.Visible = false;
                        }
                    }
                }
            }
        }


        private void changePassStripButton_Click(object sender, EventArgs e)
        {

            //UpdatePassForm updateForm = new UpdatePassForm(
            //  users.Find(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()));
            UpdatePassForm updateForm = new UpdatePassForm(users.Find(x => x.username == username));

            while (true)
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {

                    //введенный пароль правильныый
                    if (updateForm.oldPassTextBox.Text == updateForm.user.password)
                    {
                        if (updateForm.newPassTextBox.Text == updateForm.confirmPassTextBox.Text)
                        {
                            if (updateForm.user.constraint == true)
                            {
                                string constraints = "0123456789+-*/ ";
                                string pass = "";
                                foreach (char c in updateForm.newPassTextBox.Text)
                                {
                                    //если символ входит в ограниечение, то ошибка
                                    if (constraints.ToCharArray().ToList().IndexOf(c) != -1)
                                    {
                                        MessageBox.Show("Пароль содержит недопустимые символы!");
                                        break;
                                    }
                                    else pass += c;

                                }
                                if (pass == updateForm.newPassTextBox.Text)
                                {
                                    updateForm.user.password = updateForm.newPassTextBox.Text;
                                    users.Find(x => x.username == updateForm.user.username).password = updateForm.user.password;
                                    using (StreamWriter s = new StreamWriter("users.json"))
                                    {
                                        s.Write(JsonConvert.SerializeObject(users));
                                    }

                                    userDataGridView.SelectedRows[0].Cells[2].Value = users.Find(x => x.username == updateForm.user.username).password;
                                    break;
                                }
                            }
                            else
                            {
                                updateForm.user.password = updateForm.newPassTextBox.Text;
                                users.Find(x => x.username == updateForm.user.username).password = updateForm.user.password;
                                using (StreamWriter s = new StreamWriter("users.json"))
                                {
                                    s.Write(JsonConvert.SerializeObject(users));
                                }

                                userDataGridView.SelectedRows[0].Cells[2].Value = users.Find(x => x.username == updateForm.user.username).password;
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введен неверный пароль!");
                    }

                }
            }
        }

        private void addUserStripButton_Click(object sender, EventArgs e)
        {
            if (flag == Base.BD)
            {
                AddForm form = new AddForm(connection, flag, ref users);
                while (form.ShowDialog() == DialogResult.OK)
                {
                    string sql = "INSERT INTO users (username,idgroup) VALUES(@username,@idgroup)";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("@username", MySqlDbType.String).Value = form.userTextBox.Text;
                    cmd.Parameters.Add("@idgroup", MySqlDbType.Int16).Value = form.userGroups.FirstOrDefault(x => x.Value == form.groupComboBox.Text).Key;

                    try
                    {
                        int z = cmd.ExecuteNonQuery();
                        //добавление строки в грид
                        using (MySqlDataReader reader = DBUtils.GetLastUserFromDB(connection))
                        {
                            if (reader.Read())
                            {
                                bool isLock = reader.GetInt16(4) == 1 ? true : false;
                                bool isConstraint = reader.GetInt16(5) == 1 ? true : false;
                                userDataGridView.Rows.Add(reader.GetInt16(0), reader.GetString(1), reader.GetString(2));
                                userDataGridView[3, userDataGridView.Rows.Count - 1].Value = isLock;
                                userDataGridView[4, userDataGridView.Rows.Count - 1].Value = isConstraint;
                            }
                        }

                        break;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Указано недопустимое значение имени пользователя/ группы!", "Ошибка");
                    }
                }
            }
            else
            {
                AddForm form = new AddForm(connection, flag, ref users);
                while (form.ShowDialog() == DialogResult.OK)
                {
                    if (users.Find(x => x.username == form.userTextBox.Text) == null &&
                        form.userGroups.Values.ToList().Find(x => x == form.groupComboBox.Text) == null)
                    {
                        MessageBox.Show("Указана неверная группа пользователя!");

                    }
                    else if (users.Find(x => x.username == form.userTextBox.Text) != null)
                    {
                        MessageBox.Show("Пользователь с таким именем уже существует!");
                    }
                    else
                    {   
                        //новый объект юзера
                        User newUser = new User(
                            form.userTextBox.Text,
                            group = form.userGroups.FirstOrDefault(x => x.Value == form.groupComboBox.Text).Value);

                        users.Add(newUser);
                        try
                        {
                            using (StreamWriter s = new StreamWriter("users.json"))
                            {
                                s.Write(JsonConvert.SerializeObject(users));
                            }

                            userDataGridView.Rows.Add(
                                int.Parse(userDataGridView.Rows[userDataGridView.Rows.Count - 1].Cells[0].Value.ToString()) + 1,
                                newUser.username,
                                newUser.password
                            );
                            userDataGridView[3, userDataGridView.Rows.Count - 1].Value = newUser.activity;
                            userDataGridView[4, userDataGridView.Rows.Count - 1].Value = newUser.constraint;

                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Указано недопустимое значение имени пользователя/группы!", "Ошибка");
                        }
                    }
                }
            }
        }

        //бан
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //для БД
            if (flag == Base.BD)
            {
                string sql = "UPDATE users SET activity=@activity WHERE iduser=@iduser";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.Parameters.Add("@iduser", MySqlDbType.Int16).Value = int.Parse(userDataGridView.SelectedRows[0].Cells[0].Value.ToString());

                if (bool.Parse(userDataGridView.SelectedRows[0].Cells[4].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Вы уверены, что хотите заблокировать запись?") == DialogResult.OK)
                    {

                        cmd.Parameters.Add("@activity", MySqlDbType.Int16).Value = 1;
                        try
                        {
                            int z = cmd.ExecuteNonQuery();
                            userDataGridView.SelectedRows[0].Cells[4].Value = true;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите разблокировать запись?") == DialogResult.OK)
                    {

                        cmd.Parameters.Add("@activity", MySqlDbType.Int16).Value = 0;
                        try
                        {
                            int z = cmd.ExecuteNonQuery();
                            userDataGridView.SelectedRows[0].Cells[4].Value = false;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
            //для JSON
            else
            {
                

                if (bool.Parse(userDataGridView.SelectedRows[0].Cells[4].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Вы уверены, что хотите заблокировать запись?") == DialogResult.OK)
                    {
                        //инверсия
                        users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).activity =
                            !users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).activity;
                        
                        try
                        {
                            using (StreamWriter s = new StreamWriter("users.json"))
                            {
                                s.Write(JsonConvert.SerializeObject(users));
                            }
                            
                            userDataGridView.SelectedRows[0].Cells[4].Value = true;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите разблокировать запись?") == DialogResult.OK)
                    {

                        //инверсия
                        users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).activity =
                            !users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).activity;

                        try
                        {
                            using (StreamWriter s = new StreamWriter("users.json"))
                            {
                                s.Write(JsonConvert.SerializeObject(users));
                            }

                            userDataGridView.SelectedRows[0].Cells[4].Value = false;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
        }
        //добавление ограничений
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //для БД
            if (flag == Base.BD)
            {
                string sql = "UPDATE users SET constr=@constr WHERE iduser=@iduser";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = connection;
                cmd.Parameters.Add("@iduser", MySqlDbType.Int16).Value = int.Parse(userDataGridView.SelectedRows[0].Cells[0].Value.ToString());

                if (bool.Parse(userDataGridView.SelectedRows[0].Cells[3].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Вы уверены, что хотите добавить ограничение?") == DialogResult.OK)
                    {

                        cmd.Parameters.Add("@constr", MySqlDbType.Int16).Value = 1;
                        try
                        {
                            int z = cmd.ExecuteNonQuery();
                            userDataGridView.SelectedRows[0].Cells[3].Value = true;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите убрать ограничение?") == DialogResult.OK)
                    {

                        cmd.Parameters.Add("@constr", MySqlDbType.Int16).Value = 0;
                        try
                        {
                            int z = cmd.ExecuteNonQuery();
                            userDataGridView.SelectedRows[0].Cells[3].Value = false;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
            //для JSON
            else
            {
                if (bool.Parse(userDataGridView.SelectedRows[0].Cells[3].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Вы уверены, что хотите добавить ограничение?") == DialogResult.OK)
                    {
                        //инверсия
                        users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).constraint =
                            !users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).constraint;
                        try
                        {
                            using (StreamWriter s = new StreamWriter("users.json"))
                            {
                                s.Write(JsonConvert.SerializeObject(users));
                            }

                            userDataGridView.SelectedRows[0].Cells[3].Value = true;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Вы уверены, что хотите убрать ограничение?") == DialogResult.OK)
                    {
                        //инверсия
                        users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).constraint =
                            !users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).constraint;
                        try
                        {
                            using (StreamWriter s = new StreamWriter("users.json"))
                            {
                                s.Write(JsonConvert.SerializeObject(users));
                            }
                            userDataGridView.SelectedRows[0].Cells[3].Value = false;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }
    }
}
