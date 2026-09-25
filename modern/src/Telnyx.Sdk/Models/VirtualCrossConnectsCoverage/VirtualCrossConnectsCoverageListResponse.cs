using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.NetworkCoverage;

namespace Telnyx.Sdk.Models.VirtualCrossConnectsCoverage;

[JsonConverter(typeof(JsonModelConverter<VirtualCrossConnectsCoverageListResponse, VirtualCrossConnectsCoverageListResponseFromRaw>))]
public sealed record class VirtualCrossConnectsCoverageListResponse : JsonModel
{
    /// <summary>
    /// The available throughput in Megabits per Second (Mbps) for your Virtual Cross Connect.
    /// </summary>
    public IReadOnlyList<double>? AvailableBandwidth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>(
                "available_bandwidth"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "available_bandwidth",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The Virtual Private Cloud with which you would like to establish a cross connect.
    /// </summary>
    public ApiEnum<string, VirtualCrossConnectsCoverageListResponseCloudProvider>? CloudProvider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VirtualCrossConnectsCoverageListResponseCloudProvider>>(
                "cloud_provider"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cloud_provider", value);
        }
    }

    /// <summary>
    /// The region where your Virtual Private Cloud hosts are located. Should be
    /// identical to how the cloud provider names region, i.e. us-east-1 for AWS
    /// but Frankfurt for Azure
    /// </summary>
    public string? CloudProviderRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cloud_provider_region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cloud_provider_region", value);
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
        _ = this.AvailableBandwidth;
        this.CloudProvider?.Validate();
        _ = this.CloudProviderRegion;
        this.Location?.Validate();
        _ = this.RecordType;
    }

    public VirtualCrossConnectsCoverageListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VirtualCrossConnectsCoverageListResponse (
        VirtualCrossConnectsCoverageListResponse virtualCrossConnectsCoverageListResponse
    ) : base(virtualCrossConnectsCoverageListResponse)
    {  }
    #pragma warning restore CS8618

    public VirtualCrossConnectsCoverageListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VirtualCrossConnectsCoverageListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VirtualCrossConnectsCoverageListResponseFromRaw.FromRawUnchecked"/>
    public static VirtualCrossConnectsCoverageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VirtualCrossConnectsCoverageListResponseFromRaw : IFromRawJson<VirtualCrossConnectsCoverageListResponse>
{
    /// <inheritdoc/>
    public VirtualCrossConnectsCoverageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VirtualCrossConnectsCoverageListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The Virtual Private Cloud with which you would like to establish a cross connect.
/// </summary>
[JsonConverter(typeof(VirtualCrossConnectsCoverageListResponseCloudProviderConverter))]
public enum VirtualCrossConnectsCoverageListResponseCloudProvider
{
    Aws, Azure, Gce
}sealed class VirtualCrossConnectsCoverageListResponseCloudProviderConverter : JsonConverter<VirtualCrossConnectsCoverageListResponseCloudProvider>
{
    public override VirtualCrossConnectsCoverageListResponseCloudProvider Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws"=>VirtualCrossConnectsCoverageListResponseCloudProvider.Aws,
            "azure"=>VirtualCrossConnectsCoverageListResponseCloudProvider.Azure,
            "gce"=>VirtualCrossConnectsCoverageListResponseCloudProvider.Gce,
            _ =>(VirtualCrossConnectsCoverageListResponseCloudProvider)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VirtualCrossConnectsCoverageListResponseCloudProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VirtualCrossConnectsCoverageListResponseCloudProvider.Aws=>"aws",
            VirtualCrossConnectsCoverageListResponseCloudProvider.Azure=>"azure",
            VirtualCrossConnectsCoverageListResponseCloudProvider.Gce=>"gce",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}