using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UacConnections;

[JsonConverter(typeof(JsonModelConverter<UacConnectionCreateResponse, UacConnectionCreateResponseFromRaw>))]
public sealed record class UacConnectionCreateResponse : JsonModel
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

    public UacConnectionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UacConnectionCreateResponse (
        UacConnectionCreateResponse uacConnectionCreateResponse
    ) : base(uacConnectionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public UacConnectionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UacConnectionCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UacConnectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static UacConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UacConnectionCreateResponseFromRaw : IFromRawJson<UacConnectionCreateResponse>
{
    /// <inheritdoc/>
    public UacConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UacConnectionCreateResponse.FromRawUnchecked(rawData);
}