using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.DetailRecords;

/// <summary>
/// An object following one of the schemas published in https://developers.telnyx.com/docs/api/v2/detail-records
/// </summary>
[JsonConverter(typeof(DetailRecordListResponseConverter))]
public record class DetailRecordListResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string RecordType {
        get {
            return Match(messageDetailRecord: ( x )=>x.RecordType,
            conferenceDetailRecord: ( x )=>x.RecordType,
            conferenceParticipantDetailRecord: ( x )=>x.RecordType,
            amdDetailRecord: ( x )=>x.RecordType,
            verifyDetailRecord: ( x )=>x.RecordType,
            simCardUsageDetailRecord: ( x )=>x.RecordType,
            mediaStorageDetailRecord: ( x )=>x.RecordType);
        }
    }

    public string? Cost {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.Cost,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( x )=>x.Cost,
            amdDetailRecord: ( x )=>x.Cost,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( x )=>x.Cost);
        }
    }

    public System::DateTimeOffset? CreatedAt {
        get {
            return Match<System::DateTimeOffset?>(messageDetailRecord: ( x )=>x.CreatedAt,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( x )=>x.CreatedAt,
            simCardUsageDetailRecord: ( x )=>x.CreatedAt,
            mediaStorageDetailRecord: ( x )=>x.CreatedAt);
        }
    }

    public string? Currency {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.Currency,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( x )=>x.Currency,
            amdDetailRecord: ( x )=>x.Currency,
            verifyDetailRecord: ( x )=>x.Currency,
            simCardUsageDetailRecord: ( x )=>x.Currency,
            mediaStorageDetailRecord: ( x )=>x.Currency);
        }
    }

    public string? DeliveryStatus {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.DeliveryStatus,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( x )=>x.DeliveryStatus,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? Mcc {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.Mcc,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( x )=>x.Mcc,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? Mnc {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.Mnc,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( x )=>x.Mnc,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? Rate {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.Rate,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( x )=>x.Rate,
            amdDetailRecord: ( x )=>x.Rate,
            verifyDetailRecord: ( x )=>x.Rate,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( x )=>x.Rate);
        }
    }

    public string? Tags {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.Tags,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( x )=>x.Tags,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            return Match<System::DateTimeOffset?>(messageDetailRecord: ( x )=>x.UpdatedAt,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( x )=>x.UpdatedAt,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? UserID {
        get {
            return Match<string?>(messageDetailRecord: ( x )=>x.UserID,
            conferenceDetailRecord: ( x )=>x.UserID,
            conferenceParticipantDetailRecord: ( x )=>x.UserID,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( x )=>x.UserID);
        }
    }

    public string? ID {
        get {
            return Match<string?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( x )=>x.ID,
            conferenceParticipantDetailRecord: ( x )=>x.ID,
            amdDetailRecord: ( x )=>x.ID,
            verifyDetailRecord: ( x )=>x.ID,
            simCardUsageDetailRecord: ( x )=>x.ID,
            mediaStorageDetailRecord: ( x )=>x.ID);
        }
    }

    public string? CallLegID {
        get {
            return Match<string?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( x )=>x.CallLegID,
            conferenceParticipantDetailRecord: ( x )=>x.CallLegID,
            amdDetailRecord: ( x )=>x.CallLegID,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public long? CallSec {
        get {
            return Match<long?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( x )=>x.CallSec,
            conferenceParticipantDetailRecord: ( x )=>x.CallSec,
            amdDetailRecord: ( _ )=>null,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? CallSessionID {
        get {
            return Match<string?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( x )=>x.CallSessionID,
            conferenceParticipantDetailRecord: ( x )=>x.CallSessionID,
            amdDetailRecord: ( x )=>x.CallSessionID,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? ConnectionID {
        get {
            return Match<string?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( x )=>x.ConnectionID,
            conferenceParticipantDetailRecord: ( _ )=>null,
            amdDetailRecord: ( x )=>x.ConnectionID,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public bool? IsTelnyxBillable {
        get {
            return Match<bool?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( x )=>x.IsTelnyxBillable,
            conferenceParticipantDetailRecord: ( x )=>x.IsTelnyxBillable,
            amdDetailRecord: ( x )=>x.IsTelnyxBillable,
            verifyDetailRecord: ( _ )=>null,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( _ )=>null);
        }
    }

    public string? RateMeasuredIn {
        get {
            return Match<string?>(messageDetailRecord: ( _ )=>null,
            conferenceDetailRecord: ( _ )=>null,
            conferenceParticipantDetailRecord: ( x )=>x.RateMeasuredIn,
            amdDetailRecord: ( x )=>x.RateMeasuredIn,
            verifyDetailRecord: ( x )=>x.RateMeasuredIn,
            simCardUsageDetailRecord: ( _ )=>null,
            mediaStorageDetailRecord: ( x )=>x.RateMeasuredIn);
        }
    }

    public DetailRecordListResponse (
        MessageDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (
        ConferenceDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (
        ConferenceParticipantDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (
        AmdDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (
        VerifyDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (
        SimCardUsageDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (
        MediaStorageDetailRecord value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public DetailRecordListResponse (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MessageDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMessageDetailRecord(out var value)) {
///     // `value` is of type `MessageDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMessageDetailRecord(
        [NotNullWhen(true)] out MessageDetailRecord? value
    )
    {
        value =this.Value as MessageDetailRecord ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceDetailRecord(out var value)) {
///     // `value` is of type `ConferenceDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceDetailRecord(
        [NotNullWhen(true)] out ConferenceDetailRecord? value
    )
    {
        value =this.Value as ConferenceDetailRecord ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ConferenceParticipantDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConferenceParticipantDetailRecord(out var value)) {
///     // `value` is of type `ConferenceParticipantDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConferenceParticipantDetailRecord(
        [NotNullWhen(true)] out ConferenceParticipantDetailRecord? value
    )
    {
        value =this.Value as ConferenceParticipantDetailRecord ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="AmdDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAmdDetailRecord(out var value)) {
///     // `value` is of type `AmdDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAmdDetailRecord(
        [NotNullWhen(true)] out AmdDetailRecord? value
    )
    {
        value =this.Value as AmdDetailRecord ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="VerifyDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickVerifyDetailRecord(out var value)) {
///     // `value` is of type `VerifyDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickVerifyDetailRecord(
        [NotNullWhen(true)] out VerifyDetailRecord? value
    )
    {
        value =this.Value as VerifyDetailRecord ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SimCardUsageDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSimCardUsageDetailRecord(out var value)) {
///     // `value` is of type `SimCardUsageDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSimCardUsageDetailRecord(
        [NotNullWhen(true)] out SimCardUsageDetailRecord? value
    )
    {
        value =this.Value as SimCardUsageDetailRecord ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="MediaStorageDetailRecord"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMediaStorageDetailRecord(out var value)) {
///     // `value` is of type `MediaStorageDetailRecord`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMediaStorageDetailRecord(
        [NotNullWhen(true)] out MediaStorageDetailRecord? value
    )
    {
        value =this.Value as MediaStorageDetailRecord ;
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
///     (MessageDetailRecord value) =&gt; {...},
///     (ConferenceDetailRecord value) =&gt; {...},
///     (ConferenceParticipantDetailRecord value) =&gt; {...},
///     (AmdDetailRecord value) =&gt; {...},
///     (VerifyDetailRecord value) =&gt; {...},
///     (SimCardUsageDetailRecord value) =&gt; {...},
///     (MediaStorageDetailRecord value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<MessageDetailRecord> messageDetailRecord,
        System::Action<ConferenceDetailRecord> conferenceDetailRecord,
        System::Action<ConferenceParticipantDetailRecord> conferenceParticipantDetailRecord,
        System::Action<AmdDetailRecord> amdDetailRecord,
        System::Action<VerifyDetailRecord> verifyDetailRecord,
        System::Action<SimCardUsageDetailRecord> simCardUsageDetailRecord,
        System::Action<MediaStorageDetailRecord> mediaStorageDetailRecord
    )
    {
        switch (this.Value)
        {
            case MessageDetailRecord value:
                messageDetailRecord(value);
                break;
            case ConferenceDetailRecord value:
                conferenceDetailRecord(value);
                break;
            case ConferenceParticipantDetailRecord value:
                conferenceParticipantDetailRecord(value);
                break;
            case AmdDetailRecord value:
                amdDetailRecord(value);
                break;
            case VerifyDetailRecord value:
                verifyDetailRecord(value);
                break;
            case SimCardUsageDetailRecord value:
                simCardUsageDetailRecord(value);
                break;
            case MediaStorageDetailRecord value:
                mediaStorageDetailRecord(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of DetailRecordListResponse");

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
///     (MessageDetailRecord value) =&gt; {...},
///     (ConferenceDetailRecord value) =&gt; {...},
///     (ConferenceParticipantDetailRecord value) =&gt; {...},
///     (AmdDetailRecord value) =&gt; {...},
///     (VerifyDetailRecord value) =&gt; {...},
///     (SimCardUsageDetailRecord value) =&gt; {...},
///     (MediaStorageDetailRecord value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<MessageDetailRecord, T> messageDetailRecord,
        System::Func<ConferenceDetailRecord, T> conferenceDetailRecord,
        System::Func<ConferenceParticipantDetailRecord, T> conferenceParticipantDetailRecord,
        System::Func<AmdDetailRecord, T> amdDetailRecord,
        System::Func<VerifyDetailRecord, T> verifyDetailRecord,
        System::Func<SimCardUsageDetailRecord, T> simCardUsageDetailRecord,
        System::Func<MediaStorageDetailRecord, T> mediaStorageDetailRecord
    )
    {
        return this.Value switch
        {
            MessageDetailRecord value=>messageDetailRecord(value),
            ConferenceDetailRecord value=>conferenceDetailRecord(value),
            ConferenceParticipantDetailRecord value=>conferenceParticipantDetailRecord(value),
            AmdDetailRecord value=>amdDetailRecord(value),
            VerifyDetailRecord value=>verifyDetailRecord(value),
            SimCardUsageDetailRecord value=>simCardUsageDetailRecord(value),
            MediaStorageDetailRecord value=>mediaStorageDetailRecord(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of DetailRecordListResponse")
        } ;
    }

    public static implicit operator DetailRecordListResponse (
        MessageDetailRecord value
    )=> new(value) ;

    public static implicit operator DetailRecordListResponse (
        ConferenceDetailRecord value
    )=> new(value) ;

    public static implicit operator DetailRecordListResponse (
        ConferenceParticipantDetailRecord value
    )=> new(value) ;

    public static implicit operator DetailRecordListResponse (
        AmdDetailRecord value
    )=> new(value) ;

    public static implicit operator DetailRecordListResponse (
        VerifyDetailRecord value
    )=> new(value) ;

    public static implicit operator DetailRecordListResponse (
        SimCardUsageDetailRecord value
    )=> new(value) ;

    public static implicit operator DetailRecordListResponse (
        MediaStorageDetailRecord value
    )=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of DetailRecordListResponse");
        }
        this.Switch((messageDetailRecord) => messageDetailRecord.Validate(),
        (conferenceDetailRecord) => conferenceDetailRecord.Validate(),
        (conferenceParticipantDetailRecord) => conferenceParticipantDetailRecord.Validate(),
        (amdDetailRecord) => amdDetailRecord.Validate(),
        (verifyDetailRecord) => verifyDetailRecord.Validate(),
        (simCardUsageDetailRecord) => simCardUsageDetailRecord.Validate(),
        (mediaStorageDetailRecord) => mediaStorageDetailRecord.Validate());
    }

    public virtual bool Equals(DetailRecordListResponse? other)
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
        {
            MessageDetailRecord _=>0,
            ConferenceDetailRecord _=>1,
            ConferenceParticipantDetailRecord _=>2,
            AmdDetailRecord _=>3,
            VerifyDetailRecord _=>4,
            SimCardUsageDetailRecord _=>5,
            MediaStorageDetailRecord _=>6,
            _ =>-1
        } ;
    }
}

sealed class DetailRecordListResponseConverter : JsonConverter<DetailRecordListResponse>
{
    public override DetailRecordListResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? recordType;
        try {
            recordType = element.GetProperty("record_type").GetString();
        } catch {
            recordType = null;
        }

        switch (recordType)
        {
            default:
                {
                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<MessageDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<ConferenceDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<ConferenceParticipantDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<AmdDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<VerifyDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<SimCardUsageDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<MediaStorageDetailRecord>(element, options);
                        if (deserialized != null) {
                            deserialized.Validate();
                            return new(deserialized, element);
                        }
                    }
                    catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
                    {
                        // ignore
                    }

                    return new(element);
                }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        DetailRecordListResponse value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<MessageDetailRecord, MessageDetailRecordFromRaw>))]
public sealed record class MessageDetailRecord : JsonModel
{
    /// <summary>
    /// Identifies the record schema
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Country-specific carrier used to send or receive the message
    /// </summary>
    public string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier", value);
        }
    }

    /// <summary>
    /// Fee charged by certain carriers in order to deliver certain message types.
    /// Telnyx passes this fee on to the customer according to our pricing table
    /// </summary>
    public string? CarrierFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier_fee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_fee", value);
        }
    }

    /// <summary>
    /// The recipient of the message (to parameter in the Messaging API)
    /// </summary>
    public string? Cld {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cld"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cld", value);
        }
    }

    /// <summary>
    /// The sender of the message (from parameter in the Messaging API). For Alphanumeric
    /// ID messages, this is the sender ID value
    /// </summary>
    public string? Cli {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cli"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cli", value);
        }
    }

    /// <summary>
    /// Message completion time
    /// </summary>
    public System::DateTimeOffset? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "completed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("completed_at", value);
        }
    }

    /// <summary>
    /// Amount, in the user currency, for the Telnyx billing cost
    /// </summary>
    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// Two-letter representation of the country of the cld property using the ISO
    /// 3166-1 alpha-2 format
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Message creation time
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Telnyx account currency used to describe monetary values, including billing cost
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Final webhook delivery status
    /// </summary>
    public string? DeliveryStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivery_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivery_status", value);
        }
    }

    /// <summary>
    /// Failover customer-provided URL which Telnyx posts delivery status webhooks to
    /// </summary>
    public string? DeliveryStatusFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivery_status_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivery_status_failover_url", value);
        }
    }

    /// <summary>
    /// Primary customer-provided URL which Telnyx posts delivery status webhooks to
    /// </summary>
    public string? DeliveryStatusWebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivery_status_webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivery_status_webhook_url", value);
        }
    }

    /// <summary>
    /// Logical direction of the message from the Telnyx customer's perspective.
    /// It's inbound when the Telnyx customer receives the message, or outbound otherwise
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
    /// Telnyx API error codes returned by the Telnyx gateway
    /// </summary>
    public IReadOnlyList<string>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates whether this is a Free-To-End-User (FTEU) short code message
    /// </summary>
    public bool? Fteu {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "fteu"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fteu", value);
        }
    }

    /// <summary>
    /// Mobile country code. Only available for certain products, such as Global Outbound-Only
    /// from Alphanumeric Sender ID
    /// </summary>
    public string? Mcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Describes the Messaging service used to send the message. Available services
    /// are: Short Message Service (SMS), Multimedia Messaging Service (MMS), and
    /// Rich Communication Services (RCS)
    /// </summary>
    public ApiEnum<string, MessageType>? MessageType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MessageType>>(
                "message_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message_type", value);
        }
    }

    /// <summary>
    /// Mobile network code. Only available for certain products, such as Global Outbound-Only
    /// from Alphanumeric Sender ID
    /// </summary>
    public string? Mnc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <summary>
    /// Indicates whether both sender and recipient numbers are Telnyx-managed
    /// </summary>
    public bool? OnNet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "on_net"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_net", value);
        }
    }

    /// <summary>
    /// Number of message parts. The message is broken down in multiple parts when
    /// its length surpasses the limit of 160 characters
    /// </summary>
    public long? Parts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "parts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("parts", value);
        }
    }

    /// <summary>
    /// Unique identifier of the Messaging Profile used to send or receive the message
    /// </summary>
    public string? ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_id", value);
        }
    }

    /// <summary>
    /// Name of the Messaging Profile used to send or receive the message
    /// </summary>
    public string? ProfileName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_name", value);
        }
    }

    /// <summary>
    /// Currency amount per billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Time when the message was sent
    /// </summary>
    public System::DateTimeOffset? SentAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "sent_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sent_at", value);
        }
    }

    /// <summary>
    /// Two-letter representation of the country of the cli property using the ISO
    /// 3166-1 alpha-2 format
    /// </summary>
    public string? SourceCountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "source_country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source_country_code", value);
        }
    }

    /// <summary>
    /// Final status of the message after the delivery attempt
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
    /// Comma-separated tags assigned to the Telnyx number associated with the message
    /// </summary>
    public string? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tags", value);
        }
    }

    /// <summary>
    /// Message updated time
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// Identifier of the Telnyx account who owns the message
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <summary>
    /// Unique identifier of the message
    /// </summary>
    public string? Uuid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uuid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uuid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.Carrier;
        _ = this.CarrierFee;
        _ = this.Cld;
        _ = this.Cli;
        _ = this.CompletedAt;
        _ = this.Cost;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DeliveryStatus;
        _ = this.DeliveryStatusFailoverUrl;
        _ = this.DeliveryStatusWebhookUrl;
        this.Direction?.Validate();
        _ = this.Errors;
        _ = this.Fteu;
        _ = this.Mcc;
        this.MessageType?.Validate();
        _ = this.Mnc;
        _ = this.OnNet;
        _ = this.Parts;
        _ = this.ProfileID;
        _ = this.ProfileName;
        _ = this.Rate;
        _ = this.SentAt;
        _ = this.SourceCountryCode;
        this.Status?.Validate();
        _ = this.Tags;
        _ = this.UpdatedAt;
        _ = this.UserID;
        _ = this.Uuid;
    }

    public MessageDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageDetailRecord (MessageDetailRecord messageDetailRecord) : base(
        messageDetailRecord
    )
    {  }
    #pragma warning restore CS8618

    public MessageDetailRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageDetailRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageDetailRecordFromRaw.FromRawUnchecked"/>
    public static MessageDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MessageDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class MessageDetailRecordFromRaw : IFromRawJson<MessageDetailRecord>
{
    /// <inheritdoc/>
    public MessageDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageDetailRecord.FromRawUnchecked(rawData);
}/// <summary>
/// Logical direction of the message from the Telnyx customer's perspective. It's
/// inbound when the Telnyx customer receives the message, or outbound otherwise
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
/// Describes the Messaging service used to send the message. Available services are:
/// Short Message Service (SMS), Multimedia Messaging Service (MMS), and Rich Communication
/// Services (RCS)
/// </summary>
[JsonConverter(typeof(MessageTypeConverter))]
public enum MessageType
{
    Sms, Mms, Rcs
}sealed class MessageTypeConverter : JsonConverter<MessageType>
{
    public override MessageType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MessageType.Sms,
            "MMS"=>MessageType.Mms,
            "RCS"=>MessageType.Rcs,
            _ =>(MessageType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, MessageType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageType.Sms=>"SMS",
            MessageType.Mms=>"MMS",
            MessageType.Rcs=>"RCS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Final status of the message after the delivery attempt
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    GwTimeout, Delivered, DlrUnconfirmed, DlrTimeout, Received, GwReject, Failed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gw_timeout"=>Status.GwTimeout,
            "delivered"=>Status.Delivered,
            "dlr_unconfirmed"=>Status.DlrUnconfirmed,
            "dlr_timeout"=>Status.DlrTimeout,
            "received"=>Status.Received,
            "gw_reject"=>Status.GwReject,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.GwTimeout=>"gw_timeout",
            Status.Delivered=>"delivered",
            Status.DlrUnconfirmed=>"dlr_unconfirmed",
            Status.DlrTimeout=>"dlr_timeout",
            Status.Received=>"received",
            Status.GwReject=>"gw_reject",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ConferenceDetailRecord, ConferenceDetailRecordFromRaw>))]
