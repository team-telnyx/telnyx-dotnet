using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Voice;

[JsonConverter(typeof(JsonModelConverter<VoiceDeleteResponse, VoiceDeleteResponseFromRaw>))]
public sealed record class VoiceDeleteResponse : JsonModel
{
    /// <summary>
    /// Legacy V2 CDR usage report response
    /// </summary>
    public CdrUsageReportResponseLegacy? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CdrUsageReportResponseLegacy>(
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

    public VoiceDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceDeleteResponse (VoiceDeleteResponse voiceDeleteResponse) : base(
        voiceDeleteResponse
    )
    {  }
    #pragma warning restore CS8618

    public VoiceDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static VoiceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceDeleteResponseFromRaw : IFromRawJson<VoiceDeleteResponse>
{
    /// <inheritdoc/>
    public VoiceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceDeleteResponse.FromRawUnchecked(rawData);
}