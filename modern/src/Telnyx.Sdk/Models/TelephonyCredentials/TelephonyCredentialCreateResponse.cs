using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TelephonyCredentials;

[JsonConverter(typeof(JsonModelConverter<TelephonyCredentialCreateResponse, TelephonyCredentialCreateResponseFromRaw>))]
public sealed record class TelephonyCredentialCreateResponse : JsonModel
{
    public TelephonyCredential? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelephonyCredential>(
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

    public TelephonyCredentialCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonyCredentialCreateResponse (
        TelephonyCredentialCreateResponse telephonyCredentialCreateResponse
    ) : base(telephonyCredentialCreateResponse)
    {  }
    #pragma warning restore CS8618

    public TelephonyCredentialCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonyCredentialCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonyCredentialCreateResponseFromRaw.FromRawUnchecked"/>
    public static TelephonyCredentialCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonyCredentialCreateResponseFromRaw : IFromRawJson<TelephonyCredentialCreateResponse>
{
    /// <inheritdoc/>
    public TelephonyCredentialCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonyCredentialCreateResponse.FromRawUnchecked(rawData);
}