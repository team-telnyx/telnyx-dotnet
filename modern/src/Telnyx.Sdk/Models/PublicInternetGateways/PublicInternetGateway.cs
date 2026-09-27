using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignments;
using Telnyx.Sdk.Models.Networks;

namespace Telnyx.Sdk.Models.PublicInternetGateways;

[JsonConverter(typeof(JsonModelConverter<PublicInternetGateway, PublicInternetGatewayFromRaw>))]
public sealed record class PublicInternetGateway : JsonModel
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

    /// <summary>
    /// A user specified name for the interface.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The id of the network associated with the interface.
    /// </summary>
    public string? NetworkID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "network_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network_id", value);
        }
    }

    /// <summary>
    /// The current status of the interface deployment.
    /// </summary>
    public ApiEnum<string, InterfaceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InterfaceStatus>>(
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

    /// <summary>
    /// The publically accessible ip for this interface.
    /// </summary>
    public string? PublicIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "public_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("public_ip", value);
        }
    }

    /// <summary>
    /// The region interface is deployed to.
    /// </summary>
    public string? RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    public static implicit operator Record (
        PublicInternetGateway publicInternetGateway
    )=> new() {
        ID = publicInternetGateway.ID,
        CreatedAt = publicInternetGateway.CreatedAt,
        RecordType = publicInternetGateway.RecordType,
        UpdatedAt = publicInternetGateway.UpdatedAt
    } ;

    public static implicit operator NetworkInterface (
        PublicInternetGateway publicInternetGateway
    )=> new() {
        Name = publicInternetGateway.Name,
        NetworkID = publicInternetGateway.NetworkID,
        Status = publicInternetGateway.Status
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.Name;
        _ = this.NetworkID;
        this.Status?.Validate();
        _ = this.PublicIP;
        _ = this.RegionCode;
    }

    public PublicInternetGateway ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicInternetGateway (
        PublicInternetGateway publicInternetGateway
    ) : base(publicInternetGateway)
    {  }
    #pragma warning restore CS8618

    public PublicInternetGateway (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicInternetGateway (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicInternetGatewayFromRaw.FromRawUnchecked"/>
    public static PublicInternetGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PublicInternetGatewayFromRaw : IFromRawJson<PublicInternetGateway>
{
    /// <inheritdoc/>
    public PublicInternetGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicInternetGateway.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PublicInternetGatewayPublicInternetGateway, PublicInternetGatewayPublicInternetGatewayFromRaw>))]
public sealed record class PublicInternetGatewayPublicInternetGateway : JsonModel
{
    /// <summary>
    /// The publically accessible ip for this interface.
    /// </summary>
    public string? PublicIP {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "public_ip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("public_ip", value);
        }
    }

    /// <summary>
    /// The region interface is deployed to.
    /// </summary>
    public string? RegionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PublicIP;
        _ = this.RegionCode;
    }

    public PublicInternetGatewayPublicInternetGateway ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublicInternetGatewayPublicInternetGateway (
        PublicInternetGatewayPublicInternetGateway publicInternetGatewayPublicInternetGateway
    ) : base(publicInternetGatewayPublicInternetGateway)
    {  }
    #pragma warning restore CS8618

    public PublicInternetGatewayPublicInternetGateway (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PublicInternetGatewayPublicInternetGateway (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PublicInternetGatewayPublicInternetGatewayFromRaw.FromRawUnchecked"/>
    public static PublicInternetGatewayPublicInternetGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PublicInternetGatewayPublicInternetGatewayFromRaw : IFromRawJson<PublicInternetGatewayPublicInternetGateway>
{
    /// <inheritdoc/>
    public PublicInternetGatewayPublicInternetGateway FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PublicInternetGatewayPublicInternetGateway.FromRawUnchecked(rawData);
}