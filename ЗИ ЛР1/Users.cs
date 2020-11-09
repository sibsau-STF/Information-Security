using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗИ_ЛР1
{
	public class Users
	{
		public Users()
		{
			LoadFromFile();
		}
		List<User> users = new List<User>();

		void WriteToFile()
		{
			try
			{
				string json = JsonConvert.SerializeObject(users, Formatting.Indented);
				File.WriteAllText("users", json);
			}
			catch
			{
				MessageBox.Show("Ошибка записи файла пользователей");
				Application.Exit();
			}
		}

		void LoadFromFile()
		{
			try
			{
				string json = File.ReadAllText("users");
				users = JsonConvert.DeserializeObject<List<User>>(json);
			}
			catch
			{
				MessageBox.Show("Ошибка загрузки списка пользователей");
				users.Add(new User("ADMIN", Coding.codingPassword(""), true));
				WriteToFile();
			}
		}

		int failedAuthCount = 0;
		public User checkAuth(string userName, string password)
		{						
			foreach (var user in users)
			{
				if (user.userName == userName)
				{
					if (user.isBlocked)
					{
						MessageBox.Show("Пользователь заблокирован");
						return null;
					}
					if (user.password == Coding.codingPassword(password))
					{
						if (user.isFirstAuth)
						{
							var checkPasswordForm = new ConfirmPasswordForm("Подтвердите пароль");
							if (DialogResult.OK == checkPasswordForm.ShowDialog())
							{
								if (checkPasswordForm.password == password)
								{
									user.isFirstAuth = false;
									WriteToFile();
									return user;
								}								
							}
						}
						else
						{
							return user;
						}
					}
				}
			}
			failedAuthCount++;
			if (failedAuthCount >= 3)
			{
				MessageBox.Show("Произведено больше трёх попыток авторизации");
				Application.Exit();
			}
			MessageBox.Show("Ошибка авторизации. Осталось попыток: " + (3 - failedAuthCount).ToString());
			return null;
		}

		public void addUser(string userName, string password = "")
		{
			bool isUserNameFinded = false;
			foreach (var user in users)
			{
				if (user.userName == userName)
				{
					isUserNameFinded = true;
				}
			}
			if (isUserNameFinded)
			{
				MessageBox.Show("Пользователь с заданным именем существует");
			}
			else
			{
				users.Add(new User(userName, Coding.codingPassword(password)));
				WriteToFile();
				bindingSource.ResetBindings(false);
			}			
		}

		public void deleteUser(int id)
		{
			users.RemoveAt(id);
			WriteToFile();
			bindingSource.ResetBindings(false);
			MessageBox.Show("Пользователь удалён");
		}

		bool isCheckedPasswordPattern = false;
		bool checkPasswordPattern(string password)
		{
			return !isCheckedPasswordPattern || Regex.IsMatch(password, @"[a-zA-Z]") && Regex.IsMatch(password, @"[\d]") && Regex.IsMatch(password, @"[.,!?;()]") ;
		}

		public void changePassword(string userName, string oldPassword = "", string newPassword = "")
		{
			if (checkPasswordPattern(newPassword))
			{
				int userIndex = -1;
				userIndex = users.FindIndex((user) => user.userName == userName);
				if (userIndex == -1)
				{
					MessageBox.Show("Пользователь с заданным именем существует");
				}
				else
				{
					if (users[userIndex].password == Coding.codingPassword(oldPassword))
					{
						users[userIndex].password = Coding.codingPassword(newPassword);
						WriteToFile();
						bindingSource.ResetBindings(false);
						MessageBox.Show("Пароль успешно изменён");
					}
					else
					{
						MessageBox.Show("Пароли должны совпадать");
					}
				}
			}
			else
			{
				MessageBox.Show("Пароль не соответствует требованиям");
			}
		}

		DataGridView dataGridView;
		BindingSource bindingSource;

		public void bindGridView(DataGridView dataGridView)
		{
			bindingSource = new BindingSource();
			bindingSource.DataSource = users;
			this.dataGridView = dataGridView;
			this.dataGridView.DataSource = bindingSource;
			this.dataGridView.CellValueChanged += DataGridView_CellValueChanged;
		}
		
		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int columnIndex = e.ColumnIndex;

			if (columnIndex == 1)
			{
				string password = (string)dataGridView[e.ColumnIndex, e.RowIndex].Value;
				users[e.RowIndex].password = Coding.codingPassword(password);
			}
			WriteToFile();
		}


		public void bindCheckBox(CheckBox checkBox)
		{
			checkBox.CheckedChanged += CheckBox_CheckedChanged;
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			isCheckedPasswordPattern = !isCheckedPasswordPattern;
		}
	}

	public class User
	{
		public User(string userName, string password, bool isAdmin = false, bool isBlocked = false)
		{
			this.userName = userName;
			this.password = password;
			this.isAdmin = isAdmin;
			this.isBlocked = isBlocked;
			this.isFirstAuth = true;
		}
		public string userName { get; set; }
		public string password { get; set; }
		public bool isAdmin { get; set; }
		public bool isBlocked { get; set; }
		public bool isFirstAuth { get; set; }
	}
}
