namespace Telnyx
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using Telnyx.Infrastructure;

    /// <summary>
    /// Configuration.
    /// </summary>
    public static class TelnyxConfiguration
    {
        private static string telnyxApiVersion = "2019-03-14";

        private static string apiKey;
        private static string apiBase;

        static TelnyxConfiguration()
        {
            TelnyxNetVersion = new AssemblyName(typeof(Requestor).GetTypeInfo().Assembly.FullName).Version.ToString(3);
        }

        /// <summary>
        /// Gets or sets TelnyxApiVersion.
        /// </summary>
        public static string TelnyxApiVersion
        {
            get { return telnyxApiVersion; }
            set { telnyxApiVersion = value; }
        }

        /// <summary>
        /// Gets gets or sets TelnyxNetVersion.
        /// </summary>
        public static string TelnyxNetVersion { get; }

        /// <summary>
        /// Gets or sets this option allows you to provide your own HttpMessageHandler. Useful with Android/iPhone.
        /// </summary>
        public static HttpMessageHandler HttpMessageHandler { get; set; }

        /// <summary>
        /// Gets or sets HttpTimeSpan.
        /// </summary>
        public static TimeSpan? HttpTimeSpan { get; set; }

        /// <summary>
        /// Gets or sets newApiKey.
        /// </summary>
        /// <param name="newApiKey">New Api Key.</param>
        public static void SetApiKey(string newApiKey)
        {
            apiKey = newApiKey;
        }

        /// <summary>
        /// SetApiBase.
        /// </summary>
        /// <param name="baseUrl">baseUrl.</param>
        public static void SetApiBase(string baseUrl)
        {
            apiBase = baseUrl;
        }

        /// <summary>
        /// Get Api Base.
        /// </summary>
        /// <returns>apiBase.</returns>
        internal static string GetApiBase()
        {
            if (string.IsNullOrEmpty(apiBase))
            {
                apiBase = Urls.DefaultBaseUrl;
            }

            return apiBase;
        }

        /// <summary>
        /// GetApiKey.
        /// </summary>
        /// <returns>apiKey.</returns>
        internal static string GetApiKey()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
#if NET45
                apiKey = System.Configuration.ConfigurationManager.AppSettings["TelnyxApiKey"];
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new ApplicationException("There is no app settings for TelynxApiKey. Please double check your web/app.config and continue. Or explicitly set the API key in the constructor");
                }
#else
                apiKey = Environment.GetEnvironmentVariable("TelnyxApiKey");
#endif
            }

            return apiKey;
        }
    }
}
