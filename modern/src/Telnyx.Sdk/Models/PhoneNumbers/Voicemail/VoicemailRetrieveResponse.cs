using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voicemail;

[JsonConverter(typeof(JsonModelConverter<VoicemailRetrieveResponse, VoicemailRetrieveResponseFromRaw>))]
public sealed record class VoicemailRetrieveResponse : JsonModel
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

    public VoicemailRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailRetrieveResponse (
        VoicemailRetrieveResponse voicemailRetrieveResponse
    ) : base(voicemailRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public VoicemailRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static VoicemailRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoicemailRetrieveResponseFromRaw : IFromRawJson<VoicemailRetrieveResponse>
{
    /// <inheritdoc/>
    public VoicemailRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailRetrieveResponse.FromRawUnchecked(rawData);
}