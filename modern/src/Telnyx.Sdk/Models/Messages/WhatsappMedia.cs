using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<WhatsappMedia, WhatsappMediaFromRaw>))]
public sealed record class WhatsappMedia : JsonModel
{
    /// <summary>
    /// media caption
    /// </summary>
    public string? Caption {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "caption"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("caption", value);
        }
    }

    /// <summary>
    /// file name with extension
    /// </summary>
    public string? Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "filename"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// media URL
    /// </summary>
    public string? Link {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "link"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("link", value);
        }
    }

    /// <summary>
    /// true if voice message
    /// </summary>
    public bool? Voice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "voice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Caption;
        _ = this.Filename;
        _ = this.Link;
        _ = this.Voice;
    }

    public WhatsappMedia ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMedia (WhatsappMedia whatsappMedia) : base(whatsappMedia)
    {  }
    #pragma warning restore CS8618

    public WhatsappMedia (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMedia (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMediaFromRaw.FromRawUnchecked"/>
    public static WhatsappMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappMediaFromRaw : IFromRawJson<WhatsappMedia>
{
    /// <inheritdoc/>
    public WhatsappMedia FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMedia.FromRawUnchecked(rawData);
}