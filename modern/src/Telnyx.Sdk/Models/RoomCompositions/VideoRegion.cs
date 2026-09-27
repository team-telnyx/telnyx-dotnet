using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RoomCompositions;

[JsonConverter(typeof(JsonModelConverter<VideoRegion, VideoRegionFromRaw>))]
public sealed record class VideoRegion : JsonModel
{
    /// <summary>
    /// Height of the video region
    /// </summary>
    public long? Height {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "height"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Maximum number of columns of the region's placement grid. By default, the
    /// region has as many columns as needed to layout all the specified video sources.
    /// </summary>
    public long? MaxColumns {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_columns"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_columns", value);
        }
    }

    /// <summary>
    /// Maximum number of rows of the region's placement grid. By default, the region
    /// has as many rows as needed to layout all the specified video sources.
    /// </summary>
    public long? MaxRows {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_rows"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_rows", value);
        }
    }

    /// <summary>
    /// Array of video recording ids to be composed in the region. Can be "*" to specify
    /// all video recordings in the session
    /// </summary>
    public IReadOnlyList<string>? VideoSources {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "video_sources"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "video_sources",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Width of the video region
    /// </summary>
    public long? Width {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "width"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <summary>
    /// X axis value (in pixels) of the region's upper left corner relative to the
    /// upper left corner of the whole room composition viewport.
    /// </summary>
    public long? XPos {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "x_pos"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("x_pos", value);
        }
    }

    /// <summary>
    /// Y axis value (in pixels) of the region's upper left corner relative to the
    /// upper left corner of the whole room composition viewport.
    /// </summary>
    public long? YPos {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "y_pos"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("y_pos", value);
        }
    }

    /// <summary>
    /// Regions with higher z_pos values are stacked on top of regions with lower
    /// z_pos values
    /// </summary>
    public long? ZPos {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "z_pos"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("z_pos", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.MaxColumns;
        _ = this.MaxRows;
        _ = this.VideoSources;
        _ = this.Width;
        _ = this.XPos;
        _ = this.YPos;
        _ = this.ZPos;
    }

    public VideoRegion ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoRegion (VideoRegion videoRegion) : base(videoRegion)
    {  }
    #pragma warning restore CS8618

    public VideoRegion (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoRegion (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VideoRegionFromRaw.FromRawUnchecked"/>
    public static VideoRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VideoRegionFromRaw : IFromRawJson<VideoRegion>
{
    /// <inheritdoc/>
    public VideoRegion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VideoRegion.FromRawUnchecked(rawData);
}