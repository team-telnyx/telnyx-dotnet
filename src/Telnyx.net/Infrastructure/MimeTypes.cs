// <copyright file="MimeTypes.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace Telnyx.Infrastructure
{
    using System.IO;

    /// <summary>
    /// Mime Types.
    /// </summary>
    internal static class MimeTypes
    {
        /// <summary>
        /// GetMimeType.
        /// </summary>
        /// <param name="fileName">fileName.</param>
        /// <returns>mime type.</returns>
        public static string GetMimeType(string fileName)
        {
            switch (Path.GetExtension(fileName.ToLowerInvariant()))
            {
                case ".jpeg":
                case ".jpg":
                    return "image/jpeg";

                case ".pdf":
                    return "application/pdf";

                case ".png":
                    return "image/png";

                default:
                    return "application/octet-stream";
            }
        }
    }
}
