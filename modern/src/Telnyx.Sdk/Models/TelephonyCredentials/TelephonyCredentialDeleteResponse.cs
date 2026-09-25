using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TelephonyCredentials;

[JsonConverter(typeof(JsonModelConverter<TelephonyCredentialDeleteResponse, TelephonyCredentialDeleteResponseFromRaw>))]
public sealed record class TelephonyCredentialDeleteResponse : JsonModel
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

    public TelephonyCredentialDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonyCredentialDeleteResponse (
        TelephonyCredentialDeleteResponse telephonyCredentialDeleteResponse
    ) : base(telephonyCredentialDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public TelephonyCredentialDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonyCredentialDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonyCredentialDeleteResponseFromRaw.FromRawUnchecked"/>
    public static TelephonyCredentialDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonyCredentialDeleteResponseFromRaw : IFromRawJson<TelephonyCredentialDeleteResponse>
{
    /// <inheritdoc/>
    public TelephonyCredentialDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonyCredentialDeleteResponse.FromRawUnchecked(rawData);
}