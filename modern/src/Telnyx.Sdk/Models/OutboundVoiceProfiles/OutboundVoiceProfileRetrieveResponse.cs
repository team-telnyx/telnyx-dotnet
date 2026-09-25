using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

[JsonConverter(typeof(JsonModelConverter<OutboundVoiceProfileRetrieveResponse, OutboundVoiceProfileRetrieveResponseFromRaw>))]
public sealed record class OutboundVoiceProfileRetrieveResponse : JsonModel
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

    public OutboundVoiceProfileRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileRetrieveResponse (
        OutboundVoiceProfileRetrieveResponse outboundVoiceProfileRetrieveResponse
    ) : base(outboundVoiceProfileRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfileRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundVoiceProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static OutboundVoiceProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundVoiceProfileRetrieveResponseFromRaw : IFromRawJson<OutboundVoiceProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public OutboundVoiceProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundVoiceProfileRetrieveResponse.FromRawUnchecked(rawData);
}