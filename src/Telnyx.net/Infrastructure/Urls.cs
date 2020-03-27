// <copyright file="Urls.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    /// <summary>
    /// Urls
    /// </summary>
    internal static class Urls
    {
        /// <summary>
        /// Gets defaultBaseUrl
        /// </summary>
        internal static string DefaultBaseUrl => "https://api.Telnyx.com/v2";

        /// <summary>
        /// Gets baseUrl
        /// </summary>
        internal static string BaseUrl => TelnyxConfiguration.GetApiBase();

        /// <summary>
        /// Gets defaultBaseConnectUrl
        /// </summary>
        internal static string DefaultBaseConnectUrl => "https://connect.Telnyx.com";

        /// <summary>
        /// Gets baseConnectUrl
        /// </summary>
        internal static string BaseConnectUrl => TelnyxConfiguration.GetConnectBase();

        /// <summary>
        /// Gets defaultBaseFilesUrl
        /// </summary>
        internal static string DefaultBaseFilesUrl => "https://files.Telnyx.com/v1";

        /// <summary>
        /// Gets baseFilesUrl
        /// </summary>
        internal static string BaseFilesUrl => TelnyxConfiguration.GetFilesBase();
    }
}
