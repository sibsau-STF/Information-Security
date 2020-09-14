using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth;

namespace Lab1
	{
	public partial class SignIn : Form
		{
		BaseAuth Auth = new JsonAuth("./users.json");
		UserEntry User;
		int LoginTries = 0;

		public SignIn ()
			{
			InitializeComponent();
			warningLabel.ForeColor = Color.Red;
			loginPanel.Visible = true;
			}

		private void button1_Click (object sender, EventArgs e)
			{
			string login = loginBox.Text;
			string password = passwordBox.Text;
			string repeat = repeatBox.Text;

			// get user info
			var userData = Auth.findUser(login);

			if (userData == null)
				{
				warningLabel.Text = "User doesn't exists";
				return;
				}

			if ( userData.IsBanned )
				{
				warningLabel.Text = "User is banned";
				return;
				}

			// если входит в первый раз, то надо изменить пароль
			if ( userData.Password == "" )
				{
				repeatBox.Enabled = true;
				warningLabel.Text = "Repeat password";

				if ( password != repeat )
					{
					warningLabel.Text = "Passwords don't match";
					return;
					}

				if ( password=="")
					{
					warningLabel.Text = "Password must not be empty";
					return;
					}

				// Set password
				userData.Password = password;
				var result = Auth.changeUser(userData);
				if ( result.ID == 0 )
					{
					User = result.UserData;
					LoginTries = 0;
					openMain(User);
					return;
					}
				}

			var response = Auth.authUser(login, password);

			if ( response.ID == 0 )
				{
				warningLabel.Text = "";
				User = response.UserData;
				LoginTries = 0;
				openMain(User);
				}
			else
				{
				warningLabel.Text = response.Message;
				LoginTries += 1;
				}

			if ( LoginTries == 3 )
				Application.Exit();
			}

		private void openMain (UserEntry user)
			{
			Main form = new Main(Auth, user);
			form.Show();
			this.Hide();
			}
		private void AboutProgram_Click (object sender, System.EventArgs e)
			{
			new About().Show();
			}
		}
	}
