using System;

namespace Telnyx.Sdk.Core;

readonly record struct SecurityOptions
{
    public SecurityOptions ()
    {   }

    public Boolean Payment { get; init; } = false;

    public Boolean BearerAuth { get; init; } = false;

    public Boolean OAuthClientAuth { get; init; } = false;

    public static SecurityOptions All()
    =>new()
    {
        Payment = true,
        BearerAuth = true,
        OAuthClientAuth = true,
    };
}