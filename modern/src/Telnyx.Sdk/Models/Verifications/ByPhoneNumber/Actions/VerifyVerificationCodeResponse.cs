using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Verifications.ByPhoneNumber.Actions;

[JsonConverter(typeof(JsonModelConverter<VerifyVerificationCodeResponse, VerifyVerificationCodeResponseFromRaw>))]
public sealed record class VerifyVerificationCodeResponse : JsonModel
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

    public VerifyVerificationCodeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyVerificationCodeResponse (
        VerifyVerificationCodeResponse verifyVerificationCodeResponse
    ) : base(verifyVerificationCodeResponse)
    {  }
    #pragma warning restore CS8618

    public VerifyVerificationCodeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyVerificationCodeResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyVerificationCodeResponseFromRaw.FromRawUnchecked"/>
    public static VerifyVerificationCodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VerifyVerificationCodeResponse (Data data) : this()
    { this.Data = data; }
}

class VerifyVerificationCodeResponseFromRaw : IFromRawJson<VerifyVerificationCodeResponse>
{
    /// <inheritdoc/>
    public VerifyVerificationCodeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyVerificationCodeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// +E164 formatted phone number.
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
    /// Identifies if the verification code has been accepted or rejected.
    /// </summary>
    public required ApiEnum<string, ResponseCode> ResponseCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ResponseCode>>(
                "response_code"
            );
        }
        init { this._rawData.Set("response_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        this.ResponseCode.Validate();
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
/// Identifies if the verification code has been accepted or rejected.
/// </summary>
[JsonConverter(typeof(ResponseCodeConverter))]
public enum ResponseCode
{
    Accepted, Rejected
}sealed class ResponseCodeConverter : JsonConverter<ResponseCode>
{
    public override ResponseCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted"=>ResponseCode.Accepted,
            "rejected"=>ResponseCode.Rejected,
            _ =>(ResponseCode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ResponseCode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ResponseCode.Accepted=>"accepted",
            ResponseCode.Rejected=>"rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}