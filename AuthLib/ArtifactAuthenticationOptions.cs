using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLib
{
    public class ArtifactAuthenticationOptions : AuthenticationOptions
    {
        public ArtifactAuthenticationOptions(string authenticationType) : base(authenticationType)
        {
            AuthenticationMode = AuthenticationMode.Passive;
            CallbackPath = new PathString("/signin-artifact");
        }

        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned.
        /// The middleware will process this request when it arrives.
        /// Default value is "/signin-artifact".
        /// </summary>
        public PathString CallbackPath { get; set; }
    }
}
