using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Connections;

[JsonConverter(typeof(JsonModelConverter<ConnectionListActiveCallsResponse, ConnectionListActiveCallsResponseFromRaw>))]
public sealed record class ConnectionListActiveCallsResponse : JsonModel
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
    /// Indicates the duration of the call in seconds
    /// </summary>
    public required long CallDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "call_duration"
            );
        }
        init { this._rawData.Set("call_duration", value); }
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
    /// State received from a command.
    /// </summary>
    public required string ClientState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "client_state"
            );
        }
        init { this._rawData.Set("client_state", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallDuration;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ClientState;
        this.RecordType.Validate();
    }

    public ConnectionListActiveCallsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionListActiveCallsResponse (
        ConnectionListActiveCallsResponse connectionListActiveCallsResponse
    ) : base(connectionListActiveCallsResponse)
    {  }
    #pragma warning restore CS8618

    public ConnectionListActiveCallsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionListActiveCallsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionListActiveCallsResponseFromRaw.FromRawUnchecked"/>
    public static ConnectionListActiveCallsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionListActiveCallsResponseFromRaw : IFromRawJson<ConnectionListActiveCallsResponse>
{
    /// <inheritdoc/>
    public ConnectionListActiveCallsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionListActiveCallsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
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