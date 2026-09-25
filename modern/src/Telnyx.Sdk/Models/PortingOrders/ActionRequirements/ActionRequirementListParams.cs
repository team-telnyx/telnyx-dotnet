using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.ActionRequirements;

/// <summary>
/// Returns a list of action requirements for a specific porting order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionRequirementListParams : ParamsBase
{
    public string? PortingOrderID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[id][in][],
    /// filter[requirement_type_id], filter[action_type], filter[status]
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
    /// Consolidated sort parameter (deepObject style). Originally: sort[value]
    /// </summary>
    public Sort? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Sort>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public ActionRequirementListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRequirementListParams (
        ActionRequirementListParams actionRequirementListParams
    ) : base(actionRequirementListParams)
    { this.PortingOrderID = actionRequirementListParams.PortingOrderID; }
    #pragma warning restore CS8618

    public ActionRequirementListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRequirementListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string portingOrderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PortingOrderID = portingOrderID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionRequirementListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string portingOrderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            portingOrderID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["PortingOrderID"] = JsonSerializer.SerializeToElement(this.PortingOrderID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionRequirementListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PortingOrderID?.Equals(other.PortingOrderID) ?? other.PortingOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/action_requirements",
            this.PortingOrderID)
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
/// Consolidated filter parameter (deepObject style). Originally: filter[id][in][],
/// filter[requirement_type_id], filter[action_type], filter[status]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter action requirements by a list of IDs
    /// </summary>
    public IReadOnlyList<string>? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "id",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter action requirements by action type
    /// </summary>
    public ApiEnum<string, ActionType>? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ActionType>>(
                "action_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action_type", value);
        }
    }

    /// <summary>
    /// Filter action requirements by requirement type ID
    /// </summary>
    public string? RequirementTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_type_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_type_id", value);
        }
    }

    /// <summary>
    /// Filter action requirements by status
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ActionType?.Validate();
        _ = this.RequirementTypeID;
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

/// <summary>
/// Filter action requirements by action type
/// </summary>
[JsonConverter(typeof(ActionTypeConverter))]
public enum ActionType
{
    AuIDVerification
}

sealed class ActionTypeConverter : JsonConverter<ActionType>
{
    public override ActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "au_id_verification"=>ActionType.AuIDVerification,
            _ =>(ActionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ActionType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionType.AuIDVerification=>"au_id_verification",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter action requirements by status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Created, Pending, Completed, Cancelled, Failed
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
            "created"=>Status.Created,
            "pending"=>Status.Pending,
            "completed"=>Status.Completed,
            "cancelled"=>Status.Cancelled,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Created=>"created",
            Status.Pending=>"pending",
            Status.Completed=>"completed",
            Status.Cancelled=>"cancelled",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Consolidated sort parameter (deepObject style). Originally: sort[value]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Sort, SortFromRaw>))]
public sealed record class Sort : JsonModel
{
    /// <summary>
    /// Specifies the sort order for results. If not given, results are sorted by
    /// created_at in descending order.
    /// </summary>
    public ApiEnum<string, Value>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Value>>(
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
    { this.Value?.Validate(); }

    public Sort ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Sort (Sort sort) : base(sort)
    {  }
    #pragma warning restore CS8618

    public Sort (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Sort (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SortFromRaw.FromRawUnchecked"/>
    public static Sort FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SortFromRaw : IFromRawJson<Sort>
{
    /// <inheritdoc/>
    public Sort FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Sort.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the sort order for results. If not given, results are sorted by created_at
/// in descending order.
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    CreatedAt, CreatedAtDesc, UpdatedAt, UpdatedAtDesc
}

sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at"=>Value.CreatedAt,
            "-created_at"=>Value.CreatedAtDesc,
            "updated_at"=>Value.UpdatedAt,
            "-updated_at"=>Value.UpdatedAtDesc,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.CreatedAt=>"created_at",
            Value.CreatedAtDesc=>"-created_at",
            Value.UpdatedAt=>"updated_at",
            Value.UpdatedAtDesc=>"-updated_at",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}