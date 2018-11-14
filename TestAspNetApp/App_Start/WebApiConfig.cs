using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace TestAspNetApp
{
	public static class WebApiConfig
	{
		public static void Register (HttpConfiguration config)
		{
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			// Middleware example
			config.Filters.Add(new AuthorizationMiddleware());

			// Dependency Injection
			var container = new UnityContainer();
			container.RegisterType<IExampleDependency, ExampleDependency>(new HierarchicalLifetimeManager());
			container.RegisterType<IOtherDependency, OtherDependency>(new HierarchicalLifetimeManager());
			config.DependencyResolver = new UnityResolver(container);
		}
	}
}
