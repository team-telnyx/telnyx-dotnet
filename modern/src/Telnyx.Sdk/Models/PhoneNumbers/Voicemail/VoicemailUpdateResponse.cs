using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

[JsonConverter(typeof(JsonModelConverter<VoicemailUpdateResponse, VoicemailUpdateResponseFromRaw>))]
public sealed record class VoicemailUpdateResponse : JsonModel
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

    public VoicemailUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailUpdateResponse (
        VoicemailUpdateResponse voicemailUpdateResponse
    ) : base(voicemailUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public VoicemailUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailUpdateResponseFromRaw.FromRawUnchecked"/>
    public static VoicemailUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoicemailUpdateResponseFromRaw : IFromRawJson<VoicemailUpdateResponse>
{
    /// <inheritdoc/>
    public VoicemailUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailUpdateResponse.FromRawUnchecked(rawData);
}