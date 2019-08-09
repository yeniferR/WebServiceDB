using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace connectionDB.APi
{
	public static class Globals
	{
		//public static ProjectionEngine engine { get; set; }
		public static OracleConnection GlobalConnection { get; set; }
		public static string ConnectionString { get; set; }

	}
}
