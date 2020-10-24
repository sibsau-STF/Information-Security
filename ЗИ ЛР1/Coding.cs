using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗИ_ЛР1
{
	public static class Coding
	{
		public static string codingPassword(string password)
		{
			if (password == "") return "";
			string codedPassword = summStringsBytes("12345678", getGammirString(password, 8));
			return codedPassword;
		}

		static string summStringsBytes(string s1, string s2)
		{
			if (s1.Length == s2.Length)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < s1.Length; i++)
				{
					stringBuilder.Append(Convert.ToChar(s1[i] + s2[0]));
				}
				return stringBuilder.ToString();
			}
			else
			{
				MessageBox.Show("Неизвестная ошибка кодирования");
				return null;
			}
		}

		static string getGammirString(string password, int length)
		{
			if (password.Length < 3)
			{
				MessageBox.Show("Неизвестная ошибка кодирования");
				Application.Exit();
			}
			StringBuilder stringBuilder = new StringBuilder();
			char lastGamma = password[2];
			char A = password[0];
			char C = password[1];			
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(lastGamma);
				lastGamma = Convert.ToChar((Convert.ToInt32(A) * Convert.ToInt32(lastGamma) + Convert.ToInt32(C)) % 256);				
			}
			return stringBuilder.ToString();
		}
	}
}
