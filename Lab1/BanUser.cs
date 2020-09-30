using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auth;

namespace Lab1
	{
	public partial class BanUser : Form
		{
		BaseAuth AuthModel;
		List<UserEntry> Users;
		public BanUser (BaseAuth auth)
			{
			InitializeComponent();
			AuthModel = auth;
			Users = AuthModel.readAllUsers();
			Users.ForEach(user => checkedListBox1.Items.Add(user.Login, user.IsBanned));
			}

		private void applyButton_Click (object sender, EventArgs e)
			{
			var count = checkedListBox1.Items.Count;
			for ( int id = 0; id < count; id++ )
				Users[id].IsBanned = checkedListBox1.CheckedIndices.Contains(id);
			AuthModel.writeUsers(Users);
			DialogResult = DialogResult.OK;
			}
		}
	}
