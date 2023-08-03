// <copyright file="TelnyxMockFixture.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Extensions.Configuration;
    using Telnyx;

    public class TelnyxMockFixture : IDisposable
    {
        /// <value>Minimum required version of Telnyx-mock.</value>
        /// <remarks>
        /// If you bump this, don't forget to bump `Telnyx_MOCK_VERSION` in `appveyor.yml` as well.
        /// </remarks>
        private const string MockMinimumVersion = "0.1.0";

        private readonly string origApiBase;
        private readonly string origApiKey;
        private readonly string telnyx_api_key;
        private readonly string port;

        public TelnyxMockFixture()
        {
            if (TelnyxMockHandler.StartTelnyxMock())
            {
                this.port = TelnyxMockHandler.Port.ToString();
            }
            else
            {
                this.port = Environment.GetEnvironmentVariable("TELNYX_MOCK_PORT") ?? "12111";
            }

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            this.telnyx_api_key = config["TelnyxApiKey"];
            if (string.IsNullOrEmpty(this.telnyx_api_key))
            {
                this.telnyx_api_key = Environment.GetEnvironmentVariable("TelnyxApiKey");
            }
            else
            {
                Environment.SetEnvironmentVariable("TelnyxApiKey", this.telnyx_api_key);
            }

            //this.EnsureTelnyxMockMinimumVersion();

            this.origApiBase = TelnyxConfiguration.GetApiBase();
            this.origApiKey = TelnyxConfiguration.GetApiKey();

            TelnyxConfiguration.SetApiBase($"http://localhost:{this.port}/v2");
            TelnyxConfiguration.SetApiKey(this.telnyx_api_key);
        }

        public virtual void Dispose()
        {
            TelnyxConfiguration.SetApiBase(this.origApiBase);
            TelnyxConfiguration.SetApiKey(this.origApiKey);

            TelnyxMockHandler.StopTelnyxMock();
        }

        /// <summary>
        /// Gets fixture data with expansions specified.
        /// Use the special <c>*</c> character to specify that all fields should be
        /// expanded.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for telnyx-mock.</param>
        /// <param name="expansions">Set of expansions that should be applied.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        public string GetFixture(string path, string[] expansions = null)
        {
            string url = $"http://localhost:{this.port}{path}";

            if (expansions != null)
            {
                string query = string.Join("&", expansions.Select(x => $"expand[]={x}").ToArray());
                url += $"?{query}";
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        this.telnyx_api_key);

                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new TelnyxTestException(
                        $"Couldn't reach telnyx-mock at `localhost:{this.port}`. "
                        + "Is it running? Please see README for setup instructions.");
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new TelnyxTestException(
                        $"telnyx-mock returned status code: {response.StatusCode}.");
                }

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Compares two version strings.
        /// </summary>
        /// <param name="a">A version string (e.g. "1.2.3").</param>
        /// <param name="b">Another version string.</param>
        /// <returns>-1 if a > b, 1 if a. < b, 0 if a == b</returns>
        private static int CompareVersions(string a, string b)
        {
            var version1 = new Version(a);
            var version2 = new Version(b);
            return version2.CompareTo(version1);
        }

        private void EnsureTelnyxMockMinimumVersion()
        {
            string url = $"http://localhost:{this.port}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new TelnyxTestException(
                        $"Couldn't reach Telnyx-mock at `localhost:{this.port}`. "
                        + "Is it running? Please see README for setup instructions.");
                }

                string version = response.Headers.GetValues("Telnyx-Mock-Version").FirstOrDefault();

                if (!version.Equals("master") &&
                    (CompareVersions(version, MockMinimumVersion) > 0))
                {
                    throw new TelnyxTestException(
                        $"Your version of telnyx-mock ({version}) is too old. The minimum "
                        + $"version to run this test suite is {MockMinimumVersion}. Please see its "
                        + "repository for upgrade instructions.");
                }
            }
        }
    }
}
