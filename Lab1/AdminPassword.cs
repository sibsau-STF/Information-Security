using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab1
	{
	public partial class AdminPassword : Form
		{
		public string Password { get; protected set; }
		public AdminPassword ()
			{
			InitializeComponent();
			}

		private void button1_Click (object sender, EventArgs e)
			{
			Password = textBox1.Text;

			new SignIn().Show();
			this.Hide();
			}
		}
	}
