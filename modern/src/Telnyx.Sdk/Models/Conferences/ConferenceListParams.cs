using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences;

/// <summary>
/// Lists conferences. Conferences are created on demand, and will expire after all
/// participants have left the conference or after 4 hours regardless of the number
/// of active participants. Conferences are listed in descending order by `expires_at`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConferenceListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[application_name][contains],
    /// filter[outbound.outbound_voice_profile_id], filter[leg_id], filter[application_session_id],
    /// filter[connection_id], filter[product], filter[failed], filter[from], filter[to],
    /// filter[name], filter[type], filter[occurred_at][eq/gt/gte/lt/lte], filter[status]
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

    /// <summary>
    /// Region where the conference data is located
    /// </summary>
    public ApiEnum<string, ConferenceListParamsRegion>? Region {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, ConferenceListParamsRegion>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("region", value);
        }
    }

    public ConferenceListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceListParams (
        ConferenceListParams conferenceListParams
    ) : base(conferenceListParams)
    {  }
    #pragma warning restore CS8618

    public ConferenceListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConferenceListParams FromRawUnchecked(
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

    public virtual bool Equals(ConferenceListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/conferences"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[application_name][contains],
/// filter[outbound.outbound_voice_profile_id], filter[leg_id], filter[application_session_id],
/// filter[connection_id], filter[product], filter[failed], filter[from], filter[to],
/// filter[name], filter[type], filter[occurred_at][eq/gt/gte/lt/lte], filter[status]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Application name filters
    /// </summary>
    public ApplicationName? ApplicationName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApplicationName>(
                "application_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("application_name", value);
        }
    }

    /// <summary>
    /// The unique identifier of the call session. A session may include multiple
    /// call leg events.
    /// </summary>
    public string? ApplicationSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "application_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("application_session_id", value);
        }
    }

    /// <summary>
    /// The unique identifier of the conection.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// Delivery failed or not.
    /// </summary>
    public bool? Failed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "failed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failed", value);
        }
    }

    /// <summary>
    /// Filter by From number.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// The unique identifier of an individual call leg.
    /// </summary>
    public string? LegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("leg_id", value);
        }
    }

    /// <summary>
    /// If present, conferences will be filtered to those with a matching `name`
    /// attribute. Matching is case-sensitive
    /// </summary>
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

    /// <summary>
    /// Event occurred_at filters
    /// </summary>
    public OccurredAt? OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OccurredAt>(
                "occurred_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("occurred_at", value);
        }
    }

    /// <summary>
    /// Identifies the associated outbound voice profile.
    /// </summary>
    public string? OutboundOutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound.outbound_voice_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound.outbound_voice_profile_id", value);
        }
    }

    /// <summary>
    /// Filter by product.
    /// </summary>
    public ApiEnum<string, Product>? Product {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Product>>(
                "product"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("product", value);
        }
    }

    /// <summary>
    /// If present, conferences will be filtered by status.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
    /// Filter by To number.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <summary>
    /// Event type
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.Conferences.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Conferences.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ApplicationName?.Validate();
        _ = this.ApplicationSessionID;
        _ = this.ConnectionID;
        _ = this.Failed;
        _ = this.From;
        _ = this.LegID;
        _ = this.Name;
        this.OccurredAt?.Validate();
        _ = this.OutboundOutboundVoiceProfileID;
        this.Product?.Validate();
        this.Status?.Validate();
        _ = this.To;
        this.Type?.Validate();
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

/// <summary>
/// Application name filters
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ApplicationName, ApplicationNameFromRaw>))]
public sealed record class ApplicationName : JsonModel
{
    /// <summary>
    /// If present, applications with &lt;code&gt;application_name&lt;/code&gt; containing
    /// the given value will be returned. Matching is not case-sensitive. Requires
    /// at least three characters.
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public ApplicationName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApplicationName (ApplicationName applicationName) : base(
        applicationName
    )
    {  }
    #pragma warning restore CS8618

    public ApplicationName (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ApplicationName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ApplicationNameFromRaw.FromRawUnchecked"/>
    public static ApplicationName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ApplicationNameFromRaw : IFromRawJson<ApplicationName>
{
    /// <inheritdoc/>
    public ApplicationName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ApplicationName.FromRawUnchecked(rawData);
}

/// <summary>
/// Event occurred_at filters
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OccurredAt, OccurredAtFromRaw>))]
public sealed record class OccurredAt : JsonModel
{
    /// <summary>
    /// Event occurred_at: equal
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

    /// <summary>
    /// Event occurred_at: greater than
    /// </summary>
    public string? Gt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gt", value);
        }
    }

    /// <summary>
    /// Event occurred_at: greater than or equal
    /// </summary>
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// Event occurred_at: lower than
    /// </summary>
    public string? Lt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lt", value);
        }
    }

    /// <summary>
    /// Event occurred_at: lower than or equal
    /// </summary>
    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Eq;
        _ = this.Gt;
        _ = this.Gte;
        _ = this.Lt;
        _ = this.Lte;
    }

    public OccurredAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OccurredAt (OccurredAt occurredAt) : base(occurredAt)
    {  }
    #pragma warning restore CS8618

    public OccurredAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OccurredAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OccurredAtFromRaw.FromRawUnchecked"/>
    public static OccurredAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OccurredAtFromRaw : IFromRawJson<OccurredAt>
{
    /// <inheritdoc/>
    public OccurredAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OccurredAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by product.
/// </summary>
[JsonConverter(typeof(ProductConverter))]
public enum Product
{
    CallControl, Fax, Texml
}

sealed class ProductConverter : JsonConverter<Product>
{
    public override Product Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "call_control"=>Product.CallControl,
            "fax"=>Product.Fax,
            "texml"=>Product.Texml,
            _ =>(Product)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Product value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Product.CallControl=>"call_control",
            Product.Fax=>"fax",
            Product.Texml=>"texml",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// If present, conferences will be filtered by status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Init, InProgress, Completed
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "init"=>Status.Init,
            "in_progress"=>Status.InProgress,
            "completed"=>Status.Completed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Init=>"init",
            Status.InProgress=>"in_progress",
            Status.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Event type
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Command, Webhook
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Conferences.Type>
{
    public override global::Telnyx.Sdk.Models.Conferences.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "command"=>global::Telnyx.Sdk.Models.Conferences.Type.Command,
            "webhook"=>global::Telnyx.Sdk.Models.Conferences.Type.Webhook,
            _ =>(global::Telnyx.Sdk.Models.Conferences.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Conferences.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Conferences.Type.Command=>"command",
            global::Telnyx.Sdk.Models.Conferences.Type.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Region where the conference data is located
/// </summary>
[JsonConverter(typeof(ConferenceListParamsRegionConverter))]
public enum ConferenceListParamsRegion
{
    Australia, Europe, MiddleEast, Us
}

sealed class ConferenceListParamsRegionConverter : JsonConverter<ConferenceListParamsRegion>
{
    public override ConferenceListParamsRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Australia"=>ConferenceListParamsRegion.Australia,
            "Europe"=>ConferenceListParamsRegion.Europe,
            "Middle East"=>ConferenceListParamsRegion.MiddleEast,
            "US"=>ConferenceListParamsRegion.Us,
            _ =>(ConferenceListParamsRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceListParamsRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceListParamsRegion.Australia=>"Australia",
            ConferenceListParamsRegion.Europe=>"Europe",
            ConferenceListParamsRegion.MiddleEast=>"Middle East",
            ConferenceListParamsRegion.Us=>"US",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}