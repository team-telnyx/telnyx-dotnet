using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobileVoiceConnections;

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionCreateResponse, MobileVoiceConnectionCreateResponseFromRaw>))]
public sealed record class MobileVoiceConnectionCreateResponse : JsonModel
{
    public MobileVoiceConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobileVoiceConnection>(
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

    public MobileVoiceConnectionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionCreateResponse (
        MobileVoiceConnectionCreateResponse mobileVoiceConnectionCreateResponse
    ) : base(mobileVoiceConnectionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionCreateResponseFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionCreateResponseFromRaw : IFromRawJson<MobileVoiceConnectionCreateResponse>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionCreateResponse.FromRawUnchecked(rawData);
}