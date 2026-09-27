using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RcsCardContent, RcsCardContentFromRaw>))]
public sealed record class RcsCardContent : JsonModel
{
    /// <summary>
    /// Description of the card (at most 2000 characters)
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// A media file within a rich card.
    /// </summary>
    public RcsCardContentMedia? Media {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsCardContentMedia>(
                "media"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("media", value);
        }
    }

    /// <summary>
    /// List of suggestions to include in the card. Maximum 10 suggestions.
    /// </summary>
    public IReadOnlyList<RcsSuggestion>? Suggestions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RcsSuggestion>>(
                "suggestions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RcsSuggestion>?>(
                "suggestions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Title of the card (at most 200 characters)
    /// </summary>
    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        this.Media?.Validate();
        foreach (var item in this.Suggestions ?? [])
        {
            item.Validate();
        }
        _ = this.Title;
    }

    public RcsCardContent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsCardContent (RcsCardContent rcsCardContent) : base(rcsCardContent)
    {  }
    #pragma warning restore CS8618

    public RcsCardContent (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsCardContent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsCardContentFromRaw.FromRawUnchecked"/>
    public static RcsCardContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcsCardContentFromRaw : IFromRawJson<RcsCardContent>
{
    /// <inheritdoc/>
    public RcsCardContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsCardContent.FromRawUnchecked(rawData);
}

/// <summary>
/// A media file within a rich card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RcsCardContentMedia, RcsCardContentMediaFromRaw>))]
public sealed record class RcsCardContentMedia : JsonModel
{
    public RcsContentInfo? ContentInfo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RcsContentInfo>(
                "content_info"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_info", value);
        }
    }

    /// <summary>
    /// The height of the media within a rich card with a vertical layout. For a standalone
    /// card with horizontal layout, height is not customizable, and this field is ignored.
    /// </summary>
    public ApiEnum<string, Height>? Height {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Height>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContentInfo?.Validate();
        this.Height?.Validate();
    }

    public RcsCardContentMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsCardContentMedia (RcsCardContentMedia rcsCardContentMedia) : base(
        rcsCardContentMedia
    )
    {  }
    #pragma warning restore CS8618

    public RcsCardContentMedia (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsCardContentMedia (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsCardContentMediaFromRaw.FromRawUnchecked"/>
    public static RcsCardContentMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RcsCardContentMediaFromRaw : IFromRawJson<RcsCardContentMedia>
{
    /// <inheritdoc/>
    public RcsCardContentMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsCardContentMedia.FromRawUnchecked(rawData);
}/// <summary>
/// The height of the media within a rich card with a vertical layout. For a standalone
/// card with horizontal layout, height is not customizable, and this field is ignored.
/// </summary>
[JsonConverter(typeof(HeightConverter))]
public enum Height
{
    HeightUnspecified, Short, Medium, Tall
}sealed class HeightConverter : JsonConverter<Height>
{
    public override Height Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HEIGHT_UNSPECIFIED"=>Height.HeightUnspecified,
            "SHORT"=>Height.Short,
            "MEDIUM"=>Height.Medium,
            "TALL"=>Height.Tall,
            _ =>(Height)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Height value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Height.HeightUnspecified=>"HEIGHT_UNSPECIFIED",
            Height.Short=>"SHORT",
            Height.Medium=>"MEDIUM",
            Height.Tall=>"TALL",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}