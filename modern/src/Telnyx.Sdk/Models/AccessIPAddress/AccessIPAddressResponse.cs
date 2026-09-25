using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AccessIPAddress;

[JsonConverter(typeof(JsonModelConverter<AccessIPAddressResponse, AccessIPAddressResponseFromRaw>))]
public sealed record class AccessIPAddressResponse : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string IPAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "ip_address"
            );
        }
        init { this._rawData.Set("ip_address", value); }
    }

    public required string Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// An enumeration.
    /// </summary>
    public required ApiEnum<string, CloudflareSyncStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CloudflareSyncStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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
        _ = this.IPAddress;
        _ = this.Source;
        this.Status.Validate();
        _ = this.UserID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.UpdatedAt;
    }

    public AccessIPAddressResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccessIPAddressResponse (
        AccessIPAddressResponse accessIPAddressResponse
    ) : base(accessIPAddressResponse)
    {  }
    #pragma warning restore CS8618

    public AccessIPAddressResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccessIPAddressResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AccessIPAddressResponseFromRaw.FromRawUnchecked"/>
    public static AccessIPAddressResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AccessIPAddressResponseFromRaw : IFromRawJson<AccessIPAddressResponse>
{
    /// <inheritdoc/>
    public AccessIPAddressResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AccessIPAddressResponse.FromRawUnchecked(rawData);
}