public sealed record class ConferenceDetailRecord : JsonModel
{
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Conference id
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
    /// Telnyx UUID that identifies the conference call leg
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
    /// Duration of the conference call in seconds
    /// </summary>
    public long? CallSec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "call_sec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sec", value);
        }
    }

    /// <summary>
    /// Telnyx UUID that identifies with conference call session
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
    /// Connection id
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
    /// Conference end time
    /// </summary>
    public System::DateTimeOffset? EndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "ended_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ended_at", value);
        }
    }

    /// <summary>
    /// Conference expiry time
    /// </summary>
    public System::DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// Indicates whether Telnyx billing charges might be applicable
    /// </summary>
    public bool? IsTelnyxBillable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_telnyx_billable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_telnyx_billable", value);
        }
    }

    /// <summary>
    /// Conference name
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Sum of the conference call duration for all participants in seconds
    /// </summary>
    public long? ParticipantCallSec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "participant_call_sec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("participant_call_sec", value);
        }
    }

    /// <summary>
    /// Number of participants that joined the conference call
    /// </summary>
    public long? ParticipantCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "participant_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("participant_count", value);
        }
    }

    /// <summary>
    /// Region where the conference is hosted
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// Conference start time
    /// </summary>
    public System::DateTimeOffset? StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    /// <summary>
    /// User id
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.ID;
        _ = this.CallLegID;
        _ = this.CallSec;
        _ = this.CallSessionID;
        _ = this.ConnectionID;
        _ = this.EndedAt;
        _ = this.ExpiresAt;
        _ = this.IsTelnyxBillable;
        _ = this.Name;
        _ = this.ParticipantCallSec;
        _ = this.ParticipantCount;
        _ = this.Region;
        _ = this.StartedAt;
        _ = this.UserID;
    }

    public ConferenceDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceDetailRecord (
        ConferenceDetailRecord conferenceDetailRecord
    ) : base(conferenceDetailRecord)
    {  }
    #pragma warning restore CS8618

    public ConferenceDetailRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceDetailRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceDetailRecordFromRaw.FromRawUnchecked"/>
    public static ConferenceDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConferenceDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class ConferenceDetailRecordFromRaw : IFromRawJson<ConferenceDetailRecord>
{
    /// <inheritdoc/>
    public ConferenceDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceDetailRecord.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ConferenceParticipantDetailRecord, ConferenceParticipantDetailRecordFromRaw>))]
