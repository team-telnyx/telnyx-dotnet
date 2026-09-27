using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Voice;

[JsonConverter(typeof(JsonModelConverter<VoiceCreateResponse, VoiceCreateResponseFromRaw>))]
public sealed record class VoiceCreateResponse : JsonModel
{
    /// <summary>
    /// Response object for CDR detailed report
    /// </summary>
    public CdrDetailedReqResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CdrDetailedReqResponse>(
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

    public VoiceCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCreateResponse (VoiceCreateResponse voiceCreateResponse) : base(
        voiceCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public VoiceCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceCreateResponseFromRaw.FromRawUnchecked"/>
    public static VoiceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceCreateResponseFromRaw : IFromRawJson<VoiceCreateResponse>
{
    /// <inheritdoc/>
    public VoiceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceCreateResponse.FromRawUnchecked(rawData);
}