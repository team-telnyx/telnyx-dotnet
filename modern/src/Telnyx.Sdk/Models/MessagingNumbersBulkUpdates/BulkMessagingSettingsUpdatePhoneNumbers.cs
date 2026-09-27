using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingNumbersBulkUpdates;

[JsonConverter(typeof(JsonModelConverter<BulkMessagingSettingsUpdatePhoneNumbers, BulkMessagingSettingsUpdatePhoneNumbersFromRaw>))]
public sealed record class BulkMessagingSettingsUpdatePhoneNumbers : JsonModel
{
    /// <summary>
    /// Phone numbers that failed to update.
    /// </summary>
    public IReadOnlyList<string>? Failed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "failed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "failed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Order ID to verify bulk update status.
    /// </summary>
    public string? OrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_id", value);
        }
    }

    /// <summary>
    /// Phone numbers pending to be updated.
    /// </summary>
    public IReadOnlyList<string>? Pending {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "pending"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "pending",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
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

    /// <summary>
    /// Phoned numbers updated successfully.
    /// </summary>
    public IReadOnlyList<string>? Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "success"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "success",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Failed;
        _ = this.OrderID;
        _ = this.Pending;
        this.RecordType?.Validate();
        _ = this.Success;
    }

    public BulkMessagingSettingsUpdatePhoneNumbers ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkMessagingSettingsUpdatePhoneNumbers (
        BulkMessagingSettingsUpdatePhoneNumbers bulkMessagingSettingsUpdatePhoneNumbers
    ) : base(bulkMessagingSettingsUpdatePhoneNumbers)
    {  }
    #pragma warning restore CS8618

    public BulkMessagingSettingsUpdatePhoneNumbers (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkMessagingSettingsUpdatePhoneNumbers (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BulkMessagingSettingsUpdatePhoneNumbersFromRaw.FromRawUnchecked"/>
    public static BulkMessagingSettingsUpdatePhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BulkMessagingSettingsUpdatePhoneNumbersFromRaw : IFromRawJson<BulkMessagingSettingsUpdatePhoneNumbers>
{
    /// <inheritdoc/>
    public BulkMessagingSettingsUpdatePhoneNumbers FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BulkMessagingSettingsUpdatePhoneNumbers.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    MessagingNumbersBulkUpdate
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
            "messaging_numbers_bulk_update"=>RecordType.MessagingNumbersBulkUpdate,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.MessagingNumbersBulkUpdate=>"messaging_numbers_bulk_update",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}