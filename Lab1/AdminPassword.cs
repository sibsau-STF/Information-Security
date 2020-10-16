using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Installer;

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
			if ( File.Exists("users.json.hash") )
				Encoder.ApplyEncoding("users.json", Password, false);

			new SignIn().Show();
			this.Hide();
			}

		private void AdminPassword_Load (object sender, EventArgs e)
			{
			var hash = RegistryWorker.GetSignature(SystemInfo.Information);
			var signature = RegistryWorker.ReadSignature();
			
			if ( !hash.SequenceEqual(signature) )
				{
				var result = MessageBox.Show(this, "Wrong signature", "Error", MessageBoxButtons.OK);
				Application.Exit();
				}
			}
		}
	}