public sealed record class ConferenceParticipantDetailRecord : JsonModel
{
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Participant id
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
    /// Duration of the conference call for billing purposes
    /// </summary>
    public long? BilledSec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "billed_sec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billed_sec", value);
        }
    }

    /// <summary>
    /// Telnyx UUID that identifies the conference call leg
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
    /// Duration of the conference call in seconds
    /// </summary>
    public long? CallSec {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "call_sec"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sec", value);
        }
    }

    /// <summary>
    /// Telnyx UUID that identifies with conference call session
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
    /// Conference id
    /// </summary>
    public string? ConferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_id", value);
        }
    }

    /// <summary>
    /// Currency amount for Telnyx billing cost
    /// </summary>
    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// Telnyx account currency used to describe monetary values, including billing cost
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Number called by the participant to join the conference
    /// </summary>
    public string? DestinationNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "destination_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("destination_number", value);
        }
    }

    /// <summary>
    /// Indicates whether Telnyx billing charges might be applicable
    /// </summary>
    public bool? IsTelnyxBillable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_telnyx_billable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_telnyx_billable", value);
        }
    }

    /// <summary>
    /// Participant join time
    /// </summary>
    public System::DateTimeOffset? JoinedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "joined_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("joined_at", value);
        }
    }

    /// <summary>
    /// Participant leave time
    /// </summary>
    public System::DateTimeOffset? LeftAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "left_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("left_at", value);
        }
    }

    /// <summary>
    /// Participant origin number used in the conference call
    /// </summary>
    public string? OriginatingNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "originating_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("originating_number", value);
        }
    }

    /// <summary>
    /// Currency amount per billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? RateMeasuredIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate_measured_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate_measured_in", value);
        }
    }

    /// <summary>
    /// User id
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.ID;
        _ = this.BilledSec;
        _ = this.CallLegID;
        _ = this.CallSec;
        _ = this.CallSessionID;
        _ = this.ConferenceID;
        _ = this.Cost;
        _ = this.Currency;
        _ = this.DestinationNumber;
        _ = this.IsTelnyxBillable;
        _ = this.JoinedAt;
        _ = this.LeftAt;
        _ = this.OriginatingNumber;
        _ = this.Rate;
        _ = this.RateMeasuredIn;
        _ = this.UserID;
    }

    public ConferenceParticipantDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipantDetailRecord (
        ConferenceParticipantDetailRecord conferenceParticipantDetailRecord
    ) : base(conferenceParticipantDetailRecord)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipantDetailRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipantDetailRecord (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantDetailRecordFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipantDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConferenceParticipantDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class ConferenceParticipantDetailRecordFromRaw : IFromRawJson<ConferenceParticipantDetailRecord>
{
    /// <inheritdoc/>
    public ConferenceParticipantDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipantDetailRecord.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<AmdDetailRecord, AmdDetailRecordFromRaw>))]
