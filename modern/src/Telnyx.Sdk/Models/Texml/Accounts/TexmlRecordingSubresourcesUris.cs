using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts;

/// <summary>
/// Subresources details for a recording if available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TexmlRecordingSubresourcesUris, TexmlRecordingSubresourcesUrisFromRaw>))]
public sealed record class TexmlRecordingSubresourcesUris : JsonModel
{
    public string? Transcriptions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transcriptions"
            );
        }
        init { this._rawData.Set("transcriptions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Transcriptions; }

    public TexmlRecordingSubresourcesUris ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlRecordingSubresourcesUris (
        TexmlRecordingSubresourcesUris texmlRecordingSubresourcesUris
    ) : base(texmlRecordingSubresourcesUris)
    {  }
    #pragma warning restore CS8618

    public TexmlRecordingSubresourcesUris (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlRecordingSubresourcesUris (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlRecordingSubresourcesUrisFromRaw.FromRawUnchecked"/>
    public static TexmlRecordingSubresourcesUris FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlRecordingSubresourcesUrisFromRaw : IFromRawJson<TexmlRecordingSubresourcesUris>
{
    /// <inheritdoc/>
    public TexmlRecordingSubresourcesUris FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlRecordingSubresourcesUris.FromRawUnchecked(rawData);
}