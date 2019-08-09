using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace connectionDB.ServiceModel
{
	[Api("Datos de mi paquete conexion")]
	[Route("/Datos/equipos","GET")]
	public class DatosEquipoRequest
	{
		//public string Result { get; set; }

	}

	[Api("Datos de mi paquete conexio")]
	[Route("/Datos/ConsultaEquipos", "GET")]

	public class ConsultaEquipo
	{
		public string Result { get; set; }
	}
}