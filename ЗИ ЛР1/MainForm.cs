using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗИ_ЛР1
{
	public partial class MainForm : Form
	{
		Users users;
		User authedUserData;
		public MainForm(Users users, User authedUserData)
		{
			this.users = users;
			this.authedUserData = authedUserData;
			InitializeComponent();
		}

		private void сведенияОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AuthorInfo().Show();
		}

		private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			label1.Text = "Привет, " + authedUserData.userName;
			label5.Text = authedUserData.isAdmin ? "Администратор" : "Пользователь";
			users.bindGridView(dataGridView1);
			users.bindCheckBox(checkBox1);
			panel2.Visible = authedUserData.isAdmin;
		}

		private void списокПользователейToolStripMenuItem_Click(object sender, EventArgs e)
		{
			panel1.Visible = false;
		}

		private void сменаПароляToolStripMenuItem_Click(object sender, EventArgs e)
		{
			panel1.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox2.Text == textBox3.Text)
			{
				users.changePassword(authedUserData.userName, textBox1.Text, textBox2.Text);
			}
			else
			{
				MessageBox.Show("Пароли не совпадают");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			users.deleteUser(dataGridView1.SelectedCells[0].RowIndex);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			users.addUser(textBox4.Text);
		}
	}
}
