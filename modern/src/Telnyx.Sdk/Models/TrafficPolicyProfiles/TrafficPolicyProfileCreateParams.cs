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
/// Create a new traffic policy profile. At least one of `services`, `ip_ranges`,
/// or `domains` must be provided.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TrafficPolicyProfileCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The type of the traffic policy profile.
    /// </summary>
    public required ApiEnum<string, global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type> Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

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
    /// Bandwidth limit in kbps. Must be 512 or 1024.
    /// </summary>
    public ApiEnum<long, LimitBwKbps>? LimitBwKbps {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<long, LimitBwKbps>>(
                "limit_bw_kbps"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("limit_bw_kbps", value);
        }
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

    public TrafficPolicyProfileCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfileCreateParams (
        TrafficPolicyProfileCreateParams trafficPolicyProfileCreateParams
    ) : base(trafficPolicyProfileCreateParams)
    { this._rawBodyData = new(trafficPolicyProfileCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public TrafficPolicyProfileCreateParams (
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
    TrafficPolicyProfileCreateParams (
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
    public static TrafficPolicyProfileCreateParams FromRawUnchecked(
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

    public virtual bool Equals(TrafficPolicyProfileCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/traffic_policy_profiles"
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
/// The type of the traffic policy profile.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Whitelist, Blacklist
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type>
{
    public override global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whitelist"=>global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type.Whitelist,
            "blacklist"=>global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type.Blacklist,
            _ =>(global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type.Whitelist=>"whitelist",
            global::Telnyx.Sdk.Models.TrafficPolicyProfiles.Type.Blacklist=>"blacklist",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Bandwidth limit in kbps. Must be 512 or 1024.
/// </summary>
[JsonConverter(typeof(LimitBwKbpsConverter))]
public enum LimitBwKbps
{
    LimitBwKbps512, LimitBwKbps1024
}

sealed class LimitBwKbpsConverter : JsonConverter<LimitBwKbps>
{
    public override LimitBwKbps Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<long>(ref reader, options) switch
        {
            512L=>LimitBwKbps.LimitBwKbps512,
            1024L=>LimitBwKbps.LimitBwKbps1024,
            _ =>(LimitBwKbps)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, LimitBwKbps value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LimitBwKbps.LimitBwKbps512=>512L,
            LimitBwKbps.LimitBwKbps1024=>1024L,
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}