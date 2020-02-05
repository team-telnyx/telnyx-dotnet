// <copyright file="TelnyxTestException.cs" company="Telnyx">
// Copyright (c) Telnyx. All rights reserved.
// </copyright>

namespace TelnyxTests
{
    using System;

    /// <summary>
    /// Represents errors that are related to tests themselves rather than the
    /// features under test.
    /// </summary>
    public class TelnyxTestException : Exception
    {
        public TelnyxTestException()
        {
        }

        public TelnyxTestException(string message)
            : base(message)
        {
        }
    }
}
