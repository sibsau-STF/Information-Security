using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Auth;

namespace Lab1
	{
	public partial class ChangePassword : Form
		{
		public UserEntry User;
		BaseAuth AuthModel;
		public ChangePassword (UserEntry user, BaseAuth auth)
			{
			InitializeComponent();
			User = user;
			AuthModel = auth;
			}

		private void printMsg (string text, bool error = true)
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

			User.Password = newPassword;
			var response = AuthModel.changeUser(User);
			if ( response.ID == 0 )
				{
				printMsg("Success", false);
				DialogResult = DialogResult.OK;
				this.Close();
				}
			else
				{
				User.Password = oldPassword;
				printMsg(response.Message);
				}
			}
		}
	}
