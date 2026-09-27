using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NotificationEventConditions;

[JsonConverter(typeof(JsonModelConverter<NotificationEventConditionListResponse, NotificationEventConditionListResponseFromRaw>))]
public sealed record class NotificationEventConditionListResponse : JsonModel
{
    /// <summary>
    /// A UUID.
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
    /// Dictates whether a notification channel id needs to be provided when creating
    /// a notficiation setting.
    /// </summary>
    public bool? AllowMultipleChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "allow_multiple_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("allow_multiple_channels", value);
        }
    }

    public ApiEnum<string, NotificationEventConditionListResponseAssociatedRecordType>? AssociatedRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NotificationEventConditionListResponseAssociatedRecordType>>(
                "associated_record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("associated_record_type", value);
        }
    }

    /// <summary>
    /// Dictates whether a notification setting will take effect immediately.
    /// </summary>
    public bool? Asynchronous {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "asynchronous"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("asynchronous", value);
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

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

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

    public string? NotificationEventID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "notification_event_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notification_event_id", value);
        }
    }

    public IReadOnlyList<Parameter>? Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Parameter>>(
                "parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Parameter>?>(
                "parameters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Dictates the supported notification channel types that can be emitted.
    /// </summary>
    public IReadOnlyList<string>? SupportedChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "supported_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "supported_channels",
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
        _ = this.ID;
        _ = this.AllowMultipleChannels;
        this.AssociatedRecordType?.Validate();
        _ = this.Asynchronous;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Enabled;
        _ = this.Name;
        _ = this.NotificationEventID;
        foreach (var item in this.Parameters ?? [])
        {
            item.Validate();
        }
        _ = this.SupportedChannels;
        _ = this.UpdatedAt;
    }

    public NotificationEventConditionListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationEventConditionListResponse (
        NotificationEventConditionListResponse notificationEventConditionListResponse
    ) : base(notificationEventConditionListResponse)
    {  }
    #pragma warning restore CS8618

    public NotificationEventConditionListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationEventConditionListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationEventConditionListResponseFromRaw.FromRawUnchecked"/>
    public static NotificationEventConditionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationEventConditionListResponseFromRaw : IFromRawJson<NotificationEventConditionListResponse>
{
    /// <inheritdoc/>
    public NotificationEventConditionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationEventConditionListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NotificationEventConditionListResponseAssociatedRecordTypeConverter))]
public enum NotificationEventConditionListResponseAssociatedRecordType
{
    Account, PhoneNumber
}sealed class NotificationEventConditionListResponseAssociatedRecordTypeConverter : JsonConverter<NotificationEventConditionListResponseAssociatedRecordType>
{
    public override NotificationEventConditionListResponseAssociatedRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account"=>NotificationEventConditionListResponseAssociatedRecordType.Account,
            "phone_number"=>NotificationEventConditionListResponseAssociatedRecordType.PhoneNumber,
            _ =>(NotificationEventConditionListResponseAssociatedRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationEventConditionListResponseAssociatedRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NotificationEventConditionListResponseAssociatedRecordType.Account=>"account",
            NotificationEventConditionListResponseAssociatedRecordType.PhoneNumber=>"phone_number",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Parameter, ParameterFromRaw>))]
public sealed record class Parameter : JsonModel
{
    public string? DataType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "data_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_type", value);
        }
    }

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

    public bool? Optional {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "optional"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("optional", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DataType;
        _ = this.Name;
        _ = this.Optional;
    }

    public Parameter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Parameter (Parameter parameter) : base(parameter)
    {  }
    #pragma warning restore CS8618

    public Parameter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Parameter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParameterFromRaw.FromRawUnchecked"/>
    public static Parameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ParameterFromRaw : IFromRawJson<Parameter>
{
    /// <inheritdoc/>
    public Parameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Parameter.FromRawUnchecked(rawData);
}