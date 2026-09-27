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

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberOrderCreateVerificationCodesResponse, MessagingHostedNumberOrderCreateVerificationCodesResponseFromRaw>))]
public sealed record class MessagingHostedNumberOrderCreateVerificationCodesResponse : JsonModel
{
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public MessagingHostedNumberOrderCreateVerificationCodesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberOrderCreateVerificationCodesResponse (
        MessagingHostedNumberOrderCreateVerificationCodesResponse messagingHostedNumberOrderCreateVerificationCodesResponse
    ) : base(messagingHostedNumberOrderCreateVerificationCodesResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberOrderCreateVerificationCodesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberOrderCreateVerificationCodesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberOrderCreateVerificationCodesResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberOrderCreateVerificationCodesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MessagingHostedNumberOrderCreateVerificationCodesResponse (
        IReadOnlyList<Data> data
    ) : this()
    { this.Data = data; }
}

class MessagingHostedNumberOrderCreateVerificationCodesResponseFromRaw : IFromRawJson<MessagingHostedNumberOrderCreateVerificationCodesResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberOrderCreateVerificationCodesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberOrderCreateVerificationCodesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Verification code result response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Phone number for which the verification code was created
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <summary>
    /// Error message describing why the verification code creation failed
    /// </summary>
    public string? Error {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Type of verification method used
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Unique identifier for the verification code
    /// </summary>
    public string? VerificationCodeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verification_code_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verification_code_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        _ = this.Error;
        this.Type?.Validate();
        _ = this.VerificationCodeID;
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

    [SetsRequiredMembers]
    public Data (string phoneNumber) : this()
    { this.PhoneNumber = phoneNumber; }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// Type of verification method used
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Sms, Call
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type>
{
    public override global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type.Sms,
            "call"=>global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type.Call,
            _ =>(global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type.Sms=>"sms",
            global::Telnyx.Sdk.Models.MessagingHostedNumberOrders.Type.Call=>"call",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}