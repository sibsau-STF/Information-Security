using Installer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ЗИ_ЛР1;

namespace Installer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			setSystemInfo();
		}

		SystemInfo systemInfo = new SystemInfo();

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				FileStream fs = new FileStream(Path.Combine(textBox1.Text, "programm.exe"), FileMode.Create);
				fs.Write(Resources.installedFile, 0, Resources.installedFile.Length);
				fs.Close();
			}
			catch
			{
				MessageBox.Show("Ошибка пути файла. Установка невозможна");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox1.Text = folderBrowserDialog1.SelectedPath;
				setSystemInfo();
			}
		}

		void setSystemInfo()
		{
			systemInfo.path = textBox1.Text;
			label1.Text = systemInfo.getTotalInfoToUser();
		}
	}
}
