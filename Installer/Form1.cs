using Installer.Properties;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
		RSAParameters publicKey;

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				//Подписываем и сохраняем открытый ключ
				byte[] systemInfoData = Encoding.ASCII.GetBytes(systemInfo.getTotalInfo());
				RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
				publicKey = rSACryptoServiceProvider.ExportParameters(false);
				File.WriteAllText(Path.Combine(textBox1.Text, "openKey.json"), JsonConvert.SerializeObject(publicKey));
				byte[] signedData = rSACryptoServiceProvider.SignData(systemInfoData, CryptoConfig.MapNameToOID(HashAlgorithmName.MD5.Name));
				Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("Statnikov A.S.", true).SetValue("Signature", signedData);

				RSAParameters publicKey2 = JsonConvert.DeserializeObject<RSAParameters>(File.ReadAllText(Path.Combine(textBox1.Text, "openKey.json")));
				RSACryptoServiceProvider rSACryptoServiceProvider2 = new RSACryptoServiceProvider();
				rSACryptoServiceProvider2.ImportParameters(publicKey2);
				byte[] signedData2 = (byte[])Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Statnikov A.S.").GetValue("Signature");
				byte[] systemInfo2 = Encoding.ASCII.GetBytes(systemInfo.getTotalInfo());
				MessageBox.Show(rSACryptoServiceProvider2.VerifyData(systemInfo2, CryptoConfig.MapNameToOID(HashAlgorithmName.MD5.Name), signedData).ToString());

				//Копирование файлов
				FileStream fs = new FileStream(Path.Combine(textBox1.Text, "Newtonsoft.Json.dll"), FileMode.Create);
				fs.Write(Resources.newtonsoftDll, 0, Resources.newtonsoftDll.Length);
				fs.Close();
				FileStream fs2 = new FileStream(Path.Combine(textBox1.Text, "programm.exe"), FileMode.Create);
				fs2.Write(Resources.installedFile, 0, Resources.installedFile.Length);
				fs2.Close();

				MessageBox.Show("Установка успешна!");
				Process.Start("explorer.exe", textBox1.Text);
			}
			catch
			{
				MessageBox.Show("Неизвестная ошибка. Установка невозможна");
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
