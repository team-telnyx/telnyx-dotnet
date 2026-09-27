using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

[JsonConverter(typeof(JsonModelConverter<AuthenticationProviderDeleteResponse, AuthenticationProviderDeleteResponseFromRaw>))]
public sealed record class AuthenticationProviderDeleteResponse : JsonModel
{
    public AuthenticationProvider? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AuthenticationProvider>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public AuthenticationProviderDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderDeleteResponse (
        AuthenticationProviderDeleteResponse authenticationProviderDeleteResponse
    ) : base(authenticationProviderDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AuthenticationProviderDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderDeleteResponseFromRaw : IFromRawJson<AuthenticationProviderDeleteResponse>
{
    /// <inheritdoc/>
    public AuthenticationProviderDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProviderDeleteResponse.FromRawUnchecked(rawData);
}