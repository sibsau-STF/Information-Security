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
using Newtonsoft.Json;

namespace Installer1
	{
	public partial class Form1 : Form
		{
		RSAParameters publicKey;

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
			if ( Directory.Exists(textBox1.Text) )
				Directory.CreateDirectory(textBox1.Text);

			foreach ( var file in files )
				File.Copy(file.FullName, Path.Combine(textBox1.Text, file.Name), true);

			byte[] systemInfoData = RegistryWorker.GetSignature(SystemInfo.Information);
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			publicKey = rSACryptoServiceProvider.ExportParameters(false);
			File.WriteAllBytes(Path.Combine(textBox1.Text, "openKey.key"), Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(publicKey)));
			byte[] signedData = rSACryptoServiceProvider.SignData(systemInfoData, CryptoConfig.MapNameToOID(HashAlgorithmName.SHA1.Name));
			RegistryWorker.WriteSignature(signedData);

			Application.Exit();
			}

		private void closeBtn_Click_1 (object sender, EventArgs e)
			{
			Application.Exit();
			}

		}
	}
