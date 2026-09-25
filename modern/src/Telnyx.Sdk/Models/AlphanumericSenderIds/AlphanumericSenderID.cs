using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AlphanumericSenderIds;

[JsonConverter(typeof(JsonModelConverter<AlphanumericSenderID, AlphanumericSenderIDFromRaw>))]
public sealed record class AlphanumericSenderID : JsonModel
{
    /// <summary>
    /// Uniquely identifies the alphanumeric sender ID resource.
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
    /// The alphanumeric sender ID string.
    /// </summary>
    public string? AlphanumericSenderIDValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "alphanumeric_sender_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("alphanumeric_sender_id", value);
        }
    }

    /// <summary>
    /// The messaging profile this sender ID belongs to.
    /// </summary>
    public string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("messaging_profile_id", value);
        }
    }

    /// <summary>
    /// The organization that owns this sender ID.
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

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

    /// <summary>
    /// A US long code number to use as fallback when sending to US destinations.
    /// </summary>
    public string? UsLongCodeFallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "us_long_code_fallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("us_long_code_fallback", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AlphanumericSenderIDValue;
        _ = this.MessagingProfileID;
        _ = this.OrganizationID;
        this.RecordType?.Validate();
        _ = this.UsLongCodeFallback;
    }

    public AlphanumericSenderID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlphanumericSenderID (
        AlphanumericSenderID alphanumericSenderID
    ) : base(alphanumericSenderID)
    {  }
    #pragma warning restore CS8618

    public AlphanumericSenderID (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AlphanumericSenderID (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AlphanumericSenderIDFromRaw.FromRawUnchecked"/>
    public static AlphanumericSenderID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AlphanumericSenderIDFromRaw : IFromRawJson<AlphanumericSenderID>
{
    /// <inheritdoc/>
    public AlphanumericSenderID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AlphanumericSenderID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    AlphanumericSenderID
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
            "alphanumeric_sender_id"=>RecordType.AlphanumericSenderID,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.AlphanumericSenderID=>"alphanumeric_sender_id",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}