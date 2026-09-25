using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Queues;

[JsonConverter(typeof(JsonModelConverter<QueueUpdateResponse, QueueUpdateResponseFromRaw>))]
public sealed record class QueueUpdateResponse : JsonModel
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

    public QueueUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueUpdateResponse (QueueUpdateResponse queueUpdateResponse) : base(
        queueUpdateResponse
    )
    {  }
    #pragma warning restore CS8618

    public QueueUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueUpdateResponseFromRaw.FromRawUnchecked"/>
    public static QueueUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueUpdateResponseFromRaw : IFromRawJson<QueueUpdateResponse>
{
    /// <inheritdoc/>
    public QueueUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueueUpdateResponse.FromRawUnchecked(rawData);
}