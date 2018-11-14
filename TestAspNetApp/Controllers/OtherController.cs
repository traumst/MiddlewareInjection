using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestAspNetApp.Controllers
{
    public class OtherController : ApiController
	{
		/// <summary>
		/// Dependency to be injected
		/// </summary>
		IOtherDependency _dependency;

		/// <summary>
		/// Constructor injection
		/// </summary>
		public OtherController (IOtherDependency dependency)
		{
			_dependency = dependency;
		}

		// GET api/other
		public string Get ()
		{
			var result = _dependency.ExampleMethod("Alex");

			return result;
		}
	}
}
