using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailMessages;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

/// <summary>
/// All fields are optional — a draft may be saved incomplete. `account_id`, `inbox_id`,
/// `status`, `sent_at`, `sent_message_id`, `reply_to_message_id` and `thread_id`
/// are server-owned and ignored if supplied.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailDraftRequest, EmailDraftRequestFromRaw>))]
public sealed record class EmailDraftRequest : JsonModel
{
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Attachments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "attachments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    public IReadOnlyList<EmailAddressInput>? Bcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "bcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddressInput>?>(
                "bcc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<EmailAddressInput>? Cc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "cc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddressInput>?>(
                "cc",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? FromEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from_email", value);
        }
    }

    public string? FromName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from_name", value);
        }
    }

    public IReadOnlyDictionary<string, string>? Headers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Alias for `html_body`, matching the send endpoint.
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

    public string? HtmlBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "html_body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("html_body", value);
        }
    }

    public IReadOnlyList<string>? Labels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "labels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ReplyTo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reply_to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reply_to", value);
        }
    }

    public string? Subject {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "subject"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("subject", value);
        }
    }

    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Alias for `text_body`, matching the send endpoint.
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

    public string? TextBody {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text_body"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text_body", value);
        }
    }

    public IReadOnlyList<EmailAddressInput>? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<EmailAddressInput>>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailAddressInput>?>(
                "to",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Attachments;
        foreach (var item in this.Bcc ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Cc ?? [])
        {
            item.Validate();
        }
        _ = this.FromEmail;
        _ = this.FromName;
        _ = this.Headers;
        _ = this.Html;
        _ = this.HtmlBody;
        _ = this.Labels;
        _ = this.Metadata;
        _ = this.ReplyTo;
        _ = this.Subject;
        _ = this.Tags;
        _ = this.Text;
        _ = this.TextBody;
        foreach (var item in this.To ?? [])
        {
            item.Validate();
        }
    }

    public EmailDraftRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDraftRequest (EmailDraftRequest emailDraftRequest) : base(
        emailDraftRequest
    )
    {  }
    #pragma warning restore CS8618

    public EmailDraftRequest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDraftRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDraftRequestFromRaw.FromRawUnchecked"/>
    public static EmailDraftRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailDraftRequestFromRaw : IFromRawJson<EmailDraftRequest>
{
    /// <inheritdoc/>
    public EmailDraftRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDraftRequest.FromRawUnchecked(rawData);
}