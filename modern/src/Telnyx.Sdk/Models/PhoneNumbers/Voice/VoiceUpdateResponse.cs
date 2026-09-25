using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Actions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

[JsonConverter(typeof(JsonModelConverter<VoiceUpdateResponse, VoiceUpdateResponseFromRaw>))]
public sealed record class VoiceUpdateResponse : JsonModel
{
    public PhoneNumberWithVoiceSettings? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberWithVoiceSettings>(
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

    public VoiceUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceUpdateResponse (VoiceUpdateResponse voiceUpdateResponse) : base(
        voiceUpdateResponse
    )
    {  }
    #pragma warning restore CS8618

    public VoiceUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceUpdateResponseFromRaw.FromRawUnchecked"/>
    public static VoiceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceUpdateResponseFromRaw : IFromRawJson<VoiceUpdateResponse>
{
    /// <inheritdoc/>
    public VoiceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceUpdateResponse.FromRawUnchecked(rawData);
}