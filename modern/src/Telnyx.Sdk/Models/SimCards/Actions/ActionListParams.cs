using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCards.Actions;

/// <summary>
/// This API lists a paginated collection of SIM card actions. It enables exploring
/// a collection of existing asynchronous operations using specific filters.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter for SIM card actions (deepObject style). Originally:
    /// filter[sim_card_id], filter[status], filter[bulk_sim_card_action_id], filter[action_type]
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
            options.BaseUrl.ToString().TrimEnd('/') + "/sim_card_actions"
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
/// Consolidated filter parameter for SIM card actions (deepObject style). Originally:
/// filter[sim_card_id], filter[status], filter[bulk_sim_card_action_id], filter[action_type]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by action type.
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
    /// Filter by a bulk SIM card action ID.
    /// </summary>
    public string? BulkSimCardActionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "bulk_sim_card_action_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bulk_sim_card_action_id", value);
        }
    }

    /// <summary>
    /// A valid SIM card ID.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// Filter by a specific status of the resource's lifecycle.
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
        this.ActionType?.Validate();
        _ = this.BulkSimCardActionID;
        _ = this.SimCardID;
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
/// Filter by action type.
/// </summary>
[JsonConverter(typeof(ActionTypeConverter))]
public enum ActionType
{
    Enable,
    EnableStandbySimCard,
    Disable,
    SetStandby,
    RemovePublicIP,
    SetPublicIP,
    EnableVoice,
    DisableVoice
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
            "enable"=>ActionType.Enable,
            "enable_standby_sim_card"=>ActionType.EnableStandbySimCard,
            "disable"=>ActionType.Disable,
            "set_standby"=>ActionType.SetStandby,
            "remove_public_ip"=>ActionType.RemovePublicIP,
            "set_public_ip"=>ActionType.SetPublicIP,
            "enable_voice"=>ActionType.EnableVoice,
            "disable_voice"=>ActionType.DisableVoice,
            _ =>(ActionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ActionType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionType.Enable=>"enable",
            ActionType.EnableStandbySimCard=>"enable_standby_sim_card",
            ActionType.Disable=>"disable",
            ActionType.SetStandby=>"set_standby",
            ActionType.RemovePublicIP=>"remove_public_ip",
            ActionType.SetPublicIP=>"set_public_ip",
            ActionType.EnableVoice=>"enable_voice",
            ActionType.DisableVoice=>"disable_voice",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by a specific status of the resource's lifecycle.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress, Completed, Failed
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
            "in-progress"=>Status.InProgress,
            "completed"=>Status.Completed,
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
            Status.InProgress=>"in-progress",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}