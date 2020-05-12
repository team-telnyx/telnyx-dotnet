// <copyright file="StringOrObject.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    using System;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// String Or Object.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    internal static class StringOrObject<T>
        where T : IHasId
    {
        /// <summary>
        /// Map.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="updateId">updateId.</param>
        /// <param name="updateObject">updateObject.</param>
        public static void Map(object value, Action<string> updateId, Action<T> updateObject)
        {
            if (value is JObject)
            {
                var item = default(T);
                string objectValue = ((JObject)value).SelectToken("object")?.ToString();
                Type concreteType = TelnyxTypeRegistry.GetConcreteType(typeof(T), objectValue);

                if (concreteType != null)
                {
                    item = (T)((JToken)value).ToObject(concreteType);
                }

                if (item != null)
                {
                    updateId(item.Id);
                    updateObject(item);
                }
                else
                {
                    // We were unable to deserialize the object, but make a last attempt to grab
                    // the ID from the raw JObject.
                    var id = ((JObject)value).SelectToken("id")?.ToString();
                    updateId(id);
                    updateObject(default);
                }
            }
            else if (value is string)
            {
                updateId((string)value);
                updateObject(default);
            }
        }
    }
}
