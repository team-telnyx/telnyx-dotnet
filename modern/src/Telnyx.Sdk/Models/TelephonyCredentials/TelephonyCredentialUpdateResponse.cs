using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TelephonyCredentials;

[JsonConverter(typeof(JsonModelConverter<TelephonyCredentialUpdateResponse, TelephonyCredentialUpdateResponseFromRaw>))]
public sealed record class TelephonyCredentialUpdateResponse : JsonModel
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

    public TelephonyCredentialUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonyCredentialUpdateResponse (
        TelephonyCredentialUpdateResponse telephonyCredentialUpdateResponse
    ) : base(telephonyCredentialUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public TelephonyCredentialUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonyCredentialUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonyCredentialUpdateResponseFromRaw.FromRawUnchecked"/>
    public static TelephonyCredentialUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonyCredentialUpdateResponseFromRaw : IFromRawJson<TelephonyCredentialUpdateResponse>
{
    /// <inheritdoc/>
    public TelephonyCredentialUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonyCredentialUpdateResponse.FromRawUnchecked(rawData);
}