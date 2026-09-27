using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

[JsonConverter(typeof(JsonModelConverter<OutboundVoiceProfileCreateResponse, OutboundVoiceProfileCreateResponseFromRaw>))]
public sealed record class OutboundVoiceProfileCreateResponse : JsonModel
{
    public OutboundVoiceProfile? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundVoiceProfile>(
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

    public OutboundVoiceProfileCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileCreateResponse (
        OutboundVoiceProfileCreateResponse outboundVoiceProfileCreateResponse
    ) : base(outboundVoiceProfileCreateResponse)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfileCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundVoiceProfileCreateResponseFromRaw.FromRawUnchecked"/>
    public static OutboundVoiceProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundVoiceProfileCreateResponseFromRaw : IFromRawJson<OutboundVoiceProfileCreateResponse>
{
    /// <inheritdoc/>
    public OutboundVoiceProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundVoiceProfileCreateResponse.FromRawUnchecked(rawData);
}