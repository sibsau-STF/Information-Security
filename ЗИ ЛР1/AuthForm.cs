using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗИ_ЛР1
{
	public partial class AuthForm : Form
	{
		public AuthForm()
		{
			InitializeComponent();
		}
		Users users { get; set; }
		private void AuthForm_Load(object sender, EventArgs e)
		{
			users = new Users();
		}
		User authedUserData = null;

		void Auth()
		{
			authedUserData = users.checkAuth(textBox2.Text, textBox1.Text);
			if (authedUserData != null)
			{
				MainForm form = new MainForm(users, authedUserData);
				this.Visible = false;
				form.ShowDialog();
				this.Visible = true;
			}
			else
			{

			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Auth();
		}

		private void button1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Auth();
			}
		}

		private void AuthForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Auth();
			}
		}

		private void textBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Auth();
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Auth();
			}
		}
	}
}
