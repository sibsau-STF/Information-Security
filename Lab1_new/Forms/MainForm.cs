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


/***
 * Класс DBUtils: методы для работы с БД 
 * Класс JSONUtils: методы для работы с JSON
 * Класс User: представление пользователя (данные о пользователе и т.д.)
 */
namespace Lab_1
{
    //БД или JSON
    public enum Base
    {
        BD = 1,
        JSON = 2
    }

    public partial class Form1 : Form
    {
        //поскольку я дурак, я сперва сделал для БД, потом для JSON
        //функции и код для БД я не удалял, оставил, поэтому добавил ветвления
        //если работаем с JSON, то и смотрим на ветку JSON (на flag)
        Base flag = Base.JSON;
        //список юзеров с JSON -- Да-да, если будет 2ккк юзеров, то это все будет в оперативке (аве мне)
        public List<User> users = new List<User>();
        //коннектор для БД мускула (не актуально)
        private MySqlConnection connection = new MySqlConnection();

        //данные об авторизованном пользователе 
        //(не делал акцессор, так как если надо их можно в качестве аргумента передать)
        private string username;
        private string password;
        private string group;

        //ограничения для пароля. СМ. СВОЙ ВАРИАНТ и ВПИСЫВАЙТЕ!!! (перед показом преподу, сотрите коммент)
        string constraints = @"0123456789/*-+=";

