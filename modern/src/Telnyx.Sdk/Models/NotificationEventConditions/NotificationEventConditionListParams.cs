using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NotificationEventConditions;

/// <summary>
/// Returns a list of your notifications events conditions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NotificationEventConditionListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[associated_record_type][eq],
    /// filter[channel_type_id][eq], filter[notification_profile_id][eq], filter[notification_channel][eq],
    /// filter[notification_event_condition_id][eq], filter[status][eq]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    public NotificationEventConditionListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationEventConditionListParams (
        NotificationEventConditionListParams notificationEventConditionListParams
    ) : base(notificationEventConditionListParams)
    {  }
    #pragma warning restore CS8618

    public NotificationEventConditionListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationEventConditionListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NotificationEventConditionListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(NotificationEventConditionListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/notification_event_conditions"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Consolidated filter parameter (deepObject style). Originally: filter[associated_record_type][eq],
/// filter[channel_type_id][eq], filter[notification_profile_id][eq], filter[notification_channel][eq],
/// filter[notification_event_condition_id][eq], filter[status][eq]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public AssociatedRecordType? AssociatedRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AssociatedRecordType>(
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

    public ChannelTypeID? ChannelTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChannelTypeID>(
                "channel_type_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_type_id", value);
        }
    }

    public NotificationChannel? NotificationChannel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationChannel>(
                "notification_channel"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notification_channel", value);
        }
    }

    public NotificationEventConditionID? NotificationEventConditionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationEventConditionID>(
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

    public NotificationProfileID? NotificationProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationProfileID>(
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

    public Status? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Status>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AssociatedRecordType?.Validate();
        this.ChannelTypeID?.Validate();
        this.NotificationChannel?.Validate();
        this.NotificationEventConditionID?.Validate();
        this.NotificationProfileID?.Validate();
        this.Status?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AssociatedRecordType, AssociatedRecordTypeFromRaw>))]
