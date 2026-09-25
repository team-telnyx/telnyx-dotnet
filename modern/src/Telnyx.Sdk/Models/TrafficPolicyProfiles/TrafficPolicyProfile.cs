using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.TrafficPolicyProfiles;

[JsonConverter(typeof(JsonModelConverter<TrafficPolicyProfile, TrafficPolicyProfileFromRaw>))]
public sealed record class TrafficPolicyProfile : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Array of domain names.
    /// </summary>
    public IReadOnlyList<string>? Domains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "domains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "ip_ranges"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "ip_ranges",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Bandwidth limit in kbps.
    /// </summary>
    public long? LimitBwKbps {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "limit_bw_kbps"
            );
        }
        init { this._rawData.Set("limit_bw_kbps", value); }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Array of PCEF service IDs included in the profile.
    /// </summary>
    public IReadOnlyList<string>? Services {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "services"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "services",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of the traffic policy profile.
    /// </summary>
    public ApiEnum<string, TrafficPolicyProfileType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TrafficPolicyProfileType>>(
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

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Domains;
        _ = this.IPRanges;
        _ = this.LimitBwKbps;
        _ = this.RecordType;
        _ = this.Services;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public TrafficPolicyProfile ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrafficPolicyProfile (
        TrafficPolicyProfile trafficPolicyProfile
    ) : base(trafficPolicyProfile)
    {  }
    #pragma warning restore CS8618

    public TrafficPolicyProfile (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TrafficPolicyProfile (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TrafficPolicyProfileFromRaw.FromRawUnchecked"/>
    public static TrafficPolicyProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TrafficPolicyProfileFromRaw : IFromRawJson<TrafficPolicyProfile>
{
    /// <inheritdoc/>
    public TrafficPolicyProfile FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TrafficPolicyProfile.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the traffic policy profile.
/// </summary>
[JsonConverter(typeof(TrafficPolicyProfileTypeConverter))]
public enum TrafficPolicyProfileType
{
    Whitelist, Blacklist, Throttling
}sealed class TrafficPolicyProfileTypeConverter : JsonConverter<TrafficPolicyProfileType>
{
    public override TrafficPolicyProfileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whitelist"=>TrafficPolicyProfileType.Whitelist,
            "blacklist"=>TrafficPolicyProfileType.Blacklist,
            "throttling"=>TrafficPolicyProfileType.Throttling,
            _ =>(TrafficPolicyProfileType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrafficPolicyProfileType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TrafficPolicyProfileType.Whitelist=>"whitelist",
            TrafficPolicyProfileType.Blacklist=>"blacklist",
            TrafficPolicyProfileType.Throttling=>"throttling",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}