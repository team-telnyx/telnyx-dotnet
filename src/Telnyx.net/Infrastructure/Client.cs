// <copyright file="Client.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
#if NET45
    using System;
    using System.Reflection;
#endif
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Runtime.InteropServices;
    using Newtonsoft.Json;

    /// <summary>
    /// Client.
    /// </summary>
    internal class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="requestMessage">Request Message.</param>
        public Client(HttpRequestMessage requestMessage)
        {
            this.RequestMessage = requestMessage;
        }

        private HttpRequestMessage RequestMessage { get; set; }

        /// <summary>
        /// Apply user agent.
        /// </summary>
        public void ApplyUserAgent()
        {
            this.RequestMessage.Headers.UserAgent.ParseAdd($"Telnyx/v1 .NetBindings/{TelnyxConfiguration.TelnyxNetVersion}");
        }

        /// <summary>
        /// Apply client data.
        /// </summary>
        public void ApplyClientData()
        {
            this.RequestMessage.Headers.Add("X-Telnyx-Client-User-Agent", this.GetClientUserAgentString());
        }

#if NET45
        private static string GetMonoVersion()
        {
            Type monoRuntimeType = typeof(object).Assembly.GetType("Mono.Runtime");

            if (monoRuntimeType != null)
            {
                MethodInfo getDisplayNameMethod = monoRuntimeType.GetMethod(
                    "GetDisplayName",
                    BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.ExactBinding,
                    null,
                    Type.EmptyTypes,
                    null);

                if (getDisplayNameMethod != null)
                {
                    return (string)getDisplayNameMethod.Invoke(null, null);
                }
            }

            return null;
        }
#endif

        private string GetClientUserAgentString()
        {
            var values = new Dictionary<string, string>
            {
                { "bindings_version", TelnyxConfiguration.TelnyxNetVersion },
                { "lang", ".net" },
                { "publisher", "Telnyx" },
            };

#if NET45
            values.Add("lang_version", ".NET Framework 4.5+");
            values.Add("os_version", Environment.OSVersion.ToString());

            string monoVersion = Client.GetMonoVersion();
            if (monoVersion != null)
            {
                values.Add("mono_version", monoVersion);
            }
#else
            values.Add("lang_version", RuntimeInformation.FrameworkDescription);
            values.Add("os_version", RuntimeInformation.OSDescription);
#endif
            return JsonConvert.SerializeObject(values, Formatting.None);
        }
    }
}
