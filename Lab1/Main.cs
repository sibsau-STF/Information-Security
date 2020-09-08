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

			if ( User.Rule != "Admin" )
				usersPanel.Enabled = false;
			else
				DisplayUsers();
			}

		void DisplayUsers ()
			{
			tableUsers.DataSource = Users;
			dataGridView1.DataSource = tableUsers;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ReadOnly = true;
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
		private void changePass_Click (object sender, EventArgs e)
			{
			using ( ChangePassword dlg = new ChangePassword(User, AuthModel) )
				{
				if ( dlg.ShowDialog() == DialogResult.OK )
					{
					User = dlg.User;
					Users = AuthModel.readAllUsers();
					DisplayUsers();
					}
				}
			}
		private void addUserButton_Click (object sender, EventArgs e)
			{
			using ( AddUser dlg = new AddUser(AuthModel) )
				{
				if ( dlg.ShowDialog() == DialogResult.OK )
					{
					Users = AuthModel.readAllUsers();
					DisplayUsers();
					}
				}
			}

		private void button2_Click (object sender, EventArgs e)
			{
			SaveChanges();
			}
		private void Main_FormClosed (object sender, FormClosedEventArgs e)
			{
			Application.Exit();
			}

		private void banButton_Click (object sender, EventArgs e)
			{
			using ( BanUser dlg = new BanUser(AuthModel) )
				{
				if ( dlg.ShowDialog() == DialogResult.OK )
					{
					Users = AuthModel.readAllUsers();
					DisplayUsers();
					}
				}
			}
		}
	}
