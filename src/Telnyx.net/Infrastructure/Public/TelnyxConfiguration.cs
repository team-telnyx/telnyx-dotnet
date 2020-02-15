namespace Telnyx
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
    using Newtonsoft.Json;
    using Telnyx.Infrastructure;

    /// <summary>
    /// Configuration
    /// </summary>
    public static class TelnyxConfiguration
    {
        private static string telnyxApiVersion = "2019-03-14";

        private static string apiKey;
        private static string apiBase;
        private static JsonSerializerSettings serializerSettings = DefaultSerializerSettings();

        static TelnyxConfiguration()
        {
            TelnyxNetVersion = new AssemblyName(typeof(Requestor).GetTypeInfo().Assembly.FullName).Version.ToString(3);
        }

        /// <summary>
        /// Gets or sets TelnyxApiVersion
        /// </summary>
        public static string TelnyxApiVersion
        {
            get { return telnyxApiVersion; }
            set { telnyxApiVersion = value; }
        }

        /// <summary>
        /// Gets or sets the settings used for deserializing JSON objects returned by Telnyx's API.
        /// It is highly recommended you do not change these settings, as doing so can produce
        /// unexpected results. If you do change these settings, make sure that
        /// <see cref="Telnyx.Infrastructure.TelnyxObjectConverter"/> is among the converters,
        /// otherwise the library will no longer be able to deserialize polymorphic resources
        /// represented by interfaces (e.g. ).
        /// </summary>
        public static JsonSerializerSettings SerializerSettings
        {
            get { return serializerSettings; }
            set { serializerSettings = value; }
        }

        /// <summary>
        /// Gets gets or sets TelnyxNetVersion
        /// </summary>
        public static string TelnyxNetVersion { get; }

        /// <summary>
        /// Gets or sets this option allows you to provide your own HttpMessageHandler. Useful with Android/iPhone.
        /// </summary>
        public static HttpMessageHandler HttpMessageHandler { get; set; }

        /// <summary>
        /// Gets or sets TelnyxNetVersion
        /// </summary>
        public static TimeSpan? HttpTimeSpan { get; set; }

        /// <summary>
        /// Gets or sets newApiKey
        /// </summary>
        /// <param name="newApiKey">New Api Key</param>
        public static void SetApiKey(string newApiKey)
        {
            apiKey = newApiKey;
        }

        /// <summary>
        /// SetApiBase
        /// </summary>
        /// <param name="baseUrl">baseUrl</param>
        public static void SetApiBase(string baseUrl)
        {
            apiBase = baseUrl;
        }

        /// <summary>
        /// Returns a new instance of <see cref="Newtonsoft.Json.JsonSerializerSettings"/> with
        /// the default settings used by Telnyx.net.
        /// </summary>
        /// <returns>A <see cref="Newtonsoft.Json.JsonSerializerSettings"/> instance</returns>
        public static JsonSerializerSettings DefaultSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new TelnyxObjectConverter(),
                },
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Get Api Base
        /// </summary>
        /// <returns>apiBase</returns>
        internal static string GetApiBase()
        {
            if (string.IsNullOrEmpty(apiBase))
            {
                apiBase = Urls.DefaultBaseUrl;
            }

            return apiBase;
        }

        /// <summary>
        /// GetApiKey
        /// </summary>
        /// <returns>apiKey</returns>
        internal static string GetApiKey()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
#if NET45
                apiKey = System.Configuration.ConfigurationManager.AppSettings["TelnyxApiKey"];
#else
                apiKey = Environment.GetEnvironmentVariable("TelnyxApiKey");
#endif
            }

            return apiKey;
        }
    }
}
