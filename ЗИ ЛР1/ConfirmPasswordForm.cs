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
	public partial class ConfirmPasswordForm : Form
	{
		public ConfirmPasswordForm(string messageText)
		{
			InitializeComponent();
			label1.Text = messageText;
		}

		public string password = "";

		private void button1_Click(object sender, EventArgs e)
		{
			returnResult();
		}

		void returnResult()
		{
			password = textBox1.Text;
			this.DialogResult = DialogResult.OK;
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				returnResult();
			}
		}
	}
}
