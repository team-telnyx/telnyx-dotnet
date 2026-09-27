using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobileVoiceConnections;

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionUpdateResponse, MobileVoiceConnectionUpdateResponseFromRaw>))]
public sealed record class MobileVoiceConnectionUpdateResponse : JsonModel
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

    public MobileVoiceConnectionUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionUpdateResponse (
        MobileVoiceConnectionUpdateResponse mobileVoiceConnectionUpdateResponse
    ) : base(mobileVoiceConnectionUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionUpdateResponseFromRaw : IFromRawJson<MobileVoiceConnectionUpdateResponse>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionUpdateResponse.FromRawUnchecked(rawData);
}