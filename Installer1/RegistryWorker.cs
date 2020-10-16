using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Installer
	{
	public static class RegistryWorker
		{
		public static void WriteSignature (byte[] key)
			{
			var HKEY = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("Frolov D.A.", true);
			HKEY.SetValue("Signature", key);
			}

		public static byte[] ReadSignature ()
			{
			return (byte[])Registry.CurrentUser.OpenSubKey("Software")
				.OpenSubKey("Frolov D.A.").GetValue("Signature");
			}

		public static byte[] GetSignature (SystemInfo.SystemInfoDumb dumb)
			{
			byte[] arr = dumb.Serialize();
			byte[] hash = SHA1.Create().ComputeHash(arr);
			return hash;
			}
		}
	}
