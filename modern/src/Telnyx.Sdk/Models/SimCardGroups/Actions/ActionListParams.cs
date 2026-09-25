using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCardGroups.Actions;

/// <summary>
/// This API allows listing a paginated collection a SIM card group actions. It allows
/// to explore a collection of existing asynchronous operation using specific filters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionListParams : ParamsBase
{
    /// <summary>
    /// A valid SIM card group ID.
    /// </summary>
    public string? FilterSimCardGroupID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[sim_card_group_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[sim_card_group_id]", value);
        }
    }

    /// <summary>
    /// Filter by a specific status of the resource's lifecycle.
    /// </summary>
    public ApiEnum<string, FilterStatus>? FilterStatus {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterStatus>>(
                "filter[status]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[status]", value);
        }
    }

    /// <summary>
    /// Filter by action type.
    /// </summary>
    public ApiEnum<string, FilterType>? FilterType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterType>>(
                "filter[type]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[type]", value);
        }
    }

    /// <summary>
    /// The page number to load.
    /// </summary>
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

    /// <summary>
    /// The size of the page.
    /// </summary>
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

    public ActionListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionListParams (ActionListParams actionListParams) : base(
        actionListParams
    )
    {  }
    #pragma warning restore CS8618

    public ActionListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionListParams FromRawUnchecked(
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

    public virtual bool Equals(ActionListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/sim_card_group_actions"
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
/// Filter by a specific status of the resource's lifecycle.
/// </summary>
[JsonConverter(typeof(FilterStatusConverter))]
public enum FilterStatus
{
    InProgress, Completed, Failed
}

sealed class FilterStatusConverter : JsonConverter<FilterStatus>
{
    public override FilterStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>FilterStatus.InProgress,
            "completed"=>FilterStatus.Completed,
            "failed"=>FilterStatus.Failed,
            _ =>(FilterStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterStatus.InProgress=>"in-progress",
            FilterStatus.Completed=>"completed",
            FilterStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by action type.
/// </summary>
[JsonConverter(typeof(FilterTypeConverter))]
public enum FilterType
{
    SetPrivateWirelessGateway,
    RemovePrivateWirelessGateway,
    SetWirelessBlocklist,
    RemoveWirelessBlocklist
}

sealed class FilterTypeConverter : JsonConverter<FilterType>
{
    public override FilterType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "set_private_wireless_gateway"=>FilterType.SetPrivateWirelessGateway,
            "remove_private_wireless_gateway"=>FilterType.RemovePrivateWirelessGateway,
            "set_wireless_blocklist"=>FilterType.SetWirelessBlocklist,
            "remove_wireless_blocklist"=>FilterType.RemoveWirelessBlocklist,
            _ =>(FilterType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterType.SetPrivateWirelessGateway=>"set_private_wireless_gateway",
            FilterType.RemovePrivateWirelessGateway=>"remove_private_wireless_gateway",
            FilterType.SetWirelessBlocklist=>"set_wireless_blocklist",
            FilterType.RemoveWirelessBlocklist=>"remove_wireless_blocklist",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}