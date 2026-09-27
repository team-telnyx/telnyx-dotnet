using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailValidations;

[JsonConverter(typeof(JsonModelConverter<EmailValidationCreateResponse, EmailValidationCreateResponseFromRaw>))]
public sealed record class EmailValidationCreateResponse : JsonModel
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

    public EmailValidationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailValidationCreateResponse (
        EmailValidationCreateResponse emailValidationCreateResponse
    ) : base(emailValidationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public EmailValidationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailValidationCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailValidationCreateResponseFromRaw.FromRawUnchecked"/>
    public static EmailValidationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailValidationCreateResponse (Data data) : this()
    { this.Data = data; }
}

class EmailValidationCreateResponseFromRaw : IFromRawJson<EmailValidationCreateResponse>
{
    /// <inheritdoc/>
    public EmailValidationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailValidationCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required EmailValidationChecks Checks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailValidationChecks>(
                "checks"
            );
        }
        init { this._rawData.Set("checks", value); }
    }

    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
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

    public required float RiskScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<float>(
                "risk_score"
            );
        }
        init { this._rawData.Set("risk_score", value); }
    }

    public required bool Valid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "valid"
            );
        }
        init { this._rawData.Set("valid", value); }
    }

    /// <summary>
    /// Suggested correction for typo. Omitted when nil.
    /// </summary>
    public string? DidYouMean {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "did_you_mean"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("did_you_mean", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Checks.Validate();
        _ = this.Email;
        this.RecordType.Validate();
        _ = this.RiskScore;
        _ = this.Valid;
        _ = this.DidYouMean;
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
    EmailValidation
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_validation"=>RecordType.EmailValidation, _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailValidation=>"email_validation",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}