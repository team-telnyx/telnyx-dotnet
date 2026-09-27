using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PronunciationDicts;

/// <summary>
/// Response containing a single pronunciation dictionary.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PronunciationDictResponse, PronunciationDictResponseFromRaw>))]
public sealed record class PronunciationDictResponse : JsonModel
{
    /// <summary>
    /// A pronunciation dictionary record.
    /// </summary>
    public PronunciationDictData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PronunciationDictData>(
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

    public PronunciationDictResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PronunciationDictResponse (
        PronunciationDictResponse pronunciationDictResponse
    ) : base(pronunciationDictResponse)
    {  }
    #pragma warning restore CS8618

    public PronunciationDictResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PronunciationDictResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PronunciationDictResponseFromRaw.FromRawUnchecked"/>
    public static PronunciationDictResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PronunciationDictResponseFromRaw : IFromRawJson<PronunciationDictResponse>
{
    /// <inheritdoc/>
    public PronunciationDictResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PronunciationDictResponse.FromRawUnchecked(rawData);
}