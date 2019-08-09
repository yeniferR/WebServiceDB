using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace connectionDB.ServiceModel
{


	//[DataContract]

    public class DatosEquipo
	{
	 // [DataMember]
		public string NOMBRE { get; set; }
	//	[DataMember]
		public string CIUDAD { get; set; }
	//	[DataMember]
		public string CONFERENCIA { get; set; }
	//	[DataMember]
		public string DIVISION { get; set; }

	}
	public class ResultEquipo
	{
		public string NOMBRE { get; set; }
		//	[DataMember]
		public string CIUDAD { get; set; }
		//	[DataMember]
		public string CONFERENCIA { get; set; }
		//	[DataMember]
		public string DIVISION { get; set; }
	}
	public  class ResulTConsultEquipo
	{
		public List<ResultEquipo> DatoEquipos { get; set; }
	}
	public class TipoEquipos
	{
		//[DataMember]
		public List<DatosEquipo> Equipos { get; set; }
	}
}
