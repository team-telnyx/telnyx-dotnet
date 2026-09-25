using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.PhoneNumbers.Actions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

[JsonConverter(typeof(JsonModelConverter<VoiceRetrieveResponse, VoiceRetrieveResponseFromRaw>))]
public sealed record class VoiceRetrieveResponse : JsonModel
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

    public VoiceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceRetrieveResponse (
        VoiceRetrieveResponse voiceRetrieveResponse
    ) : base(voiceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public VoiceRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VoiceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceRetrieveResponseFromRaw : IFromRawJson<VoiceRetrieveResponse>
{
    /// <inheritdoc/>
    public VoiceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceRetrieveResponse.FromRawUnchecked(rawData);
}