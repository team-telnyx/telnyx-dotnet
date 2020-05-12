// <copyright file="EpochTime.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    using System;

    /// <summary>
    /// EpochTime.
    /// </summary>
    internal static class EpochTime
    {
        private static DateTime epochStartDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// ConvertEpochToDateTime.
        /// </summary>
        /// <param name="seconds">seconds.</param>
        /// <returns>epoch start date time in seconds.</returns>
        public static DateTime ConvertEpochToDateTime(long seconds)
        {
            return epochStartDateTime.AddSeconds(seconds);
        }

        /// <summary>
        /// ConvertDateTimeToEpoch.
        /// </summary>
        /// <param name="datetime">date time.</param>
        /// <returns>total seconds.</returns>
        public static long ConvertDateTimeToEpoch(this DateTime datetime)
        {
            if (datetime < epochStartDateTime)
            {
                return 0;
            }

            return Convert.ToInt64((datetime.ToUniversalTime() - epochStartDateTime).TotalSeconds);
        }
    }
}
