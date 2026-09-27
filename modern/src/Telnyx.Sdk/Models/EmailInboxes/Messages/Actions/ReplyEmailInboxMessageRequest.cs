using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Actions;

/// <summary>
/// At least one of `text` or `html` must contain a non-whitespace body. Recipients
/// are derived from the source message; caller-supplied `to`, `cc`, or `bcc` values
/// are ignored.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReplyEmailInboxMessageRequest, ReplyEmailInboxMessageRequestFromRaw>))]
public sealed record class ReplyEmailInboxMessageRequest : JsonModel
{
    /// <summary>
    /// HTML reply body.
    /// </summary>
    public string? Html {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("html", value);
        }
    }

    /// <summary>
    /// Plain-text reply body.
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Html;
        _ = this.Text;
    }

    public ReplyEmailInboxMessageRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReplyEmailInboxMessageRequest (
        ReplyEmailInboxMessageRequest replyEmailInboxMessageRequest
    ) : base(replyEmailInboxMessageRequest)
    {  }
    #pragma warning restore CS8618

    public ReplyEmailInboxMessageRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReplyEmailInboxMessageRequest (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReplyEmailInboxMessageRequestFromRaw.FromRawUnchecked"/>
    public static ReplyEmailInboxMessageRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReplyEmailInboxMessageRequestFromRaw : IFromRawJson<ReplyEmailInboxMessageRequest>
{
    /// <inheritdoc/>
    public ReplyEmailInboxMessageRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReplyEmailInboxMessageRequest.FromRawUnchecked(rawData);
}