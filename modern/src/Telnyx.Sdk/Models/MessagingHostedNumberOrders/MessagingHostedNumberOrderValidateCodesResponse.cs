using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingHostedNumberOrders;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderValidateCodesResponse, MessagingHostedNumberOrderValidateCodesResponseFromRaw>))]
public sealed record class MessagingHostedNumberOrderValidateCodesResponse : JsonModel
{
    public MessagingHostedNumberOrderValidateCodesResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingHostedNumberOrderValidateCodesResponseData>(
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

    public MessagingHostedNumberOrderValidateCodesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderValidateCodesResponse (
        MessagingHostedNumberOrderValidateCodesResponse messagingHostedNumberOrderValidateCodesResponse
    ) : base(messagingHostedNumberOrderValidateCodesResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderValidateCodesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderValidateCodesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderValidateCodesResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderValidateCodesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberOrderValidateCodesResponseFromRaw : IFromRawJson<MessagingHostedNumberOrderValidateCodesResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderValidateCodesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderValidateCodesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderValidateCodesResponseData, MessagingHostedNumberOrderValidateCodesResponseDataFromRaw>))]
public sealed record class MessagingHostedNumberOrderValidateCodesResponseData : JsonModel
{
    public required string OrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "order_id"
            );
        }
        init { this._rawData.Set("order_id", value); }
    }

    public required IReadOnlyList<MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber> PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber>>(
                "phone_numbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OrderID;
        foreach (var item in this.PhoneNumbers)
        {
            item.Validate();
        }
    }

    public MessagingHostedNumberOrderValidateCodesResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderValidateCodesResponseData (
        MessagingHostedNumberOrderValidateCodesResponseData messagingHostedNumberOrderValidateCodesResponseData
    ) : base(messagingHostedNumberOrderValidateCodesResponseData)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderValidateCodesResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderValidateCodesResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderValidateCodesResponseDataFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderValidateCodesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingHostedNumberOrderValidateCodesResponseDataFromRaw : IFromRawJson<MessagingHostedNumberOrderValidateCodesResponseData>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderValidateCodesResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderValidateCodesResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber, MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumberFromRaw>))]
public sealed record class MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber : JsonModel
{
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        this.Status.Validate();
    }

    public MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber (
        MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber messagingHostedNumberOrderValidateCodesResponseDataPhoneNumber
    ) : base(messagingHostedNumberOrderValidateCodesResponseDataPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumberFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumberFromRaw : IFromRawJson<MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderValidateCodesResponseDataPhoneNumber.FromRawUnchecked(rawData);
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Verified, Rejected, AlreadyVerified
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
            "verified"=>Status.Verified,
            "rejected"=>Status.Rejected,
            "already_verified"=>Status.AlreadyVerified,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Verified=>"verified",
            Status.Rejected=>"rejected",
            Status.AlreadyVerified=>"already_verified",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}