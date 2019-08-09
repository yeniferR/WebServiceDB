using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using connectionDB.API;

namespace connectionDB.ServiceModel
{
	public class Datos
	{
		//public const string connectionString = "User Id=giscaribe;Password=gisdesar;Data Source=desarrollo;Pooling=False;Statement Cache Size=20;Self Tuning=false;Persist Security Info=True;";
		public const string connectionString = "User Id=system;Password=manage;Data Source=desarrollo;Pooling=False;Statement Cache Size=20;Self Tuning=false;Persist Security Info=True;";
		public virtual OracleConnection Db { get; set; }

		public DataSet DatosEquipos()
		{
			DataSet resultado = new DataSet();
			using (OracleCommand command = (OracleCommand)Db.CreateCommand())
			{
				Helper.OpenDb(Db);

				command.CommandText = "alter session set nls_date_format='YYYY-MM-DD HH24:MI:SS'";
				command.CommandType = CommandType.Text;
				command.ExecuteNonQuery();
				command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter { ParameterName = "resultado", Value = Oracle.ManagedDataAccess.Types.OracleRefCursor.Null });
				command.Parameters[0].Direction = System.Data.ParameterDirection.Output;

				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "Connectiondb.Result";


				//using (OracleDataReader reader = (OracleDataReader)command.ExecuteReader(CommandBehavior.CloseConnection))
				//{
				//	if (reader.HasRows)
				//	{
				//		DataTable data = new DataTable();
				//		do
				//		{
				//			data = new DataTable();
				//			data.Load(reader);
				//			resultado.Tables.Add(data);
				//		} while (!reader.IsClosed);

				//	}
				//}
				try
				{
					OracleDataReader r = (OracleDataReader)command.ExecuteReader(CommandBehavior.CloseConnection);
					DataTable data = new DataTable();
					int i = 0;
					do
					{
						data = new DataTable();
						data.Load(r);
						switch (i)
						{
							case 0:
								data.TableName = "EQUIPOS";
								break;
			
						}

						resultado.Tables.Add(data);
						i++;
					} while (!r.IsClosed);
				}
				catch (Exception ex)
				{
					resultado = null;
					//mensaje = ex.Message;
				}

				return resultado;
			}

			

		}

		public DataSet ConsulEquipo(string equipo, out string mensaje)
		{
			mensaje = "";
			DataSet resultado = new DataSet();
			Helper.OpenDb(Db);
			using (OracleCommand command = (OracleCommand)Db.CreateCommand())
			{
				Helper.OpenDb(Db);

				command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter { ParameterName = "nombreEquipo", Value = equipo });
				command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter { ParameterName = "resultado", Value = Oracle.ManagedDataAccess.Types.OracleRefCursor.Null });
				command.Parameters[1].Direction = System.Data.ParameterDirection.Output;

				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "Connectiondb.ConsultDatos";
				try
				{
					OracleDataReader r = (OracleDataReader)command.ExecuteReader(CommandBehavior.CloseConnection);
					DataTable data = new DataTable();
					do
					{
						
						data = new DataTable();
						data.Load(r);
						resultado.Tables.Add(data);

					} while (!r.IsClosed);
				}
				catch(Exception ex)
				{
					mensaje = ex.Message;
					return resultado = null;

				}
				return resultado;
			}

			
		}



	 } // final corchete
}
