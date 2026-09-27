using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

[JsonConverter(typeof(JsonModelConverter<VoicemailCreateResponse, VoicemailCreateResponseFromRaw>))]
public sealed record class VoicemailCreateResponse : JsonModel
{
    public VoicemailPrefResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoicemailPrefResponse>(
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

    public VoicemailCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailCreateResponse (
        VoicemailCreateResponse voicemailCreateResponse
    ) : base(voicemailCreateResponse)
    {  }
    #pragma warning restore CS8618

    public VoicemailCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailCreateResponseFromRaw.FromRawUnchecked"/>
    public static VoicemailCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoicemailCreateResponseFromRaw : IFromRawJson<VoicemailCreateResponse>
{
    /// <inheritdoc/>
    public VoicemailCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailCreateResponse.FromRawUnchecked(rawData);
}