using Funq;
using ServiceStack;
using connectionDB.ServiceInterface;
using ServiceStack.Api.Swagger;
using System.Configuration;
using connectionDB.APi;
using ServiceStack.OrmLite;
using ServiceStack.Data;
using ServiceStack.Text;
using System;
using System.Globalization;

namespace connectionDB
{
	//VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
	public class AppHost : AppHostBase
	{
		/// <summary>
		/// Base constructor requires a Name and Assembly where web service implementation is located
		/// </summary>
		public AppHost()
			: base("connectionDB", typeof(DatosEquipoServices).Assembly) { }

		/// <summary>
		/// 
		/// Application specific configuration
		/// This method should initialize any IoC resources utilized by your web service classes.
		/// </summary>
		public override void Configure(Container container)
		{
			Plugins.Add(new SwaggerFeature { });
			string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
			JsConfig.ExcludeTypeInfo = true;
			const string FORMAT = "dd/MM/yyyy hh:mm tt";
			JsConfig<DateTime>.SerializeFn = date => date.ToString(FORMAT, CultureInfo.InvariantCulture);
			JsConfig<DateTime>.DeSerializeFn = s => DateTime.ParseExact(s, FORMAT, CultureInfo.InvariantCulture);
			//Config examples
			//this.Plugins.Add(new PostmanFeature());
			//this.Plugins.Add(new CorsFeature());
			SetConfig(new HostConfig
			{
				ApiVersion = "1.2"
			});
			var dbFactory = new OrmLiteConnectionFactory(
					 connStr, ServiceStack.OrmLite.Oracle.OracleDialect.Provider);
			container.Register<IDbConnectionFactory>(
				new OrmLiteConnectionFactory(connStr, ServiceStack.OrmLite.Oracle.OracleDialect.Provider));
			dbFactory.Open();
			Globals.GlobalConnection = new Oracle.ManagedDataAccess.Client.OracleConnection(dbFactory.ConnectionString);
			Globals.ConnectionString = dbFactory.ConnectionString;
			Globals.GlobalConnection.Open();
		}
	}
}