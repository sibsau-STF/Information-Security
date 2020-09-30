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
	public partial class AddUser : Form
		{
		public UserEntry NewUser;
		BaseAuth AuthModel;
		public AddUser (BaseAuth auth)
			{
			InitializeComponent();
			AuthModel = auth;
			}

		private void confirmBox_Click (object sender, EventArgs e)
			{
			var login = loginBox.Text;
			var restrict = restrictBox.Checked;
			var banned = bannedBox.Checked;
			string rule = (string)ruleCombo.SelectedItem;

			if ( login == "" || rule == null || rule == "" )
				return;
			NewUser = new UserEntry(login, "", rule, banned, restrict);

			var result = AuthModel.registerUser(NewUser);
			if ( result.ID == 0 )
				{
				DialogResult = DialogResult.OK;
				Close();
				}
			else
				{
				statusLabel.Text = result.Message;
				}
			}
		}
	}
