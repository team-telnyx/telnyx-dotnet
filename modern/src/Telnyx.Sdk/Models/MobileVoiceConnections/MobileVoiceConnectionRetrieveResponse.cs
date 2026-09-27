using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobileVoiceConnections;

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionRetrieveResponse, MobileVoiceConnectionRetrieveResponseFromRaw>))]
public sealed record class MobileVoiceConnectionRetrieveResponse : JsonModel
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

    public MobileVoiceConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionRetrieveResponse (
        MobileVoiceConnectionRetrieveResponse mobileVoiceConnectionRetrieveResponse
    ) : base(mobileVoiceConnectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionRetrieveResponseFromRaw : IFromRawJson<MobileVoiceConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionRetrieveResponse.FromRawUnchecked(rawData);
}