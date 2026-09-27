using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NotificationSettings;

[JsonConverter(typeof(JsonModelConverter<NotificationSetting, NotificationSettingFromRaw>))]
public sealed record class NotificationSetting : JsonModel
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

    public string? AssociatedRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    public string? AssociatedRecordTypeValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "associated_record_type_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("associated_record_type_value", value);
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
    /// A UUID reference to the associated Notification Channel.
    /// </summary>
    public string? NotificationChannelID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "notification_channel_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notification_channel_id", value);
        }
    }

    /// <summary>
    /// A UUID reference to the associated Notification Event Condition.
    /// </summary>
    public string? NotificationEventConditionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "notification_event_condition_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notification_event_condition_id", value);
        }
    }

    /// <summary>
    /// A UUID reference to the associated Notification Profile.
    /// </summary>
    public string? NotificationProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "notification_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notification_profile_id", value);
        }
    }

    public IReadOnlyList<NotificationSettingParameter>? Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NotificationSettingParameter>>(
                "parameters"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<NotificationSettingParameter>?>(
                "parameters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Most preferences apply immediately; however, other may needs to propagate.
    /// </summary>
    public ApiEnum<string, NotificationSettingStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NotificationSettingStatus>>(
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
        _ = this.AssociatedRecordType;
        _ = this.AssociatedRecordTypeValue;
        _ = this.CreatedAt;
        _ = this.NotificationChannelID;
        _ = this.NotificationEventConditionID;
        _ = this.NotificationProfileID;
        foreach (var item in this.Parameters ?? [])
        {
            item.Validate();
        }
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public NotificationSetting ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationSetting (NotificationSetting notificationSetting) : base(
        notificationSetting
    )
    {  }
    #pragma warning restore CS8618

    public NotificationSetting (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationSetting (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationSettingFromRaw.FromRawUnchecked"/>
    public static NotificationSetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationSettingFromRaw : IFromRawJson<NotificationSetting>
{
    /// <inheritdoc/>
    public NotificationSetting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationSetting.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NotificationSettingParameter, NotificationSettingParameterFromRaw>))]
public sealed record class NotificationSettingParameter : JsonModel
{
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

    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public NotificationSettingParameter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationSettingParameter (
        NotificationSettingParameter notificationSettingParameter
    ) : base(notificationSettingParameter)
    {  }
    #pragma warning restore CS8618

    public NotificationSettingParameter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationSettingParameter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationSettingParameterFromRaw.FromRawUnchecked"/>
    public static NotificationSettingParameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NotificationSettingParameterFromRaw : IFromRawJson<NotificationSettingParameter>
{
    /// <inheritdoc/>
    public NotificationSettingParameter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationSettingParameter.FromRawUnchecked(rawData);
}/// <summary>
/// Most preferences apply immediately; however, other may needs to propagate.
/// </summary>
[JsonConverter(typeof(NotificationSettingStatusConverter))]
public enum NotificationSettingStatus
{
    Enabled,
    EnableReceived,
    EnablePending,
    EnableSubmtited,
    DeleteReceived,
    DeletePending,
    DeleteSubmitted,
    Deleted
}sealed class NotificationSettingStatusConverter : JsonConverter<NotificationSettingStatus>
{
    public override NotificationSettingStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>NotificationSettingStatus.Enabled,
            "enable-received"=>NotificationSettingStatus.EnableReceived,
            "enable-pending"=>NotificationSettingStatus.EnablePending,
            "enable-submtited"=>NotificationSettingStatus.EnableSubmtited,
            "delete-received"=>NotificationSettingStatus.DeleteReceived,
            "delete-pending"=>NotificationSettingStatus.DeletePending,
            "delete-submitted"=>NotificationSettingStatus.DeleteSubmitted,
            "deleted"=>NotificationSettingStatus.Deleted,
            _ =>(NotificationSettingStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationSettingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NotificationSettingStatus.Enabled=>"enabled",
            NotificationSettingStatus.EnableReceived=>"enable-received",
            NotificationSettingStatus.EnablePending=>"enable-pending",
            NotificationSettingStatus.EnableSubmtited=>"enable-submtited",
            NotificationSettingStatus.DeleteReceived=>"delete-received",
            NotificationSettingStatus.DeletePending=>"delete-pending",
            NotificationSettingStatus.DeleteSubmitted=>"delete-submitted",
            NotificationSettingStatus.Deleted=>"deleted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}