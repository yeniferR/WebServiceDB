using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace connectionDB.ServiceModel
{
	public static class Helper
	{
		public static void OpenDb(OracleConnection Db)
		{
			if (Db == null)
			{
				Db = new Oracle.ManagedDataAccess.Client.OracleConnection(Datos.connectionString);
			}
			if (Db.State == ConnectionState.Closed)
				Db.Open();
		}
		public static void OpenDb(IDbConnection Db)
		{
			if (Db == null)
			{
				Db = new Oracle.ManagedDataAccess.Client.OracleConnection(Datos.connectionString);
			}
			if (Db.State == ConnectionState.Closed)
				Db.Open();
		}
		public static List<T> ToList<T>(this DataTable dataTable)
	where T : class, new()
		{
			var list = new List<T>();
			var typeOfT = typeof(T);
			var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(null);

			foreach (DataRow row in dataTable.Rows)
			{
				var t = new T();
				foreach (DataColumn column in dataTable.Columns)
				{
					var propertyName = column.ColumnName;
					var property = t.GetType().GetProperty(propertyName, BindingFlags.Instance |
																		   BindingFlags.Public |
																		   BindingFlags.IgnoreCase);
					if (property != null)
					{
						if (property.PropertyType.Name == "DateTime")
						{
							DateTime d = Convert.ToDateTime(row[column]);
							property.SetValue(t, d);
						}
						else
						{
								property.SetValue(t, Convert.ChangeType(row[column], property.PropertyType, null));
						}
					}
				}
				list.Add(t);
			}
			return list;
		}

	}

}
