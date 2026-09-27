using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Media;

[JsonConverter(typeof(JsonModelConverter<MediaRetrieveResponse, MediaRetrieveResponseFromRaw>))]
public sealed record class MediaRetrieveResponse : JsonModel
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

    public MediaRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaRetrieveResponse (
        MediaRetrieveResponse mediaRetrieveResponse
    ) : base(mediaRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MediaRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MediaRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MediaRetrieveResponseFromRaw : IFromRawJson<MediaRetrieveResponse>
{
    /// <inheritdoc/>
    public MediaRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaRetrieveResponse.FromRawUnchecked(rawData);
}