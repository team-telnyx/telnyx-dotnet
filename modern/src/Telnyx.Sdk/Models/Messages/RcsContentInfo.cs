using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RcsContentInfo, RcsContentInfoFromRaw>))]
public sealed record class RcsContentInfo : JsonModel
{
    /// <summary>
    /// Publicly reachable URL of the file.
    /// </summary>
    public required string FileUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "file_url"
            );
        }
        init { this._rawData.Set("file_url", value); }
    }

    /// <summary>
    /// If set the URL content will not be cached.
    /// </summary>
    public bool? ForceRefresh {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "force_refresh"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("force_refresh", value);
        }
    }

    /// <summary>
    /// Publicly reachable URL of the thumbnail. Maximum size of 100 kB.
    /// </summary>
    public string? ThumbnailUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "thumbnail_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("thumbnail_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileUrl;
        _ = this.ForceRefresh;
        _ = this.ThumbnailUrl;
    }

    public RcsContentInfo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsContentInfo (RcsContentInfo rcsContentInfo) : base(rcsContentInfo)
    {  }
    #pragma warning restore CS8618

    public RcsContentInfo (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsContentInfo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsContentInfoFromRaw.FromRawUnchecked"/>
    public static RcsContentInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public RcsContentInfo (string fileUrl) : this()
    { this.FileUrl = fileUrl; }
}

class RcsContentInfoFromRaw : IFromRawJson<RcsContentInfo>
{
    /// <inheritdoc/>
    public RcsContentInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsContentInfo.FromRawUnchecked(rawData);
}