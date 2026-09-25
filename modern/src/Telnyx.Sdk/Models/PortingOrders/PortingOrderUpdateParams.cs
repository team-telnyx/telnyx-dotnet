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

namespace Telnyx.Sdk.Models.PortingOrders;

/// <summary>
/// Edits the details of an existing porting order.
///
/// <para>Any or all of a porting orders attributes may be included in the resource
/// object included in a PATCH request.</para>
///
/// <para>If a request does not include all of the attributes for a resource, the
/// system will interpret the missing attributes as if they were included with their
/// current values. To explicitly set something to null, it must be included in the
/// request with a null value.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PortingOrderUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public ActivationSettings? ActivationSettings {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ActivationSettings>(
                "activation_settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("activation_settings", value);
        }
    }

    public string? CustomerGroupReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_group_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("customer_group_reference", value);
        }
    }

    public string? CustomerReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("customer_reference", value);
        }
    }

    /// <summary>
    /// Can be specified directly or via the `requirement_group_id` parameter.
    /// </summary>
    public PortingOrderDocuments? Documents {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PortingOrderDocuments>(
                "documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("documents", value);
        }
    }

    public PortingOrderEndUser? EndUser {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PortingOrderEndUser>(
                "end_user"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("end_user", value);
        }
    }

    public PortingOrderUpdateParamsMessaging? Messaging {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PortingOrderUpdateParamsMessaging>(
                "messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("messaging", value);
        }
    }

    public PortingOrderMisc? Misc {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PortingOrderMisc>(
                "misc"
            );
        }
        init { this._rawBodyData.Set("misc", value); }
    }

    public PortingOrderPhoneNumberConfiguration? PhoneNumberConfiguration {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PortingOrderPhoneNumberConfiguration>(
                "phone_number_configuration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("phone_number_configuration", value);
        }
    }

    /// <summary>
    /// If present, we will read the current values from the specified Requirement
    /// Group into the Documents and Requirements for this Porting Order. Note that
    /// any future changes in the Requirement Group would have no impact on this Porting
    /// Order. We will return an error if a specified Requirement Group conflicts
    /// with documents or requirements in the same request.
    /// </summary>
    public string? RequirementGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "requirement_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("requirement_group_id", value);
        }
    }

    /// <summary>
    /// List of requirements for porting numbers.
    /// </summary>
    public IReadOnlyList<Requirement>? Requirements {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Requirement>>(
                "requirements"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Requirement>?>(
                "requirements",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PortingOrderUserFeedback? UserFeedback {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PortingOrderUserFeedback>(
                "user_feedback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("user_feedback", value);
        }
    }

    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhook_url", value);
        }
    }

    public PortingOrderUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderUpdateParams (
        PortingOrderUpdateParams portingOrderUpdateParams
    ) : base(portingOrderUpdateParams)
    {
        this.ID = portingOrderUpdateParams.ID;

        this._rawBodyData = new(portingOrderUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public PortingOrderUpdateParams (
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
    PortingOrderUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PortingOrderUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PortingOrderUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}",
            this.ID)
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

[JsonConverter(typeof(JsonModelConverter<ActivationSettings, ActivationSettingsFromRaw>))]
public sealed record class ActivationSettings : JsonModel
{
    /// <summary>
    /// ISO 8601 formatted Date/Time requested for the FOC date
    /// </summary>
    public DateTimeOffset? FocDatetimeRequested {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "foc_datetime_requested"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("foc_datetime_requested", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.FocDatetimeRequested; }

    public ActivationSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivationSettings (ActivationSettings activationSettings) : base(
        activationSettings
    )
    {  }
    #pragma warning restore CS8618

    public ActivationSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivationSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActivationSettingsFromRaw.FromRawUnchecked"/>
    public static ActivationSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActivationSettingsFromRaw : IFromRawJson<ActivationSettings>
{
    /// <inheritdoc/>
    public ActivationSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActivationSettings.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PortingOrderUpdateParamsMessaging, PortingOrderUpdateParamsMessagingFromRaw>))]
public sealed record class PortingOrderUpdateParamsMessaging : JsonModel
{
    /// <summary>
    /// Indicates whether Telnyx will port messaging capabilities from the losing
    /// carrier. If false, any messaging capabilities will stay with their current provider.
    /// </summary>
    public bool? EnableMessaging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_messaging", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.EnableMessaging; }

    public PortingOrderUpdateParamsMessaging ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderUpdateParamsMessaging (
        PortingOrderUpdateParamsMessaging portingOrderUpdateParamsMessaging
    ) : base(portingOrderUpdateParamsMessaging)
    {  }
    #pragma warning restore CS8618

    public PortingOrderUpdateParamsMessaging (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderUpdateParamsMessaging (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderUpdateParamsMessagingFromRaw.FromRawUnchecked"/>
    public static PortingOrderUpdateParamsMessaging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderUpdateParamsMessagingFromRaw : IFromRawJson<PortingOrderUpdateParamsMessaging>
{
    /// <inheritdoc/>
    public PortingOrderUpdateParamsMessaging FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderUpdateParamsMessaging.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies a value for a requirement on the Porting Order.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Requirement, RequirementFromRaw>))]
public sealed record class Requirement : JsonModel
{
    /// <summary>
    /// identifies the document or provides the text value that satisfies this requirement
    /// </summary>
    public required string FieldValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "field_value"
            );
        }
        init { this._rawData.Set("field_value", value); }
    }

    /// <summary>
    /// Identifies the requirement type that the `field_value` fulfills
    /// </summary>
    public required string RequirementTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "requirement_type_id"
            );
        }
        init { this._rawData.Set("requirement_type_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldValue;
        _ = this.RequirementTypeID;
    }

    public Requirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Requirement (Requirement requirement) : base(requirement)
    {  }
    #pragma warning restore CS8618

    public Requirement (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Requirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementFromRaw.FromRawUnchecked"/>
    public static Requirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequirementFromRaw : IFromRawJson<Requirement>
{
    /// <inheritdoc/>
    public Requirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Requirement.FromRawUnchecked(rawData);
}