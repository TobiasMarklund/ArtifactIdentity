using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Logging;

namespace AuthLib
{
    class ArtifactAuthenticationHandler : AuthenticationHandler<ArtifactAuthenticationOptions>
    {
        private ILogger _logger;

        public ArtifactAuthenticationHandler(ILogger _logger)
        {
            this._logger = _logger;
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            try
            {
                // Get
                return null;
            } catch (Exception ex)
            {
                _logger.WriteError("Authentication failed", ex);
                return null;
            }
        }

        public override async Task<bool> InvokeAsync()
        {
            return await InvokeReplyPathAsync();
        }

        private async Task<bool> InvokeReplyPathAsync()
        {
            if (Options.CallbackPath.HasValue && Options.CallbackPath == Request.Path)
            {
                var ticket = await AuthenticateAsync();
                if (ticket == null)
                {
                    _logger.WriteWarning("Invalid artifact");
                    Response.StatusCode = 500;
                    return true;
                }

                Response.Redirect("...");
                return true;
            }

            return false;
        }
    }
}