        public Form1()
        {
            InitializeComponent();
            //если через БД, то получаем объект подключения (не актуально)
            if (flag == Base.BD)
            {
                connection = DBUtils.GetDBConnection();
                try
                {
                    connection.Open();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
            //типа инициализация, хотя может, и не надо (не помню как конструктор в шарпе работает)
            username = "";
            password = "";
            users = new List<User>();
        }

        private void LoadUsers()
        {
            //БД(не актуально)
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
            //JSON
            else
            {
                users = JSONUtils.GetAllUsersFromJSON();
                int i = 0;                                                       //счетчик - условный id и номер в гриде
                foreach (var u in users)
                {
                    userDataGridView.Rows.Add(i+1, u.username, u.password);
                    userDataGridView[3, i].Value = u.constraint;
                    userDataGridView[4, i].Value = u.activity;
                    i++;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //БД(не актуально)
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
            //JSON
            else if (flag == Base.JSON)
            {
                //форма авторизации
                AuthForm authForm = new AuthForm(this);
                //флаг корректности и колличество неудачных попыток
                bool isCorrect = false;
                int falseCount = 0;

                while (!isCorrect)
                {
                    //если ошибок 3+, то закрываем все формы
                    if (falseCount >= 3)
                    {
                        authForm.Close();
                        this.Close();
                        break;
                    }
                    //показываем форму авторизации
                    if (authForm.ShowDialog() == DialogResult.OK)
                    {
                        isCorrect = true;
                        username = authForm.Username;
                        password = authForm.Password;
                        List<User> users = JSONUtils.GetAllUsersFromJSON();
                        //верификация введенных данных
                        User user = users.FirstOrDefault(x => x.username == username && x.password == password);

                        //если верификация успешна
                        if (user != null)
                        {
                            group = user.group;
                            //если акк заблокирован, то ошибка
                            if (user.activity == true)
                            {
                                MessageBox.Show("Отказано в доступе!", "Ошибка", MessageBoxButtons.OK);
                                isCorrect = false;
                            }
                        }
                        //если верификация провалена, ошибка
                        else
                        {
                            MessageBox.Show("Неверно указаны имя или пароль!", "Ошибка", MessageBoxButtons.OK);
                            isCorrect = false;
                            falseCount++;
                        }
                        if (isCorrect) break;
                    }
                    //если закрыли форму авторизации, то прекращаем работу
                    else
                    {
                        this.Close();
                        break;
                        
                    }
                }

                //если верификация успешна, загружаем пользователей в грид
                if (isCorrect)
                {
                    LoadUsers();
                    //если пустой пароль, то запускаем форму изменения пароля
                    if (password == "")
                    {
                        UpdatePassForm updateForm = new UpdatePassForm(users.Find(x => x.username == username));
                        while (true)
                        {
                            if (updateForm.ShowDialog() == DialogResult.OK)
                            {
                                //введенный пароль - правильныый
                                if (updateForm.oldPassTextBox.Text == updateForm.user.password)
                                {
                                    if (updateForm.newPassTextBox.Text == updateForm.confirmPassTextBox.Text)
                                    {
                                        //если есть ограничения на пароль
                                        if (updateForm.user.constraint == true)
                                        {
                                            string constraints = "0123456789+-*/ ";
                                            bool noConstraints = true;
                                            foreach (char c in updateForm.newPassTextBox.Text)
                                            {
                                                //если символ входит в ограниечение, то ошибка
                                                if (constraints.ToCharArray().ToList().IndexOf(c) != -1)
                                                {
                                                    MessageBox.Show("Пароль содержит недопустимые символы!");
                                                    noConstraints = false;
                                                    break;
                                                }
                                            }
                                            if (noConstraints)
                                            {
                                                updateForm.user.password = updateForm.newPassTextBox.Text;
                                                users.Find(x => x.username == updateForm.user.username).password = updateForm.user.password;
                                                using (StreamWriter s = new StreamWriter("users.json"))
                                                {
                                                    s.Write(JsonConvert.SerializeObject(users));
                                                }
                                                //изменяем грид
                                                userDataGridView.SelectedRows[0].Cells[2].Value = users.Find(x => x.username == updateForm.user.username).password;
                                                break;
                                            }
                                        }
                                        //если ограничений нет, вносим изменения (в файл и грид)
                                        else
                                        {
                                            updateForm.user.password = updateForm.newPassTextBox.Text;
                                            users.Find(x => x.username == updateForm.user.username).password = updateForm.user.password;
                                            using (StreamWriter s = new StreamWriter("users.json"))
                                            {
                                                s.Write(JsonConvert.SerializeObject(users));
                                            }

                                            userDataGridView.SelectedRows[0].Cells[2].Value = updateForm.user.password;
                                            break;
                                        }
                                    }
                                    //ошибки
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
                        //если пользователь не админ, то скрываем элементы с функциями
                        if(username != "admin")
                        {
                            addUserStripButton.Visible = false;
                            userDataGridView.Visible = false;
                            lockStripButton.Visible = false;
                            constStripButton.Visible = false;
                        }
                    }
                }
            }
        }

        //обработчик - смена пароля
        private void changePassStripButton_Click(object sender, EventArgs e)
        {
            UpdatePassForm updateForm = new UpdatePassForm(users.Find(x => x.username == username));

            while (true)
            {
                //вызов окна
                if (updateForm.ShowDialog() == DialogResult.OK)
                {

                    //валидация
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
                    //ошибка
                    else
                    {
                        MessageBox.Show("Введен неверный пароль!");
                    }

                }
                else
                {
                    break;
                }
            }
        }
        //обработчик - добавление юзера
        private void addUserStripButton_Click(object sender, EventArgs e)
        {
            //БД (не актуально)
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
            //JSON
            else
            {
                AddForm form = new AddForm(connection, flag, ref users);
                while (form.ShowDialog() == DialogResult.OK)
                {
                    //проверка введенной группы пользователей
                    if (users.Find(x => x.username == form.userTextBox.Text) == null &&
                        form.userGroups.Values.ToList().Find(x => x == form.groupComboBox.Text) == null)
                    {
                        MessageBox.Show("Указана неверная группа пользователя!");

                    }
                    //проверка введенного имя пользователя
                    else if (users.Find(x => x.username == form.userTextBox.Text) != null)
                    {
                        MessageBox.Show("Пользователь с таким именем уже существует!");
                    }
                    //добавление
                    else
                    {
                        //новый объект юзера
                        User newUser = new User(
                            form.userTextBox.Text,
                            group = form.userGroups.FirstOrDefault(x => x.Value == form.groupComboBox.Text).Value);

                        users.Add(newUser);

                        //добавление в файл
                        using (StreamWriter s = new StreamWriter("users.json"))
                        {
                            s.Write(JsonConvert.SerializeObject(users));
                        }
                        //добавление в грид
                        userDataGridView.Rows.Add(
                            int.Parse(userDataGridView.Rows[userDataGridView.Rows.Count - 1].Cells[0].Value.ToString()) + 1,
                            newUser.username,
                            newUser.password
                        );
                        userDataGridView[3, userDataGridView.Rows.Count - 1].Value = newUser.activity;
                        userDataGridView[4, userDataGridView.Rows.Count - 1].Value = newUser.constraint;

                        break;
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

        //обработчик - бан
        private void lockStripButton_Click(object sender, EventArgs e)
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

                //заблокирование
                if (bool.Parse(userDataGridView.SelectedRows[0].Cells[4].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Вы уверены, что хотите заблокировать запись?") == DialogResult.OK)
                    {
                        //инверсия
                        users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).activity =
                            !users.First(x => x.username == userDataGridView.SelectedRows[0].Cells[1].Value.ToString()).activity;

                        try
                        {
                            //правка файла
                            using (StreamWriter s = new StreamWriter("users.json"))
                            {
                                s.Write(JsonConvert.SerializeObject(users));
                            }
                            //правка грида
                            userDataGridView.SelectedRows[0].Cells[4].Value = true;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                //разблокирование
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }
    }
}
