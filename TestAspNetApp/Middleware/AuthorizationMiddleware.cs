using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace TestAspNetApp
{
	public class Principal : System.Security.Principal.IPrincipal
	{
		public IIdentity Identity { get; }

		public bool IsInRole (string role)
		{
			if (String.IsNullOrEmpty(role))
				return false;
			return true;
		}
	}

	public class AuthorizationMiddleware : ActionFilterAttribute, IAuthenticationFilter
	{
		private bool _auth;

		List<string> users = new List<string>{
			"alex", "admin"
		};

		public Task AuthenticateAsync (HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			var request = context.Request;

			IEnumerable<string> authValues = new List<string>();
			_auth = context.ActionContext.Request.Headers.TryGetValues("auth", out authValues);
			//_auth = context.ActionContext.RequestContext

			string user = String.Empty;
			foreach (string val in authValues)
			{
				if (users.Contains(val))
				{
					user = Guid.NewGuid().ToString();
					context.Request.Properties.Add("userid", user);
					break;
				}
			}

			if (String.IsNullOrEmpty(user))
			{
				context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
			}

			return Task.FromResult(0);
		}

		public Task ChallengeAsync (HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			var challenge = new AuthenticationHeaderValue("Basic");
			context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
			return Task.FromResult(0);
		}

	}
}