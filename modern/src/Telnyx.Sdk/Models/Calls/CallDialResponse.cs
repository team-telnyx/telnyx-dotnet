using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<CallDialResponse, CallDialResponseFromRaw>))]
public sealed record class CallDialResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public CallDialResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallDialResponse (CallDialResponse callDialResponse) : base(
        callDialResponse
    )
    {  }
    #pragma warning restore CS8618

    public CallDialResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallDialResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallDialResponseFromRaw.FromRawUnchecked"/>
    public static CallDialResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallDialResponseFromRaw : IFromRawJson<CallDialResponse>
{
    /// <inheritdoc/>
    public CallDialResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallDialResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
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

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
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
    /// The ID of the recording. Only present when the record parameter is set to record-from-answer.
    /// </summary>
    public string? RecordingID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recording_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("recording_id", value);
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
        _ = this.RecordingID;
        _ = this.StartTime;
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
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Call
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "call"=>RecordType.Call, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Call=>"call",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}