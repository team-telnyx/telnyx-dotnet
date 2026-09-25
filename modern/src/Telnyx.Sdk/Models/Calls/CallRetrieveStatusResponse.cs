using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CallRetrieveStatusResponse, CallRetrieveStatusResponseFromRaw>))]
public sealed record class CallRetrieveStatusResponse : JsonModel
{
    public CallRetrieveStatusResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallRetrieveStatusResponseData>(
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

    public CallRetrieveStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveStatusResponse (
        CallRetrieveStatusResponse callRetrieveStatusResponse
    ) : base(callRetrieveStatusResponse)
    {  }
    #pragma warning restore CS8618

    public CallRetrieveStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveStatusResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveStatusResponseFromRaw.FromRawUnchecked"/>
    public static CallRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRetrieveStatusResponseFromRaw : IFromRawJson<CallRetrieveStatusResponse>
{
    /// <inheritdoc/>
    public CallRetrieveStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRetrieveStatusResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallRetrieveStatusResponseData, CallRetrieveStatusResponseDataFromRaw>))]
public sealed record class CallRetrieveStatusResponseData : JsonModel
{
    /// <summary>
    /// Unique identifier and token for controlling the call.
    /// </summary>
    public required string CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_control_id"
            );
        }
        init { this._rawData.Set("call_control_id", value); }
    }

    /// <summary>
    /// ID that is unique to the call and can be used to correlate webhook events
    /// </summary>
    public required string CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_leg_id"
            );
        }
        init { this._rawData.Set("call_leg_id", value); }
    }

    /// <summary>
    /// ID that is unique to the call session and can be used to correlate webhook
    /// events. Call session is a group of related call legs that logically belong
    /// to the same phone call, e.g. an inbound and outbound leg of a transferred call
    /// </summary>
    public required string CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_session_id"
            );
        }
        init { this._rawData.Set("call_session_id", value); }
    }

    /// <summary>
    /// Indicates whether the call is alive or not. For Dial command it will always
    /// be `false` (dialing is asynchronous).
    /// </summary>
    public required bool IsAlive {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "is_alive"
            );
        }
        init { this._rawData.Set("is_alive", value); }
    }

    public required ApiEnum<string, CallRetrieveStatusResponseDataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CallRetrieveStatusResponseDataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Indicates the duration of the call in seconds
    /// </summary>
    public long? CallDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "call_duration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_duration", value);
        }
    }

    /// <summary>
    /// State received from a command.
    /// </summary>
    public string? ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_state", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the call ended. Only present when
    /// the call is not alive
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
    /// ISO 8601 formatted date indicating when the call started
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.IsAlive;
        this.RecordType.Validate();
        _ = this.CallDuration;
        _ = this.ClientState;
        _ = this.EndTime;
        _ = this.StartTime;
    }

    public CallRetrieveStatusResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveStatusResponseData (
        CallRetrieveStatusResponseData callRetrieveStatusResponseData
    ) : base(callRetrieveStatusResponseData)
    {  }
    #pragma warning restore CS8618

    public CallRetrieveStatusResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveStatusResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveStatusResponseDataFromRaw.FromRawUnchecked"/>
    public static CallRetrieveStatusResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallRetrieveStatusResponseDataFromRaw : IFromRawJson<CallRetrieveStatusResponseData>
{
    /// <inheritdoc/>
    public CallRetrieveStatusResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRetrieveStatusResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(CallRetrieveStatusResponseDataRecordTypeConverter))]
public enum CallRetrieveStatusResponseDataRecordType
{
    Call
}sealed class CallRetrieveStatusResponseDataRecordTypeConverter : JsonConverter<CallRetrieveStatusResponseDataRecordType>
{
    public override CallRetrieveStatusResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call"=>CallRetrieveStatusResponseDataRecordType.Call,
            _ =>(CallRetrieveStatusResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallRetrieveStatusResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallRetrieveStatusResponseDataRecordType.Call=>"call",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}