using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Queues;

[JsonConverter(typeof(JsonModelConverter<QueueResource, QueueResourceFromRaw>))]
public sealed record class QueueResource : JsonModel
{
    /// <summary>
    /// The id of the account the resource belongs to.
    /// </summary>
    public string? AccountSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_sid", value);
        }
    }

    /// <summary>
    /// The average wait time in seconds for members in the queue.
    /// </summary>
    public long? AverageWaitTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "average_wait_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("average_wait_time", value);
        }
    }

    /// <summary>
    /// The current number of members in the queue.
    /// </summary>
    public long? CurrentSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "current_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_size", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was created.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_created"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_created", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was last updated.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_updated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_updated", value);
        }
    }

    /// <summary>
    /// The maximum size of the queue.
    /// </summary>
    public long? MaxSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_size", value);
        }
    }

    /// <summary>
    /// The unique identifier of the queue.
    /// </summary>
    public string? Sid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sid", value);
        }
    }

    /// <summary>
    /// A list of related resources identified by their relative URIs.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? SubresourceUris {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "subresource_uris"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "subresource_uris",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The relative URI for this queue.
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
        _ = this.AccountSid;
        _ = this.AverageWaitTime;
        _ = this.CurrentSize;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.MaxSize;
        _ = this.Sid;
        _ = this.SubresourceUris;
        _ = this.Uri;
    }

    public QueueResource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueResource (QueueResource queueResource) : base(queueResource)
    {  }
    #pragma warning restore CS8618

    public QueueResource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueResource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueResourceFromRaw.FromRawUnchecked"/>
    public static QueueResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueResourceFromRaw : IFromRawJson<QueueResource>
{
    /// <inheritdoc/>
    public QueueResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueueResource.FromRawUnchecked(rawData);
}