using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Logging;

namespace AuthLib
{
    class ArtifactAuthenticationMiddleware : AuthenticationMiddleware<ArtifactAuthenticationOptions>
    {
        private readonly ILogger _logger;

        public ArtifactAuthenticationMiddleware(OwinMiddleware next, 
                                                IAppBuilder app,
                                                ArtifactAuthenticationOptions options) : base(next, options)
        {
            _logger = app.CreateLogger<ArtifactAuthenticationMiddleware>();

        }

        protected override AuthenticationHandler<ArtifactAuthenticationOptions> CreateHandler()
        {
            return new ArtifactAuthenticationHandler(_logger);
        }
    }
}
