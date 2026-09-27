using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

[JsonConverter(typeof(JsonModelConverter<CallResource, CallResourceFromRaw>))]
public sealed record class CallResource : JsonModel
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
    /// The value of the answering machine detection result, if this feature was
    /// enabled for the call.
    /// </summary>
    public ApiEnum<string, AnsweredBy>? AnsweredBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AnsweredBy>>(
                "answered_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("answered_by", value);
        }
    }

    /// <summary>
    /// Caller ID, if present.
    /// </summary>
    public string? CallerName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "caller_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("caller_name", value);
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
    /// The direction of this call.
    /// </summary>
    public ApiEnum<string, Direction>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Direction>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    /// <summary>
    /// The duration of this call, given in seconds.
    /// </summary>
    public string? Duration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// The end time of this call.
    /// </summary>
    public string? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_time", value);
        }
    }

    /// <summary>
    /// The phone number or SIP address that made this call.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The from number formatted for display.
    /// </summary>
    public string? FromFormatted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from_formatted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from_formatted", value);
        }
    }

    /// <summary>
    /// The price of this call, the currency is specified in the price_unit field.
    /// Only populated when the call cost feature is enabled for the account.
    /// </summary>
    public string? Price {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "price"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("price", value);
        }
    }

    /// <summary>
    /// The unit in which the price is given.
    /// </summary>
    public string? PriceUnit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "price_unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("price_unit", value);
        }
    }

    /// <summary>
    /// The identifier of this call.
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
    /// The start time of this call.
    /// </summary>
    public string? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// The status of this call.
    /// </summary>
    public ApiEnum<string, CallResourceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallResourceStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// The phone number or SIP address that received this call.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <summary>
    /// The to number formatted for display.
    /// </summary>
    public string? ToFormatted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to_formatted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to_formatted", value);
        }
    }

    /// <summary>
    /// The relative URI for this call.
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
        this.AnsweredBy?.Validate();
        _ = this.CallerName;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        this.Direction?.Validate();
        _ = this.Duration;
        _ = this.EndTime;
        _ = this.From;
        _ = this.FromFormatted;
        _ = this.Price;
        _ = this.PriceUnit;
        _ = this.Sid;
        _ = this.StartTime;
        this.Status?.Validate();
        _ = this.To;
        _ = this.ToFormatted;
        _ = this.Uri;
    }

    public CallResource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallResource (CallResource callResource) : base(callResource)
    {  }
    #pragma warning restore CS8618

    public CallResource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallResource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallResourceFromRaw.FromRawUnchecked"/>
    public static CallResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallResourceFromRaw : IFromRawJson<CallResource>
{
    /// <inheritdoc/>
    public CallResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallResource.FromRawUnchecked(rawData);
}

/// <summary>
/// The value of the answering machine detection result, if this feature was enabled
/// for the call.
/// </summary>
[JsonConverter(typeof(AnsweredByConverter))]
public enum AnsweredBy
{
    Human, Machine, NotSure
}sealed class AnsweredByConverter : JsonConverter<AnsweredBy>
{
    public override AnsweredBy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "human"=>AnsweredBy.Human,
            "machine"=>AnsweredBy.Machine,
            "not_sure"=>AnsweredBy.NotSure,
            _ =>(AnsweredBy)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, AnsweredBy value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AnsweredBy.Human=>"human",
            AnsweredBy.Machine=>"machine",
            AnsweredBy.NotSure=>"not_sure",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The direction of this call.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound, Outbound
}sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>Direction.Inbound,
            "outbound"=>Direction.Outbound,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"inbound",
            Direction.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of this call.
/// </summary>
[JsonConverter(typeof(CallResourceStatusConverter))]
public enum CallResourceStatus
{
    Ringing, InProgress, Canceled, Completed, Failed, Busy, NoAnswer
}sealed class CallResourceStatusConverter : JsonConverter<CallResourceStatus>
{
    public override CallResourceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ringing"=>CallResourceStatus.Ringing,
            "in-progress"=>CallResourceStatus.InProgress,
            "canceled"=>CallResourceStatus.Canceled,
            "completed"=>CallResourceStatus.Completed,
            "failed"=>CallResourceStatus.Failed,
            "busy"=>CallResourceStatus.Busy,
            "no-answer"=>CallResourceStatus.NoAnswer,
            _ =>(CallResourceStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallResourceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallResourceStatus.Ringing=>"ringing",
            CallResourceStatus.InProgress=>"in-progress",
            CallResourceStatus.Canceled=>"canceled",
            CallResourceStatus.Completed=>"completed",
            CallResourceStatus.Failed=>"failed",
            CallResourceStatus.Busy=>"busy",
            CallResourceStatus.NoAnswer=>"no-answer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}