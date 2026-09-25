using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.LogMessages;

/// <summary>
/// Retrieve a list of log messages for all external connections associated with
/// your account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class LogMessageListParams : ParamsBase
{
    /// <summary>
    /// Filter parameter for log messages (deepObject style). Supports filtering by
    /// external_connection_id and telephone_number with eq/contains operations.
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

    public LogMessageListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogMessageListParams (
        LogMessageListParams logMessageListParams
    ) : base(logMessageListParams)
    {  }
    #pragma warning restore CS8618

    public LogMessageListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LogMessageListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static LogMessageListParams FromRawUnchecked(
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

    public virtual bool Equals(LogMessageListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/external_connections/log_messages"
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
/// Filter parameter for log messages (deepObject style). Supports filtering by external_connection_id
/// and telephone_number with eq/contains operations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// The external connection ID to filter by or "null" to filter for logs without
    /// an external connection ID
    /// </summary>
    public string? ExternalConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "external_connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_connection_id", value);
        }
    }

    /// <summary>
    /// Telephone number filter operations for log messages. Use 'eq' for exact matches
    /// or 'contains' for partial matches.
    /// </summary>
    public TelephoneNumber? TelephoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TelephoneNumber>(
                "telephone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telephone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalConnectionID;
        this.TelephoneNumber?.Validate();
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
/// Telephone number filter operations for log messages. Use 'eq' for exact matches
/// or 'contains' for partial matches.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TelephoneNumber, TelephoneNumberFromRaw>))]
public sealed record class TelephoneNumber : JsonModel
{
    /// <summary>
    /// The partial phone number to filter log messages for. Requires 3-15 digits.
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

    /// <summary>
    /// The phone number to filter log messages for or "null" to filter for logs
    /// without a phone number
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
    {
        _ = this.Contains;
        _ = this.Eq;
    }

    public TelephoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephoneNumber (TelephoneNumber telephoneNumber) : base(
        telephoneNumber
    )
    {  }
    #pragma warning restore CS8618

    public TelephoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephoneNumberFromRaw.FromRawUnchecked"/>
    public static TelephoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephoneNumberFromRaw : IFromRawJson<TelephoneNumber>
{
    /// <inheritdoc/>
    public TelephoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephoneNumber.FromRawUnchecked(rawData);
}