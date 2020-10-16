using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Installer
	{
	public class SystemInfo
		{
		public enum KeyboardInfoKey
			{
			KeyboardType = 0,
			KeyboardSubtype = 1,
			FuncKeys = 2
			}

		[DllImport("user32.dll", EntryPoint = "GetKeyboardType")]
		static extern int GetKeyboardType (int nTypeFlag);

		[Serializable]
		public struct SystemInfoDumb
			{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
			public string UserName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
			public string ComputerName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string OSPath;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
			public string SystemPath;

			public int MonitorWidth;

			public long DriveMemory;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
			public string ProgramRootDir;

			public int KeyboardType;

			public int KeyboardSubType;

			public static bool operator == (SystemInfoDumb dumb1, SystemInfoDumb dumb2)
				{
				return dumb1.UserName == dumb2.UserName &&
					dumb1.ComputerName == dumb2.ComputerName &&
					dumb1.OSPath == dumb2.OSPath &&
					dumb1.SystemPath == dumb2.SystemPath &&
					dumb1.MonitorWidth == dumb2.MonitorWidth &&
					dumb1.DriveMemory == dumb2.DriveMemory &&
					dumb1.ProgramRootDir == dumb2.ProgramRootDir &&
					dumb1.KeyboardType == dumb2.KeyboardType &&
					dumb1.KeyboardSubType == dumb2.KeyboardSubType;
				}

			public static bool operator != (SystemInfoDumb dumb1, SystemInfoDumb dumb2)
				{
				return !( dumb1 == dumb2 );
				}

			public byte[] Serialize ()
				{
				int size = Marshal.SizeOf(this);
				byte[] arr = new byte[size];

				IntPtr ptr = Marshal.AllocHGlobal(size);
				Marshal.StructureToPtr(this, ptr, true);
				Marshal.Copy(ptr, arr, 0, size);
				Marshal.FreeHGlobal(ptr);
				return arr;
				}
			}

		static SystemInfoDumb info = new SystemInfoDumb()
			{
			UserName = UserName,
			ComputerName = ComputerName,
			OSPath = OSPath,
			SystemPath = SystemPath,
			DriveMemory = DriveMemory,
			MonitorWidth = MonitorWidth,
			ProgramRootDir = ProgramRootDir,
			KeyboardType = KeyboardType,
			KeyboardSubType = KeyboardSubType
			};

		public static SystemInfoDumb Information => info;

		public static string UserName => SystemInformation.UserName;

		public static string ComputerName => SystemInformation.ComputerName;

		public static string OSPath => Environment.SystemDirectory;

		public static string SystemPath => Directory.GetParent((Environment.SystemDirectory)).FullName;

		public static int MonitorWidth => SystemInformation.VirtualScreen.Width; //Screen.PrimaryScreen.Bounds.Width;

		public static long DriveMemory => new DriveInfo(ProgramRootDir).TotalSize;

		public static string ProgramRootDir => Path.GetPathRoot(Environment.CurrentDirectory);

		public static int KeyboardType => GetKeyboardType((int)KeyboardInfoKey.KeyboardType);

		public static int KeyboardSubType => GetKeyboardType((int)KeyboardInfoKey.KeyboardSubtype);

		}
	}
