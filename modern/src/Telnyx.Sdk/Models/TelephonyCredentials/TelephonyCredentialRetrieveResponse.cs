using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TelephonyCredentials;

[JsonConverter(typeof(JsonModelConverter<TelephonyCredentialRetrieveResponse, TelephonyCredentialRetrieveResponseFromRaw>))]
public sealed record class TelephonyCredentialRetrieveResponse : JsonModel
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

    public TelephonyCredentialRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonyCredentialRetrieveResponse (
        TelephonyCredentialRetrieveResponse telephonyCredentialRetrieveResponse
    ) : base(telephonyCredentialRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public TelephonyCredentialRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonyCredentialRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonyCredentialRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TelephonyCredentialRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonyCredentialRetrieveResponseFromRaw : IFromRawJson<TelephonyCredentialRetrieveResponse>
{
    /// <inheritdoc/>
    public TelephonyCredentialRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonyCredentialRetrieveResponse.FromRawUnchecked(rawData);
}