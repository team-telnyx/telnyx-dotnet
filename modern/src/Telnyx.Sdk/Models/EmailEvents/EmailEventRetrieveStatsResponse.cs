using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailEvents;

[JsonConverter(typeof(JsonModelConverter<EmailEventRetrieveStatsResponse, EmailEventRetrieveStatsResponseFromRaw>))]
public sealed record class EmailEventRetrieveStatsResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailEventRetrieveStatsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailEventRetrieveStatsResponse (
        EmailEventRetrieveStatsResponse emailEventRetrieveStatsResponse
    ) : base(emailEventRetrieveStatsResponse)
    {  }
    #pragma warning restore CS8618

    public EmailEventRetrieveStatsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailEventRetrieveStatsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailEventRetrieveStatsResponseFromRaw.FromRawUnchecked"/>
    public static EmailEventRetrieveStatsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailEventRetrieveStatsResponse (Data data) : this()
    { this.Data = data; }
}

class EmailEventRetrieveStatsResponseFromRaw : IFromRawJson<EmailEventRetrieveStatsResponse>
{
    /// <inheritdoc/>
    public EmailEventRetrieveStatsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailEventRetrieveStatsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Recipient-level outcome counts for the queried time range. Each to, cc, and
    /// bcc recipient counts separately; repeated events of the same type for the
    /// same message and recipient count once. Partial MTA injection results count
    /// successful recipients as sent and unsuccessful recipients as failed. Only
    /// the ten listed event types are counted; other valid event types (scheduled,
    /// cancelled, sandbox, sending, rejected) are not included in stats.
    /// </summary>
    public required Counts Counts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Counts>(
                "counts"
            );
        }
        init { this._rawData.Set("counts", value); }
    }

    /// <summary>
    /// Recipient-level event rates as percentages, rounded to 2 decimal places.
    /// </summary>
    public required Rates Rates {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Rates>(
                "rates"
            );
        }
        init { this._rawData.Set("rates", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required TimeRange TimeRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TimeRange>(
                "time_range"
            );
        }
        init { this._rawData.Set("time_range", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Counts.Validate();
        this.Rates.Validate();
        this.RecordType.Validate();
        this.TimeRange.Validate();
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// Recipient-level outcome counts for the queried time range. Each to, cc, and bcc
/// recipient counts separately; repeated events of the same type for the same message
/// and recipient count once. Partial MTA injection results count successful recipients
/// as sent and unsuccessful recipients as failed. Only the ten listed event types
/// are counted; other valid event types (scheduled, cancelled, sandbox, sending,
/// rejected) are not included in stats.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Counts, CountsFromRaw>))]
public sealed record class Counts : JsonModel
{
    public required long Bounced {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "bounced"
            );
        }
        init { this._rawData.Set("bounced", value); }
    }

    public required long Clicked {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "clicked"
            );
        }
        init { this._rawData.Set("clicked", value); }
    }

    public required long Complained {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "complained"
            );
        }
        init { this._rawData.Set("complained", value); }
    }

    public required long Deferred {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "deferred"
            );
        }
        init { this._rawData.Set("deferred", value); }
    }

    public required long Delivered {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "delivered"
            );
        }
        init { this._rawData.Set("delivered", value); }
    }

    public required long Failed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "failed"
            );
        }
        init { this._rawData.Set("failed", value); }
    }

    public required long Opened {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "opened"
            );
        }
        init { this._rawData.Set("opened", value); }
    }

    public required long Queued {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "queued"
            );
        }
        init { this._rawData.Set("queued", value); }
    }

    public required long Sent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "sent"
            );
        }
        init { this._rawData.Set("sent", value); }
    }

    public required long Unsubscribed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "unsubscribed"
            );
        }
        init { this._rawData.Set("unsubscribed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bounced;
        _ = this.Clicked;
        _ = this.Complained;
        _ = this.Deferred;
        _ = this.Delivered;
        _ = this.Failed;
        _ = this.Opened;
        _ = this.Queued;
        _ = this.Sent;
        _ = this.Unsubscribed;
    }

    public Counts ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Counts (Counts counts) : base(counts)
    {  }
    #pragma warning restore CS8618

    public Counts (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Counts (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CountsFromRaw.FromRawUnchecked"/>
    public static Counts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CountsFromRaw : IFromRawJson<Counts>
{
    /// <inheritdoc/>
    public Counts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Counts.FromRawUnchecked(rawData);
}/// <summary>
/// Recipient-level event rates as percentages, rounded to 2 decimal places.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rates, RatesFromRaw>))]
public sealed record class Rates : JsonModel
{
    /// <summary>
    /// Bounced recipients / queued recipients as a percentage.
    /// </summary>
    public required float BounceRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "bounce_rate"
            );
        }
        init { this._rawData.Set("bounce_rate", value); }
    }

    /// <summary>
    /// Recipients clicked / recipients opened as a percentage.
    /// </summary>
    public required float ClickRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "click_rate"
            );
        }
        init { this._rawData.Set("click_rate", value); }
    }

    /// <summary>
    /// Recipients with a complaint feedback report / delivered recipients as a percentage.
    /// </summary>
    public required float ComplaintRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "complaint_rate"
            );
        }
        init { this._rawData.Set("complaint_rate", value); }
    }

    /// <summary>
    /// Deferred recipients / queued recipients as a percentage.
    /// </summary>
    public required float DeferredRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "deferred_rate"
            );
        }
        init { this._rawData.Set("deferred_rate", value); }
    }

    /// <summary>
    /// Delivered recipients / queued recipients as a percentage.
    /// </summary>
    public required float DeliveryRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "delivery_rate"
            );
        }
        init { this._rawData.Set("delivery_rate", value); }
    }

    /// <summary>
    /// Recipients opened / recipients delivered as a percentage.
    /// </summary>
    public required float OpenRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "open_rate"
            );
        }
        init { this._rawData.Set("open_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BounceRate;
        _ = this.ClickRate;
        _ = this.ComplaintRate;
        _ = this.DeferredRate;
        _ = this.DeliveryRate;
        _ = this.OpenRate;
    }

    public Rates ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rates (Rates rates) : base(rates)
    {  }
    #pragma warning restore CS8618

    public Rates (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Rates (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RatesFromRaw.FromRawUnchecked"/>
    public static Rates FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RatesFromRaw : IFromRawJson<Rates>
{
    /// <inheritdoc/>
    public Rates FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Rates.FromRawUnchecked(rawData);
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailEventStats
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_event_stats"=>RecordType.EmailEventStats,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailEventStats=>"email_event_stats",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}