using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Media;

[JsonConverter(typeof(JsonModelConverter<MediaUpdateResponse, MediaUpdateResponseFromRaw>))]
public sealed record class MediaUpdateResponse : JsonModel
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

    public MediaUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaUpdateResponse (MediaUpdateResponse mediaUpdateResponse) : base(
        mediaUpdateResponse
    )
    {  }
    #pragma warning restore CS8618

    public MediaUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MediaUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MediaUpdateResponseFromRaw : IFromRawJson<MediaUpdateResponse>
{
    /// <inheritdoc/>
    public MediaUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaUpdateResponse.FromRawUnchecked(rawData);
}