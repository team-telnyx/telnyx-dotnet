using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UacConnections;

[JsonConverter(typeof(JsonModelConverter<UacConnectionRetrieveResponse, UacConnectionRetrieveResponseFromRaw>))]
public sealed record class UacConnectionRetrieveResponse : JsonModel
{
    /// <summary>
    /// A UAC (User Agent Client) Connection registers Telnyx to your PBX — the opposite
    /// of a standard SIP trunk, where the PBX registers to Telnyx. Use UAC when
    /// your PBX doesn’t support outbound SIP registration or you need Telnyx to
    /// maintain the registration.
    /// </summary>
    public UacConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UacConnection>(
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

    public UacConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacConnectionRetrieveResponse (
        UacConnectionRetrieveResponse uacConnectionRetrieveResponse
    ) : base(uacConnectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public UacConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacConnectionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UacConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacConnectionRetrieveResponseFromRaw : IFromRawJson<UacConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public UacConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacConnectionRetrieveResponse.FromRawUnchecked(rawData);
}