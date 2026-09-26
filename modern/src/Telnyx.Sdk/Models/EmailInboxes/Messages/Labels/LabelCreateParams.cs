using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Labels;

/// <summary>
/// Adds one or more mutable labels to a message. Labels carry agent workflow state
/// such as `spam`, `needs_review`, or `processed`.
///
/// <para>Labels are **not** the same as the send-time `tags` on outbound messages:
/// `tags` are immutable and propagate to Email Detail Records and Mission Control
/// for billing attribution, while labels are mailbox state that never reaches the
/// reporting contract.</para>
///
/// <para>The operation is an idempotent set union — adding a label the message already
/// carries is a no-op and still returns 200. Labels are case-sensitive, and message
/// labels are independent of thread labels.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LabelCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string InboxID { get; init; }

    public string? MessageID { get; init; }

    /// <summary>
    /// One or more labels. Each label is a freeform, case-sensitive string of at
    /// most 255 characters; a message or thread may carry at most 50 labels. The
    /// `telnyx:` prefix is a reserved system namespace and is rejected on customer writes.
    /// </summary>
    public required IReadOnlyList<string> Labels {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "labels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public LabelCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelCreateParams (LabelCreateParams labelCreateParams) : base(
        labelCreateParams
    )
    {
        this.InboxID = labelCreateParams.InboxID;
        this.MessageID = labelCreateParams.MessageID;

        this._rawBodyData = new(labelCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public LabelCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string inboxID,
        string messageID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InboxID = inboxID;
        this.MessageID = messageID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LabelCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string inboxID,
        string messageID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            inboxID,
            messageID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
        ["MessageID"] = JsonSerializer.SerializeToElement(this.MessageID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(LabelCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.InboxID.Equals(other.InboxID)&&(this.MessageID?.Equals(other.MessageID) ?? other.MessageID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_inboxes/{0}/messages/{1}/labels",
            EncodePathSegment(this.InboxID),
            EncodePathSegment(this.MessageID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}