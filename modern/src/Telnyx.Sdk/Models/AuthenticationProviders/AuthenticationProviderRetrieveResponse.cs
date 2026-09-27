using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

[JsonConverter(typeof(JsonModelConverter<AuthenticationProviderRetrieveResponse, AuthenticationProviderRetrieveResponseFromRaw>))]
public sealed record class AuthenticationProviderRetrieveResponse : JsonModel
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

    public AuthenticationProviderRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderRetrieveResponse (
        AuthenticationProviderRetrieveResponse authenticationProviderRetrieveResponse
    ) : base(authenticationProviderRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AuthenticationProviderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderRetrieveResponseFromRaw : IFromRawJson<AuthenticationProviderRetrieveResponse>
{
    /// <inheritdoc/>
    public AuthenticationProviderRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProviderRetrieveResponse.FromRawUnchecked(rawData);
}