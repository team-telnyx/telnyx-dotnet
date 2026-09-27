using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NetworkCoverage;

[JsonConverter(typeof(JsonModelConverter<NetworkCoverageListResponse, NetworkCoverageListResponseFromRaw>))]
public sealed record class NetworkCoverageListResponse : JsonModel
{
    /// <summary>
    /// List of interface types supported in this region.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AvailableService>>? AvailableServices {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AvailableService>>>(
                "available_services"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AvailableService>>?>(
                "available_services",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public NetappsLocation17904fcfbc? Location {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NetappsLocation17904fcfbc>(
                "location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AvailableServices ?? [])
        {
            item.Validate();
        }
        this.Location?.Validate();
        _ = this.RecordType;
    }

    public NetworkCoverageListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NetworkCoverageListResponse (
        NetworkCoverageListResponse networkCoverageListResponse
    ) : base(networkCoverageListResponse)
    {  }
    #pragma warning restore CS8618

    public NetworkCoverageListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NetworkCoverageListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NetworkCoverageListResponseFromRaw.FromRawUnchecked"/>
    public static NetworkCoverageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NetworkCoverageListResponseFromRaw : IFromRawJson<NetworkCoverageListResponse>
{
    /// <inheritdoc/>
    public NetworkCoverageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NetworkCoverageListResponse.FromRawUnchecked(rawData);
}