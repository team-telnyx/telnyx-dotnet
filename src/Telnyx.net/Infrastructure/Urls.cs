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
        internal static string DefaultBaseUrl => "https://api.telnyx.com/v2";

        /// <summary>
        /// Gets baseUrl
        /// </summary>
        internal static string BaseUrl => TelnyxConfiguration.GetApiBase();
    }
}
