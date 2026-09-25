using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

[JsonConverter(typeof(JsonModelConverter<OutboundVoiceProfile, OutboundVoiceProfileFromRaw>))]
public sealed record class OutboundVoiceProfile : JsonModel
{
    /// <summary>
    /// A user-supplied name to help with organization.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Identifies the resource.
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
    /// The ID of the billing group associated with the outbound proflile. Defaults
    /// to null (for no group assigned).
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init { this._rawData.Set("billing_group_id", value); }
    }

    public OutboundCallRecording? CallRecording {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundCallRecording>(
                "call_recording"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_recording", value);
        }
    }

    /// <summary>
    /// Specifies the time window and call limits for calls made using this outbound
    /// voice profile. Note that all times are UTC in 24-hour clock time.
    /// </summary>
    public OutboundVoiceProfileCallingWindow? CallingWindow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundVoiceProfileCallingWindow>(
                "calling_window"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("calling_window", value);
        }
    }

    /// <summary>
    /// Must be no more than your global concurrent call limit. Null means no limit.
    /// </summary>
    public long? ConcurrentCallLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "concurrent_call_limit"
            );
        }
        init { this._rawData.Set("concurrent_call_limit", value); }
    }

    /// <summary>
    /// Amount of connections associated with this outbound voice profile.
    /// </summary>
    public long? ConnectionsCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "connections_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connections_count", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The maximum amount of usage charges, in USD, you want Telnyx to allow on
    /// this outbound voice profile in a day before disallowing new calls.
    /// </summary>
    public string? DailySpendLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "daily_spend_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("daily_spend_limit", value);
        }
    }

    /// <summary>
    /// Specifies whether to enforce the daily_spend_limit on this outbound voice profile.
    /// </summary>
    public bool? DailySpendLimitEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "daily_spend_limit_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("daily_spend_limit_enabled", value);
        }
    }

    /// <summary>
    /// Specifies whether the outbound voice profile can be used. Disabled profiles
    /// will result in outbound calls being blocked for the associated Connections.
    /// </summary>
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

    /// <summary>
    /// Maximum rate (price per minute) for a Destination to be allowed when making
    /// outbound calls.
    /// </summary>
    public double? MaxDestinationRate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "max_destination_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_destination_rate", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Indicates the coverage of the termination regions.
    /// </summary>
    public ApiEnum<string, ServicePlan>? ServicePlan {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ServicePlan>>(
                "service_plan"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("service_plan", value);
        }
    }

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
    /// Specifies the type of traffic allowed in this profile.
    /// </summary>
    public ApiEnum<string, TrafficType>? TrafficType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TrafficType>>(
                "traffic_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("traffic_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Setting for how costs for outbound profile are calculated.
    /// </summary>
    public ApiEnum<string, UsagePaymentMethod>? UsagePaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UsagePaymentMethod>>(
                "usage_payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("usage_payment_method", value);
        }
    }

    /// <summary>
    /// The list of destinations you want to be able to call using this outbound
    /// voice profile formatted in alpha2.
    /// </summary>
    public IReadOnlyList<string>? WhitelistedDestinations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whitelisted_destinations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.ID;
        _ = this.BillingGroupID;
        this.CallRecording?.Validate();
        this.CallingWindow?.Validate();
        _ = this.ConcurrentCallLimit;
        _ = this.ConnectionsCount;
        _ = this.CreatedAt;
        _ = this.DailySpendLimit;
        _ = this.DailySpendLimitEnabled;
        _ = this.Enabled;
        _ = this.MaxDestinationRate;
        _ = this.RecordType;
        this.ServicePlan?.Validate();
        _ = this.Tags;
        this.TrafficType?.Validate();
        _ = this.UpdatedAt;
        this.UsagePaymentMethod?.Validate();
        _ = this.WhitelistedDestinations;
    }

    public OutboundVoiceProfile ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfile (
        OutboundVoiceProfile outboundVoiceProfile
    ) : base(outboundVoiceProfile)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfile (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfile (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundVoiceProfileFromRaw.FromRawUnchecked"/>
    public static OutboundVoiceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public OutboundVoiceProfile (string name) : this()
    { this.Name = name; }
}

class OutboundVoiceProfileFromRaw : IFromRawJson<OutboundVoiceProfile>
{
    /// <inheritdoc/>
    public OutboundVoiceProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundVoiceProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the time window and call limits for calls made using this outbound voice
/// profile. Note that all times are UTC in 24-hour clock time.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OutboundVoiceProfileCallingWindow, OutboundVoiceProfileCallingWindowFromRaw>))]
public sealed record class OutboundVoiceProfileCallingWindow : JsonModel
{
    /// <summary>
    /// The maximum number of calls that can be initiated to a single called party
    /// (CLD) within the calling window. A null value means no limit.
    /// </summary>
    public long? CallsPerCld {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "calls_per_cld"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("calls_per_cld", value);
        }
    }

    /// <summary>
    /// The UTC time of day (in HH:MM format, 24-hour clock) when calls are no longer
    /// allowed to start.
    /// </summary>
    public string? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_time", value);
        }
    }

    /// <summary>
    /// The UTC time of day (in HH:MM format, 24-hour clock) when calls are allowed
    /// to start.
    /// </summary>
    public string? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallsPerCld;
        _ = this.EndTime;
        _ = this.StartTime;
    }

    public OutboundVoiceProfileCallingWindow ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileCallingWindow (
        OutboundVoiceProfileCallingWindow outboundVoiceProfileCallingWindow
    ) : base(outboundVoiceProfileCallingWindow)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfileCallingWindow (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileCallingWindow (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundVoiceProfileCallingWindowFromRaw.FromRawUnchecked"/>
    public static OutboundVoiceProfileCallingWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OutboundVoiceProfileCallingWindowFromRaw : IFromRawJson<OutboundVoiceProfileCallingWindow>
{
    /// <inheritdoc/>
    public OutboundVoiceProfileCallingWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundVoiceProfileCallingWindow.FromRawUnchecked(rawData);
}