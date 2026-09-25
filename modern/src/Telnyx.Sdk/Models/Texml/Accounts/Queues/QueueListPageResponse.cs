using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Queues;

[JsonConverter(typeof(JsonModelConverter<QueueListPageResponse, QueueListPageResponseFromRaw>))]
public sealed record class QueueListPageResponse : JsonModel
{
    /// <summary>
    /// The number of the last element on the page, zero-indexed.
    /// </summary>
    public long? End {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end", value);
        }
    }

    /// <summary>
    /// /v2/texml/Accounts/61bf923e-5e4d-4595-a110-56190ea18a1b/Queues.json?Page=0&amp;PageSize=1
    /// </summary>
    public string? FirstPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "first_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_page_uri", value);
        }
    }

    /// <summary>
    /// /v2/texml/Accounts/61bf923e-5e4d-4595-a110-56190ea18a1b/Queues.json?Page=1&amp;PageSize=1&amp;PageToken=MTY4AjgyNDkwNzIxMQ
    /// </summary>
    public string? NextPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next_page_uri", value);
        }
    }

    /// <summary>
    /// Current page number, zero-indexed.
    /// </summary>
    public long? Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// The number of items on the page
    /// </summary>
    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    public IReadOnlyList<QueueResource>? Queues {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<QueueResource>>(
                "queues"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<QueueResource>?>(
                "queues",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of the first element on the page, zero-indexed.
    /// </summary>
    public long? Start {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "start"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <summary>
    /// The URI of the current page.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.FirstPageUri;
        _ = this.NextPageUri;
        _ = this.Page;
        _ = this.PageSize;
        foreach (var item in this.Queues ?? [])
        {
            item.Validate();
        }
        _ = this.Start;
        _ = this.Uri;
    }

    public QueueListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueListPageResponse (
        QueueListPageResponse queueListPageResponse
    ) : base(queueListPageResponse)
    {  }
    #pragma warning restore CS8618

    public QueueListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueListPageResponseFromRaw.FromRawUnchecked"/>
    public static QueueListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueListPageResponseFromRaw : IFromRawJson<QueueListPageResponse>
{
    /// <inheritdoc/>
    public QueueListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueueListPageResponse.FromRawUnchecked(rawData);
}