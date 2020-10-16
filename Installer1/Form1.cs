using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Installer;

namespace Installer1
	{
	public partial class Form1 : Form
		{
		public Form1 ()
			{
			InitializeComponent();
			}

		private void openBtn_Click (object sender, EventArgs e)
			{
			folderBrowserDialog1.SelectedPath = textBox1.Text;
			if ( folderBrowserDialog1.ShowDialog() == DialogResult.OK )
				textBox1.Text = folderBrowserDialog1.SelectedPath;
			}
		private void installBtn_Click_1 (object sender, EventArgs e)
			{
			var fromDir = Path.Combine(Environment.CurrentDirectory, "app");
			var files = new DirectoryInfo(fromDir).GetFiles();
			Directory.CreateDirectory(textBox1.Text);
			foreach ( var file in files )
				File.Copy(file.FullName, Path.Combine(textBox1.Text, file.Name), true);

			var signature = RegistryWorker.GetSignature(SystemInfo.Information);
			RegistryWorker.WriteSignature(signature);
			Application.Exit();
			}

		private void closeBtn_Click_1 (object sender, EventArgs e)
			{
			Application.Exit();
			}

		}
	}
