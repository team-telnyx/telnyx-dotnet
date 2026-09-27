using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<ShortCode, ShortCodeFromRaw>))]
public sealed record class ShortCode : JsonModel
{
    /// <summary>
    /// Unique identifier for a messaging profile.
    /// </summary>
    public required string? MessagingProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "messaging_profile_id"
            );
        }
        init { this._rawData.Set("messaging_profile_id", value); }
    }

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
    /// ISO 3166-1 alpha-2 country code.
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
    /// ISO 8601 formatted date indicating when the resource was created.
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
    /// Identifies the type of the resource.
    /// </summary>
    public ApiEnum<string, ShortCodeRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ShortCodeRecordType>>(
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
    /// Short digit sequence used to address messages.
    /// </summary>
    public string? ShortCodeValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "short_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("short_code", value);
        }
    }

    /// <summary>
    /// Tags associated with the resource.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MessagingProfileID;
        _ = this.ID;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        this.RecordType?.Validate();
        _ = this.ShortCodeValue;
        _ = this.Tags;
        _ = this.UpdatedAt;
    }

    public ShortCode ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShortCode (ShortCode shortCode) : base(shortCode)
    {  }
    #pragma warning restore CS8618

    public ShortCode (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortCode (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ShortCodeFromRaw.FromRawUnchecked"/>
    public static ShortCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ShortCode (string? messagingProfileID) : this()
    { this.MessagingProfileID = messagingProfileID; }
}

class ShortCodeFromRaw : IFromRawJson<ShortCode>
{
    /// <inheritdoc/>
    public ShortCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ShortCode.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(ShortCodeRecordTypeConverter))]
public enum ShortCodeRecordType
{
    ShortCode
}sealed class ShortCodeRecordTypeConverter : JsonConverter<ShortCodeRecordType>
{
    public override ShortCodeRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "short_code"=>ShortCodeRecordType.ShortCode,
            _ =>(ShortCodeRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShortCodeRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ShortCodeRecordType.ShortCode=>"short_code",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}