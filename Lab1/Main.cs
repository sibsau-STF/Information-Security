using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auth;
namespace Lab1
	{
	public partial class Main : Form
		{
		List<UserEntry> Users;

		BaseAuth AuthModel;

		UserEntry User;

		BindingSource tableUsers = new BindingSource();

		public Main (BaseAuth auth, UserEntry user)
			{
			InitializeComponent();
			AuthModel = auth;
			Users = AuthModel.readAllUsers();
			User = user;
			nicknameLabel.Text = "User: " + User.Login;
			DisplayUsers();
			}

		void DisplayUsers ()
			{
			tableUsers.DataSource = Users;
			dataGridView1.DataSource = tableUsers;
			dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
			dataGridView1.AllowUserToAddRows = true;
			}

		void SaveChanges ()
			{
			AuthModel.writeUsers(Users);
			tableUsers.DataSource = Users;
			}

		private void openSignIn ()
			{
			SignIn form = new SignIn();
			form.Show();
			this.Hide();
			}

		private void logoutButton_Click (object sender, EventArgs e)
			{
			openSignIn();
			}

		private void Main_FormClosed (object sender, FormClosedEventArgs e)
			{
			Application.Exit();
			}

		private void button2_Click (object sender, EventArgs e)
			{
			SaveChanges();
			}
		}
	}
