using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WebSearch.Research;

[JsonConverter(typeof(JsonModelConverter<ResearchCitation, ResearchCitationFromRaw>))]
public sealed record class ResearchCitation : JsonModel
{
    /// <summary>
    /// Title of the source page.
    /// </summary>
    public required string Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// Source URL.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Relevant excerpt from the source (if available).
    /// </summary>
    public string? Snippet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "snippet"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("snippet", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Title;
        _ = this.Url;
        _ = this.Snippet;
    }

    public ResearchCitation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchCitation (ResearchCitation researchCitation) : base(
        researchCitation
    )
    {  }
    #pragma warning restore CS8618

    public ResearchCitation (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResearchCitation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResearchCitationFromRaw.FromRawUnchecked"/>
    public static ResearchCitation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ResearchCitationFromRaw : IFromRawJson<ResearchCitation>
{
    /// <inheritdoc/>
    public ResearchCitation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResearchCitation.FromRawUnchecked(rawData);
}