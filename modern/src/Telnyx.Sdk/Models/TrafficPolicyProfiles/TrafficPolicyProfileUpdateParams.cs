using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

/// <summary>
/// Updates the specified traffic policy profile and returns the updated profile.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TrafficPolicyProfileUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Array of domain names.
    /// </summary>
    public IReadOnlyList<string>? Domains {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "domains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "domains",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of IP ranges in CIDR notation.
    /// </summary>
    public IReadOnlyList<string>? IPRanges {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "ip_ranges"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "ip_ranges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Bandwidth limit in kbps. Must be 512 or 1024, or null to remove.
    /// </summary>
    public ApiEnum<long, TrafficPolicyProfileUpdateParamsLimitBwKbps>? LimitBwKbps {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<long, TrafficPolicyProfileUpdateParamsLimitBwKbps>>(
                "limit_bw_kbps"
            );
        }
        init { this._rawBodyData.Set("limit_bw_kbps", value); }
    }

    /// <summary>
    /// Array of PCEF service IDs to include in the profile.
    /// </summary>
    public IReadOnlyList<string>? Services {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "services"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "services",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of the traffic policy profile.
    /// </summary>
    public ApiEnum<string, TrafficPolicyProfileUpdateParamsType>? Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TrafficPolicyProfileUpdateParamsType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("type", value);
        }
    }

    public TrafficPolicyProfileUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileUpdateParams (
        TrafficPolicyProfileUpdateParams trafficPolicyProfileUpdateParams
    ) : base(trafficPolicyProfileUpdateParams)
    {
        this.ID = trafficPolicyProfileUpdateParams.ID;

        this._rawBodyData = new(trafficPolicyProfileUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public TrafficPolicyProfileUpdateParams (
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
    TrafficPolicyProfileUpdateParams (
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
    public static TrafficPolicyProfileUpdateParams FromRawUnchecked(
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

    public virtual bool Equals(TrafficPolicyProfileUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/traffic_policy_profiles/{0}",
            EncodePathSegment(this.ID))
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
/// Bandwidth limit in kbps. Must be 512 or 1024, or null to remove.
/// </summary>
[JsonConverter(typeof(TrafficPolicyProfileUpdateParamsLimitBwKbpsConverter))]
public enum TrafficPolicyProfileUpdateParamsLimitBwKbps
{
    LimitBwKbps512, LimitBwKbps1024
}

sealed class TrafficPolicyProfileUpdateParamsLimitBwKbpsConverter : JsonConverter<TrafficPolicyProfileUpdateParamsLimitBwKbps>
{
    public override TrafficPolicyProfileUpdateParamsLimitBwKbps Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            512L=>TrafficPolicyProfileUpdateParamsLimitBwKbps.LimitBwKbps512,
            1024L=>TrafficPolicyProfileUpdateParamsLimitBwKbps.LimitBwKbps1024,
            _ =>(TrafficPolicyProfileUpdateParamsLimitBwKbps)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrafficPolicyProfileUpdateParamsLimitBwKbps value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TrafficPolicyProfileUpdateParamsLimitBwKbps.LimitBwKbps512=>512L,
            TrafficPolicyProfileUpdateParamsLimitBwKbps.LimitBwKbps1024=>1024L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The type of the traffic policy profile.
/// </summary>
[JsonConverter(typeof(TrafficPolicyProfileUpdateParamsTypeConverter))]
public enum TrafficPolicyProfileUpdateParamsType
{
    Whitelist, Blacklist, Throttling
}

sealed class TrafficPolicyProfileUpdateParamsTypeConverter : JsonConverter<TrafficPolicyProfileUpdateParamsType>
{
    public override TrafficPolicyProfileUpdateParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whitelist"=>TrafficPolicyProfileUpdateParamsType.Whitelist,
            "blacklist"=>TrafficPolicyProfileUpdateParamsType.Blacklist,
            "throttling"=>TrafficPolicyProfileUpdateParamsType.Throttling,
            _ =>(TrafficPolicyProfileUpdateParamsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrafficPolicyProfileUpdateParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TrafficPolicyProfileUpdateParamsType.Whitelist=>"whitelist",
            TrafficPolicyProfileUpdateParamsType.Blacklist=>"blacklist",
            TrafficPolicyProfileUpdateParamsType.Throttling=>"throttling",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}