public sealed record class AmdDetailRecord : JsonModel
{
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Feature invocation id
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
    /// Billing Group id
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_group_id", value);
        }
    }

    /// <summary>
    /// Name of the Billing Group specified in billing_group_id
    /// </summary>
    public string? BillingGroupName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_group_name", value);
        }
    }

    /// <summary>
    /// Telnyx UUID that identifies the related call leg
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
    /// Telnyx UUID that identifies the related call session
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
    /// Connection id
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
    /// Connection name
    /// </summary>
    public string? ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_name", value);
        }
    }

    /// <summary>
    /// Currency amount for Telnyx billing cost
    /// </summary>
    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// Telnyx account currency used to describe monetary values, including billing cost
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Feature name
    /// </summary>
    public ApiEnum<string, Feature>? Feature {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Feature>>(
                "feature"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("feature", value);
        }
    }

    /// <summary>
    /// Feature invocation time
    /// </summary>
    public System::DateTimeOffset? InvokedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "invoked_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("invoked_at", value);
        }
    }

    /// <summary>
    /// Indicates whether Telnyx billing charges might be applicable
    /// </summary>
    public bool? IsTelnyxBillable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_telnyx_billable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_telnyx_billable", value);
        }
    }

    /// <summary>
    /// Currency amount per billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? RateMeasuredIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate_measured_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate_measured_in", value);
        }
    }

    /// <summary>
    /// User-provided tags
    /// </summary>
    public string? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tags", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.ID;
        _ = this.BillingGroupID;
        _ = this.BillingGroupName;
        _ = this.CallLegID;
        _ = this.CallSessionID;
        _ = this.ConnectionID;
        _ = this.ConnectionName;
        _ = this.Cost;
        _ = this.Currency;
        this.Feature?.Validate();
        _ = this.InvokedAt;
        _ = this.IsTelnyxBillable;
        _ = this.Rate;
        _ = this.RateMeasuredIn;
        _ = this.Tags;
    }

    public AmdDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AmdDetailRecord (AmdDetailRecord amdDetailRecord) : base(
        amdDetailRecord
    )
    {  }
    #pragma warning restore CS8618

    public AmdDetailRecord (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AmdDetailRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AmdDetailRecordFromRaw.FromRawUnchecked"/>
    public static AmdDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AmdDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class AmdDetailRecordFromRaw : IFromRawJson<AmdDetailRecord>
{
    /// <inheritdoc/>
    public AmdDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AmdDetailRecord.FromRawUnchecked(rawData);
}/// <summary>
/// Feature name
/// </summary>
[JsonConverter(typeof(FeatureConverter))]
public enum Feature
{
    Premium
}sealed class FeatureConverter : JsonConverter<Feature>
{
    public override Feature Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "PREMIUM"=>Feature.Premium, _ =>(Feature)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Feature value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Feature.Premium=>"PREMIUM",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<VerifyDetailRecord, VerifyDetailRecordFromRaw>))]
