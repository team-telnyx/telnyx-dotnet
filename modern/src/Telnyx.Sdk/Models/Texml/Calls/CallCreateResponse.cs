using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Calls;

[JsonConverter(typeof(JsonModelConverter<CallCreateResponse, CallCreateResponseFromRaw>))]
public sealed record class CallCreateResponse : JsonModel
{
    /// <summary>
    /// The call control ID of the created call.
    /// </summary>
    public required string CallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_sid"
            );
        }
        init { this._rawData.Set("call_sid", value); }
    }

    /// <summary>
    /// The caller address.
    /// </summary>
    public required string From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// The initial status of the outbound call.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The called address.
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallSid;
        _ = this.From;
        this.Status.Validate();
        _ = this.To;
    }

    public CallCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCreateResponse (CallCreateResponse callCreateResponse) : base(
        callCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public CallCreateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallCreateResponseFromRaw.FromRawUnchecked"/>
    public static CallCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallCreateResponseFromRaw : IFromRawJson<CallCreateResponse>
{
    /// <inheritdoc/>
    public CallCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The initial status of the outbound call.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "queued"=>Status.Queued, _ =>(Status)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Queued=>"queued",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}