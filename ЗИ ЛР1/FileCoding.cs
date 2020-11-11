using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗИ_ЛР1
{
	class FileCoding
	{
		public FileCoding(Form form)
		{
			try
			{
				RSAParameters publicKey = JsonConvert.DeserializeObject<RSAParameters>(File.ReadAllText("openKey.json"));
				RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
				rSACryptoServiceProvider.ImportParameters(publicKey);
				byte[] signedData = (byte[])Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Statnikov A.S.").GetValue("Signature");
				byte[] systemInfo = Encoding.ASCII.GetBytes(new SystemInfo().getTotalInfo());
				if (rSACryptoServiceProvider.VerifyData(systemInfo, CryptoConfig.MapNameToOID(HashAlgorithmName.MD5.Name), signedData))
				{
					ConfirmPasswordForm confirmPasswordForm = new ConfirmPasswordForm("Введите контрольную фразу");
					if (confirmPasswordForm.ShowDialog() == DialogResult.OK)
					{
						try
						{
							DecodeFile("usersCoded", "users", MD4(Encoding.ASCII.GetBytes(confirmPasswordForm.password)));
							File.Delete("usersCoded");
							form.ShowDialog();
							CodeFile("users", "usersCoded", MD4(Encoding.ASCII.GetBytes(confirmPasswordForm.password)));
							File.Delete("users");
						}
						catch
						{
							MessageBox.Show("Ошибка контрольной фразы");
							Application.Exit();
						}
					}
				}
				else
				{
					MessageBox.Show("Ошибка: несанкционировнное копирование");
					Application.Exit();
				}
			}
			catch
			{
				MessageBox.Show("Ошибка: несанкционировнное копирование");
				Application.Exit();
			}
		}

		byte[] MD4(byte[] input)
		{
			//TODO: MD4
			return MD5.Create().ComputeHash(input);
		}

		public void CodeFile(string filePathFrom, string filePathTo, byte[] key)
		{
			if (File.Exists(filePathFrom))
			{				
				File.WriteAllBytes(filePathTo, codeBytes(File.ReadAllBytes(filePathFrom), key));
			}
			else
			{
				MessageBox.Show("Ошибка кодирования данных при сохранении");
			}
		}

		public void DecodeFile(string filePathFrom, string filePathTo, byte[] key)
		{
			if (File.Exists(filePathFrom))
			{
				File.WriteAllBytes(filePathTo, decodeBytes(File.ReadAllBytes(filePathFrom), key));
			}
		}

		byte[] codeBytes(byte[] array, byte[] key)
		{
			AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();
			cryptoProvider.Mode = CipherMode.CBC;
			cryptoProvider.IV = key;
			cryptoProvider.Key = key;
			var enctyptor = cryptoProvider.CreateEncryptor();
			return enctyptor.TransformFinalBlock(array, 0, array.Length);
		}

		byte[] decodeBytes(byte[] array, byte[] key)
		{
			AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();
			cryptoProvider.Mode = CipherMode.CBC;
			cryptoProvider.IV = key;
			cryptoProvider.Key = key;
			var dectyptor = cryptoProvider.CreateDecryptor();
			return dectyptor.TransformFinalBlock(array, 0, array.Length);
		}
	}
}
