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
		public ConfirmPasswordForm()
		{
			InitializeComponent();
		}

		public string password = "";

		private void button1_Click(object sender, EventArgs e)
		{
			password = textBox1.Text;
			this.DialogResult = DialogResult.OK;
		}
	}
}
