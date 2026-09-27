using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Queues;

[JsonConverter(typeof(JsonModelConverter<QueueRetrieveResponse, QueueRetrieveResponseFromRaw>))]
public sealed record class QueueRetrieveResponse : JsonModel
{
    public global::Telnyx.Sdk.Models.Queues.Queue? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Telnyx.Sdk.Models.Queues.Queue>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public QueueRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueRetrieveResponse (
        QueueRetrieveResponse queueRetrieveResponse
    ) : base(queueRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public QueueRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static QueueRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueRetrieveResponseFromRaw : IFromRawJson<QueueRetrieveResponse>
{
    /// <inheritdoc/>
    public QueueRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueueRetrieveResponse.FromRawUnchecked(rawData);
}