public sealed record class VerifyDetailRecord : JsonModel
{
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Unique ID of the verification
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

    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Telnyx account currency used to describe monetary values, including billing costs
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    public string? DeliveryStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "delivery_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("delivery_status", value);
        }
    }

    /// <summary>
    /// E.164 formatted phone number
    /// </summary>
    public string? DestinationPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "destination_phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("destination_phone_number", value);
        }
    }

    /// <summary>
    /// Currency amount per billing unit used to calculate the Telnyx billing costs
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Billing unit used to calculate the Telnyx billing costs
    /// </summary>
    public string? RateMeasuredIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate_measured_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate_measured_in", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public string? VerificationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verification_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verification_status", value);
        }
    }

    public string? VerifyChannelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verify_channel_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verify_channel_id", value);
        }
    }

    /// <summary>
    /// Depending on the type of verification, the `verify_channel_id` points to
    /// one of the following channel ids; --- verify_channel_type | verify_channel_id
    /// ------------------- | ----------------- sms, psd2           | messaging_id
    /// call, flashcall     | call_control_id ---
    /// </summary>
    public ApiEnum<string, VerifyChannelType>? VerifyChannelType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VerifyChannelType>>(
                "verify_channel_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verify_channel_type", value);
        }
    }

    public string? VerifyProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verify_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verify_profile_id", value);
        }
    }

    /// <summary>
    /// Currency amount for Verify Usage Fee
    /// </summary>
    public string? VerifyUsageFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verify_usage_fee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verify_usage_fee", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DeliveryStatus;
        _ = this.DestinationPhoneNumber;
        _ = this.Rate;
        _ = this.RateMeasuredIn;
        _ = this.UpdatedAt;
        _ = this.VerificationStatus;
        _ = this.VerifyChannelID;
        this.VerifyChannelType?.Validate();
        _ = this.VerifyProfileID;
        _ = this.VerifyUsageFee;
    }

    public VerifyDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyDetailRecord (VerifyDetailRecord verifyDetailRecord) : base(
        verifyDetailRecord
    )
    {  }
    #pragma warning restore CS8618

    public VerifyDetailRecord (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyDetailRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyDetailRecordFromRaw.FromRawUnchecked"/>
    public static VerifyDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VerifyDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class VerifyDetailRecordFromRaw : IFromRawJson<VerifyDetailRecord>
{
    /// <inheritdoc/>
    public VerifyDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyDetailRecord.FromRawUnchecked(rawData);
}/// <summary>
/// Depending on the type of verification, the `verify_channel_id` points to one of
/// the following channel ids; --- verify_channel_type | verify_channel_id -------------------
/// | ----------------- sms, psd2           | messaging_id call, flashcall     |
/// call_control_id ---
/// </summary>
[JsonConverter(typeof(VerifyChannelTypeConverter))]
public enum VerifyChannelType
{
    Sms, Psd2, Call, Flashcall
}sealed class VerifyChannelTypeConverter : JsonConverter<VerifyChannelType>
{
    public override VerifyChannelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>VerifyChannelType.Sms,
            "psd2"=>VerifyChannelType.Psd2,
            "call"=>VerifyChannelType.Call,
            "flashcall"=>VerifyChannelType.Flashcall,
            _ =>(VerifyChannelType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VerifyChannelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VerifyChannelType.Sms=>"sms",
            VerifyChannelType.Psd2=>"psd2",
            VerifyChannelType.Call=>"call",
            VerifyChannelType.Flashcall=>"flashcall",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<SimCardUsageDetailRecord, SimCardUsageDetailRecordFromRaw>))]
