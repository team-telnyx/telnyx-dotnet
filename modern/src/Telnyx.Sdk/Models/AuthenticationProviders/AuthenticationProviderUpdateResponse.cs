using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

[JsonConverter(typeof(JsonModelConverter<AuthenticationProviderUpdateResponse, AuthenticationProviderUpdateResponseFromRaw>))]
public sealed record class AuthenticationProviderUpdateResponse : JsonModel
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

    public AuthenticationProviderUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderUpdateResponse (
        AuthenticationProviderUpdateResponse authenticationProviderUpdateResponse
    ) : base(authenticationProviderUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderUpdateResponseFromRaw.FromRawUnchecked"/>
    public static AuthenticationProviderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderUpdateResponseFromRaw : IFromRawJson<AuthenticationProviderUpdateResponse>
{
    /// <inheritdoc/>
    public AuthenticationProviderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProviderUpdateResponse.FromRawUnchecked(rawData);
}