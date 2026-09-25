using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.VerifiedNumbers;

[JsonConverter(typeof(JsonModelConverter<VerifiedNumber, VerifiedNumberFromRaw>))]
public sealed record class VerifiedNumber : JsonModel
{
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
    /// The possible verified numbers record types.
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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

    public string? VerifiedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "verified_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verified_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneNumber;
        this.RecordType?.Validate();
        _ = this.VerifiedAt;
    }

    public VerifiedNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifiedNumber (VerifiedNumber verifiedNumber) : base(verifiedNumber)
    {  }
    #pragma warning restore CS8618

    public VerifiedNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifiedNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifiedNumberFromRaw.FromRawUnchecked"/>
    public static VerifiedNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifiedNumberFromRaw : IFromRawJson<VerifiedNumber>
{
    /// <inheritdoc/>
    public VerifiedNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifiedNumber.FromRawUnchecked(rawData);
}

/// <summary>
/// The possible verified numbers record types.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    VerifiedNumber
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "verified_number"=>RecordType.VerifiedNumber, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.VerifiedNumber=>"verified_number",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}