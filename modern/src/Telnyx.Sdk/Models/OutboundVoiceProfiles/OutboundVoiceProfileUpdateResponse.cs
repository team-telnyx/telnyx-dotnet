using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

[JsonConverter(typeof(JsonModelConverter<OutboundVoiceProfileUpdateResponse, OutboundVoiceProfileUpdateResponseFromRaw>))]
public sealed record class OutboundVoiceProfileUpdateResponse : JsonModel
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

    public OutboundVoiceProfileUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileUpdateResponse (
        OutboundVoiceProfileUpdateResponse outboundVoiceProfileUpdateResponse
    ) : base(outboundVoiceProfileUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfileUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundVoiceProfileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static OutboundVoiceProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundVoiceProfileUpdateResponseFromRaw : IFromRawJson<OutboundVoiceProfileUpdateResponse>
{
    /// <inheritdoc/>
    public OutboundVoiceProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundVoiceProfileUpdateResponse.FromRawUnchecked(rawData);
}