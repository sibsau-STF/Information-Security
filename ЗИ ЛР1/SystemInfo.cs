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

		string getDriveNameOfProgrammPath()
		{
			string currentDrive = Path.GetPathRoot(Environment.CurrentDirectory);
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				if (currentDrive == drive.Name)
					if (drive.VolumeLabel != "")
						return drive.VolumeLabel;
					else
						return drive.Name;
			}
			return "Ошибка сканирования дисков";
		}

		public string getTotalInfo()
		{
			return getMouseButtonCount() + " " + getHeightOfScreen() + " " + getMemoryCount() + " " + getDriveNameOfProgrammPath();
		}

		public string getTotalInfoHash()
		{
			return Encoding.ASCII.GetString(MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(getTotalInfo())));
		}
	}
}