public sealed record class SimCardUsageDetailRecord : JsonModel
{
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Unique identifier for this SIM Card Usage
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
    /// Event close time
    /// </summary>
    public System::DateTimeOffset? ClosedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "closed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("closed_at", value);
        }
    }

    /// <summary>
    /// Event creation time
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Telnyx account currency used to describe monetary values, including billing cost
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Data cost
    /// </summary>
    public double? DataCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "data_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_cost", value);
        }
    }

    /// <summary>
    /// Currency amount per billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? DataRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "data_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_rate", value);
        }
    }

    /// <summary>
    /// Unit of wireless link consumption
    /// </summary>
    public string? DataUnit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "data_unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_unit", value);
        }
    }

    /// <summary>
    /// Number of megabytes downloaded
    /// </summary>
    public double? DownlinkData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "downlink_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("downlink_data", value);
        }
    }

    /// <summary>
    /// International Mobile Subscriber Identity
    /// </summary>
    public string? Imsi {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "imsi"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("imsi", value);
        }
    }

    /// <summary>
    /// Ip address that generated the event
    /// </summary>
    public string? IPAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ip_address", value);
        }
    }

    /// <summary>
    /// Mobile country code
    /// </summary>
    public string? Mcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Mobile network code
    /// </summary>
    public string? Mnc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <summary>
    /// Telephone number associated to SIM card
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Unique identifier for SIM card
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// User-provided tags
    /// </summary>
    public string? SimCardTags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_tags", value);
        }
    }

    /// <summary>
    /// Unique identifier for SIM group
    /// </summary>
    public string? SimGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_group_id", value);
        }
    }

    /// <summary>
    /// Sim group name for sim card
    /// </summary>
    public string? SimGroupName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_group_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_group_name", value);
        }
    }

    /// <summary>
    /// Number of megabytes uploaded
    /// </summary>
    public double? UplinkData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "uplink_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uplink_data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.ID;
        _ = this.ClosedAt;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.DataCost;
        _ = this.DataRate;
        _ = this.DataUnit;
        _ = this.DownlinkData;
        _ = this.Imsi;
        _ = this.IPAddress;
        _ = this.Mcc;
        _ = this.Mnc;
        _ = this.PhoneNumber;
        _ = this.SimCardID;
        _ = this.SimCardTags;
        _ = this.SimGroupID;
        _ = this.SimGroupName;
        _ = this.UplinkData;
    }

    public SimCardUsageDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardUsageDetailRecord (
        SimCardUsageDetailRecord simCardUsageDetailRecord
    ) : base(simCardUsageDetailRecord)
    {  }
    #pragma warning restore CS8618

    public SimCardUsageDetailRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardUsageDetailRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardUsageDetailRecordFromRaw.FromRawUnchecked"/>
    public static SimCardUsageDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SimCardUsageDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class SimCardUsageDetailRecordFromRaw : IFromRawJson<SimCardUsageDetailRecord>
{
    /// <inheritdoc/>
    public SimCardUsageDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardUsageDetailRecord.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MediaStorageDetailRecord, MediaStorageDetailRecordFromRaw>))]
