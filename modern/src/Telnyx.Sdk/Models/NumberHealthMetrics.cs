using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

/// <summary>
/// High level health metrics about the number and it's messaging sending patterns.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NumberHealthMetrics, NumberHealthMetricsFromRaw>))]
public sealed record class NumberHealthMetrics : JsonModel
{
    /// <summary>
    /// The ratio of messages received to the number of messages sent.
    /// </summary>
    public required float InboundOutboundRatio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "inbound_outbound_ratio"
            );
        }
        init { this._rawData.Set("inbound_outbound_ratio", value); }
    }

    /// <summary>
    /// The number of messages analyzed for the health metrics.
    /// </summary>
    public required long MessageCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "message_count"
            );
        }
        init { this._rawData.Set("message_count", value); }
    }

    /// <summary>
    /// The ratio of messages blocked for spam to the number of messages attempted.
    /// </summary>
    public required float SpamRatio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "spam_ratio"
            );
        }
        init { this._rawData.Set("spam_ratio", value); }
    }

    /// <summary>
    /// The ratio of messages sucessfully delivered to the number of messages attempted.
    /// </summary>
    public required float SuccessRatio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "success_ratio"
            );
        }
        init { this._rawData.Set("success_ratio", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InboundOutboundRatio;
        _ = this.MessageCount;
        _ = this.SpamRatio;
        _ = this.SuccessRatio;
    }

    public NumberHealthMetrics ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberHealthMetrics (NumberHealthMetrics numberHealthMetrics) : base(
        numberHealthMetrics
    )
    {  }
    #pragma warning restore CS8618

    public NumberHealthMetrics (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberHealthMetrics (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberHealthMetricsFromRaw.FromRawUnchecked"/>
    public static NumberHealthMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberHealthMetricsFromRaw : IFromRawJson<NumberHealthMetrics>
{
    /// <inheritdoc/>
    public NumberHealthMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberHealthMetrics.FromRawUnchecked(rawData);
}