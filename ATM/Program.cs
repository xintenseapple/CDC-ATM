using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
	static class Program
	{
		public static SqlConnection connection;
		public static string rabbitmqIP;
		public static string rabbitUser;
		public static string rabbitPass;
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string cs = "";
			Jason json = JsonConvert.DeserializeObject<Jason>(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "globalConfig.json")));


			cs = json.sqlInfo.ToString();
			rabbitmqIP = json.rabbitIP.ToString();
			rabbitUser = json.rabbitUser.ToString();
			rabbitPass = json.rabbitPass.ToString();

			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			connection = new SqlConnection(cs);
			Application.Run(new Form1());


		}
		public class Jason
		{
			public string rabbitIP { get; set; }
			public string sqlInfo { get; set; }
			public string rabbitUser { get; set; }
			public string rabbitPass { get; set; }
		}
	}
}
