using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Queues;

[JsonConverter(typeof(JsonModelConverter<QueueListPageResponse, QueueListPageResponseFromRaw>))]
public sealed record class QueueListPageResponse : JsonModel
{
    public IReadOnlyList<global::Telnyx.Sdk.Models.Queues.Queue>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<global::Telnyx.Sdk.Models.Queues.Queue>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<global::Telnyx.Sdk.Models.Queues.Queue>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
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