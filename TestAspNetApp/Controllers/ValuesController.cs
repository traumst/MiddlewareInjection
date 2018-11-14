using System;
using System.Collections.Generic;
using System.Web.Http;

namespace TestAspNetApp.Controllers
{
	public class ValuesController : ApiController
	{
		/// <summary>
		/// Dependency to be injected
		/// </summary>
		IExampleDependency _dependency;

		/// <summary>
		/// Constructor injection
		/// </summary>
		public ValuesController (IExampleDependency dependency)
		{
			_dependency = dependency;
		}

		// GET api/values
		public IEnumerable<string> Get ()
		{
			var result = _dependency.ExampleMethod("Alex");

			string userid = "DID NOT WORK!";

			bool parsed = Request.Properties.TryGetValue("userid", out object tmpUser);
			if (parsed)
				userid = tmpUser as string;


			return new string[] { result, userid };
		}
	}
}
