using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobileNetworkOperators;

/// <summary>
/// Telnyx has a set of GSM mobile operators partners that are available through our
/// mobile network roaming. This resource is entirely managed by Telnyx and may change
/// over time. That means that this resource won't allow any write operations for
/// it. Still, it's available so it can be used as a support resource that can be
/// related to other resources or become a configuration option.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MobileNetworkOperatorListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter for mobile network operators (deepObject style).
    /// Originally: filter[name][starts_with], filter[name][contains], filter[name][ends_with],
    /// filter[country_code], filter[mcc], filter[mnc], filter[tadig], filter[network_preferences_enabled]
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

    public MobileNetworkOperatorListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileNetworkOperatorListParams (
        MobileNetworkOperatorListParams mobileNetworkOperatorListParams
    ) : base(mobileNetworkOperatorListParams)
    {  }
    #pragma warning restore CS8618

    public MobileNetworkOperatorListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileNetworkOperatorListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MobileNetworkOperatorListParams FromRawUnchecked(
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

    public virtual bool Equals(MobileNetworkOperatorListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/mobile_network_operators"
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
/// Consolidated filter parameter for mobile network operators (deepObject style).
/// Originally: filter[name][starts_with], filter[name][contains], filter[name][ends_with],
/// filter[country_code], filter[mcc], filter[mnc], filter[tadig], filter[network_preferences_enabled]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by exact country_code.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Filter by exact MCC.
    /// </summary>
    public string? Mcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Filter by exact MNC.
    /// </summary>
    public string? Mnc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <summary>
    /// Advanced name filtering operations
    /// </summary>
    public Name? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Name>(
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
    /// Filter by network_preferences_enabled.
    /// </summary>
    public bool? NetworkPreferencesEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "network_preferences_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network_preferences_enabled", value);
        }
    }

    /// <summary>
    /// Filter by exact TADIG.
    /// </summary>
    public string? Tadig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tadig"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tadig", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.Mcc;
        _ = this.Mnc;
        this.Name?.Validate();
        _ = this.NetworkPreferencesEnabled;
        _ = this.Tadig;
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
/// Advanced name filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Name, NameFromRaw>))]
public sealed record class Name : JsonModel
{
    /// <summary>
    /// Filter by name containing match.
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
    /// Filter by name ending with.
    /// </summary>
    public string? EndsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ends_with"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ends_with", value);
        }
    }

    /// <summary>
    /// Filter by name starting with.
    /// </summary>
    public string? StartsWith {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "starts_with"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("starts_with", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.EndsWith;
        _ = this.StartsWith;
    }

    public Name ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Name (Name name) : base(name)
    {  }
    #pragma warning restore CS8618

    public Name (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Name (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NameFromRaw.FromRawUnchecked"/>
    public static Name FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NameFromRaw : IFromRawJson<Name>
{
    /// <inheritdoc/>
    public Name FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Name.FromRawUnchecked(rawData);
}