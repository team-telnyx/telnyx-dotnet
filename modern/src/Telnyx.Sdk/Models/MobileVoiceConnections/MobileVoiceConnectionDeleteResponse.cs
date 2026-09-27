using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobileVoiceConnections;

[JsonConverter(typeof(JsonModelConverter<MobileVoiceConnectionDeleteResponse, MobileVoiceConnectionDeleteResponseFromRaw>))]
public sealed record class MobileVoiceConnectionDeleteResponse : JsonModel
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

    public MobileVoiceConnectionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileVoiceConnectionDeleteResponse (
        MobileVoiceConnectionDeleteResponse mobileVoiceConnectionDeleteResponse
    ) : base(mobileVoiceConnectionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public MobileVoiceConnectionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileVoiceConnectionDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileVoiceConnectionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static MobileVoiceConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileVoiceConnectionDeleteResponseFromRaw : IFromRawJson<MobileVoiceConnectionDeleteResponse>
{
    /// <inheritdoc/>
    public MobileVoiceConnectionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileVoiceConnectionDeleteResponse.FromRawUnchecked(rawData);
}