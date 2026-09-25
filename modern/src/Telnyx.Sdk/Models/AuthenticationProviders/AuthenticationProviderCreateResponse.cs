using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

[JsonConverter(typeof(JsonModelConverter<AuthenticationProviderCreateResponse, AuthenticationProviderCreateResponseFromRaw>))]
public sealed record class AuthenticationProviderCreateResponse : JsonModel
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

    public AuthenticationProviderCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderCreateResponse (
        AuthenticationProviderCreateResponse authenticationProviderCreateResponse
    ) : base(authenticationProviderCreateResponse)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderCreateResponseFromRaw.FromRawUnchecked"/>
    public static AuthenticationProviderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderCreateResponseFromRaw : IFromRawJson<AuthenticationProviderCreateResponse>
{
    /// <inheritdoc/>
    public AuthenticationProviderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProviderCreateResponse.FromRawUnchecked(rawData);
}