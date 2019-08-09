using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using connectionDB.ServiceInterface;
using connectionDB.ServiceModel;

namespace connectionDB.Tests
{
	public class UnitTest
	{
		private readonly ServiceStackHost appHost;

		public UnitTest()
		{
			appHost = new BasicAppHost().Init();
			appHost.Container.AddTransient<DatosEquipoServices>();
		}

		[OneTimeTearDown]
		public void OneTimeTearDown() => appHost.Dispose();

		[Test]
		public void Can_call_MyServices()
		{
			var service = appHost.Container.Resolve<DatosEquipoServices>();

			var response = (HelloResponse)service.Any(new Hello { Name = "World" });

			Assert.That(response.Result, Is.EqualTo("Hello, World!"));
		}
	}
}
