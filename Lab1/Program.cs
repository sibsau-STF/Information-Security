using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
	{
	static class Program
		{
		static AdminPassword passwordForm;
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ()
			{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			passwordForm = new AdminPassword();
			Application.ApplicationExit += new EventHandler(exitApp);
			Application.Run(passwordForm);
			}


		private static void exitApp (object sender, EventArgs e)
			{
			if ( passwordForm.Password!= null && passwordForm.Password.Length > 0 )
				Encoder.ApplyEncoding("users.json", passwordForm.Password, true);
			}
		}
	}
