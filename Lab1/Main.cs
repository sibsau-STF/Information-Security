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

		private void printMsg(string text, bool error = true)
			{
			statusLabel.Text = text;
			statusLabel.ForeColor = error ? Color.DarkRed : Color.Green;
			}

		private void changePassButton_Click (object sender, EventArgs e)
			{
			var oldPassword = this.oldPassBox.Text;
			var newPassword = this.newPassBox.Text;
			var repeatPassword = this.repeatPassBox.Text;

			if ( newPassword != repeatPassword )
				{
				printMsg("Passwords don't match");
				return;
				}

			if ( oldPassword != User.Password )
				{
				printMsg("Wrong old password");
				return;
				}

			if ( oldPassword == newPassword )
				{
				printMsg("Specify another new password");
				return;
				}

			try
				{
				User.Password = newPassword;
				AuthModel.changeUser(User);
				printMsg("Success", false);
				}
			catch (ArgumentException ex )
				{
				User.Password = oldPassword;
				printMsg(ex.Message);
				return;
				}
			finally
				{
				Users = AuthModel.readAllUsers();
				DisplayUsers();
				}
			}
		}
	}
