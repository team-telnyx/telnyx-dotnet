using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages;

[JsonConverter(typeof(JsonModelConverter<AttachmentRequest, AttachmentRequestFromRaw>))]
public sealed record class AttachmentRequest : JsonModel
{
    /// <summary>
    /// Attachment content, typically Base64-encoded. Defaults to empty string when omitted.
    /// </summary>
    public string? Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <summary>
    /// MIME Content-ID used to reference an inline attachment.
    /// </summary>
    public string? ContentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_id"
            );
        }
        init { this._rawData.Set("content_id", value); }
    }

    /// <summary>
    /// MIME content type. Defaults to "application/octet-stream" when omitted.
    /// </summary>
    public string? ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "content_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// MIME disposition (`attachment` or `inline`).
    /// </summary>
    public string? Disposition {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "disposition"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("disposition", value);
        }
    }

    /// <summary>
    /// Attachment filename. Defaults to "attachment" when omitted.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.ContentID;
        _ = this.ContentType;
        _ = this.Disposition;
        _ = this.Filename;
    }

    public AttachmentRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AttachmentRequest (AttachmentRequest attachmentRequest) : base(
        attachmentRequest
    )
    {  }
    #pragma warning restore CS8618

    public AttachmentRequest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AttachmentRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentRequestFromRaw.FromRawUnchecked"/>
    public static AttachmentRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AttachmentRequestFromRaw : IFromRawJson<AttachmentRequest>
{
    /// <inheritdoc/>
    public AttachmentRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AttachmentRequest.FromRawUnchecked(rawData);
}