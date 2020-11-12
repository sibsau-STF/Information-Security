using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Installer;
using Newtonsoft.Json;

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
			try
				{
				RSAParameters publicKey = JsonConvert.DeserializeObject<RSAParameters>(File.ReadAllText("openKey.key"));
				RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
				rSACryptoServiceProvider.ImportParameters(publicKey);
				byte[] signedData = RegistryWorker.ReadSignature();
				byte[] systemInfo = RegistryWorker.GetSignature(SystemInfo.Information);

				if ( rSACryptoServiceProvider.VerifyData(systemInfo, CryptoConfig.MapNameToOID(HashAlgorithmName.SHA1.Name), signedData) )
					{
					return;
					}
				else
					{
					MessageBox.Show("ERROR: program safety corrupted");
					Application.Exit();
					}
				}
			catch
				{
				MessageBox.Show("ERROR: program safety corrupted");
				Application.Exit();
				}
			}
		}
	}
