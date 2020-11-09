using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ЗИ_ЛР1
{
	class SystemInfo
	{
		[DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
		static extern int GetSystemMetrics(int nTypeFlag);

		string getMouseButtonCount()
		{
			return GetSystemMetrics(43).ToString();
		}

		string getHeightOfScreen()
		{
			return SystemInformation.VirtualScreen.Height.ToString();
		}

		string getMemoryCount()
		{
			var wmiObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

			var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new
			{
				TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
			}).FirstOrDefault();

			return ((int)memoryValues.TotalVisibleMemorySize / 1024).ToString();
		}

		public string path;

		string getDriveNameOfProgrammPath()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				if (Path.GetPathRoot(path) == drive.Name && drive.IsReady)
					if (drive.VolumeLabel != "")
						return drive.VolumeLabel;
					else
						return drive.Name;
			}
			return "Ошибка сканирования диска";
		}

		public string getTotalInfo()
		{
			return getMouseButtonCount() + " " + getHeightOfScreen() + " " + getMemoryCount() + " " + getDriveNameOfProgrammPath();
		}

		public string getTotalInfoToUser()
		{
			return "Количество кнопок мыши: " + getMouseButtonCount() + "\r\nВысота экрана: " + getHeightOfScreen() + "\r\nКоличество оперативной памяти: " + getMemoryCount() + "\r\nМетка тома: " + getDriveNameOfProgrammPath();
		}

		public string getTotalInfoHash()
		{
			return Encoding.ASCII.GetString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(getTotalInfo())));
		}
	}
}