public sealed record class MediaStorageDetailRecord : JsonModel
{
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Unique identifier for the Media Storage Event
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
    /// Type of action performed against the Media Storage API
    /// </summary>
    public string? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "action_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action_type", value);
        }
    }

    /// <summary>
    /// Asset id
    /// </summary>
    public string? AssetID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "asset_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("asset_id", value);
        }
    }

    /// <summary>
    /// Currency amount for Telnyx billing cost
    /// </summary>
    public string? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// Event creation time
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Telnyx account currency used to describe monetary values, including billing cost
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Link channel id
    /// </summary>
    public string? LinkChannelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "link_channel_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("link_channel_id", value);
        }
    }

    /// <summary>
    /// Link channel type
    /// </summary>
    public string? LinkChannelType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "link_channel_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("link_channel_type", value);
        }
    }

    /// <summary>
    /// Organization owner id
    /// </summary>
    public string? OrgID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "org_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("org_id", value);
        }
    }

    /// <summary>
    /// Currency amount per billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// Billing unit used to calculate the Telnyx billing cost
    /// </summary>
    public string? RateMeasuredIn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate_measured_in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate_measured_in", value);
        }
    }

    /// <summary>
    /// Request status
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// User id
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <summary>
    /// Webhook id
    /// </summary>
    public string? WebhookID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecordType;
        _ = this.ID;
        _ = this.ActionType;
        _ = this.AssetID;
        _ = this.Cost;
        _ = this.CreatedAt;
        _ = this.Currency;
        _ = this.LinkChannelID;
        _ = this.LinkChannelType;
        _ = this.OrgID;
        _ = this.Rate;
        _ = this.RateMeasuredIn;
        _ = this.Status;
        _ = this.UserID;
        _ = this.WebhookID;
    }

    public MediaStorageDetailRecord ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaStorageDetailRecord (
        MediaStorageDetailRecord mediaStorageDetailRecord
    ) : base(mediaStorageDetailRecord)
    {  }
    #pragma warning restore CS8618

    public MediaStorageDetailRecord (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaStorageDetailRecord (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaStorageDetailRecordFromRaw.FromRawUnchecked"/>
    public static MediaStorageDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MediaStorageDetailRecord (string recordType) : this()
    { this.RecordType = recordType; }
}class MediaStorageDetailRecordFromRaw : IFromRawJson<MediaStorageDetailRecord>
{
    /// <inheritdoc/>
    public MediaStorageDetailRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaStorageDetailRecord.FromRawUnchecked(rawData);
}