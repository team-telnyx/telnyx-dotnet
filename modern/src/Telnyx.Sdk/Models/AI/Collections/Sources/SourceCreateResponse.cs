using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Sources;

/// <summary>
/// Envelope containing a single collection source.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SourceCreateResponse, SourceCreateResponseFromRaw>))]
public sealed record class SourceCreateResponse : JsonModel
{
    public CollectionsSource? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CollectionsSource>(
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

    public SourceCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SourceCreateResponse (
        SourceCreateResponse sourceCreateResponse
    ) : base(sourceCreateResponse)
    {  }
    #pragma warning restore CS8618

    public SourceCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SourceCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceCreateResponseFromRaw.FromRawUnchecked"/>
    public static SourceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SourceCreateResponseFromRaw : IFromRawJson<SourceCreateResponse>
{
    /// <inheritdoc/>
    public SourceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SourceCreateResponse.FromRawUnchecked(rawData);
}