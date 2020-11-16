using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace stefanini_e_counter
{
    public class EzPzAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IOptions<ECounterAuthentication> authenticationOptions;

        public EzPzAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IOptions<ECounterAuthentication> authenticationOptions) : base(options, logger, encoder, clock)
        {
            this.authenticationOptions = authenticationOptions;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(Context.Request.Headers.TryGetValue("Authorization", out StringValues values))
            {
                foreach(var authorizationValue in values)
                {
                    if(AuthenticationHeaderValue.TryParse(authorizationValue, out AuthenticationHeaderValue authValue))
                    {
                        if(authValue.Scheme == "Bearer")
                        {
                            if(authValue.Parameter == authenticationOptions.Value.Token)
                                return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new GenericPrincipal(new GenericIdentity("user"), null),"EzPzTokenAuth")));
                        }
                    }
                }
            }
            return Task.FromResult(AuthenticateResult.Fail("No bueno !"));
        }
    }
}