// <copyright file="ParameterBuilder.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Telnyx.Infrastructure.Middleware;
    using Telnyx.net.Services;

    /// <summary>
    /// ParameterBuilder.
    /// </summary>
    internal static class ParameterBuilder
    {
        /// <summary>
        /// ApplyAllParameters.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="service">service.</param>
        /// <param name="obj">obj.</param>
        /// <param name="url">url.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <returns>requestString.</returns>
        public static string ApplyAllParameters<T>(this Service<T> service, BaseOptions obj, string url, bool isListMethod = false)
            where T : ITelnyxEntity
        {
            // store the original url from the service call into requestString (e.g. https://api.Telnyx.com/v1/accounts/account_id)
            // before the Telnyx attributes get applied. all of the attributes that will get passed to Telnyx will be applied to this string,
            // don't worry - if the request is a post, the Requestor will take care of moving the attributes to the post body
            var requestString = url;

            // obj = the options object passed from the service
            if (obj != null)
            {
                // Normalize extra params for json serialization
                if (obj.ExtraParams != null && !obj.ExtraParams.Any())
                {
                    obj.ExtraParams = null;
                }

                // Normalize expand for json serialization
                if (obj.Expand != null && !obj.Expand.Any())
                {
                    obj.Expand = null;
                }

                RequestStringBuilder.CreateQuery(ref requestString, obj);

                if (obj.ExtraParams != null)
                {
                    foreach (KeyValuePair<string, string> pair in obj.ExtraParams)
                    {
                        var key = WebUtility.UrlEncode(pair.Key);
                        RequestStringBuilder.ApplyParameterToRequestString(ref requestString, key, pair.Value);
                    }
                }

                if (obj.Expand != null)
                {
                    foreach (var value in obj.Expand)
                    {
                        RequestStringBuilder.ApplyParameterToRequestString(ref requestString, "expand[]", value);
                    }
                }
            }

            if (service != null)
            {
                // expandable properties
                var propertiesToExpand = service.GetType()
                    .GetRuntimeProperties()
                    .Where(p => p.Name.StartsWith("Expand") && p.PropertyType == typeof(bool))
                    .Where(p => (bool)p.GetValue(service, null))
                    .Select(p => p.Name);

                foreach (var propertyName in propertiesToExpand)
                {
                    string expandPropertyName = propertyName.Substring("Expand".Length);
                    expandPropertyName = Regex.Replace(expandPropertyName, "([a-z])([A-Z])", "$1_$2").ToLower();

                    if (isListMethod)
                    {
                        expandPropertyName = "data." + expandPropertyName;
                    }

                    requestString = ApplyParameterToUrl(requestString, "expand[]", expandPropertyName);
                }
            }

            return requestString;
        }

        /// <summary>
        /// ApplyParameterToUrl.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="argument">argument.</param>
        /// <param name="value">value.</param>
        /// <returns>url string.</returns>
        public static string ApplyParameterToUrl(string url, string argument, string value)
        {
            RequestStringBuilder.ApplyParameterToRequestString(ref url, argument, value);

            return url;
        }

        /// <summary>
        /// ApplyAllParameters.
        /// </summary>
        /// <param name="service">service.</param>
        /// <param name="obj">obj.</param>
        /// <param name="url">url.</param>
        /// <param name="isListMethod">isListMethod.</param>
        /// <returns>requestString.</returns>
        public static string ApplyAllParameters(this FileService service, BaseOptions obj, string url, bool isListMethod = false)
        {
            // store the original url from the service call into requestString (e.g. https://api.Telnyx.com/v1/accounts/account_id)
            // before the Telnyx attributes get applied. all of the attributes that will get passed to Telnyx will be applied to this string,
            // don't worry - if the request is a post, the Requestor will take care of moving the attributes to the post body
            var requestString = url;

            // obj = the options object passed from the service
            if (obj != null)
            {
                // Normalize extra params for json serialization
                if (obj.ExtraParams != null && !obj.ExtraParams.Any())
                {
                    obj.ExtraParams = null;
                }

                // Normalize expand for json serialization
                if (obj.Expand != null && !obj.Expand.Any())
                {
                    obj.Expand = null;
                }

                RequestStringBuilder.CreateQuery(ref requestString, obj);

                if (obj.ExtraParams != null)
                {
                    foreach (KeyValuePair<string, string> pair in obj.ExtraParams)
                    {
                        var key = WebUtility.UrlEncode(pair.Key);
                        RequestStringBuilder.ApplyParameterToRequestString(ref requestString, key, pair.Value);
                    }
                }

                if (obj.Expand != null)
                {
                    foreach (var value in obj.Expand)
                    {
                        RequestStringBuilder.ApplyParameterToRequestString(ref requestString, "expand[]", value);
                    }
                }
            }

            if (service != null)
            {
                // expandable properties
                var propertiesToExpand = service.GetType()
                    .GetRuntimeProperties()
                    .Where(p => p.Name.StartsWith("Expand") && p.PropertyType == typeof(bool))
                    .Where(p => (bool)p.GetValue(service, null))
                    .Select(p => p.Name);

                foreach (var propertyName in propertiesToExpand)
                {
                    string expandPropertyName = propertyName.Substring("Expand".Length);
                    expandPropertyName = Regex.Replace(expandPropertyName, "([a-z])([A-Z])", "$1_$2").ToLower();

                    if (isListMethod)
                    {
                        expandPropertyName = "data." + expandPropertyName;
                    }

                    requestString = ApplyParameterToUrl(requestString, "expand[]", expandPropertyName);
                }
            }

            return requestString;
        }
    }
}
