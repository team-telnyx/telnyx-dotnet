using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CallConversationInsightsGenerated, CallConversationInsightsGeneratedFromRaw>))]
public sealed record class CallConversationInsightsGenerated : JsonModel
{
    /// <summary>
    /// Identifies the type of resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The type of event being delivered.
    /// </summary>
    public ApiEnum<string, CallConversationInsightsGeneratedEventType>? EventType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallConversationInsightsGeneratedEventType>>(
                "event_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 datetime of when the event occurred.
    /// </summary>
    public System::DateTimeOffset? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    public CallConversationInsightsGeneratedPayload? Payload {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallConversationInsightsGeneratedPayload>(
                "payload"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payload", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, CallConversationInsightsGeneratedRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallConversationInsightsGeneratedRecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.EventType?.Validate();
        _ = this.OccurredAt;
        this.Payload?.Validate();
        this.RecordType?.Validate();
    }

    public CallConversationInsightsGenerated ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallConversationInsightsGenerated (
        CallConversationInsightsGenerated callConversationInsightsGenerated
    ) : base(callConversationInsightsGenerated)
    {  }
    #pragma warning restore CS8618

    public CallConversationInsightsGenerated (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallConversationInsightsGenerated (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallConversationInsightsGeneratedFromRaw.FromRawUnchecked"/>
    public static CallConversationInsightsGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallConversationInsightsGeneratedFromRaw : IFromRawJson<CallConversationInsightsGenerated>
{
    /// <inheritdoc/>
    public CallConversationInsightsGenerated FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallConversationInsightsGenerated.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event being delivered.
/// </summary>
[JsonConverter(typeof(CallConversationInsightsGeneratedEventTypeConverter))]
public enum CallConversationInsightsGeneratedEventType
{
    CallConversationInsightsGenerated
}sealed class CallConversationInsightsGeneratedEventTypeConverter : JsonConverter<CallConversationInsightsGeneratedEventType>
{
    public override CallConversationInsightsGeneratedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call.conversation_insights.generated"=>CallConversationInsightsGeneratedEventType.CallConversationInsightsGenerated,
            _ =>(CallConversationInsightsGeneratedEventType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallConversationInsightsGeneratedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallConversationInsightsGeneratedEventType.CallConversationInsightsGenerated=>"call.conversation_insights.generated",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<CallConversationInsightsGeneratedPayload, CallConversationInsightsGeneratedPayloadFromRaw>))]
public sealed record class CallConversationInsightsGeneratedPayload : JsonModel
{
    /// <summary>
    /// Call ID used to issue commands via Call Control API.
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the call and can be used to correlate webhook events.
    /// </summary>
    public string? CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_leg_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the call session and can be used to correlate webhook
    /// events. Call session is a group of related call legs that logically belong
    /// to the same phone call, e.g. an inbound and outbound leg of a transferred call.
    /// </summary>
    public string? CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_session_id", value);
        }
    }

    /// <summary>
    /// The type of calling party connection.
    /// </summary>
    public ApiEnum<string, CallConversationInsightsGeneratedPayloadCallingPartyType>? CallingPartyType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CallConversationInsightsGeneratedPayloadCallingPartyType>>(
                "calling_party_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("calling_party_type", value);
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
    /// Call Control App ID (formerly Telnyx connection ID) used in the call.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// ID that is unique to the insight group being generated for the call.
    /// </summary>
    public string? InsightGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "insight_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("insight_group_id", value);
        }
    }

    /// <summary>
    /// Array of insight results being generated for the call.
    /// </summary>
    public IReadOnlyList<Result>? Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Result>>(
                "results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Result>?>(
                "results",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        this.CallingPartyType?.Validate();
        _ = this.ClientState;
        _ = this.ConnectionID;
        _ = this.InsightGroupID;
        foreach (var item in this.Results ?? [])
        {
            item.Validate();
        }
    }

    public CallConversationInsightsGeneratedPayload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallConversationInsightsGeneratedPayload (
        CallConversationInsightsGeneratedPayload callConversationInsightsGeneratedPayload
    ) : base(callConversationInsightsGeneratedPayload)
    {  }
    #pragma warning restore CS8618

    public CallConversationInsightsGeneratedPayload (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallConversationInsightsGeneratedPayload (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallConversationInsightsGeneratedPayloadFromRaw.FromRawUnchecked"/>
    public static CallConversationInsightsGeneratedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallConversationInsightsGeneratedPayloadFromRaw : IFromRawJson<CallConversationInsightsGeneratedPayload>
{
    /// <inheritdoc/>
    public CallConversationInsightsGeneratedPayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallConversationInsightsGeneratedPayload.FromRawUnchecked(rawData);
}/// <summary>
/// The type of calling party connection.
/// </summary>
[JsonConverter(typeof(CallConversationInsightsGeneratedPayloadCallingPartyTypeConverter))]
public enum CallConversationInsightsGeneratedPayloadCallingPartyType
{
    Pstn, Sip
}sealed class CallConversationInsightsGeneratedPayloadCallingPartyTypeConverter : JsonConverter<CallConversationInsightsGeneratedPayloadCallingPartyType>
{
    public override CallConversationInsightsGeneratedPayloadCallingPartyType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pstn"=>CallConversationInsightsGeneratedPayloadCallingPartyType.Pstn,
            "sip"=>CallConversationInsightsGeneratedPayloadCallingPartyType.Sip,
            _ =>(CallConversationInsightsGeneratedPayloadCallingPartyType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallConversationInsightsGeneratedPayloadCallingPartyType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallConversationInsightsGeneratedPayloadCallingPartyType.Pstn=>"pstn",
            CallConversationInsightsGeneratedPayloadCallingPartyType.Sip=>"sip",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// ID that is unique to the insight result being generated for the call.
    /// </summary>
    public string? InsightID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "insight_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("insight_id", value);
        }
    }

    /// <summary>
    /// The result of the insight.
    /// </summary>
    public ResultResult? ResultValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ResultResult>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InsightID;
        this.ResultValue?.Validate();
    }

    public Result ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result (Result result) : base(result)
    {  }
    #pragma warning restore CS8618

    public Result (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Result (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Result.FromRawUnchecked(rawData);
}/// <summary>
/// The result of the insight.
/// </summary>
[JsonConverter(typeof(ResultResultConverter))]
public record class ResultResult : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ResultResult (
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public ResultResult (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ResultResult (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInsightObject(out var value)) {
///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInsightObject(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<IReadOnlyDictionary<string, JsonElement>> insightObjectResult,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                insightObjectResult(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ResultResult");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> insightObjectResult,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value=>insightObjectResult(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ResultResult")
        } ;
    }

    public static implicit operator ResultResult (
        Dictionary<string, JsonElement> value
    )=> new((IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator ResultResult (string value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of ResultResult");
        }
    }

    public virtual bool Equals(ResultResult? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { IReadOnlyDictionary<string, JsonElement> _=>0, string _=>1, _ =>-1 } ;
    }
}sealed class ResultResultConverter : JsonConverter<ResultResult>
{
    public override ResultResult? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<IReadOnlyDictionary<string, JsonElement>>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, ResultResult value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(CallConversationInsightsGeneratedRecordTypeConverter))]
public enum CallConversationInsightsGeneratedRecordType
{
    Event
}sealed class CallConversationInsightsGeneratedRecordTypeConverter : JsonConverter<CallConversationInsightsGeneratedRecordType>
{
    public override CallConversationInsightsGeneratedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event"=>CallConversationInsightsGeneratedRecordType.Event,
            _ =>(CallConversationInsightsGeneratedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CallConversationInsightsGeneratedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CallConversationInsightsGeneratedRecordType.Event=>"event",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}