public sealed record class AssociatedRecordType : JsonModel
{
    /// <summary>
    /// Filter by the associated record type
    /// </summary>
    public ApiEnum<string, Eq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Eq>>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Eq?.Validate(); }

    public AssociatedRecordType ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssociatedRecordType (
        AssociatedRecordType associatedRecordType
    ) : base(associatedRecordType)
    {  }
    #pragma warning restore CS8618

    public AssociatedRecordType (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssociatedRecordType (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssociatedRecordTypeFromRaw.FromRawUnchecked"/>
    public static AssociatedRecordType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssociatedRecordTypeFromRaw : IFromRawJson<AssociatedRecordType>
{
    /// <inheritdoc/>
    public AssociatedRecordType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssociatedRecordType.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by the associated record type
/// </summary>
[JsonConverter(typeof(EqConverter))]
public enum Eq
{
    Account, PhoneNumber
}

sealed class EqConverter : JsonConverter<Eq>
{
    public override Eq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "account"=>Eq.Account, "phone_number"=>Eq.PhoneNumber, _ =>(Eq)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Eq value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Eq.Account=>"account",
            Eq.PhoneNumber=>"phone_number",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ChannelTypeID, ChannelTypeIDFromRaw>))]
public sealed record class ChannelTypeID : JsonModel
{
    /// <summary>
    /// Filter by the id of a channel type
    /// </summary>
    public ApiEnum<string, ChannelTypeIDEq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChannelTypeIDEq>>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Eq?.Validate(); }

    public ChannelTypeID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelTypeID (ChannelTypeID channelTypeID) : base(channelTypeID)
    {  }
    #pragma warning restore CS8618

    public ChannelTypeID (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelTypeID (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ChannelTypeIDFromRaw.FromRawUnchecked"/>
    public static ChannelTypeID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ChannelTypeIDFromRaw : IFromRawJson<ChannelTypeID>
{
    /// <inheritdoc/>
    public ChannelTypeID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ChannelTypeID.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by the id of a channel type
/// </summary>
[JsonConverter(typeof(ChannelTypeIDEqConverter))]
public enum ChannelTypeIDEq
{
    Webhook, Sms, Email, Voice
}

sealed class ChannelTypeIDEqConverter : JsonConverter<ChannelTypeIDEq>
{
    public override ChannelTypeIDEq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook"=>ChannelTypeIDEq.Webhook,
            "sms"=>ChannelTypeIDEq.Sms,
            "email"=>ChannelTypeIDEq.Email,
            "voice"=>ChannelTypeIDEq.Voice,
            _ =>(ChannelTypeIDEq)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChannelTypeIDEq value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ChannelTypeIDEq.Webhook=>"webhook",
            ChannelTypeIDEq.Sms=>"sms",
            ChannelTypeIDEq.Email=>"email",
            ChannelTypeIDEq.Voice=>"voice",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<NotificationChannel, NotificationChannelFromRaw>))]
public sealed record class NotificationChannel : JsonModel
{
    /// <summary>
    /// Filter by the id of a notification channel
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public NotificationChannel ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannel (NotificationChannel notificationChannel) : base(
        notificationChannel
    )
    {  }
    #pragma warning restore CS8618

    public NotificationChannel (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationChannel (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationChannelFromRaw.FromRawUnchecked"/>
    public static NotificationChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationChannelFromRaw : IFromRawJson<NotificationChannel>
{
    /// <inheritdoc/>
    public NotificationChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationChannel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NotificationEventConditionID, NotificationEventConditionIDFromRaw>))]
public sealed record class NotificationEventConditionID : JsonModel
{
    /// <summary>
    /// Filter by the id of a notification channel
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public NotificationEventConditionID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationEventConditionID (
        NotificationEventConditionID notificationEventConditionID
    ) : base(notificationEventConditionID)
    {  }
    #pragma warning restore CS8618

    public NotificationEventConditionID (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationEventConditionID (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationEventConditionIDFromRaw.FromRawUnchecked"/>
    public static NotificationEventConditionID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationEventConditionIDFromRaw : IFromRawJson<NotificationEventConditionID>
{
    /// <inheritdoc/>
    public NotificationEventConditionID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationEventConditionID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<NotificationProfileID, NotificationProfileIDFromRaw>))]
public sealed record class NotificationProfileID : JsonModel
{
    /// <summary>
    /// Filter by the id of a notification profile
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public NotificationProfileID ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationProfileID (
        NotificationProfileID notificationProfileID
    ) : base(notificationProfileID)
    {  }
    #pragma warning restore CS8618

    public NotificationProfileID (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationProfileID (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NotificationProfileIDFromRaw.FromRawUnchecked"/>
    public static NotificationProfileID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NotificationProfileIDFromRaw : IFromRawJson<NotificationProfileID>
{
    /// <inheritdoc/>
    public NotificationProfileID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NotificationProfileID.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Status, StatusFromRaw>))]
public sealed record class Status : JsonModel
{
    /// <summary>
    /// The status of a notification setting
    /// </summary>
    public ApiEnum<string, StatusEq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StatusEq>>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Eq?.Validate(); }

    public Status ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Status (Status status) : base(status)
    {  }
    #pragma warning restore CS8618

    public Status (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Status (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StatusFromRaw.FromRawUnchecked"/>
    public static Status FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StatusFromRaw : IFromRawJson<Status>
{
    /// <inheritdoc/>
    public Status FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Status.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of a notification setting
/// </summary>
[JsonConverter(typeof(StatusEqConverter))]
public enum StatusEq
{
    Enabled,
    EnableReceived,
    EnablePending,
    EnableSubmtited,
    DeleteReceived,
    DeletePending,
    DeleteSubmitted,
    Deleted
}

sealed class StatusEqConverter : JsonConverter<StatusEq>
{
    public override StatusEq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>StatusEq.Enabled,
            "enable-received"=>StatusEq.EnableReceived,
            "enable-pending"=>StatusEq.EnablePending,
            "enable-submtited"=>StatusEq.EnableSubmtited,
            "delete-received"=>StatusEq.DeleteReceived,
            "delete-pending"=>StatusEq.DeletePending,
            "delete-submitted"=>StatusEq.DeleteSubmitted,
            "deleted"=>StatusEq.Deleted,
            _ =>(StatusEq)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, StatusEq value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StatusEq.Enabled=>"enabled",
            StatusEq.EnableReceived=>"enable-received",
            StatusEq.EnablePending=>"enable-pending",
            StatusEq.EnableSubmtited=>"enable-submtited",
            StatusEq.DeleteReceived=>"delete-received",
            StatusEq.DeletePending=>"delete-pending",
            StatusEq.DeleteSubmitted=>"delete-submitted",
            StatusEq.Deleted=>"deleted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}