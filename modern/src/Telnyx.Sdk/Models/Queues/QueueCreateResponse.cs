using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Queues;

[JsonConverter(typeof(JsonModelConverter<QueueCreateResponse, QueueCreateResponseFromRaw>))]
public sealed record class QueueCreateResponse : JsonModel
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

    public QueueCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public QueueCreateResponse (QueueCreateResponse queueCreateResponse) : base(
        queueCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public QueueCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="QueueCreateResponseFromRaw.FromRawUnchecked"/>
    public static QueueCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class QueueCreateResponseFromRaw : IFromRawJson<QueueCreateResponse>
{
    /// <inheritdoc/>
    public QueueCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>QueueCreateResponse.FromRawUnchecked(rawData);
}