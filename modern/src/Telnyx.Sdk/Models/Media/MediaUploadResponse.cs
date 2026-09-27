using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Media;

[JsonConverter(typeof(JsonModelConverter<MediaUploadResponse, MediaUploadResponseFromRaw>))]
public sealed record class MediaUploadResponse : JsonModel
{
    public MediaResource? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MediaResource>(
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

    public MediaUploadResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaUploadResponse (MediaUploadResponse mediaUploadResponse) : base(
        mediaUploadResponse
    )
    {  }
    #pragma warning restore CS8618

    public MediaUploadResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaUploadResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaUploadResponseFromRaw.FromRawUnchecked"/>
    public static MediaUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MediaUploadResponseFromRaw : IFromRawJson<MediaUploadResponse>
{
    /// <inheritdoc/>
    public MediaUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaUploadResponse.FromRawUnchecked(rawData);
}