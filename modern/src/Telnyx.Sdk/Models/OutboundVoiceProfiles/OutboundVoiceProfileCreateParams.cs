using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

/// <summary>
/// Creates a new outbound voice profile defining calling permissions, destinations,
/// and limits for outbound calls, and returns the created profile.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class OutboundVoiceProfileCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A user-supplied name to help with organization.
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The ID of the billing group associated with the outbound proflile. Defaults
    /// to null (for no group assigned).
    /// </summary>
    public string? BillingGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "billing_group_id"
            );
        }
        init { this._rawBodyData.Set("billing_group_id", value); }
    }

    public OutboundCallRecording? CallRecording {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OutboundCallRecording>(
                "call_recording"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("call_recording", value);
        }
    }

    /// <summary>
    /// Specifies the time window and call limits for calls made using this outbound
    /// voice profile. Note that all times are UTC in 24-hour clock time.
    /// </summary>
    public CallingWindow? CallingWindow {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CallingWindow>(
                "calling_window"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("calling_window", value);
        }
    }

    /// <summary>
    /// Must be no more than your global concurrent call limit. Null means no limit.
    /// </summary>
    public long? ConcurrentCallLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "concurrent_call_limit"
            );
        }
        init { this._rawBodyData.Set("concurrent_call_limit", value); }
    }

    /// <summary>
    /// The maximum amount of usage charges, in USD, you want Telnyx to allow on
    /// this outbound voice profile in a day before disallowing new calls.
    /// </summary>
    public string? DailySpendLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "daily_spend_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("daily_spend_limit", value);
        }
    }

    /// <summary>
    /// Specifies whether to enforce the daily_spend_limit on this outbound voice profile.
    /// </summary>
    public bool? DailySpendLimitEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "daily_spend_limit_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("daily_spend_limit_enabled", value);
        }
    }

    /// <summary>
    /// Specifies whether the outbound voice profile can be used. Disabled profiles
    /// will result in outbound calls being blocked for the associated Connections.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Maximum rate (price per minute) for a Destination to be allowed when making
    /// outbound calls.
    /// </summary>
    public double? MaxDestinationRate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "max_destination_rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_destination_rate", value);
        }
    }

    /// <summary>
    /// Indicates the coverage of the termination regions.
    /// </summary>
    public ApiEnum<string, ServicePlan>? ServicePlan {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ServicePlan>>(
                "service_plan"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("service_plan", value);
        }
    }

    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TrafficType>>(
                "traffic_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("traffic_type", value);
        }
    }

    /// <summary>
    /// Setting for how costs for outbound profile are calculated.
    /// </summary>
    public ApiEnum<string, UsagePaymentMethod>? UsagePaymentMethod {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, UsagePaymentMethod>>(
                "usage_payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("usage_payment_method", value);
        }
    }

    /// <summary>
    /// The list of destinations you want to be able to call using this outbound
    /// voice profile formatted in alpha2.
    /// </summary>
    public IReadOnlyList<string>? WhitelistedDestinations {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "whitelisted_destinations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "whitelisted_destinations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public OutboundVoiceProfileCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileCreateParams (
        OutboundVoiceProfileCreateParams outboundVoiceProfileCreateParams
    ) : base(outboundVoiceProfileCreateParams)
    { this._rawBodyData = new(outboundVoiceProfileCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public OutboundVoiceProfileCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static OutboundVoiceProfileCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(OutboundVoiceProfileCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/outbound_voice_profiles"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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
/// Specifies the time window and call limits for calls made using this outbound voice
/// profile. Note that all times are UTC in 24-hour clock time.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CallingWindow, CallingWindowFromRaw>))]
public sealed record class CallingWindow : JsonModel
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

    public CallingWindow ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallingWindow (CallingWindow callingWindow) : base(callingWindow)
    {  }
    #pragma warning restore CS8618

    public CallingWindow (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallingWindow (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallingWindowFromRaw.FromRawUnchecked"/>
    public static CallingWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallingWindowFromRaw : IFromRawJson<CallingWindow>
{
    /// <inheritdoc/>
    public CallingWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallingWindow.FromRawUnchecked(rawData);
}