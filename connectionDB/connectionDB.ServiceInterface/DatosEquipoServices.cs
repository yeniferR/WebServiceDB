using ServiceStack;
using connectionDB.APi;
using connectionDB.ServiceModel;
using System.Data;

namespace connectionDB.ServiceInterface
{
	public class DatosEquipoServices : Service
	{
		public object Any(DatosEquipoRequest request)
		{
			Datos c = new Datos();
			c.Db = Globals.GlobalConnection;
			var r = c.DatosEquipos();
			if (r.Tables.Count > 0)
			{
		
				TipoEquipos ti = new TipoEquipos();
				ti.Equipos = r.Tables[0].ToList<DatosEquipo>();

				return ti;
			} else
			{
				return new ServiceModel.ErrorResponse
				{

					Message = "No hay datos"
				};
			}
		

		}

		public object Any(ConsultaEquipo request)
		{
			Datos c = new Datos();
			c.Db = Globals.GlobalConnection;
			string mensaje = "";
			var r = c.ConsulEquipo( request.Result ,out mensaje);
			if (r.Tables.Count >0)
			{
				TipoEquipos ti = new TipoEquipos();
				ti.Equipos = r.Tables[0].ToList<DatosEquipo>();

				return ti;
			}
			else
			{
				return new ServiceModel.ErrorResponse
				{

					Message = "No hay datos"
				};
			}
			
		}

	}



}